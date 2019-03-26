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
    public partial class FormSaleSoftZoneWednesday : Form
    {


        public FormSaleSoftZoneWednesday()
        {
            InitializeComponent();
        }
        public FormSaleSoftZoneWednesday(List<Attraction> attractions,
            List<AttractionType> attractionTypes,
            Admin admin
            )
        {
            this.admin = admin;
            this.attractions = attractions;
            this.attractionTypes = attractionTypes;
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            List<Attraction> responceAttractions = GetCheckedAttractions();
            checkedAttractions = responceAttractions != null ? responceAttractions : (new List<Attraction>());
            fillAttractionDataGridView(checkedAttractions);
            label1.Text = "Выбрано аттракциов : " + checkedAttractions.Count;
        }
        List<Attraction> checkedAttractions = new List<Attraction>();
        List<Attraction> attractions { get; set; }
        List<AttractionType> attractionTypes { get; set; }
        Admin admin { get; set; }

        private void fillAttractionDataGridView(List<Attraction> attractions)
        {
            try
            {
                dataGridViewAttractons.Columns.Clear();
                dataGridViewAttractons.Columns.Add("attractionId", "id");
                dataGridViewAttractons.Columns.Add("attractionName", "Наименование");
                dataGridViewAttractons.Columns.Add("attractionIp", "IP");
                dataGridViewAttractons.Columns.Add("attractionPrice", "Цена");
                dataGridViewAttractons.Columns.Add("attractionType", "Тип");
                dataGridViewAttractons.Columns.Add("attractionRentState", "Арендованный");
                dataGridViewAttractons.Columns.Add("attractionPulseDuration", "Длит. импульса");
                dataGridViewAttractons.Columns.Add("attractionParam1", "Param1");
                dataGridViewAttractons.Columns.Add("attractionDiscountSpread", "Скидка");
                dataGridViewAttractons.Sort(dataGridViewAttractons.Columns["attractionName"], System.ComponentModel.ListSortDirection.Ascending);

                //int numberOfAttractionsOnline = 0;


                dataGridViewAttractons.Rows.Clear();
                if (attractions.Count != 0)
                {

                    foreach (Attraction attraction in attractions)
                    {

                        //double odd = substractSpan.TotalSeconds;
                        AttractionType attractionType = attractionTypes.Find(x => (x.attractionTypeId == attraction.attractionType));
                        string attractionIsRental = "";
                        string attractionDiscountStatus = "";

                        if ((bool)attraction.attractionIsRental == true)
                        {
                            attractionIsRental = "Арендованный";
                        }
                        else
                        {
                            attractionIsRental = "Не арендованный";
                        }
                        if ((bool)attraction.attractionDiscountSpread == true)
                        {
                            attractionDiscountStatus = "Распространяется";
                        }
                        else
                        {
                            attractionDiscountStatus = "Не распространяется";
                        }
                        dataGridViewAttractons.Rows.Add(
                            attraction.id,
                            attraction.attractionName,
                            attraction.attractionIp,
                            attraction.attractionPrice,
                            attractionType.attractionTypeName,
                            attractionIsRental,
                            attraction.attractionPusleDuration,
                            attraction.attractionParam1,
                            attractionDiscountStatus);
                    }
                    dataGridViewAttractons.Sort(dataGridViewAttractons.Columns["attractionName"], System.ComponentModel.ListSortDirection.Descending);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Аттракционы");
            }
        }
        private void dataGridViewAttractons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAttractionIdInput formAttractionIdInput = new FormAttractionIdInput();
            formAttractionIdInput.ShowDialog();
            if (formAttractionIdInput.allAttraction)
            {
                checkedAttractions.Clear();
                checkedAttractions.AddRange(attractions);
               

            }
            else
            {
                checkedAttractions.Add(attractions.Find(y => (((int)y.id) == formAttractionIdInput.attractionId)));
                

            }
            label1.Text = "Выбрано аттракциов : " + checkedAttractions.Count;

            fillAttractionDataGridView(checkedAttractions);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/UpdateSoftZoneSale");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            AttractionInfoRequest attractionInfoRequest = new AttractionInfoRequest();
            attractionInfoRequest.attractions = checkedAttractions;
            attractionInfoRequest.admin = admin;
            attractionInfoRequest.active = checkBox4.Checked;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                String json = JsonConvert.SerializeObject(attractionInfoRequest);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            AttractionsInfoResponce attractionInfoResponce = new AttractionsInfoResponce();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                if (result != "null")
                {
                    string r = result.Remove(result.Length - 1);
                    var k = JsonConvert.DeserializeObject(result);
                    attractionInfoResponce = JsonConvert.DeserializeObject<AttractionsInfoResponce>(k.ToString());
                    if (attractionInfoResponce.active)
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }
                    fillAttractionDataGridView(attractionInfoResponce.attractions);
                    Close();
                }
                else
                {
                    throw new Exception("Ошибка получения данных об атракционах.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAttractionIdInput formAttractionIdInput = new FormAttractionIdInput();
            formAttractionIdInput.ShowDialog();
            if (formAttractionIdInput.allAttraction)
            {
                checkedAttractions.Clear();
            }
            else
            {
                if (formAttractionIdInput.attractionId > 0)
                    checkedAttractions.RemoveAt(attractions.IndexOf(attractions.Find(x => (int)x.id == formAttractionIdInput.attractionId)));
                
            }
            label1.Text = "Выбрано аттракциов : " + checkedAttractions.Count;

            fillAttractionDataGridView(checkedAttractions);
        }
        private string APP_PATH = "http://localhost:8001";
        private HttpWebRequest Request(string action)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/" + action);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(admin);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return httpWebRequest;
        }
        public List<Attraction> GetCheckedAttractions()
        {
            var httpWebRequest = Request("GetCheckedSoftZoneSale");
            string result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            AttractionsInfoResponce attractionInfoResponce = new AttractionsInfoResponce();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                result = streamReader.ReadToEnd();
                if (result != "null")
                {
                    string r = result.Remove(result.Length - 1);
                    var k = JsonConvert.DeserializeObject(result);
                    attractionInfoResponce = JsonConvert.DeserializeObject<AttractionsInfoResponce>(k.ToString());
                    if (attractionInfoResponce.active)
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }
                    return attractionInfoResponce.attractions;

                }
                else
                {
                    throw new Exception("Ошибка получения данных об атракционах.");
                }
            }
        }

        private void FormSaleSoftZoneWednesday_Load(object sender, EventArgs e)
        {

        }
    }
}
