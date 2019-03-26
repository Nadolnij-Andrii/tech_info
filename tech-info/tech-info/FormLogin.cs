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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            APP_PATH = ConfigurationManager.AppSettings.Get("serverURI");
        }
        private string APP_PATH = "http://localhost:9000";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(loginTextBox.Text.Length >= 5 
                    && !(String.IsNullOrEmpty(loginTextBox.Text)) 
                    && loginTextBox.Text.Trim() != string.Empty
                    && !Regex.IsMatch(loginTextBox.Text, @"[^a-zA-z\d_]"))
                { 
                    if(passwordTextBox.Text.Length >= 5
                    && !(String.IsNullOrEmpty(passwordTextBox.Text))
                    && passwordTextBox.Text.Trim() != string.Empty
                    && !Regex.IsMatch(passwordTextBox.Text, @"[^a-zA-z\d_]"))
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/GetKey");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        Admin admin = new Admin();
                        admin.login = loginTextBox.Text;
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
                                string json = JsonConvert.DeserializeObject<string>(result);
                                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                                RSA.FromXmlString(json);
                                admin.password = passwordTextBox.Text;
                                if(checkPassword(RSA, admin))
                                {
                                    admin.password = null;
                                    Form1 form = new Form1(admin, RSA );
                                    this.Visible = false;
                                    form.ShowDialog();
                                }
                            }
                            else
                            {
                                throw new Exception("Ошибка данных администратора.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Не верное значение поля Пароль");
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

        private bool checkPassword(RSACryptoServiceProvider RSA, Admin admin)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/AttractionInfo/CheckAdmin");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            
            admin.login = loginTextBox.Text;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                byte[] passHash = Encoding.Unicode.GetBytes(admin.password);
                admin.passwordEncript = null;
                byte[] enc = RSA.Encrypt(passHash, false);
                admin.passwordEncript = (byte[])enc.Clone();
                admin.password = null;
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
                if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
