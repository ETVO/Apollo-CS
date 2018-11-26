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
    public partial class frmConsultaEmprestimo : Form
    {

        int formOption;

        long admId, userId;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        public frmConsultaEmprestimo(long id, int form)
        {
            InitializeComponent();

            if (form == 1)
                admId = id;
            else
                userId = id;
            formOption = form;
        }

        public frmConsultaEmprestimo()
        {
            InitializeComponent();
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Consulta de Empréstimos");

        private void frmConsultaEmprestimo_Load(object sender, EventArgs e)
        {
            grid(false);
        }

        void atrasado(long id)
        {

        }

        List<long> idEmprestimos = new List<long>();

        List<long> idAtrasos = new List<long>();

        void grid(bool filterOn)
        {
            dgvEmprestimo.DataSource = null;
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT id_emprestimo, (SELECT codigo FROM public.livro WHERE public.livro.id_livro = e.id_livro) AS codigo, (SELECT titulo FROM public.livro WHERE public.livro.id_livro = e.id_livro) AS livro, (SELECT nome FROM public.user WHERE public.user.id_user = e.id_user) AS user, to_char(data_emp, 'dd/MM/yyyy'), to_char(data_prev_dev, 'dd/MM/yyyy') FROM public.emprestimo AS e INNER JOIN public.user AS u ON u.id_user = e.id_user INNER JOIN public.livro AS l ON l.id_livro = e.id_livro WHERE e.devolvido = FALSE";

                
                NpgsqlDataReader dr = con.Select(sql);

                if (dr.HasRows)
                {
                    idEmprestimos.Clear();
                    idAtrasos.Clear();

                    while (dr.Read())
                    {
                        string dataPrevDev = dr.GetString(5);
                        DateTime datePrevDev = DateTime.ParseExact(dataPrevDev, "dd/MM/yyyy", null);

                        long id_emp = dr.GetInt64(0);

                        idEmprestimos.Add(id_emp);

                        if (DateTime.Now > datePrevDev)
                        {
                            idAtrasos.Add(id_emp);
                        }
                    }

                }
                else
                {
                    util.Msg("Nenhum empréstimo foi encontrado!", MessageBoxIcon.Warning);
                    voltar();
                }


                if (filterOn)
                {
                    string pesq;
                    if (txtPesquisa.Text.Length > 0)
                    {
                        pesq = txtPesquisa.Text.ToLower();
                        sql += " AND (lower(u.nome) LIKE '%" + pesq + "%' OR lower(l.titulo) LIKE '%" + pesq + "%' OR lower(l.codigo) LIKE '%" + pesq + "%')";
                    }
                }

                sql += " ORDER BY e.data_prev_dev ASC";

                con.Close();

                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                DataTable dt = con.SelectDataTable(sql);


                dgvEmprestimo.Columns.Clear();
                dgvEmprestimo.Rows.Clear();

                if (dt.Rows.Count > 0)
                {

                    dgvEmprestimo.DataSource = dt;

                    int i = 0;

                    setToAutoFill(dgvEmprestimo);

                    dgvEmprestimo.Columns[i++].HeaderText = "Id";
                    dgvEmprestimo.Columns[i++].HeaderText = "Código Livro";
                    dgvEmprestimo.Columns[i++].HeaderText = "Livro";
                    dgvEmprestimo.Columns[i++].HeaderText = "Usuário";
                    dgvEmprestimo.Columns[i++].HeaderText = "Data Retirada";
                    dgvEmprestimo.Columns[i++].HeaderText = "Data Devolução";

                    if(dgvEmprestimo.Rows.Count > 0)
                        dgvEmprestimo.Columns.Add("Atrasado", "Atrasado");

                    for(int j = 0; j < dgvEmprestimo.Rows.Count; j++)
                    {
                        string atrasado = "Não";
                        if (idAtrasos.Contains(Convert.ToInt64(dgvEmprestimo.Rows[j].Cells[0].Value)))
                        {
                            atrasado = "Sim";
                            dgvEmprestimo.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                        }
                        dgvEmprestimo.Rows[j].Cells[i].Value = atrasado;
                    }

                    dgvEmprestimo.Columns[0].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nTente novamente mais tarde!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            dgvEmprestimo.ClearSelection();
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

        private void dgvEmprestimo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                seleciona(e.RowIndex);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvEmprestimo.SelectedRows.Count > 0)
                seleciona(dgvEmprestimo.SelectedRows[0].Index - 1);
        }

        private void dgvEmprestimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar =='\r')
                seleciona(dgvEmprestimo.SelectedRows[0].Index - 1);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            grid(true);
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            grid(true);
        }

        private void dgvEmprestimo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = 0;

            dgvEmprestimo.Columns[i++].HeaderText = "Id";
            dgvEmprestimo.Columns[i++].HeaderText = "Código Livro";
            dgvEmprestimo.Columns[i++].HeaderText = "Livro";
            dgvEmprestimo.Columns[i++].HeaderText = "Usuário";
            dgvEmprestimo.Columns[i++].HeaderText = "Data Retirada";
            dgvEmprestimo.Columns[i++].HeaderText = "Data Devolução";

            if (dgvEmprestimo.Rows.Count > 0)
                dgvEmprestimo.Columns.Add("Atrasado", "Atrasado");

            for (int j = 0; j < dgvEmprestimo.Rows.Count; j++)
            {
                string atrasado = "Não";
                if (idAtrasos.Contains(Convert.ToInt64(dgvEmprestimo.Rows[j].Cells[0].Value)))
                {
                    atrasado = "Sim";
                    dgvEmprestimo.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                }
                dgvEmprestimo.Rows[j].Cells[i].Value = atrasado;
            }

            dgvEmprestimo.Columns[0].Visible = false;
        }

        void seleciona(int index)
        {
            long empId = Convert.ToInt64(dgvEmprestimo.Rows[index].Cells[0].Value);

            frmEmprestimo emprestimo;

            if (formOption == 1)//admin
            {
                emprestimo = new frmEmprestimo(empId, admId, formOption);
            }
            else
                emprestimo = new frmEmprestimo(empId, userId, formOption);

            this.Hide();
            emprestimo.ShowDialog();
            this.Close();
        }
    }
}
