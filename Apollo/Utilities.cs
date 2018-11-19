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

        public DateTime AddWorkdays(DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !IsHoliday(tmpDate))
                    workDays--;
            }
            return tmpDate;
        }

        public bool IsHoliday(DateTime originalDate)
        {
            // INSERT YOUR HOlIDAY-CODE HERE!
            return false;
        }

        public int DaysDifference(DateTime a, DateTime b)
        {
            int diff = 0;
            if(a > b)
            {
                while (a.Day > b.Day || a.Month > b.Month)
                {
                    b = AddWorkdays(b, 1);
                    diff++;
                }
            }
            else
            {
                while (b.Day > a.Day || b.Month > a.Month)
                {
                    a = AddWorkdays(a, 1);
                    diff++;
                }
            }

            return diff;
        }
    }
}
