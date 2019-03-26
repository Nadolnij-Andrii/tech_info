using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;
using System.Text.RegularExpressions;

namespace tech_info
{
    public partial class Form1 : Form
    {
        public Admin admin { get; set; }
        private RSACryptoServiceProvider RSA { get; set; }
        private static Timer timer1;
        private static Timer timer2;
        private static int timeInterval1 = 1;
        private static int timeInterval2 = 2;

        List<Attraction> attractions;
        List<AttractionType> attractionTypes;
        List<CashierRegister> cashierRegisters;
        List<Cashier> cashiers;
        List<Admin> admins;
        private string APP_PATH = "http://localhost:8001";
        public Form1(
            Admin admin,
            RSACryptoServiceProvider RSA
            )
        {
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            timer1 = new Timer();
            timer2 = new Timer();
            this.admin = admin;
            this.RSA = RSA;
            InitializeComponent();
            try
            {
                fillAttractionDataGridView();
                fillCashierMashineDataGridView();
                fillCashierDataGridView();
                fillAdminDataGridView();
                timer1.Interval = timeInterval1 * 1000;
                timer2.Interval = timeInterval2 * 1000;

                timer1.Tick += new EventHandler(timer1_Tick);
                timer2.Tick += new EventHandler(timer2_Tick);

                timer1.Start();
                timer2.Start();
                loadCashiersInfo(); 
                loadAdminInfo();
                label1.Text = "Цена карты : " + GetCardPriceInfo(admin).cardStatus.status_message;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void fillAttractionDataGridView()
        {
            dataGridViewAttractons.Columns.Add("attractionId", "id");
            dataGridViewAttractons.Columns.Add("attractionName", "Наименование");
            dataGridViewAttractons.Columns.Add("attractionIp", "IP");
            dataGridViewAttractons.Columns.Add("attractionPrice", "Цена");
            dataGridViewAttractons.Columns.Add("attractionType", "Тип");
            dataGridViewAttractons.Columns.Add("attractionRentState", "Арендованный");
            dataGridViewAttractons.Columns.Add("attractionStatus", "Статус");
            dataGridViewAttractons.Columns.Add("attractionPulseDuration", "Длит. импульса");
            dataGridViewAttractons.Columns.Add("attractionParam1", "Param1");
            dataGridViewAttractons.Columns.Add("attractionDiscountSpread", "Скидка");
            DataGridViewButtonColumn changeAttractionButtons = new DataGridViewButtonColumn();
            changeAttractionButtons.Visible = true;
            changeAttractionButtons.ToolTipText = "Изменить параметры аттракциона";
            changeAttractionButtons.Text = "Изменить";
            changeAttractionButtons.Name = "change_column";
            changeAttractionButtons.HeaderText = "Редактирование";
            changeAttractionButtons.UseColumnTextForButtonValue = true;
            dataGridViewAttractons.CellClick += changeAttractionButton_CellClick;
            dataGridViewAttractons.Columns.Insert(10, changeAttractionButtons);
            dataGridViewAttractons.Sort(dataGridViewAttractons.Columns["attractionName"], System.ComponentModel.ListSortDirection.Ascending);
        }
        private void fillCashierMashineDataGridView()
        {
            cashierMashineDataGridView.Columns.Add("cashierMashineId", "id");
            cashierMashineDataGridView.Columns.Add("cashierMashineIP", "IP");
            cashierMashineDataGridView.Columns.Add("attractionState", "Стaтус");
            DataGridViewButtonColumn changeCashierMashineButtons = new DataGridViewButtonColumn();
            changeCashierMashineButtons.Visible = true;
            changeCashierMashineButtons.ToolTipText = "Изменить параметры аттракциона";
            changeCashierMashineButtons.Text = "Изменить";
            changeCashierMashineButtons.Name = "change_column";
            changeCashierMashineButtons.HeaderText = "Редактирование";
            changeCashierMashineButtons.UseColumnTextForButtonValue = true;
            cashierMashineDataGridView.CellClick += changeCashierMashineButton_CellClick;
            cashierMashineDataGridView.Columns.Insert(3, changeCashierMashineButtons);
        }
        private void fillCashierDataGridView()
        {
            cashierDataGridView.Columns.Add("cashierId", "id");
            cashierDataGridView.Columns.Add("cashierName", "ФИО");
            cashierDataGridView.Columns.Add("cardId", "Номер карты");
            DataGridViewButtonColumn changeCashierButtons = new DataGridViewButtonColumn();
            changeCashierButtons.Visible = true;
            changeCashierButtons.ToolTipText = "Изменить параметры аттракциона";
            changeCashierButtons.Text = "Изменить";
            changeCashierButtons.Name = "change_column";
            changeCashierButtons.HeaderText = "Редактирование";
            changeCashierButtons.UseColumnTextForButtonValue = true;
            cashierDataGridView.CellClick += changeCashierButtonsButton_CellClick;
            cashierDataGridView.Columns.Insert(3, changeCashierButtons);
        }
        private void fillAdminDataGridView()
        {
            adminDataGridView.Columns.Add("adminId", "id");
            adminDataGridView.Columns.Add("adminName", "ФИО");
            adminDataGridView.Columns.Add("adminLogin", "login");
            DataGridViewButtonColumn changeAdminButtons = new DataGridViewButtonColumn();
            changeAdminButtons.Visible = true;
            changeAdminButtons.ToolTipText = "Изменить параметры аттракциона";
            changeAdminButtons.Text = "Изменить";
            changeAdminButtons.Name = "change_column";
            changeAdminButtons.HeaderText = "Редактирование";
            changeAdminButtons.UseColumnTextForButtonValue = true;
            adminDataGridView.CellClick += changeAdminButtonsButton_CellClick;
            adminDataGridView.Columns.Insert(3, changeAdminButtons);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int numberOfAttractionsOnline = 0;
                timeInterval1 = 10;
                timer1.Interval = timeInterval1 * 1000;

                    var httpWebRequest = Request("GetAttractionInfo");
                    string result = "";
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    AttractionsInfo attractionInfo = new AttractionsInfo();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        
                        result = streamReader.ReadToEnd();
                        if (result != "null")
                        {
                            string r = result.Remove(result.Length - 1);
                            var k = JsonConvert.DeserializeObject(result);
                            attractionInfo = JsonConvert.DeserializeObject<AttractionsInfo>(k.ToString());
                        }
                        else
                        {
                            throw new Exception("Ошибка данных об атракционах.");
                        }
                    }
                attractions = attractionInfo.Attractions;
                attractionTypes = attractionInfo.AttractionTypes;
                dataGridViewAttractons.Rows.Clear();
                if (attractions.Count != 0)
                {
                    foreach (Attraction attraction in attractions)
                    {
                        string attractionStatus ;
                        TimeSpan substractSpan =  DateTime.Now - (DateTime)attraction.attractionLastPing;
                        double odd = substractSpan.TotalSeconds;
                        if( odd > timeInterval1*3 )
                        {
                            attractionStatus = "Не работает";
                        }
                        else
                        {
                            attractionStatus = "Работает";
                        }
                        
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
                        dataGridViewAttractons.Rows.Add(attraction.id, 
                            attraction.attractionName, 
                            attraction.attractionIp, 
                            attraction.attractionPrice, 
                            attractionType.attractionTypeName,
                            attractionIsRental,  
                            attractionStatus, 
                            attraction.attractionPusleDuration, 
                            attraction.attractionParam1,
                            attractionDiscountStatus);
                        if(attractionStatus == "Не работает")
                        {
                            dataGridViewAttractons.Rows[dataGridViewAttractons.Rows.Count - 1].Cells[6].Style.BackColor = System.Drawing.Color.Red;
                        }
                        else if(attractionStatus == "Работает")
                        {
                            numberOfAttractionsOnline++;
                            dataGridViewAttractons.Rows[dataGridViewAttractons.Rows.Count - 1].Cells[6].Style.BackColor = System.Drawing.Color.Green;
                        }
                    }
                    dataGridViewAttractons.Sort(dataGridViewAttractons.Columns["attractionName"], System.ComponentModel.ListSortDirection.Descending);
                    labelNumberOfAttractionsOnline.Text ="Колличество работающих аттракционов: "+ numberOfAttractionsOnline.ToString();
                }
            }
            catch(Exception exc)
            {
                timer1.Stop();
                MessageBox.Show(exc.Message, "Аттракционы");
                
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                int numberOfCashierRegisterOnline = 0;
                timeInterval2 = 10;
                timer2.Interval = timeInterval2 * 1000;
                var httpWebRequest = Request("GetCashierRegisters");
                string result = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                 cashierRegisters = new List<CashierRegister>();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    result = streamReader.ReadToEnd();
                    if (result != "null")
                    {
                        string r = result.Remove(result.Length - 1);
                        var k = JsonConvert.DeserializeObject(result);
                        cashierRegisters = JsonConvert.DeserializeObject<List<CashierRegister>>(k.ToString());
                    }
                    else
                    {
                        throw new Exception("Ошибка данных о кассах.");
                    }
                }
                cashierMashineDataGridView.Rows.Clear();
                if(cashierRegisters.Count != 0)
                {
                    foreach (CashierRegister cashierRegister in cashierRegisters)
                    {
                        string cashierRegisterStatus;
                        TimeSpan substractSpan = DateTime.Now - (DateTime)cashierRegister.timeLastPing;
                        double odd = substractSpan.TotalSeconds;
                        if (odd > timeInterval2*12)
                        {
                            cashierRegisterStatus = "Не работает";
                        }
                        else
                        {
                            numberOfCashierRegisterOnline++;
                            cashierRegisterStatus = "Работает";
                        }
                        cashierMashineDataGridView.Rows.Add(
                            cashierRegister.cashierRegisterId,
                            cashierRegister.cashierRegisterIP,
                            cashierRegisterStatus
                            );
                        if (cashierRegisterStatus == "Не работает")
                        {
                            cashierMashineDataGridView.Rows[cashierMashineDataGridView.Rows.Count - 1].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                        }
                        else if (cashierRegisterStatus == "Работает")
                        {
                            cashierMashineDataGridView.Rows[cashierMashineDataGridView.Rows.Count - 1].Cells[2].Style.BackColor = System.Drawing.Color.Green;
                        }
                    }
                    labelNumberOfCashierRegisterOnline.Text = "Колличество работающих касс: " + numberOfCashierRegisterOnline;
                }

            }
            catch(Exception exc)
            {
                timer2.Stop();
                MessageBox.Show(exc.Message,"Кассы");
            }
        }
        private void loadCashiersInfo()
        {
            var httpWebRequest = Request("GetCashiers");
            string result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            cashiers = new List<Cashier>();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                result = streamReader.ReadToEnd();
                if (result != "null")
                {
                    string r = result.Remove(result.Length - 1);
                    var k = JsonConvert.DeserializeObject(result);
                    cashiers = JsonConvert.DeserializeObject<List<Cashier>>(k.ToString());
                }
                else
                {
                    throw new Exception("Ошибка данных о кассирах");
                }
            }
            cashierDataGridView.Rows.Clear();
            if (cashiers.Count != 0)
            {
                foreach (Cashier cashier in cashiers)
                {
                    cashierDataGridView.Rows.Add(
                        cashier.cashierId,
                        cashier.cashierName,
                        cashier.cashierCardId
                        );
                }
            }
        }
        private void loadAdminInfo()
        {
            var httpWebRequest = Request("GetAdmins");
            string result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            admins = new List<Admin>();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                if (result != "null")
                {
                    string r = result.Remove(result.Length - 1);
                    var k = JsonConvert.DeserializeObject(result);
                    admins = JsonConvert.DeserializeObject<List<Admin>>(k.ToString());
                }
                else
                {
                    throw new Exception("Ошибка получения данных об администраторах");
                }
            }
            adminDataGridView.Rows.Clear();
            if (admins.Count != 0)
            {
                foreach (Admin admin in admins)
                {
                    adminDataGridView.Rows.Add(
                        admin.id,
                        admin.FIO,
                        admin.login
                        );
                }
            }
        }
        public void changeCashierMashineButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cashierMashineDataGridView.Columns["change_column"].Index && e.RowIndex >= 0)
            {
                int column = cashierMashineDataGridView.Columns["cashierMashineId"].Index;
                int row = e.RowIndex;
                CashierRegister changingCashierRegister = cashierRegisters.Find(x => (x.cashierRegisterId.ToString()  == cashierMashineDataGridView[column, row].Value.ToString()));
                FormChangeCashierMashine formChangeCashierMashine = new FormChangeCashierMashine(changingCashierRegister, admin);
                formChangeCashierMashine.ShowDialog();
            }
        }
        public void changeCashierButtonsButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cashierDataGridView.Columns["change_column"].Index && e.RowIndex >= 0)
            {
                int column = cashierDataGridView.Columns["cashierId"].Index;
                int row = e.RowIndex;
                Cashier changingCashier = cashiers.Find(x => (x.cashierId.ToString() == cashierDataGridView[column, row].Value.ToString()));
                FormChangeCashier formChangeCashier = new FormChangeCashier(changingCashier, admin);
                formChangeCashier.ShowDialog();
                loadCashiersInfo();
            }
        }
        public void changeAttractionButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAttractons.Columns["change_column"].Index && e.RowIndex >= 0)
            {
                int column = dataGridViewAttractons.Columns["attractionId"].Index;
                int row = e.RowIndex;
                Attraction changingAttraction = attractions.Find(x => (x.id.ToString() == dataGridViewAttractons[column,row].Value.ToString() ));
                AttractionType attractionType = attractionTypes.Find(x => x.attractionTypeId == changingAttraction.attractionType);
                FormChange formChange = new FormChange(changingAttraction, attractionType, attractionTypes, admin);
                formChange.ShowDialog();
            }
        }
        public void changeAdminButtonsButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == adminDataGridView.Columns["change_column"].Index && e.RowIndex >= 0)
            {
                int column = adminDataGridView.Columns["adminId"].Index;
                int row = e.RowIndex;
                Admin changedAdmin = admins.Find(x => (x.id.ToString() == adminDataGridView[column, row].Value.ToString()));
                FormChangeAdmin formChangeAdmin = new FormChangeAdmin(changedAdmin, admin, RSA, new AdminDelegate(changeLoginedAdminInfo));
                formChangeAdmin.ShowDialog();
                loadAdminInfo();
            }
        }
        private void changeLoginedAdminInfo(string login, byte[] password)
        {
            if(login != null)
            {
                admin.login = login;
            }
            if(password != null)
            {
                admin.passwordEncript = password;
            }
        }
        private void addAttractionButton_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd(attractionTypes, admin);
            formAdd.ShowDialog();
        }
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
        private void reloadInfoButton_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                timer1.Start();
                timer1_Tick(sender, e);
            }
            else
            {
                timer1.Start();
                timer1_Tick(sender, e);
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addCashierMashineButton_Click(object sender, EventArgs e)
        {
            FormAddCashierMashine formAddCashierMashine = new FormAddCashierMashine(admin);
            formAddCashierMashine.ShowDialog();
            loadCashiersInfo();
        }

        private void reloadCashierMashineInfo_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                timer2.Start();
                timer2_Tick(sender, e);
            }
            else
            {
                timer2.Start();
                timer2_Tick(sender, e);
                timer2.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadCashiersInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddNewCashier formAddNewCashier = new FormAddNewCashier(admin);
            formAddNewCashier.ShowDialog();
            loadCashiersInfo();
        }

        private void updateAdminInfoButton_Click(object sender, EventArgs e)
        {
            loadAdminInfo();
        }

        private void addAdminButton_Click(object sender, EventArgs e)
        {
            FormAddAdmin formAddAdmin = new FormAddAdmin(admin, RSA);
            formAddAdmin.ShowDialog();
            loadAdminInfo();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void cardPriceButton_Click(object sender, EventArgs e)
        {
            FormChangeCardPrice formChangeCardPrice = new FormChangeCardPrice(admin);
            formChangeCardPrice.ShowDialog();
            label1.Text = "Цена карты : " + GetCardPriceInfo(admin).cardStatus.status_message;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                timer1.Start();
            }
            if(!checkBox1.Checked)
            {
                timer1.Stop();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                timer2.Start();
            }
            if (!checkBox2.Checked)
            {
                timer2.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSeleAllAtomatoes formSeleAllAtomatoes = new FormSeleAllAtomatoes(attractions, attractionTypes, admin);
            formSeleAllAtomatoes.ShowDialog();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            FormSaleSoftZoneWednesday formSaleSoftZoneWednesday = new FormSaleSoftZoneWednesday(attractions,
             attractionTypes,
             admin
            );
            formSaleSoftZoneWednesday.ShowDialog();
        }
    }
}
