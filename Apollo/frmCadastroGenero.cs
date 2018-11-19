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
    public partial class frmCadastroGenero : Form
    {
        public frmCadastroGenero()
        {
            InitializeComponent();
        }

        Utilities util = new Utilities("Apollo - Cadastrar Gênero");
        Connection con;

        private void btnCria_Click(object sender, EventArgs e)
        {
            cria();
        }

        void resetaCor()
        {
            resetaCor(txtNome);
            resetaCor(txtSigla);
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
            try
            {
                resetaCor();

                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT * FROM public.genero WHERE nome = '" + txtNome.Text + "';";
                NpgsqlDataReader dr = con.Select(sql);

                if (dr.HasRows && !String.IsNullOrWhiteSpace(txtNome.Text))
                {
                    util.Msg("O Gênero \"" + txtNome.Text + "\" já está cadastrado!", MessageBoxIcon.Error);
                    destaca(txtNome);
                    return false;
                }
                if (String.IsNullOrWhiteSpace(txtNome.Text) || util.HasNumber(txtNome.Text))
                {
                    util.Msg("O campo não foi preenchido ou contém valores inválidos!", MessageBoxIcon.Error);
                    destaca(txtNome);
                    return false;
                }
                if (String.IsNullOrWhiteSpace(txtSigla.Text) || util.HasNumber(txtSigla.Text))
                {
                    util.Msg("O campo não foi preenchido ou contém valores inválidos!", MessageBoxIcon.Error);
                    destaca(txtSigla);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                return false;
            }
        }

        void cria()
        {
            try
            {
                if (valCampo())
                {
                    resetaCor();

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "INSERT INTO public.genero VALUES (DEFAULT, '" + txtNome.Text + "', '" + txtSigla.Text + "', DEFAULT);";

                    con.Run(sql);

                    util.Msg("Gênero \"" + txtNome.Text + "\" cadastrado com sucesso!", MessageBoxIcon.Information);

                    voltar();

                }
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        void voltar()
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            voltar();

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSigla.Text) && String.IsNullOrWhiteSpace(txtNome.Text))
                voltar();
            else if (util.ConfirmaMsg("Deseja realmente fechar?"))
                voltar();

        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtNome);
        }

        private void frmCadastroGenero_Load(object sender, EventArgs e)
        {

        }
    }
}
