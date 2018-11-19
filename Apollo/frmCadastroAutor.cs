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
    public partial class frmCadastroAutor : Form
    {
        public frmCadastroAutor()
        {
            InitializeComponent();
        }

        Connection con = new Connection("localhost", "5432", "postgres", "postgres", "admin");
        Utilities util = new Utilities("Apollo - Cadastro de Autor");

        private void frmCadastroAutor_Load(object sender, EventArgs e)
        {
        }
        
        private void txtDataNasc_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtDataNasc);
        }

        private void txtDataNasc_Leave(object sender, EventArgs e)
        {
        }

        void resetaCor()
        {
            resetaCor(txtNome);
            resetaCor(txtDataNasc);
        }

        void resetaCor(TextBox txt)
        {
            txt.BackColor = SystemColors.Window;
        }

        void destaca(TextBox txt)
        {
            txt.BackColor = SystemColors.Info;
        }

        bool valCampo()
        {
            resetaCor();

            con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

            string sql = "SELECT * FROM public.autor WHERE nome = '" + txtNome.Text + "';";
            NpgsqlDataReader dr = con.Select(sql);

            if (dr.HasRows && !String.IsNullOrWhiteSpace(txtNome.Text))
            {
                util.Msg("O Autor \"" + txtNome.Text + "\" já está cadastrado!\n\nDeseja cadastrar mesmo assim?", MessageBoxIcon.Error);
                destaca(txtNome);
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtNome.Text) || util.HasNumber(txtNome.Text))
            {
                util.Msg("O campo não foi preenchido ou contém valores inválidos!", MessageBoxIcon.Error);
                destaca(txtNome);
                return false;
            }
            return true;
        }

        void cria()
        {
            try
            {
                if (valCampo())
                {
                    resetaCor();

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string dataNasc;

                    if (String.IsNullOrWhiteSpace(txtDataNasc.Text))
                        dataNasc = "null";
                    else
                        dataNasc = txtDataNasc.Text;

                    string sql = "INSERT INTO public.autor VALUES (DEFAULT, '" + txtNome.Text + "', " + dataNasc + ", DEFAULT);";

                    con.Run(sql);

                    util.Msg("Autor \"" + txtNome.Text + "\" cadastrado com sucesso!", MessageBoxIcon.Information);

                    voltar();   
                }
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        void voltar()
        {
            this.Close();
        }

        private void btnCria_Click(object sender, EventArgs e)
        {
            cria();
        }

        private void txtDataNasc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDataNasc.Text) && String.IsNullOrWhiteSpace(txtNome.Text))
                voltar();
            else if (util.ConfirmaMsg("Deseja realmente fechar?"))
                voltar();
        }
    }
}
