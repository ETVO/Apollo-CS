using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
//using Message;

public static class Utilities
{
    private static string titulo = "Apollo";

    public static string Titulo
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

    static Utilities()
    {
        Titulo = "Apollo";
    }


    /// <summary>
    /// Exibe mensagem de confirmação (Com padrão de ícone "question" e de opções "YesNo")
    /// </summary>
    /// <param name="message">Mensagem a ser exibida</param>
    /// <returns></returns>
    public static bool Confirm(string message)
    {
        DialogResult result = MessageBox.Show(message, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
            return true;
        else
            return false;
    }


    /// <summary>
    /// Exibe mensagem ao usuário (Com padrão de ícone "error" e de opções "OkCancel")
    /// </summary>
    /// <param name="message">Mensagem a ser exibida</param>
    /// <returns></returns>
    public static DialogResult Message(string message)
    {
        return MessageBox.Show(message, Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
    }

    /*/// <summary>
    /// Exibe mensagem ao usuário (Com padrão de opções "OkCancel")
    /// </summary>
    /// <param name="message">Mensagem a ser exibida</param>
    /// <param name="icon">
    /// <para>O ícone a ser exibido</para>
    /// <para>("error", "info", "warning" ou "question")</para>
    /// </param>
    /// <returns></returns>
    public static DialogResult Message(string message, string icon)
    {
        return MessageBox.Show(message, Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Exibe mensagem ao usuário
    /// </summary>
    /// <param name="message">Mensagem a ser exibida</param>
    /// <param name = "icon" >
    /// <para>O ícone a ser exibido</para>
    /// <para>("error", "info", "warning" ou "question")</para>
    /// </param>
    /// <param name="options">
    /// <para>As opções do usuário</para>
    /// <para>("Ok", "OkCancel", "RetryCancel", "YesNo", "YesNoCancel")</para>
    /// </param>
    /// <returns></returns>
    public static DialogResult Message(string message, string icon, string options)
    {
        frmMsg Message = new frmMsg(message, icon, options);

        return Message.ShowDialog();
    }*/


    /// <summary>
    /// Retorna entrada codificada em MD5
    /// </summary>
    /// <param name="input">Entrada a ser convertida</param>
    /// <returns></returns>
    public static string Md5(string input)
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


    /// <summary>
    /// Retorna se a entrada tem algum número entre seus caracteres
    /// </summary>
    /// <param name="input">Entrada a ser analisada</param>
    /// <returns></returns>
    public static bool HasNumber(string input)
    {
        return input.Where(x => Char.IsDigit(x)).Any();
    }


    /// <summary>
    /// Seleciona todo o conteúdo de uma TextBox, se esta estiver vazia
    /// </summary>
    /// <param name="textBox">TextBox a ser selecionada</param>
    public static void SelectTextBoxIfEmpty(TextBox textBox)
    {
        if (!String.IsNullOrEmpty(textBox.Text))
        {
            textBox.SelectAll();
        }
    }


    /// <summary>
    /// Método DateTime.AddDays que só conta dias úteis
    /// </summary>
    /// <param name="originalDate">Data original</param>
    /// <param name="workDays">Dias a serem adicionados</param>
    /// <returns></returns>
    public static DateTime AddWorkdays(DateTime originalDate, int workDays)
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


    /// <summary>
    /// Checa se determinada data é ou não feriado
    /// </summary>
    /// <param name="originalDate">Data a ser analisada</param>
    /// <returns></returns>
    public static bool IsHoliday(DateTime originalDate)
    {
        // INSERT YOUR HOLIDAY-CODE HERE!
        return false;
    }


    /// <summary>
    /// Dias de diferença contando somente dias úteis
    /// </summary>
    /// <param name="a">Data A</param>
    /// <param name="b">Data B</param>
    /// <returns></returns>
    public static int WorkdaysDifference(DateTime a, DateTime b)
    {
        int diff = 0;
        if (a > b)
        {
            while (a.Date > b.Date)
            {
                b = AddWorkdays(b, 1);
                diff++;
            }
        }
        else
        {
            while (b.Date > a.Date)
            {
                a = AddWorkdays(a, 1);
                diff++;
            }
        }

        return diff;
    }

    /// <summary>
    /// Dias de diferença contando todos os dias
    /// </summary>
    /// <param name="a">Data A</param>
    /// <param name="b">Data B</param>
    /// <returns></returns>
    public static int DaysDifference(DateTime a, DateTime b)
    {
        int diff = 0;
        if (a > b)
        {
            while (a.Date > b.Date)
            {
                b = b.AddDays(1);
                diff++;
            }
        }
        else
        {
            while (b.Date > a.Date)
            {
                a = a.AddDays(1);
                diff++;
            }
        }

        return diff;
    }
}
