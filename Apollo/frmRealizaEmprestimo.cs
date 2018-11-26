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
    public partial class frmRealizaEmprestimo : Form
    {

        Connection con;
        Utilities util = new Utilities("Apollo - Empréstimo");


        long userId, admId, livroId;

        string titulo, codigo, autor;

        string nome, user;

        string dataEmp = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        static DateTime datePrevDev;

        string dataPrevDev = datePrevDev.Day + "/" + datePrevDev.Month + "/" + datePrevDev.Year;


        int formOption;

        bool selUser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="idAdm">Id do Usuário Administrador</param>
        /// <param name="idLivro">Id do Livro Selecionado</param>
        public frmRealizaEmprestimo(long id, long idAdm, long idLivro)
        {
            InitializeComponent();

            userId = id;
            admId = idAdm;
            livroId = idLivro;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="idAdm">Id do Usuário Administrador</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio)</para></param>
        public frmRealizaEmprestimo(long id, long idAdm, long idLivro, int form, bool selecionaUser)
        {
            InitializeComponent();

            userId = id;
            admId = idAdm;
            formOption = form;
            livroId = idLivro;
            selUser = selecionaUser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do Usuário Selecionado</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio)</para></param>
        public frmRealizaEmprestimo(long id, long idLivro, int form, bool selecionaUser)
        {
            InitializeComponent();

            userId = id;
            formOption = form;
            livroId = idLivro;
            selUser = selecionaUser;
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltarSelLivro();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            voltarSelLivro();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }
        

        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void btnRealizarEmprestimo_Click(object sender, EventArgs e)
        {
            bool flag = false;
            long id_emp = 0;

            try
            {
                if(util.ConfirmaMsg("Deseja realmente emprestar o livro \"" + titulo + "\" para o usuário \"" + nome.Split(' ')[0] + "\"?"))
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT nextval('emprestimo_id_emprestimo_seq'::regclass)";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_emp = dr.GetInt64(0);
                    }
                    else
                        throw new Exception("Não foi possível realizar a progressão da emprestimo_id_emprestimo_seq");

                    con.Close();

                    sql = "INSERT INTO public.emprestimo (id_emprestimo, id_livro, id_user, data_emp, data_prev_dev) " +
                        "VALUES (" + id_emp + ", " + livroId + ", " + userId + ", to_date('" + dataEmp + "', 'dd/MM/yyyy'), to_date('" + dataPrevDev +"', 'dd/MM/yyyy'));";
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    con.Run(sql);

                    flag = true;

                    con.Close();

                    sql = "UPDATE public.livro SET disponivel = FALSE WHERE id_livro = " + livroId;
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    con.Run(sql);

                    util.Msg("Empréstimo realizado com sucesso!", MessageBoxIcon.Information);

                    voltar();
                }
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                if (flag)
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "DELETE FROM public.emprestimo WHERE id_emprestimo = " + id_emp;

                    con.Run(sql);
                }

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

        void voltarSelLivro()
        {
            frmSelecionaLivro selLivro;
            if (formOption == 1)//admin
                selLivro = new frmSelecionaLivro(userId, admId, formOption, selUser);
            else
                selLivro = new frmSelecionaLivro(userId, formOption, selUser);

            this.Hide();
            selLivro.ShowDialog();
            this.Close();
        }

        string empPrevDev, empTitulo, empUser;

        DateTime empDev;

        void displayData()
        {
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql1 = "SELECT l.titulo, to_char(data_prev_dev, 'dd/MM/yyyy'), u.login FROM public.emprestimo AS e INNER JOIN public.user AS u ON u.id_user = e.id_user INNER JOIN public.livro AS l ON l.id_livro = e.id_livro WHERE e.devolvido = FALSE AND e.id_user = " + userId;

                NpgsqlDataReader dr1 = con.Select(sql1);

                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        empTitulo = dr1.GetString(0);
                        empPrevDev = dr1.GetString(1);
                        empUser = dr1.GetString(2);

                        empDev = DateTime.ParseExact(empPrevDev, "dd/MM/yyyy", null);

                        if(DateTime.Now > empDev)
                        {
                            util.Msg("Existe um empréstimo atrasado no nome do usuário \"" + empUser + "\"\n\nLivro: " + empTitulo + "\nVencimento: " + empPrevDev + " (atrasado)", MessageBoxIcon.Error);
                            voltar();
                            return;
                        }
                    }

                    con.Close();
                }
                else
                    con.Close();


                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT titulo, codigo, id_autor FROM public.livro WHERE id_livro = " + livroId;

                NpgsqlDataReader dr = con.Select(sql);


                long id_autor;

                if (dr.HasRows)
                {
                    dr.Read();
                    titulo = dr.GetString(0);
                    codigo = dr.GetString(1);
                    id_autor = dr.GetInt64(2);

                    con.Close();

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    sql = "SELECT nome FROM public.autor WHERE id_autor = " + id_autor;

                    dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        autor = dr.GetString(0);

                        con.Close();
                    }
                    else
                        throw new Exception("Não foi possível localizar o autor!");
                }
                else
                    throw new Exception("Não foi possível localizar o livro!");

                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                sql = "SELECT nome, login FROM public.user WHERE id_user = " + userId;

                dr = con.Select(sql);

                if (dr.HasRows)
                {
                    dr.Read();
                    nome = dr.GetString(0);
                    user = dr.GetString(1);
                }
                else
                    throw new Exception("Não foi possível localizar o usuário!");

                con.Close();

                lblTitulo.Text = titulo;
                lblAutor.Text = autor;
                lblCodigo.Text = codigo;

                lblNome.Text = nome;
                lblUser.Text = user;

                datePrevDev = util.AddWorkdays(DateTime.Now, 14);

                dataPrevDev = datePrevDev.Day + "/" + datePrevDev.Month + "/" + datePrevDev.Year;

                lblDataDev.Text = dataPrevDev;
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltarSelLivro();
            }
        }
    }
}
