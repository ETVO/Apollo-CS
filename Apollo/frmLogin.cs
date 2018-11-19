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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Utilities util = new Utilities("Apollo - Login");

        Connection con;
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmInicio inicio = new frmInicio();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if(util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        private bool valCampos()
        {
            if (txtUser.Text == "")
            {
                txtUser.Focus();
                return false;
            }
            else if (txtSenha.Text == "")
            {
                txtSenha.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            subLogin();
        }

        void subLogin()
        {
            try
            {
                if (valCampos())
                {
                    string user = txtUser.Text;
                    string senha = txtSenha.Text;
                    senha = util.Md5(senha);

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.user WHERE ra='" + user + "' OR login='" + user + "'";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read(); string senhaBanco = dr.GetString(4);
                        if (senha == senhaBanco)
                        {
                            if (!dr.GetBoolean(12))
                            {
                                if (dr.GetBoolean(11))
                                {
                                    if (util.ConfirmaMsg("Deseja ir ao Painel de Administração?"))
                                    {
                                        frmDashboardAdm adm = new frmDashboardAdm(dr.GetInt64(0));
                                        this.Hide();
                                        adm.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        frmDashboard pan = new frmDashboard(dr.GetInt64(0));
                                        this.Hide();
                                        pan.ShowDialog();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    frmDashboard pan = new frmDashboard(dr.GetInt64(0));
                                    this.Hide();
                                    pan.ShowDialog();
                                    this.Close();
                                }
                            }
                            else
                            {
                                util.Msg("Este usuário está bloqueado!\n\nSe isso parece errado, contate um administrador!", MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                        {
                            util.Msg("Senha incorreta!\n\nSe esqueceu sua senha, contate um administrador para alterá-la!", MessageBoxIcon.Error);
                            txtSenha.Text = "";
                            txtSenha.Focus();
                        }
                    }
                    else
                    {
                        util.Msg("Usuário inexistente!", MessageBoxIcon.Error);
                        txtUser.Text = "";
                        txtSenha.Text = "";
                        txtUser.Focus();
                    }
                    con.Close();
                }
                else
                {
                    util.Msg("Alguns campos não foram preenchidos!", MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes:" + ex.Message, MessageBoxIcon.Error);
            }
        }
        
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
                subLogin();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                subLogin();
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSenha.Text))
            {
                txtSenha.SelectAll();
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.SelectAll();
            }
        }

        private void lblCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastroUser cad = new frmCadastroUser(0);
            this.Hide();
            cad.ShowDialog();
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
