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
    public partial class frmAtraso : Form
    {
        string codigo, user, dataPrevDev, sMulta;

        long empId;

        char op;

        string operacao;

        double multa, diaMulta = 1.0;
        int dias;

        bool paga;

        DialogResult retorno;

        public frmAtraso()
        {
            InitializeComponent();
        }

        public frmAtraso(char option, long idEmp)
        {
            InitializeComponent();

            empId = idEmp;
            op = option;
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Atraso");

        private void frmAtraso_Load(object sender, EventArgs e)
        {
            retorno = DialogResult.Cancel;
            displayData();

            switch (op)
            {
                case 'r':
                    ren();
                    break;

                case 'd':
                    dev();
                    break;

                default:
                    padrao();
                    break;
            }
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

                DateTime datePrevDev = DateTime.ParseExact(dataPrevDev, "dd/MM/yyyy", null);

                dias = util.DaysDifference(DateTime.Now, datePrevDev);

                multa = dias * diaMulta;

                string desc = "Código do Livro: " + codigo;

                lblDesc.Text = desc;

                lblDias.Text = dias + " dias";
                lblMulta.Text = sMulta = multa.ToString("C2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void ren()
        {
            panel(false);

            operacao = "Renovação";

            lblOp.Text = operacao;

            btnAutorizar.Text = "Autorizar " + operacao;
        }

        void dev()
        {
            panel(false);

            operacao = "Devolução";

            lblOp.Text = operacao;

            btnAutorizar.Text = "Autorizar " + operacao;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            op = 'r';
            ren();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            op = 'd';
            dev();
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            altera();
        }

        void padrao()
        {
            panel(true);
        }

        void panel(bool visible)
        {
            panelPadrao.Visible = visible;
            panelOp.Visible = !visible;
            
            if (visible)
            {
                this.Height = 397;
                btnFechar.Location = new Point(272, 320);
            }
            else
            {
                this.Height = 642;
                btnFechar.Location = new Point(272, 565);
            }
        }

        void altera()
        {
            try
            {
                paga = true;

                if(radSim.Checked)
                {
                    if (!util.ConfirmaMsg("A multa de " + sMulta + " será paga?"))
                        paga = false;
                    radNao.Checked = !paga;
                }

                if (valCampos())
                {

                    string senha = txtSenha.Text;
                    senha = util.Md5(senha);
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
                                altera(dr.GetBoolean(11));



                                if(option == 0)
                                {
                                    util.Msg(operacao + " realizada com sucesso!", MessageBoxIcon.Information);

                                    if (op == 'd')
                                        retorno = DialogResult.OK;
                                    else
                                        retorno = DialogResult.Retry;
                                }
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
                    if(option == 0)
                    {
                        this.DialogResult = retorno;
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                this.Close();
            }
        }

        int option = 0;

        string justificativa;

        void altera(bool adm)
        {
            bool flag = false;

            if (adm)
            {
                con.Close();

                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                if (op == 'r')
                {
                    try
                    {
                        DateTime novaDate = util.AddWorkdays(DateTime.Now, 14);
                        string novaData = novaDate.ToString("dd/MM/yyyy");

                        if (util.ConfirmaMsg("Deseja realmente renovar esse livro ?\n\nA nova data de devolução será " + novaData + "."))
                        {
                            string sql = "UPDATE public.emprestimo SET data_prev_dev = to_date('" + novaData + "', 'dd/MM/yyyy') WHERE id_emprestimo = " + empId;

                            con.Run(sql);
                        }
                        else
                        {
                            option = 1;
                        }


                    }
                    catch (Exception ex)
                    {
                        option = 2;

                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        if (radNao.Checked)
                            multa = 0;

                        if (util.ConfirmaMsg("Deseja realmente devolver esse livro?"))
                        {
                            string sql = "INSERT INTO public.atraso VALUES (" + empId + ", to_date('" + dataPrevDev + "', 'dd/MM/yyyy'), " + multa + ", '" + txtJustificativa.Text + "');";

                            con.Run(sql);


                            con.Close();

                            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                            sql = "UPDATE public.emprestimo SET devolvido = true WHERE id_emprestimo = " + empId;

                            flag = true;

                            con.Run(sql);

                            con.Close();

                            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                            sql = "UPDATE public.livro SET disponivel = TRUE WHERE codigo = '" + codigo + "'";

                            con.Run(sql);
                        }
                        else
                        {
                            option = 1;
                        }

                    }
                    catch(Exception ex)
                    {
                        if (flag)
                        {
                            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                            string sql = "DELETE FROM public.atraso WHERE id_emprestimo = " + empId;

                            con.Run(sql);
                        }
                        option = 2;
                        throw new Exception(ex.Message);
                    }
                }
            }
            else
            {
                util.Msg("Esse usuário não é um administrador.\nUm usuário administrador deve validar a " + operacao, MessageBoxIcon.Error);
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                altera();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                altera();
        }

        private void txtJustificativa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                altera();
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
            switch (op)
            {
                case 'r':
                    return valCampos(true);
                    break;

                case 'd':
                    return valCampos(true);
                    break;

                default:
                    padrao();
                    return false;
                    break;
            }
        }

        bool valCampos(bool a)
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
    }
}
