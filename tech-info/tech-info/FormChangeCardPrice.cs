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
    public partial class FormChangeCardPrice : Form
    {
        Admin admin { get; set; }
        CardPriceInfo cardPriceInfoResponse { get; set; }
        public FormChangeCardPrice(Admin admin)
        {
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.admin = admin;
        }
        private string APP_PATH = "http://localhost:9000";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal price;

                CardPriceInfo cardPriceInfo = new CardPriceInfo();
                if (Decimal.TryParse(textBox1.Text, out price))
                {
                    CardStatus cardStatus = new CardStatus();
                    cardStatus.status_message = price.ToString();
                    cardPriceInfo.cardStatus = cardStatus;
                    cardPriceInfo.admin = admin;
                }
                else
                {
                    throw new Exception("Введите число");
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/ChangeCardPrice");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    String json = JsonConvert.SerializeObject(cardPriceInfo);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();   
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    cardPriceInfoResponse =  GetCardPriceInfo(admin);
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
        public CardPriceInfo GetCardPriceInfo(Admin admin)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/GetCardInfoFromAdminPanel");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                String json = JsonConvert.SerializeObject(admin);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                if (result != "null")
                {
                    string r = result.Remove(result.Length - 1);
                    var k = JsonConvert.DeserializeObject(result);
                    CardPriceInfo cardPriceInfo = JsonConvert.DeserializeObject<CardPriceInfo>(k.ToString());
                    return cardPriceInfo;
                }
                else
                {
                    throw new Exception("Ошибка данных администратора.");
                }
            }
        }
    }
    
}
