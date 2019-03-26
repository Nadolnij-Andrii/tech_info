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
    public partial class FormAdd : Form
    {
        private string APP_PATH = "http://localhost:9000";
        public FormAdd(List<AttractionType> attractionTypes, Admin admin)
        {
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.attractionTypes = attractionTypes;
            this.admin = admin;
            selectedAttreactionType = this.attractionTypes.ElementAt(0);
            RentalStatus = false;
            DiscountStatus = false;
            foreach (AttractionType attrType in this.attractionTypes)
            {
                comboBoxTypes.Items.Add(attrType.attractionTypeName);
            }
            RentalComboBox.Items.Add("Нет");
            RentalComboBox.Items.Add("Да");
            DiscountСomboBox.Items.Add("Не распространяется");
            DiscountСomboBox.Items.Add("Распространяется");
            DiscountСomboBox.SelectedIndex = 0;
            RentalComboBox.SelectedIndex = 0;
            comboBoxTypes.SelectedIndex = 0;
            
        }

        List<AttractionType> attractionTypes;
        AttractionType selectedAttreactionType;
        Admin admin;
        bool RentalStatus ;
        bool DiscountStatus;
        public FormAdd(object attractionId)
        {
            
            
        }
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                Attraction attraction = new Attraction();
                IPAddress ipAddress;
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
                    throw new Exception("Не верное значение Цены");
                }
                if (!(String.IsNullOrEmpty(textBoxName.Text.ToString())) && textBoxName.Text.ToString().Trim() != string.Empty)
                {
                    attraction.attractionName = textBoxName.Text.ToString();
                }
                else
                {
                    throw new Exception("Введите имя");
                }
                
                attraction.attractionType =  selectedAttreactionType.attractionTypeId;
                attraction.attractionIsRental = RentalStatus;
                attraction.attractionDiscountSpread = DiscountStatus;

                int pulseDuration;
                if (Int32.TryParse(textBoxPulseDuration.Text, out pulseDuration))
                {
                    if (pulseDuration > 0)
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
                attraction.attractionLastPing = DateTime.Now;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/PostNewAttraction");
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
                else if(httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    MessageBox.Show("Ошибка добавления аттракциона");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAttreactionType = attractionTypes.ElementAt(comboBoxTypes.SelectedIndex);
        }

        private void RentalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RentalComboBox.SelectedIndex == 0)
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
    }
}
