using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech_info
{
    public partial class FormAddCashierCard : Form
    {
        private CashierCardDelegate cashierCardDelegate;
        public FormAddCashierCard(CashierCardDelegate cardDelegate)
        {
            InitializeComponent();
            this.cashierCardDelegate = cardDelegate;
        }
        DateTime date;
        stack stk = new stack(30);
       
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            date = DateTime.Now;
        }
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((DateTime.Now - date) < TimeSpan.FromMilliseconds(30)) e.Handled = true;
        }
        private void form_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((DateTime.Now - date) < TimeSpan.FromMilliseconds(30))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        MatchCollection matches = Regex.Matches(Encoding.ASCII.GetString(stk.get()), @"([0-9])+");
                        string inputInfo = Encoding.ASCII.GetString(stk.get());
                        cashierCardDelegate(inputInfo);
                        stk.clear();
                        Close();
                    }
                    stk.push((byte)e.KeyValue);
                }
            }
            catch (Exception exc)
            {
                stk.clear();
                MessageBox.Show(exc.Message);
            }
        }
    }
}
