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
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormChangeAdmin : Form
    {
        public Admin changingAdmin { get; set; }
        public Admin loginedAdmin { get; set; }
        bool passwordChanged;
        bool loginChanged;
        string oldLogin;
        private AdminDelegate adminDelegate { get; set; }
        public RSACryptoServiceProvider RSA { get; set; }
        private string APP_PATH = "http://localhost:9000";
        public FormChangeAdmin(
            Admin changingAdmin,
            Admin loginedAdmin,
            RSACryptoServiceProvider RSA,
            AdminDelegate adminDelegate
            )
        {
            this.changingAdmin = changingAdmin;
            this.loginedAdmin = loginedAdmin;
            this.RSA = RSA;
            this.adminDelegate = adminDelegate;
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
            passwordChanged = false;
            idTextBox.Text = changingAdmin.id.ToString();
            loginTextBox.Text = changingAdmin.login;
            FIORichTextBox.Text = changingAdmin.FIO;
            loginTextBox.TextChanged += loginTextBox_TextChanged;
            oldLogin = changingAdmin.login;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginChanged)
                {
                    string messageBoxText = "Изменить логин администратора?";
                    string caption = "Изменение логина";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(messageBoxText, caption, button);
                    if (result == DialogResult.Yes)
                    {
                        if (loginTextBox.Text.Length >= 5
                           && !(String.IsNullOrEmpty(loginTextBox.Text))
                           && loginTextBox.Text.Trim() != string.Empty
                           && !Regex.IsMatch(loginTextBox.Text, @"[^a-zA-z\d_]"))
                        {
                            oldLogin = changingAdmin.login;
                            changingAdmin.login = loginTextBox.Text;
                        }
                        else
                        {
                            throw new Exception("Не верное значение поля Логин");
                        }
                    }
                }
                if (passwordChanged)
                {
                    string messageBoxText = "Изменить пароль администратора?";
                    string caption = "Изменение пароля";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(messageBoxText, caption, button);
                    if (result == DialogResult.Yes)
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
                                    changingAdmin.password = passTextBox.Text;
                                    byte[] passHash = Encoding.Unicode.GetBytes(passTextBox.Text);
                                    changingAdmin.passwordEncript = null;
                                    byte[] enc = RSA.Encrypt(passHash, false);
                                    changingAdmin.passwordEncript = (byte[])enc.Clone();
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
                }
                if (!(String.IsNullOrEmpty(FIORichTextBox.Text))
                       && FIORichTextBox.Text.Trim() != string.Empty)
                {
                    changingAdmin.FIO = FIORichTextBox.Text;
                }
                else
                {
                    throw new Exception("Не верное значение поля ФИО");
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/ChangeAdmin");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                AdminInfo adminInfo = new AdminInfo();
                changingAdmin.password = null;
                adminInfo.loginedAdmin = loginedAdmin;
                adminInfo.admin = changingAdmin;
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
                    if (oldLogin == loginedAdmin.login)
                    {
                        string login = null;
                        byte[] password = null;
                        if (loginChanged)
                        {
                            login = changingAdmin.login;
                        }
                        if (passwordChanged)
                        {
                            password = changingAdmin.passwordEncript;
                        }
                        adminDelegate(login, password);
                    }
                    Close();
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    MessageBox.Show("Администратор с таким параметрами уже существует");
                }
                else if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    MessageBox.Show("Ошибка добавления администратора");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordChanged = true;
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            loginChanged = true;
        }

        private void FormChangeAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
