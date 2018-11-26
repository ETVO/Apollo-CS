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
    public partial class frmEmprestimo : Form
    {
        bool atrasado;

        long empId, userId;

        string titulo, codigo, autor;

        string nome, user;

        string dataEmp = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        static DateTime datePrevDev;

        string dataPrevDev;

        int formOption, dias;

        double multa = 0.0, multaDia = 1;

        public frmEmprestimo()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEmp">Id do Empréstimo</param>
        /// <param name="idUser">Id do Usuário (Adm ou não)</param>
        /// <param name="form"><para>De qual formulário o frmCadastroUser está sendo aberto</para><para>(0 - frmLogin; 1 - frmDashboardAdm; 2 - frmDashboard; 3 - frmInicio)</para></param>
        public frmEmprestimo(long idEmp, long idUser, int form)
        {
            InitializeComponent();

            empId = idEmp;
            userId = idUser;
            formOption = form;
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

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            if (atrasado)
            {
                frmAtraso atraso = new frmAtraso('r', empId);
                atraso.ShowDialog();
            }
            else
            {
                DateTime novaDate = util.AddWorkdays(datePrevDev, 14);
                string novaData = novaDate.ToString("dd/MM/yyyy");

                if (util.ConfirmaMsg("Deseja realmente renovar esse livro?\n\nA nova data de devolução será " + novaData + "."))
                    renova(novaDate);
            }
            displayData();
        }
        
        void renova(DateTime date)
        {
            try
            {
                con = con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "UPDATE public.emprestimo SET data_prev_dev = '" + date.ToString("yyyy-MM-dd") + "' WHERE id_emprestimo = " + empId;

                con.Run(sql);

                util.Msg("Empréstimo renovado com sucesso!", MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                util.Msg("Não foi possível renovar esse empréstimo!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (atrasado)
            {
                frmAtraso atraso = new frmAtraso('d', empId);
                atraso.ShowDialog();

                if (atraso.DialogResult == DialogResult.OK)
                {
                    backToDash = true;
                    voltar();
                }
            }
            else
            {
                frmDevolve devolve = new frmDevolve(empId);
                devolve.ShowDialog();

                if (devolve.DialogResult == DialogResult.OK)
                {
                    backToDash = true;
                    voltar();
                }
            }
            displayData();
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Empréstimo");

        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            displayData();
        }

        bool atraso(bool atraso)
        {
            panelAtraso.Visible = atraso;

            int panelLocationInicial = 594;
            int frmHeight = 716;
            int difference = 152;

            if (atraso)
            {
                Point panelLocation = new Point(5, panelLocationInicial);
                this.Height = frmHeight;
                panelOpts.Location = panelLocation;
            }
            else
            {
                Point panelLocation = new Point(5, panelLocationInicial - difference);
                this.Height = frmHeight - difference;
                panelOpts.Location = panelLocation;
            }

            atrasado = atraso;

            return atraso;
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
                    titulo = dr.GetString(0);
                    autor = dr.GetString(1);
                    codigo = dr.GetString(2);
                    nome = dr.GetString(3);
                    user = dr.GetString(4);
                    dataPrevDev = dr.GetString(5);

                    datePrevDev = DateTime.ParseExact(dataPrevDev, "dd/MM/yyyy", null);

                    con.Close();
                }
                else
                    throw new Exception("Não foi possível localizar o empréstimo!");

                string desc;

                dias = util.DaysDifference(DateTime.Now, datePrevDev);

                desc = dias + " dias para devolução";

                if (atraso(DateTime.Now > datePrevDev))
                {

                    lblDias.Text = dias + " dias";
                    multa = dias * multaDia;
                    lblMulta.Text = multa.ToString("C2", new CultureInfo("pt-BR"));

                    desc = dias + " dias atrasado :(";
                }

                lblDesc.Text = desc;
                
                lblTitulo.Text = titulo;
                lblCodigo.Text = codigo;

                lblNome.Text = nome;
                lblUser.Text = user;
                
                dataPrevDev = datePrevDev.Day + "/" + datePrevDev.Month + "/" + datePrevDev.Year;

                lblDataDev.Text = dataPrevDev;
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }
        }

        bool backToDash = false;

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
                    if (!backToDash)
                    {
                        frmConsultaEmprestimo consultaEmprestimo = new frmConsultaEmprestimo(userId, formOption);
                        this.Hide();
                        consultaEmprestimo.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        frmDashboardAdm adm = new frmDashboardAdm(userId);
                        this.Hide();
                        adm.ShowDialog();
                        this.Close();
                    }
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
    }
}
