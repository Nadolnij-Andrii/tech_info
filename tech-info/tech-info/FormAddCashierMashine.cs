using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormAddCashierMashine : Form
    {
        public Admin admin { get; set; }
        public FormAddCashierMashine(Admin admin)
        {
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.admin = admin;
        }
        private string APP_PATH = "http://localhost:9000";
        private void addCahshierMashineButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                CashierRegister cashierRegister = new CashierRegister();
                if (Int32.TryParse(textBox1.Text, out id))
                {
                    cashierRegister.cashierRegisterId = id;
                }
                else
                {
                    throw new Exception("Не верное значение поля ID");
                }
                IPAddress ipAddress;
                if (IPAddress.TryParse(maskedTextBoxIP.Text, out ipAddress))
                {
                    cashierRegister.cashierRegisterIP = ipAddress.ToString();
                }
                else
                {
                    throw new Exception("Не верное значение поля IP");
                }
                CashierRegisterInfo cashierRegisterInfo = new CashierRegisterInfo();
                cashierRegisterInfo.cashierRegister = cashierRegister;
                cashierRegisterInfo.admin = admin;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/AddCashierMashine");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    String json = JsonConvert.SerializeObject(cashierRegisterInfo);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    Close();
                }    
                else if (httpResponse.StatusCode == HttpStatusCode.BadGateway)
                {
                    MessageBox.Show("Касса с такими параметрами уже существует");
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    MessageBox.Show("Ошибка добавления кассы");
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    MessageBox.Show("Ошибка предачи информации о кассе");
                }
            }
            catch (Exception exc)
            {
                
                MessageBox.Show(exc.Message);
            }
            
        }


    }
}
