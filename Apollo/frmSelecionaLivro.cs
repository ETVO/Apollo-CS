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
    public partial class frmSelecionaLivro : Form
    {

        long userId, admId;

        int formOption;

        bool selUser;

        string pesquisa;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="idAdm">Id do Usuário Administrador</param>
        public frmSelecionaLivro(long id, long idAdm)
        {
            InitializeComponent();

            userId = id;
            admId = idAdm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="idAdm">Id do Usuário Administrador</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        /// <param name="selUser">Se veio ou não do frmSelecionaUser</param>
        public frmSelecionaLivro(long id, long idAdm, int form, bool selecionaUser)
        {
            InitializeComponent();

            userId = id;
            admId = idAdm;
            formOption = form;
            selUser = selecionaUser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="idAdm">Id do Usuário Administrador</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        public frmSelecionaLivro(long id, long idAdm, int form)
        {
            InitializeComponent();

            userId = id;
            admId = idAdm;
            formOption = form;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio; 4 - frmSelecionaUser)</para></param>
        public frmSelecionaLivro(long id, int form, bool selecionaUser)
        {
            InitializeComponent();

            userId = id;
            formOption = form;
            selUser = selecionaUser;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltar();
        }

        void voltar()
        {
            if (!selUser)
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
            else
            {
                frmSelecionaUser selUser;
                switch (formOption)
                {
                    case 0://login
                        selUser = new frmSelecionaUser(formOption);
                        this.Hide();
                        selUser.ShowDialog();
                        this.Close();
                        break;

                    case 1://admin dashboard
                        selUser = new frmSelecionaUser(admId, formOption);
                        this.Hide();
                        selUser.ShowDialog();
                        this.Close();
                        break;

                    case 2://user dashboard
                        selUser = new frmSelecionaUser(formOption);
                        this.Hide();
                        selUser.ShowDialog();
                        this.Close();
                        break;

                    case 3://inicio
                        selUser = new frmSelecionaUser(formOption);
                        this.Hide();
                        selUser.ShowDialog();
                        this.Close();
                        break;

                    default:
                        formOption = 3;
                        voltar();
                        break;
                }
            }
        }

        Connection con; 
        Utilities util = new Utilities("Apollo - Selecione o Livro");

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            voltar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private void frmEmprestimoSelecionaLivro_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "Clique duas vezes para selecionar o livro que o usuário emprestará";
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT nome FROM public.user WHERE id_user = " + userId;

                NpgsqlDataReader dr = con.Select(sql);

                if (dr.HasRows)
                {
                    dr.Read();
                    string nome = dr.GetString(0);
                    nome = nome.Split(' ')[0];

                    string txt = "Clique duas vezes para selecionar o livro que " + nome + " emprestará";

                    lblDesc.Text = txt;
                }
                else
                    throw new Exception("Usuário não encontrado!");
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            grid(false);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            pesquisa = txtPesquisa.Text;
            grid(true);
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            grid(false);
        }

        void grid(bool filterOn)
        {
            dgvLivro.DataSource = null;
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT id_livro, codigo, titulo, genero, (SELECT nome FROM public.autor WHERE public.autor.id_autor = public.livro.id_autor) AS autor, (SELECT nome FROM public.editora WHERE public.editora.id_editora = public.livro.id_editora) AS editora, ano_lancamento FROM public.livro WHERE disponivel = TRUE";


                if (filterOn)
                {
                    string pesq;
                    if (txtPesquisa.Text.Length > 0)
                    {
                        pesq = txtPesquisa.Text.ToLower();
                        sql += " AND (lower(codigo) LIKE '%" + pesq + "%' OR lower(titulo) LIKE '%" + pesq + "%')";
                    }
                }

                DataTable dt = con.SelectDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    dgvLivro.DataSource = dt;

                    int i = 0;
                    dgvLivro.Columns[i++].HeaderText = "Id";
                    dgvLivro.Columns[i++].HeaderText = "Código";
                    dgvLivro.Columns[i++].HeaderText = "Título";
                    dgvLivro.Columns[i++].HeaderText = "Gênero";
                    dgvLivro.Columns[i++].HeaderText = "Autor";
                    dgvLivro.Columns[i++].HeaderText = "Editora";
                    dgvLivro.Columns[i++].HeaderText = "Ano Lançamento";

                    dgvLivro.Columns[0].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nTente novamente mais tarde!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            dgvLivro.ClearSelection();
        }
    }
}
