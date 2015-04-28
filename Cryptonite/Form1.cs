using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cryptonite.Properties;

namespace Cryptonite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;
            
            textBox3.Text = Crypto.Encrypt(textBox2.Text, textBox1.Text, true);
        }

        private bool IsFormValid()
        {
            return !String.IsNullOrEmpty(textBox1.Text) &&
                   !String.IsNullOrEmpty(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;
            try
            {
                Convert.FromBase64String(textBox2.Text);
            }
            catch (Exception)
            {
                textBox3.Text = Resources.Decrypt_Click_Input_string_isnt_Base64;
                return;
            }
            textBox3.Text = Crypto.Decrypt(textBox2.Text, textBox1.Text, true);
        }
    }
}
