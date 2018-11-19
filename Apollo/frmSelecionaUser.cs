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
    public partial class frmSelecionaUser : Form
    {
        string nome, ra, user, curso, tipo, periodo;
        int ano;

        string pesquisa;


        long admId;

        int formOption;

        public frmSelecionaUser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        public frmSelecionaUser(int form)
        {
            InitializeComponent();

            formOption = form;
        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        /// <param name="id">Id do usuário logado</param>
        public frmSelecionaUser(long id, int form)
        {
            InitializeComponent();

            admId = id;

            formOption = form;
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Usuário para Empréstimo");

        private void frmEmprestimoSelecionaUser_Load(object sender, EventArgs e)
        {
            grid(false);
        }

        bool ifFilter()
        {
            if (txtPesquisa.Text.Length > 0)
                return true;
            return false;
        }

        void grid(bool filterOn)
        {
            dgvUser.DataSource = null;
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT id_user, nome, ra, login, serie, curso, periodo, tipo, telefone FROM public.user WHERE bloqueado = FALSE";



                if (filterOn)
                {
                    string pesq;
                    if(txtPesquisa.Text.Length > 0)
                    {
                        pesq = txtPesquisa.Text.ToLower();
                        sql += " AND (lower(nome) LIKE '%" + pesq + "%' OR ra LIKE '%" + pesq + "%' OR lower(login) LIKE '%" + pesq + "%')";
                    }
                }

                DataTable dt = con.SelectDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    dgvUser.DataSource = dt;

                    int i = 0;
                    dgvUser.Columns[i++].HeaderText = "Id";
                    dgvUser.Columns[i++].HeaderText = "Nome";
                    dgvUser.Columns[i++].HeaderText = "RA";
                    dgvUser.Columns[i++].HeaderText = "Usuário";
                    dgvUser.Columns[i++].HeaderText = "Ano";
                    dgvUser.Columns[i++].HeaderText = "Curso";
                    dgvUser.Columns[i++].HeaderText = "Período";
                    dgvUser.Columns[i++].HeaderText = "Tipo";
                    dgvUser.Columns[i++].HeaderText = "Telefone";

                    dgvUser.Columns[0].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nTente novamente mais tarde!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            dgvUser.ClearSelection();
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
                    frmDashboardAdm adm = new frmDashboardAdm(admId);
                    this.Hide();
                    adm.ShowDialog();
                    this.Close();
                    break;

                case 2://user dashboard
                    frmDashboard dash = new frmDashboard(admId);
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

        private void dgvUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
                seleciona(e.RowIndex);
        }

        void seleciona(int index)
        {
            long selUser = Convert.ToInt64(dgvUser.Rows[index].Cells[0].Value);

            frmSelecionaLivro selLivro;

            if (formOption == 1)//admin dashboard
            {
                selLivro = new frmSelecionaLivro(selUser, admId, formOption, true);
            }
            else
            {
                selLivro = new frmSelecionaLivro(selUser, formOption, true);
            }
            this.Hide();
            selLivro.ShowDialog();
            this.Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 1)
                seleciona(dgvUser.SelectedRows[0].Index);
        }

        private void dgvUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                seleciona(dgvUser.SelectedRows[0].Index);
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            pesquisa = txtPesquisa.Text;
            grid(true);
        }

        private void btnCadastroUser_Click(object sender, EventArgs e)
        {
            frmCadastroUser cadUser = new frmCadastroUser(4, admId, formOption);
            this.Hide();
            cadUser.ShowDialog();
            this.Close();
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            //resetFilters();
            txtPesquisa.Text = "";
            grid(false);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltar();
        }
        
    }
}
