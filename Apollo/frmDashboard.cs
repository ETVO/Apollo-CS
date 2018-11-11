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
    public partial class frmDashboard : Form
    {
        Int64 idUser;

        bool adm = false;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="id">Id do usuário</param>
        public frmDashboard(Int64 id)
        {
            InitializeComponent();
            idUser = id;
        }

        Utilities util = new Utilities("Apollo - Panorama da Biblioteca");

        Connection con;

        private void frmDashboard_Load(object sender, EventArgs e)
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

                        adm = dr.GetBoolean(11);

                        if (adm)
                            btnDashboardAdm.Visible = true;
                    }
                    else
                    {
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
            if(util.ConfirmaMsg("Deseja realmente sair?"))
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

        private void btnDashboardAdm_Click(object sender, EventArgs e)
        {
            if (adm)
            {
                frmDashboardAdm adm = new frmDashboardAdm(idUser);
                this.Hide();
                adm.ShowDialog();
                this.Close();
            }
        }
    }
}
