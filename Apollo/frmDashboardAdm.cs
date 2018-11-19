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
        Int64 idUser;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="id">Id do usuário administrador</param>
        public frmDashboardAdm(Int64 id)
        {   
            InitializeComponent();
            idUser = id;
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

                    string sql = "SELECT * FROM public.user WHERE id_user=" + idUser;

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        nome = dr.GetString(1);

                        lblNome.Text = nome;

                        if (!dr.GetBoolean(11))
                        {
                            frmDashboard dash = new frmDashboard(idUser);
                            this.Hide();
                            dash.ShowDialog();
                            this.Close();
                        }
                        
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard dash = new frmDashboard(idUser);
            this.Hide();
            dash.ShowDialog();
            this.Close();
        }

        private void btnCadastroUser_Click(object sender, EventArgs e)
        {
            frmCadastroUser cadUser = new frmCadastroUser(1, idUser);
            this.Hide();
            cadUser.ShowDialog();
            this.Close();
        }

        private void btnAtualizarUser_Click(object sender, EventArgs e)
        {
            frmAtualizarUser atualizarUser = new frmAtualizarUser(idUser);
            this.Hide();
            atualizarUser.ShowDialog();
            this.Close();
        }

        private void btnCadastroLivro_Click(object sender, EventArgs e)
        {
            frmCadastroLivro cadLivro = new frmCadastroLivro(idUser);
            this.Hide();
            cadLivro.ShowDialog();
            this.Close();
        }

        private void btnNovoEmprestimo_Click(object sender, EventArgs e)
        {
            frmSelecionaUser selUser = new frmSelecionaUser(idUser, 1);
            this.Hide();
            selUser.ShowDialog();
            this.Close();
        }
    }
}
