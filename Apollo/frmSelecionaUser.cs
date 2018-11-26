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

        List<long> idAtrasados = new List<long>();

        Dictionary<long, string> titles = new Dictionary<long, string>();

        Dictionary<long, string> dates = new Dictionary<long, string>();

        void grid(bool filterOn)
        {
            dgvUser.DataSource = null;
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT id_user, nome, ra, login, serie, curso, periodo, tipo FROM public.user WHERE bloqueado = FALSE";



                if (filterOn)
                {
                    string pesq;
                    if(txtPesquisa.Text.Length > 0)
                    {
                        pesq = txtPesquisa.Text.ToLower();
                        sql += " AND (lower(nome) LIKE '%" + pesq + "%' OR ra LIKE '%" + pesq + "%' OR lower(login) LIKE '%" + pesq + "%')";
                    }
                }

                sql += " ORDER BY nome ASC";

                DataTable dt = con.SelectDataTable(sql);

                con.Close();
                if (dt.Rows.Count > 0)
                {
                    dgvUser.DataSource = dt;

                    setToAutoFill(dgvUser);

                    int i = 0;
                    dgvUser.Columns[i++].HeaderText = "Id";
                    dgvUser.Columns[i++].HeaderText = "Nome";
                    dgvUser.Columns[i++].HeaderText = "RA";
                    dgvUser.Columns[i++].HeaderText = "Usuário";
                    dgvUser.Columns[i++].HeaderText = "Ano";
                    dgvUser.Columns[i++].HeaderText = "Curso";
                    dgvUser.Columns[i++].HeaderText = "Período";
                    dgvUser.Columns[i++].HeaderText = "Tipo";

                    idAtrasados.Clear();
                    dates.Clear();
                    titles.Clear();
                    for (int j = 0; j < dgvUser.Rows.Count; j++)
                    {
                        con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                        long id_user = Convert.ToInt64(dgvUser.Rows[j].Cells[0].Value);

                        string select = "SELECT to_char(data_prev_dev, 'dd/MM/yyyy'), l.titulo FROM public.emprestimo AS e INNER JOIN public.livro AS l ON l.id_livro = e.id_livro WHERE devolvido = FALSE AND id_user = " + id_user;

                        NpgsqlDataReader sdr = con.Select(select);

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                string data = sdr.GetString(0);

                                string titulo = sdr.GetString(1);

                                DateTime date = DateTime.ParseExact(data, "dd/MM/yyyy", null);

                                if(DateTime.Now > date)
                                {
                                    dgvUser.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);


                                    idAtrasados.Add(id_user);

                                    dates.Add(id_user, data);

                                    titles.Add(id_user, titulo);
                                }
                            }
                        }

                        con.Close();
                    }

                    dgvUser.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nTente novamente mais tarde!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            dgvUser.ClearSelection();
        }

        void setToAutoFill(DataGridView dgv)
        {
            DataGridViewAutoSizeColumnMode mode = DataGridViewAutoSizeColumnMode.Fill;

            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                dgv.Columns[j].AutoSizeMode = mode;
            }
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

            if (!idAtrasados.Contains(selUser))
            {
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
            else
            {
                util.Msg("Existe um empréstimo atrasado no nome desse usuário!\n\nLivro: " + titles[selUser] + "\nVencimento: " + dates[selUser], MessageBoxIcon.Error);
            }
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

        private void dgvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = 0;
            dgvUser.Columns[i++].HeaderText = "Id";
            dgvUser.Columns[i++].HeaderText = "Nome";
            dgvUser.Columns[i++].HeaderText = "RA";
            dgvUser.Columns[i++].HeaderText = "Usuário";
            dgvUser.Columns[i++].HeaderText = "Ano";
            dgvUser.Columns[i++].HeaderText = "Curso";
            dgvUser.Columns[i++].HeaderText = "Período";
            dgvUser.Columns[i++].HeaderText = "Tipo";

            for (int j = 0; j < dgvUser.Rows.Count; j++)
            {
                long id_user = Convert.ToInt64(dgvUser.Rows[j].Cells[0].Value);

                if(idAtrasados.Contains(id_user))
                {
                    string data = dates[id_user];

                    DateTime date = DateTime.ParseExact(data, "dd/MM/yyyy", null);

                    if (DateTime.Now > date)
                    {
                        dgvUser.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    }
                }
            }

            dgvUser.Columns[0].Visible = false;
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
