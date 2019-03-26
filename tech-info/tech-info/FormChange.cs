using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace tech_info
{
    public partial class FormChange : Form
    {
        public int attractionId { get; set; }
        private string APP_PATH = "http://localhost:9000";
        public Admin admin { get; set; }
        public FormChange(Admin admin)
        {
            InitializeComponent();
        }
        List<AttractionType> attractionTypes;
        AttractionType selectedAttreactionType;
        bool RentalStatus;
        bool DiscountStatus;
        public FormChange(Attraction attraction, AttractionType attractionType, List<AttractionType> attractionTypes, Admin admin)
        {
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.attractionId = attraction.id;
            textBoxName.Text = attraction.attractionName.ToString();
            maskedTextBoxIP.Text = attraction.attractionIp.ToString();
            textBoxPrice.Text = attraction.attractionPrice.ToString();
            selectedAttreactionType = attractionTypes.Find(x => x.attractionTypeId == attraction.attractionType);
            this.attractionTypes = attractionTypes;
            foreach(AttractionType attrType in attractionTypes)
            {
                comboBoxTypes.Items.Add(attrType.attractionTypeName);
                if (attrType == selectedAttreactionType)
                {
                    comboBoxTypes.SelectedIndex = comboBoxTypes.Items.Count-1;
                }
            }

            RentalComboBox.Items.Add("Нет");
            RentalComboBox.Items.Add("Да");
            if ((bool)attraction.attractionIsRental == true)
            {
                RentalStatus = true;
                RentalComboBox.SelectedIndex = 1;
            }
            else
            {
                RentalStatus = false;
                RentalComboBox.SelectedIndex = 0;
            }
            DiscountСomboBox.Items.Add("Не распространяется");
            DiscountСomboBox.Items.Add("Распространяется");
            if ((bool)attraction.attractionDiscountSpread == true)
            {
                DiscountStatus = true;
                DiscountСomboBox.SelectedIndex = 1;
            }
            else
            {
                DiscountStatus = false;
                DiscountСomboBox.SelectedIndex = 0;
            }
            textBoxPulseDuration.Text = attraction.attractionPusleDuration.ToString();
            textBox2.Text = attraction.attractionParam1.ToString();
            this.admin = admin;
        }
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipAddress;
                Attraction attraction = new Attraction();
                attraction.id = attractionId;
                if (IPAddress.TryParse(maskedTextBoxIP.Text, out ipAddress))
                {
                    attraction.attractionIp = ipAddress.ToString();
                }
                else
                {
                    throw new Exception("Не верное значение поля IP");
                }
                double priceAttraction;
                if (Double.TryParse(textBoxPrice.Text, out priceAttraction))
                {
                    attraction.attractionPrice = priceAttraction ;
                }
                else
                {
                    throw new Exception("Не верное значение цены");
                }
                if (!(String.IsNullOrEmpty(textBoxName.Text.ToString())) && textBoxName.Text.ToString().Trim() != string.Empty)
                {
                    attraction.attractionName =  textBoxName.Text.ToString();
                }
                else
                {
                    throw new Exception("Введите имя");
                }
             
                attraction.attractionType = selectedAttreactionType.attractionTypeId;
                attraction.attractionIsRental = RentalStatus;
                attraction.attractionDiscountSpread = DiscountStatus;

                int pulseDuration;
                if(Int32.TryParse(textBoxPulseDuration.Text, out pulseDuration))
                {
                    if(pulseDuration > 0)
                    {
                       attraction.attractionPusleDuration = pulseDuration;
                    }
                    else
                    {
                        throw new Exception("Не верное значение длительности импульса");
                    }
                }
                else
                {
                    throw new Exception("Не верное значение длительности импульса");
                }
                if (Int32.TryParse(textBox2.Text, out pulseDuration))
                {
                    if (pulseDuration > 0)
                    {
                        attraction.attractionParam1 = textBox2.Text.ToString();
                    }
                    else
                    {
                        throw new Exception("Не верное значение param1");
                    }
                }
                else
                {
                    throw new Exception("Не верное значение param1");
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/PostChangesInAttractionInfo");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                AttractionInfo attractionInfo = new AttractionInfo(admin, attraction);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    String json = JsonConvert.SerializeObject(attractionInfo);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    Close();
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    MessageBox.Show("Ошибка изменения данных аттракциона");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAttreactionType = attractionTypes.ElementAt(comboBoxTypes.SelectedIndex);
        }

        private void RentalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RentalComboBox.SelectedIndex == 0)
            {
                RentalStatus = false;
            }
            else
            {
                RentalStatus = true;
            }
        }

        private void DiscountСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DiscountСomboBox.SelectedIndex == 0)
            {
                DiscountStatus = false;
            }
            else
            {
                DiscountStatus = true;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormChange_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
