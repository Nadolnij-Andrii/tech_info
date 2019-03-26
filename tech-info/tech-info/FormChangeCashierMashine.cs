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
    public partial class FormChangeCashierMashine : Form
    {
        public CashierRegister cashierRegister { get; set; }
        public Admin admin { get; set; }
        public FormChangeCashierMashine(CashierRegister cashierRegister, Admin admin)
        {
            this.cashierRegister = cashierRegister;
            InitializeComponent();
            maskedTextBoxIP.Text = cashierRegister.cashierRegisterIP.ToString();
            textBox1.Text = cashierRegister.cashierRegisterId.ToString();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.admin = admin;
        }
        private string APP_PATH = "http://localhost:9000";
        private void addCahshierMashineButton_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipAddress;
                if (IPAddress.TryParse(maskedTextBoxIP.Text, out ipAddress))
                {
                    cashierRegister.cashierRegisterIP = ipAddress.ToString();
                }
                else
                {
                    throw new Exception("Не верное значение поля IP");
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/PostChangesInCashierRegister");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                CashierRegisterInfo cashierRegisterInfo = new CashierRegisterInfo(cashierRegister, admin);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(cashierRegisterInfo);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    Close();
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    MessageBox.Show("Ошибка изменения данных кассы");
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
