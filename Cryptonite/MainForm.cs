using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Cryptonite.Properties;

namespace Cryptonite
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;
            
            outputBox.Text = Crypto.Encrypt(inputBox.Text, cryptKeyBox.Text, true);
        }

        private bool IsFormValid()
        {
            return !String.IsNullOrEmpty(cryptKeyBox.Text) &&
                   !String.IsNullOrEmpty(inputBox.Text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;

            var inputEncrypted = UrlDecodeInput(inputBox.Text);

            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                Convert.FromBase64String(inputEncrypted);
            }
            catch (Exception)
            {
                outputBox.Text = Resources.Decrypt_Click_Input_string_isnt_Base64;
                return;
            }
            outputBox.Text = Crypto.Decrypt(inputEncrypted, cryptKeyBox.Text, true);
        }

        /// <summary>
        /// Decodes an input as if it was URL encoded, leaving + chars in tact.
        /// </summary>
        /// <param name="text">Suspected URL encoded string</param>
        /// <returns>Decoded string, with +</returns>
        private static string UrlDecodeInput(string text)
        {
            var result = text;
            result = result.Replace("+", "%2B");
            result = HttpUtility.UrlDecode(result);
            return result;
        }
    }
}
