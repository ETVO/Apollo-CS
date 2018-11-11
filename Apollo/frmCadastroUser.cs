using System;
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
    public partial class frmCadastroUser : Form
    {
        /// <summary>
        /// Atributo interno para saber de qual formulário o usuário vem
        /// </summary>
        int formOption;

        /// <summary>
        /// Atributo interno para saber qual o usuário, caso venha de algum painel (admin ou user)
        /// </summary>
        Int64 userId;

        string title, desc, conclusionMsg;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio)</para></param>
        /// <param name="id">Id do usuário logado</param>
        public frmCadastroUser(int form, Int64 id)
        {
            InitializeComponent();
            formOption = form;
            userId = id;

        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio)</para></param>
        public frmCadastroUser(int form)
        {
            InitializeComponent();
            formOption = form;
        }

        Utilities util;
        Connection con;

        private void frmCadastroUser_Load(object sender, EventArgs e)
        {
            if (formOption == 2)
            {
                conclusionMsg = "Sua conta foi alterada com sucesso!";
                title = "Altere sua Conta";
                desc = "Para aprimorar sua experiência com o sistema";
            }
            else if(formOption == 1)
            {
                title = "Cadastre um Usuário";
                desc = "Para oferecer acesso aos recursos do sistema";
            }
            else
            {
                conclusionMsg = "Conta criada com sucesso!";
                title = "Crie sua Conta";
                desc = "Para ter acesso aos recursos do sistema";
            }
            cmbTipo.SelectedIndex = 0;
            panelReload();
            resetaCor('*');
            util = new Utilities("Apollo - " + title);
            this.Text = title;
            lblTitle.Text = title;
            lblDesc.Text = desc;
        }

        void panelReload()
        {
            if(cmbTipo.SelectedIndex == 0)
            {
                panelAluno.Visible = true;
                panelOutro.Visible = !panelAluno.Visible;
                this.Height = 667;
            }
            else
            {
                panelAluno.Visible = false;
                panelOutro.Visible = !panelAluno.Visible;
                this.Height = 492;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelReload();
        }

        void destaca(TextBox txtBox)
        {
            if (txtBox == txtAno)
                numAno.BackColor = SystemColors.Info;
            else if(txtBox == txtCurso)
                cmbCurso.BackColor = SystemColors.Info;
            else
                txtBox.BackColor = SystemColors.Info;

        }

        void resetaCor(char type)
        {
            List<TextBox> fields = new List<TextBox>();

            if (type == '*')
            {
                // Aluno
                fields.Add(txtNome);
                fields.Add(txtRA);
                fields.Add(txtUser);
                fields.Add(txtSenha);
                fields.Add(txtAno);
                fields.Add(txtCurso);
                fields.Add(txtTelefone);

                // Professor ou Funcionário
                fields.Add(txtNomeOutro);
                fields.Add(txtUserOutro);
                fields.Add(txtSenhaOutro);
                fields.Add(txtTelefoneOutro);
            }
            else if(type == 'a')
            {
                // Aluno
                fields.Add(txtNome);
                fields.Add(txtRA);
                fields.Add(txtUser);
                fields.Add(txtSenha);
                fields.Add(txtAno);
                fields.Add(txtCurso);
                fields.Add(txtTelefone);
            }
            else
            {
                // Professor ou Funcionário
                fields.Add(txtNomeOutro);
                fields.Add(txtUserOutro);
                fields.Add(txtSenhaOutro);
                fields.Add(txtTelefoneOutro);
            }

            foreach (TextBox field in fields)
            {
                resetaCor(field);
            }
        }

        void resetaCor(TextBox txtBox)
        {
            if (txtBox == txtAno)
                numAno.BackColor = SystemColors.Window;
            else if (txtBox == txtCurso)
                cmbCurso.BackColor = SystemColors.Window;
            else
                txtBox.BackColor = SystemColors.Window;
        }
        void limpaCampo(char type)
        {
            List<TextBox> fields = new List<TextBox>();

            if (type == '*')
            {
                // Aluno
                fields.Add(txtNome);
                fields.Add(txtRA);
                fields.Add(txtUser);
                fields.Add(txtSenha);
                fields.Add(txtAno);
                fields.Add(txtCurso);
                fields.Add(txtTelefone);

                // Professor ou Funcionário
                fields.Add(txtNomeOutro);
                fields.Add(txtUserOutro);
                fields.Add(txtSenhaOutro);
                fields.Add(txtTelefoneOutro);
            }
            else if (type == 'a')
            {
                // Aluno
                fields.Add(txtNome);
                fields.Add(txtRA);
                fields.Add(txtUser);
                fields.Add(txtSenha);
                fields.Add(txtAno);
                fields.Add(txtCurso);
                fields.Add(txtTelefone);
            }
            else
            {
                // Professor ou Funcionário
                fields.Add(txtNomeOutro);
                fields.Add(txtUserOutro);
                fields.Add(txtSenhaOutro);
                fields.Add(txtTelefoneOutro);
            }

            foreach (TextBox field in fields)
            {
                limpaCampo(field);
            }
        }

        void limpaCampo(TextBox txtBox)
        {
            if (txtBox == txtAno)
                numAno.Value = 1;
            else if (txtBox == txtCurso)
                cmbCurso.SelectedIndex = -1;
            else
                txtBox.Text = "";

            resetaCor(txtBox);
        }

        bool valCamposAluno()
        {
            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

            string sql = "SELECT * FROM public.user WHERE ra = '" + txtRA.Text + "';";
            NpgsqlDataReader dr = con.Select(sql);

            if (dr.HasRows && !String.IsNullOrWhiteSpace(txtRA.Text))
            {
                util.Msg("O RA \"" + txtRA.Text + "\" já está cadastrado!\n\nSe isso parece errado, contate um administrador!", MessageBoxIcon.Error);
                destaca(txtRA);
                con.Close();
                return false;
            }

            con.Close();

            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

            sql = "SELECT * FROM public.user WHERE login = '" + txtUser.Text + "';";
            dr = con.Select(sql);

            if (dr.HasRows && !String.IsNullOrWhiteSpace(txtUser.Text))
            {
                util.Msg("O Usuário \"" + txtUser.Text + "\" já está cadastrado!", MessageBoxIcon.Error);
                destaca(txtUser);
                return false;
            }

            bool valid = true;
            List<TextBox> fields = new List<TextBox>();

            fields.Add(txtNome);
            fields.Add(txtRA);
            fields.Add(txtUser);
            fields.Add(txtSenha);
            fields.Add(txtAno);
            fields.Add(txtCurso);
            for(int i = 0; i < fields.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(fields[i].Text) || util.HasNumber(fields[i].Text))
                {
                    if(!((fields[i] == txtRA || fields[i] == txtAno) && !String.IsNullOrWhiteSpace(fields[i].Text)))
                    {
                        if (valid) util.Msg("Alguns campos não foram preenchidos ou contém valores inválidos!", MessageBoxIcon.Error);
                        destaca(fields[i]);
                        valid = false;
                    }
                }
            }
            if (!valid)
                return false;

            if(String.IsNullOrWhiteSpace(txtTelefone.Text) || !util.HasNumber(txtTelefone.Text))
            {
                if(util.ConfirmaMsg("Você não preencheu um telefone, deseja cadastrar assim mesmo?"))
                {
                    return true;
                }
                else
                {
                    destaca(txtTelefone);
                    return false;
                }
            }
            else
               return true;
        }
        bool valCamposOutro()
        {
            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

            string sql = "SELECT * FROM public.user WHERE login = '" + txtUserOutro.Text + "';";
            NpgsqlDataReader dr = con.Select(sql);

            if (dr.HasRows && !String.IsNullOrWhiteSpace(txtUserOutro.Text))
            {
                util.Msg("O Usuário \"" + txtUserOutro.Text + "\" já está cadastrado!", MessageBoxIcon.Error);
                destaca(txtUserOutro);
                return false;
            }

            bool valid = true;
            List<TextBox> fields = new List<TextBox>();

            fields.Add(txtNomeOutro);
            fields.Add(txtUserOutro);
            fields.Add(txtSenhaOutro);
            for (int i = 0; i < fields.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(fields[i].Text) || util.HasNumber(fields[i].Text))
                {
                    if (!((fields[i] == txtRA || fields[i] == txtAno) && !String.IsNullOrWhiteSpace(fields[i].Text)))
                    {
                        if (valid) util.Msg("Alguns campos não foram preenchidos ou contém valores inválidos!", MessageBoxIcon.Error);
                        destaca(fields[i]);
                        valid = false;
                    }
                }
            }
            if (!valid)
                return false;
            if (String.IsNullOrWhiteSpace(txtTelefoneOutro.Text) || !util.HasNumber(txtTelefoneOutro.Text))
            {
                if (util.ConfirmaMsg("Você não preencheu um telefone, deseja cadastrar assim mesmo?"))
                {
                    return true;
                }
                else
                {
                    destaca(txtTelefoneOutro);
                    return false;
                }
            }
            else
                return true;
        }

        private void btnCriaAluno_Click(object sender, EventArgs e)
        {
            cria('a');
        }
        private void btnCriaOutro_Click(object sender, EventArgs e)
        {
            cria('o');
        }

        bool valCampos(char type)
        {
            if (type == 'a')
                return valCamposAluno();
            return valCamposOutro();
        }


        void cria(char type)
        {
            try
            {
                if (valCampos(type))
                {
                    resetaCor(type);

                    if (formOption == 2)
                    {//alterar

                    }
                    else
                    {//cadastrar
                        con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                        string sql = "SELECT nextval('user_id_user_seq'::regclass)";
                        long id;

                        NpgsqlDataReader dr = con.Select(sql);
                        if (dr.HasRows)
                        {
                            dr.Read();
                            id = dr.GetInt64(0);
                        }
                        else
                            throw new Exception("Problema ao realizar progressão da user_id_user_seq");

                        con.Close();

                        con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                        string periodo;
                        if (radDiurno.Checked)
                            periodo = "Diurno";
                        else
                            periodo = "Noturno";

                        if (formOption == 1)
                        {
                            if (util.ConfirmaMsg("Deseja cadastrá-lo como administrador?"))
                            {
                                if(type  == 'a')
                                {
                                    sql = "INSERT INTO public.user (id_user, tipo, nome, ra, login, senha, serie, curso, periodo, telefone, ano, adm) " +
                            "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNome.Text + "', '" + txtRA.Text + "', '" + txtUser.Text + "', '" + util.Md5(txtSenha.Text) + "', '" + txtAno.Text + "', '" + txtCurso.Text + "', '" + periodo + "', '" + txtTelefone.Text + "', " + DateTime.Now.Year + ", TRUE);";

                                }
                                else
                                {
                                    sql = "INSERT INTO public.user (id_user, tipo, nome, login, senha, telefone, ano, adm) " +
                            "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNomeOutro.Text + "', '" + txtUserOutro.Text + "', '" + util.Md5(txtSenhaOutro.Text) + "', '" + txtTelefoneOutro.Text + "', " + DateTime.Now.Year + ", TRUE);";

                                }

                                con.Run(sql);

                                util.Msg("Administrador " + txtNomeOutro.Text.Split(' ')[0] + " cadastrado com sucesso!", MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (type == 'a')
                                {
                                    sql = "INSERT INTO public.user (id_user, tipo, nome, ra, login, senha, serie, curso, periodo, telefone, ano, adm) " +
                            "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNome.Text + "', '" + txtRA.Text + "', '" + txtUser.Text + "', '" + util.Md5(txtSenha.Text) + "', '" + txtAno.Text + "', '" + txtCurso.Text + "', '" + periodo + "', '" + txtTelefone.Text + "', " + DateTime.Now.Year + ", FALSE);";

                                }
                                else
                                {
                                    sql = "INSERT INTO public.user (id_user, tipo, nome, login, senha, telefone, ano, adm) " +
                            "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNomeOutro.Text + "', '" + txtUserOutro.Text + "', '" + util.Md5(txtSenhaOutro.Text) + "', '" + txtTelefoneOutro.Text + "', " + DateTime.Now.Year + ", FALSE);";

                                }

                                con.Run(sql);

                                util.Msg("Usuário " + txtNomeOutro.Text.Split(' ')[0] + " cadastrado com sucesso!", MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (type == 'a')
                            {
                                sql = "INSERT INTO public.user (id_user, tipo, nome, ra, login, senha, serie, curso, periodo, telefone, ano, adm) " +
                        "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNome.Text + "', '" + txtRA.Text + "', '" + txtUser.Text + "', '" + util.Md5(txtSenha.Text) + "', '" + txtAno.Text + "', '" + txtCurso.Text + "', '" + periodo + "', '" + txtTelefone.Text + "', " + DateTime.Now.Year + ", FALSE);";

                            }
                            else
                            {
                                sql = "INSERT INTO public.user (id_user, tipo, nome, login, senha, telefone, ano, adm) " +
                        "VALUES (" + id.ToString() + ", '" + cmbTipo.Text + "', '" + txtNomeOutro.Text + "', '" + txtUserOutro.Text + "', '" + util.Md5(txtSenhaOutro.Text) + "', '" + txtTelefoneOutro.Text + "', " + DateTime.Now.Year + ", FALSE);";

                            }

                            con.Run(sql);

                            util.Msg(conclusionMsg, MessageBoxIcon.Information);
                        }

                        limpaCampo(type);
                        voltar();
                    }
                }
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void btnVoltarOutro_Click(object sender, EventArgs e)
        {
            voltar();
        }

        void voltar()
        {
            switch (formOption)
            {
                case 0://login
                    frmLogin login = new frmLogin();
                    this.Hide();
                    login.ShowDialog();
                    this.Close();
                    break;

                case 1://admin dashboard
                    frmDashboardAdm adm = new frmDashboardAdm(userId);
                    this.Hide();
                    adm.ShowDialog();
                    this.Close();
                    break;

                case 2://user dashboard
                    frmDashboard dash = new frmDashboard(userId);
                    this.Hide();
                    dash.ShowDialog();
                    this.Close();
                    break;

                case 3://inicio
                    frmInicio inicio = new frmInicio();
                    this.Hide();
                    inicio.ShowDialog();
                    this.Close();
                    break;

                default:
                    formOption = 3;
                    voltar();
                    break;
            }
        }

        private void btnVoltarUser_Click(object sender, EventArgs e)
        {
            voltar();
        }

        private void btnFecharOutro_Click(object sender, EventArgs e)
        {

            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private void btnFecharUser_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private void numAno_Validating(object sender, CancelEventArgs e)
        {
            txtAno.Text = numAno.Value.ToString();
        }

        private void txtCurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCurso_Validating(object sender, CancelEventArgs e)
        {
            txtCurso.Text = cmbCurso.Text;
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtNome);
        }

        private void txtRA_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtRA);
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtUser);
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtSenha);
        }

        private void numAno_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(numAno.Value.ToString()))
            {
                numAno.Select(0, numAno.Value.ToString().Length);
            }
        }

        private void cmbCurso_Enter(object sender, EventArgs e)
        {
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtTelefone);
        }

        private void txtNomeOutro_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtNomeOutro);
        }

        private void txtUserOutro_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtUserOutro);
        }

        private void txtSenhaOutro_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtSenhaOutro);
        }

        private void txtTelefoneOutro_Enter(object sender, EventArgs e)
        {
            util.selectTextBoxIfEmpty(txtTelefoneOutro);
        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurso.Text = cmbCurso.Text;
        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            txtAno.Text = numAno.Value.ToString();
        }
        
    }
}
