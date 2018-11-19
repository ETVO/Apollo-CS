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
    public partial class frmCadastroEditora : Form
    {
        public frmCadastroEditora()
        {
            InitializeComponent();
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Cadastro de Editora");

        private void btnCria_Click(object sender, EventArgs e)
        {
            cria();
        }

        void resetaCor()
        {
            resetaCor(txtNome);
        }

        void resetaCor(TextBox txt)
        {
            txt.BackColor = SystemColors.Window;
        }

        void destaca(TextBox txt)
        {
            txt.BackColor = SystemColors.Info;
        }

        void voltar()
        {
            this.Close();
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

                    string sql = "INSERT INTO public.editora VALUES (DEFAULT, '" + txtNome.Text + "', DEFAULT);";

                    con.Run(sql);

                    util.Msg("Editora \"" + txtNome.Text + "\" cadastrada com sucesso!", MessageBoxIcon.Information);

                    voltar();
                }
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtNome);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
                voltar();
            else if (util.ConfirmaMsg("Deseja realmente fechar?"))
                voltar();
        }
    }
}
