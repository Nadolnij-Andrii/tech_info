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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormChangeCashier : Form
    {
        public Cashier cashier { get; set; }
        public Admin admin { get; set; }
        public FormChangeCashier(Cashier cashier, Admin admin)
        {
            InitializeComponent();
            this.cashier = cashier;
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            cashierCardTextBox.Text = cashier.cashierCardId.ToString();
            cashierFIORichTextBox.Text = cashier.cashierName.ToString();
            cashierIdTextBox.Text = cashier.cashierId.ToString();
            this.admin = admin;
        }

        private string APP_PATH = "http://localhost:9000";
        string cardInfo;
        private void addCardButton_Click(object sender, EventArgs e)
        {
            FormAddCashierCard formAddCashierCard = new FormAddCashierCard(new CashierCardDelegate(addCard));
            formAddCashierCard.ShowDialog();
            if (cardInfo != null)
            {
                var matches = Regex.Matches(cardInfo, @"([0-9])+");
                if (matches.Count > 3)
                {
                    cashierCardTextBox.Text = matches[1].ToString();
                }
                else
                {
                    cashierCardTextBox.Text = "Карта не определена";
                }
            }
        }
        private void addCard(string cardInfoString)
        {
            cardInfo = cardInfoString;
        }

        private void asddCashierButton_Click(object sender, EventArgs e)
        {
            try
            {
                CashierInfo cashierInfo = new CashierInfo();
                if (cardInfo != "")
                {
                    if (!(String.IsNullOrEmpty(cashierFIORichTextBox.Text.ToString())) && 
                        cashierFIORichTextBox.Text.ToString().Trim() != string.Empty)
                    {
                        cashier.cashierName = cashierFIORichTextBox.Text.ToString();
                    }
                    else
                    {
                        throw new Exception("Не верное значение ФИО родителя");
                    }
                    int id;
                    if (Int32.TryParse(cashierIdTextBox.Text, out id))
                    {
                        cashier.cashierId = id;
                    }
                    else
                    {
                        throw new Exception("Не верное значение поля Id");
                    }
                    cashierInfo.cashier = cashier;
                    cashierInfo.cardInfoString = cardInfo;
                    cashierInfo.admin = admin;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/PostChangesInCashier");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        String json = JsonConvert.SerializeObject(cashierInfo);
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
                        MessageBox.Show("Ошибка изменения данных кассира");
                    }
                }
                else
                {
                    throw new Exception("Карта не определена. Добавте карту.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
