using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormAddAdmin : Form
    {
        public Admin admin { get; set; }
        public RSACryptoServiceProvider RSA { get; set; }

        public FormAddAdmin(
            Admin admin,
            RSACryptoServiceProvider RSA
            )
        {
            this.admin = admin;
            this.RSA = RSA;
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
        }
        private string APP_PATH = "http://localhost:8001";
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginTextBox.Text.Length >= 5
                   && !(String.IsNullOrEmpty(loginTextBox.Text))
                   && loginTextBox.Text.Trim() != string.Empty
                   && !Regex.IsMatch(loginTextBox.Text, @"[^a-zA-z\d_]"))
                {
                    if (!(String.IsNullOrEmpty(FIORichTextBox.Text))
                       && FIORichTextBox.Text.Trim() != string.Empty)
                    {
                        if (passTextBox.Text.Length >= 8
                       && !(String.IsNullOrEmpty(passTextBox.Text))
                       && passTextBox.Text.Trim() != string.Empty
                       && !Regex.IsMatch(passTextBox.Text, @"[^a-zA-z\d_]"))
                        {
                            if (passConfirmTextBox.Text.Length >= 8
                              && !(String.IsNullOrEmpty(passConfirmTextBox.Text))
                              && passConfirmTextBox.Text.Trim() != string.Empty
                              && !Regex.IsMatch(passConfirmTextBox.Text, @"[^a-zA-z\d_]"))
                            {
                                if (passTextBox.Text == passConfirmTextBox.Text)
                                {
                                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/AddAdmin");
                                    httpWebRequest.ContentType = "application/json";
                                    httpWebRequest.Method = "POST";
                                    Admin newAdmin = new Admin();
                                    newAdmin.FIO = FIORichTextBox.Text;
                                    newAdmin.login = loginTextBox.Text;
                                    byte[] passHash = Encoding.Unicode.GetBytes(passTextBox.Text);
                                    newAdmin.passwordEncript = null;
                                    byte[] enc = RSA.Encrypt(passHash, false);
                                    newAdmin.passwordEncript = (byte[])enc.Clone();
                                    AdminInfo adminInfo = new AdminInfo();
                                    adminInfo.loginedAdmin = admin;
                                    adminInfo.admin = newAdmin;
                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                    {
                                        string json = JsonConvert.SerializeObject(adminInfo);
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
                                        MessageBox.Show("Ошибка добавления администратора");
                                    }
                                    else if (httpResponse.StatusCode == HttpStatusCode.NotAcceptable)
                                    {
                                        MessageBox.Show("Администратор с таким параметрами уже существует");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Пароль и подтверждение пароля не совпадают");
                                }
                            }
                            else
                            {
                                throw new Exception("Не верное значение поля Подтверждение пароля");
                            }
                        }
                        else
                        {
                            throw new Exception("Не верное значение поля Пароль");
                        }
                    }
                    else
                    {
                        throw new Exception("Не верное значение поля ФИО");
                    }
                }
                else
                {
                    throw new Exception("Не верное значение поля Логин");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passConfirmTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FIORichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
