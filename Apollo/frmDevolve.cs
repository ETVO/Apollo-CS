using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Apollo
{
    public partial class frmDevolve : Form
    {
        string codigo, user, dataPrevDev, sMulta;

        long empId;

        char op;

        string operacao;

        double multa, diaMulta = 1.0;
        int dias;

        bool paga;

        public frmDevolve()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do empréstimo</param>
        public frmDevolve(long id)
        {
            InitializeComponent();

            empId = id;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            devolve();
        }

        void destaca(TextBox txt)
        {
            txt.BackColor = SystemColors.Info;
        }

        void reseta(TextBox txt)
        {
            txt.BackColor = SystemColors.Window;
        }

        bool valCampos()
        {
            List<TextBox> fields = new List<TextBox>();

            fields.Add(txtUser);
            fields.Add(txtSenha);

            bool valid = true;

            for (int i = 0; i < fields.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(fields[i].Text))
                {
                    if (valid) util.Msg("Alguns campos não foram preenchidos ou contém valores inválidos!", MessageBoxIcon.Error);
                    destaca(fields[i]);
                    valid = false;
                }
            }
            if (!valid) return false;
            return true;
        }

        void devolve()
        {
            try
            {
                if (valCampos())
                {

                    string senha = txtSenha.Text;
                    string user = txtUser.Text;

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.user WHERE ra='" + user + "' OR login='" + user + "'";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read(); string senhaBanco = dr.GetString(4);
                        if (senha == senhaBanco)
                        {
                            if (!dr.GetBoolean(12))
                            {
                                devolve(dr.GetBoolean(11));

                                util.Msg("Devolução realizada com sucesso!", MessageBoxIcon.Information);
                            }
                            else
                            {
                                util.Msg("Este usuário está bloqueado!\n\nSe isso parece errado, contate um administrador!", MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            util.Msg("Senha incorreta!\n\nSe esqueceu sua senha, contate um administrador para alterá-la!", MessageBoxIcon.Error);
                            txtSenha.Text = "";
                            txtSenha.Focus();
                        }
                    }
                    else
                    {
                        util.Msg("Usuário inexistente!", MessageBoxIcon.Error);
                        txtUser.Text = "";
                        txtSenha.Text = "";
                        txtUser.Focus();
                    }
                    if (con != null)
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                btnFechar_Click(null, null);
            }
        }

        void devolve(bool adm)
        {
            if (adm)
            {
                try
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "UPDATE public.emprestimo SET devolvido = true WHERE id_emprestimo = " + empId;
                    
                    con.Run(sql);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                util.Msg("Esse usuário não é um administrador.\nUm usuário administrador deve validar a Devolução", MessageBoxIcon.Error);
            }
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Devolução de Empréstimo");

        private void frmDevolve_Load(object sender, EventArgs e)
        {
            displayData();
        }

        void displayData()
        {
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT l.titulo, (SELECT nome FROM public.autor WHERE id_autor = l.id_autor) AS autor, l.codigo, u.nome, u.login, to_char(data_prev_dev, 'dd/MM/yyyy') FROM public.emprestimo AS e INNER JOIN public.user AS u ON u.id_user = e.id_user INNER JOIN public.livro AS l ON l.id_livro = e.id_livro WHERE e.devolvido = FALSE AND id_emprestimo = " + empId;

                NpgsqlDataReader dr = con.Select(sql);

                if (dr.HasRows)
                {
                    dr.Read();
                    codigo = dr.GetString(2);
                    user = dr.GetString(4);
                    dataPrevDev = dr.GetString(5);

                    con.Close();
                }
                else
                    throw new Exception("Não foi possível localizar o empréstimo!");

                string desc = "Código: " + codigo + " Usuário: " + user;

                lblDesc.Text = desc;
                
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                btnFechar_Click(null, null);
            }
        }
    }
}
