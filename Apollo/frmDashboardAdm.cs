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
    public partial class frmDashboardAdm : Form
    {
        Int64 id_user;

        public frmDashboardAdm(Int64 id)
        {   
            InitializeComponent();
            id_user = id;
        }

        Utilities util = new Utilities("Apollo - Painel de Administração");

        Connection con;

        private void frmDashboardAdm_Load(object sender, EventArgs e)
        {
            while (true)
            {
                try
                {
                    string nome;
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.user WHERE id_user=" + id_user;

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        nome = dr.GetString(1);

                        lblNome.Text = nome;

                        radChange();
                    }
                    else
                    {
                        con.Close();
                        util.Msg("Algo deu errado!\n\nFaça seu Login novamente!", MessageBoxIcon.Error);
                        frmLogin login = new frmLogin();
                        this.Hide();
                        login.ShowDialog();
                        this.Close();
                    }

                    break;
                }
                catch (Exception ex)
                {
                    con.Close();
                    util.Msg("Algo deu errado!\n\nMais detalhes:" + ex.Message + "\n\nFaça seu Login novamente!", MessageBoxIcon.Error);
                    frmLogin login = new frmLogin();
                    this.Hide();
                    login.ShowDialog();
                    this.Close();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente sair?"))
            {
                frmInicio inicio = new frmInicio();
                this.Hide();
                inicio.ShowDialog();
                this.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar o aplicativo?"))
                this.Close();
        }

        private void btnUserSalvar_Click(object sender, EventArgs e)
        {
            cadUser();
        }

        void cadUser()
        {
            if (checaCadUser())
            {
                try
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");
                    

                    string sql = "INSERT INTO public.user VALUES (DEFAULT, @1, @2, @3, @4, @5, @6, DEFAULT, @7, @8, @9, DEFAULT)";

                    List<object> listSQL = new List<object>();

                    listSQL.Add(txtUserNome.Text);//1
                    listSQL.Add(txtUserRA.Text);//2
                    listSQL.Add(txtUserLogin.Text);//3
                    listSQL.Add(txtUserSenha.Text);//4
                    listSQL.Add(Convert.ToInt16(numUserSerie.Value));//5
                    listSQL.Add(cmbUserCurso.Text);//6
                    if(radAluno.Checked)//7
                        listSQL.Add("Aluno");
                    else if(radProfessor.Checked)
                        listSQL.Add("Professor");
                    else
                        listSQL.Add("Funcionário");

                    listSQL.Add(txtUserTelefone.Text);

                    if (chkUserAdmin.Checked)//9
                        listSQL.Add(true);
                    else
                        listSQL.Add(false);

                    con.Run(sql, listSQL);

                    util.Msg("O cadastro de " + txtUserNome.Text.Split(' ')[0] + " foi realizado com sucesso!", MessageBoxIcon.Information);

                    limpaCadUser();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close();
                    util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                }
            }
            else
                util.Msg("Existem campos a serem preenchidos!", MessageBoxIcon.Error);

        }

        void limpaCadUser()
        {
            txtUserNome.Clear();
            txtUserRA.Clear();
            txtUserLogin.Clear();
            txtUserSenha.Clear();
            txtUserTelefone.Clear();
            radAluno.Checked = true;
            numUserSerie.Value = 1;
            cmbUserCurso.SelectedIndex = -1;
            chkUserAdmin.Checked = false;
        }

        bool checaCadUser()
        {
            if (txtUserNome.Text == "")
            {
                txtUserNome.Focus();
                return false;
            }
            else if (txtUserLogin.Text == "")
            {
                txtUserLogin.Focus();
                return false;
            }
            else if (txtUserSenha.Text == "")
            {
                txtUserSenha.Focus();
                return false;
            }
            else if (!radAluno.Checked && !radFuncionario.Checked && !radProfessor.Checked)
            {
                grpTipo.Focus();
                return false;
            }
            else
                return true;
        }

        private void radAluno_CheckedChanged(object sender, EventArgs e)
        {
            radChange();
        }

        void radChange()
        {
            lblSerie.Visible = radAluno.Checked;
            lblCurso.Visible = radAluno.Checked;
            numUserSerie.Visible = radAluno.Checked;
            cmbUserCurso.Visible = radAluno.Checked;
        }

        private void radProfessor_CheckedChanged(object sender, EventArgs e)
        {
            radChange();
        }

        private void radFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            radChange();
        }

        private void btnUserLimpar_Click(object sender, EventArgs e)
        {
            if(util.ConfirmaMsg("Deseja realmente limpar?"))
                limpaCadUser();
        }

        private void btnUserNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultaUser_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM public.user WHERE nome LIKE '%" + txtConsultaUserNome.Text + "%'";

                if(cmbConsultaUserTipo.SelectedIndex != -1)
                {
                    sql += " AND tipo='" + cmbConsultaUserTipo.Text+"'";
                }
                if(cmbConsultaUserFiltro.SelectedIndex == 1)//apenas ativos
                {
                    sql += " AND bloqueado=FALSE";
                }
                else if(cmbConsultaUserFiltro.SelectedIndex == 2)
                {
                    sql += " AND bloqueado=TRUE";
                }

                populateUserGrid(sql);
            }
            catch(Exception ex)
            {
            }
        }

        void populateUserGrid(string sql)
        {
            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

            DataTable dt = con.SelectDataTable(sql);

            dgConsultaUsuario.DataSource = dt;
            con.Close();
        }
        
        private void tabUsuarios_Enter(object sender, EventArgs e)
        {

            populateUserGrid("SELECT * FROM public.user");
        }
    }
}
