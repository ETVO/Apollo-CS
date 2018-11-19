using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Apollo
{
    public class Utilities
    {
        private string titulo = "Form";

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public Utilities()
        {
            Titulo = "";
        }

        public Utilities(string frmTit)
        {
            Titulo = frmTit;
        }

        public Boolean ConfirmaMsg(String mensagem)
        {
            DialogResult result = MessageBox.Show(mensagem, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public void Msg(string mensagem, MessageBoxIcon ico)
        {
            MessageBox.Show(mensagem, Titulo, MessageBoxButtons.OK, ico);
        }

        public string Md5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool HasNumber(string input)
        {
            return input.Where(x => Char.IsDigit(x)).Any();
        }

        public void SelectTextBoxIfEmpty(TextBox txtBox)
        {
            if (!String.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.SelectAll();
            }
        }

    }
}
