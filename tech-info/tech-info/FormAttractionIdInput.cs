using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormAttractionIdInput : Form
    {
        public FormAttractionIdInput()
        {
            
            InitializeComponent();
        }
        public int attractionId { get; set; }
        public bool allAttraction = false;
        private void button1_Click(object sender, EventArgs e)
        {
            int cardId = 0;
            if (!allAttraction)
            {
                if (Int32.TryParse(maskedTextBox1.Text, out cardId))
                {
                    attractionId = cardId;
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите коректное значение номера аттракциона", "Тех. информация");
                }
            }
            else
            {
                MessageBox.Show("Выбранны все аттракционы", "Тех. информация");
                Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(allAttraction == false && checkBox1.Checked)
            {
                maskedTextBox1.Enabled = true;
                allAttraction = true;

            }
            else if (allAttraction && checkBox1.Checked !=false)
            {
                maskedTextBox1.Enabled = false;
                allAttraction = false;
            }
        }
    }
}
