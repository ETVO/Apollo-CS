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
    public partial class frmCadastroLivro : Form
    {

        Int64 idUser;

        public frmCadastroLivro(Int64 id)
        {
            InitializeComponent();
            idUser = id;
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Cadastro de Livro");

        private void txtAnoPublicacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCadastroLivro_Load(object sender, EventArgs e)
        {
            cmbReload('*');
            resetaCor();
        }

        void cmbReload(char opt)
        {
            if (opt == '*')
            {
                cmbReload('e');
                cmbReload('a');
                cmbReload('g');
            }
            else if (opt == 'e')
            {
                try
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.editora WHERE excluido = FALSE";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        cmbEditora.Items.Clear();
                        idEditoras.Clear();
                        while (dr.Read())
                        {
                            string editora = dr.GetString(1);
                            cmbEditora.Items.Add(editora);

                            idEditoras.Add(dr.GetInt64(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (util.ConfirmaMsg("Não foi possível recuperar as editoras!\n\nMais detalhes: " + ex.Message + "\n\nDeseja tentar novamente?"))
                        cmbReload('e');
                    else
                    {
                        frmDashboardAdm adm = new frmDashboardAdm(idUser);
                        this.Hide();
                        adm.ShowDialog();
                        this.Close();
                    }
                }
            }
            else if (opt == 'a')
            {
                try
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.autor WHERE excluido = FALSE";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        cmbAutor.Items.Clear();
                        idAutores.Clear();
                        while (dr.Read())
                        {
                            string autor = dr.GetString(1);
                            cmbAutor.Items.Add(autor);

                            idAutores.Add(dr.GetInt64(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (util.ConfirmaMsg("Não foi possível recuperar os autores!\n\nMais detalhes: " + ex.Message + "\n\nDeseja tentar novamente?"))
                        cmbReload('a');
                    else
                    {
                        frmDashboardAdm adm = new frmDashboardAdm(idUser);
                        this.Hide();
                        adm.ShowDialog();
                        this.Close();
                    }
                }
            }
            else
            {
                try
                {
                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT * FROM public.genero WHERE excluido = FALSE";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        cmbGenero.Items.Clear();
                        idGeneros.Clear();
                        while (dr.Read())
                        {
                            string genero = dr.GetString(1);
                            string sigla = dr.GetString(2);
                            cmbGenero.Items.Add(genero + " (" + sigla + ")");

                            idGeneros.Add(dr.GetInt64(0));
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (util.ConfirmaMsg("Não foi possível recuperar os autores!\n\nMais detalhes: " + ex.Message + "\n\nDeseja tentar novamente?"))
                        cmbReload('a');
                    else
                    {
                        frmDashboardAdm adm = new frmDashboardAdm(idUser);
                        this.Hide();
                        adm.ShowDialog();
                        this.Close();
                    }
                }
            }

        }

        void resetaCor()
        {
            List<TextBox> fields = new List<TextBox>();


            fields.Add(txtTitulo);
            fields.Add(txtGenero);
            fields.Add(txtCodigo);
            fields.Add(txtAutor);
            fields.Add(txtEditora);
            fields.Add(txtAnoPublicacao);

            foreach (TextBox field in fields)
            {
                resetaCor(field);
            }
        }

        void resetaCor(TextBox txt)
        {
            if (txt == txtAutor)
                cmbAutor.BackColor = SystemColors.Window;
            else if (txt == txtEditora)
                cmbEditora.BackColor = SystemColors.Window;
            else if (txt == txtGenero)
                cmbGenero.BackColor = SystemColors.Window;
            else
                txt.BackColor = SystemColors.Window;
        }

        void limpaCampo()
        {
            List<TextBox> fields = new List<TextBox>();


            fields.Add(txtTitulo);
            fields.Add(txtGenero);
            fields.Add(txtCodigo);
            fields.Add(txtAutor);
            fields.Add(txtEditora);
            fields.Add(txtAnoPublicacao);

            foreach (TextBox field in fields)
            {
                limpaCampo(field);
            }
        }

        void limpaCampo(TextBox txt)
        {
            if (txt == txtAutor)
                cmbAutor.SelectedIndex = -1;
            else if (txt == txtEditora)
                cmbEditora.SelectedIndex = -1;
            else if (txt == txtGenero)
                cmbGenero.SelectedIndex = -1;
            else
                txt.Text = "";
        }

        private void cmbAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAutor.Text = cmbAutor.Text;
        }

        private void cmbEditora_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEditora.Text = cmbEditora.Text;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar?"))
                this.Close();
        }

        bool camposVazios() { 
            return String.IsNullOrWhiteSpace(txtTitulo.Text) && String.IsNullOrWhiteSpace(txtAutor.Text) && String.IsNullOrWhiteSpace(txtEditora.Text) && String.IsNullOrWhiteSpace(txtGenero.Text) && String.IsNullOrWhiteSpace(txtAnoPublicacao.Text) && String.IsNullOrWhiteSpace(txtCodigo.Text);
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (camposVazios())
                voltar();
            else if (util.ConfirmaMsg("Deseja realmente voltar?"))
                voltar();
        }

        private void btnCria_Click(object sender, EventArgs e)
        {
            cria();
        }

        void destaca(TextBox txt)
        {
            if (txt == txtAutor)
                cmbAutor.BackColor = SystemColors.Info;
            else if (txt == txtEditora)
                cmbEditora.BackColor = SystemColors.Info;
            else if (txt == txtGenero)
                cmbGenero.BackColor = SystemColors.Info;
            else
                txt.BackColor = SystemColors.Info;
        }

        bool validaCampos()
        {
            try
            {
                resetaCor();

                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT * FROM public.livro WHERE codigo = '" + txtCodigo.Text + "';";
                NpgsqlDataReader dr = con.Select(sql);

                if (dr.HasRows && !String.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    util.Msg("O Código \"" + txtCodigo.Text + "\" já está cadastrado!", MessageBoxIcon.Error);
                    destaca(txtCodigo);
                    return false;
                }

                bool valid = true;
                List<TextBox> fields = new List<TextBox>();

                fields.Add(txtCodigo);
                fields.Add(txtTitulo);
                fields.Add(txtGenero);
                fields.Add(txtAutor);
                fields.Add(txtEditora);
                fields.Add(txtGenero);
                for (int i = 0; i < fields.Count; i++)
                {
                    if (String.IsNullOrWhiteSpace(fields[i].Text) || util.HasNumber(fields[i].Text))
                    {
                        if (!((fields[i] == txtCodigo || fields[i] == txtTitulo) && !String.IsNullOrWhiteSpace(fields[i].Text)))
                        {
                            if (valid) util.Msg("Alguns campos não foram preenchidos ou contém valores inválidos!", MessageBoxIcon.Error);
                            destaca(fields[i]);
                            valid = false;
                        }
                    }
                }
                if (!valid)
                    return false;
                if (String.IsNullOrWhiteSpace(txtAnoPublicacao.Text) || !util.HasNumber(txtAnoPublicacao.Text))
                {
                    if (util.ConfirmaMsg("Você não preencheu um ano de publicação, deseja cadastrar assim mesmo?"))
                    {
                        return true;
                    }
                    else
                    {
                        destaca(txtAnoPublicacao);
                        return false;
                    }
                }
                else
                    return true;
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                return false;
            }
        }

        List<long> idAutores = new List<long>();
        List<long> idEditoras = new List<long>();
        List<long> idGeneros = new List<long>();

        void cria()
        {
            try
            {
                if (validaCampos())
                {
                    resetaCor();

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT nextval('livro_id_livro_seq'::regclass)";

                    NpgsqlDataReader dr = con.Select(sql);

                    long id_livro;

                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_livro = dr.GetInt64(0);
                    }
                    else
                        throw new Exception("Problema ao realizar progressão da livro_id_livro_seq");

                    con.Close();
                    
                    long id_autor = idAutores[cmbAutor.SelectedIndex];
                    long id_editora = idEditoras[cmbEditora.SelectedIndex];
                    long id_genero = idGeneros[cmbGenero.SelectedIndex];

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    sql = "SELECT nome FROM public.genero WHERE id_genero = " + id_genero + ";";

                    dr = con.Select(sql);

                    string genero;

                    if (dr.HasRows)
                    {
                        dr.Read();
                        genero = dr.GetString(0);

                    }
                    else
                        throw new Exception("Problema ao encontrar Gênero selecionado");


                    con.Close();


                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    sql = "INSERT INTO public.livro (id_livro, codigo, titulo, genero, id_autor, id_editora, ano_lancamento) VALUES " +
                        "(" + id_livro + ", '" + txtCodigo.Text + "', '" + txtTitulo.Text + "', '" + genero + "', " + id_autor + ", " + id_editora + ", " + txtAnoPublicacao.Text + ");";

                    con.Run(sql);

                    util.Msg("Livro \"" + txtTitulo.Text + "\" cadastrado com sucesso!", MessageBoxIcon.Information);

                    limpaCampo();

                    txtTitulo.Focus();
                }
            }
            catch(Exception ex)
            {
                util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        void voltar()
        {
            frmDashboardAdm adm = new frmDashboardAdm(idUser);
            this.Hide();
            adm.ShowDialog();
            this.Close();
        }

        private void txtGenero_TextChanged(object sender, EventArgs e)
        {
        }

        private void linkCadastroGenero_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastroGenero cadGenero = new frmCadastroGenero();
            cadGenero.ShowDialog();
            cmbReload('g');
        }

        private void linkCadastroAutor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastroAutor cadAutor = new frmCadastroAutor();
            cadAutor.ShowDialog();
            cmbReload('a');
        }

        private void linkCadastroEditora_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastroEditora cadEditora = new frmCadastroEditora();
            cadEditora.ShowDialog();
            cmbReload('e');
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtCodigo);
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtTitulo);
        }

        private void txtAnoPublicacao_Enter(object sender, EventArgs e)
        {
            util.SelectTextBoxIfEmpty(txtAnoPublicacao);
        }

        void genCodigo()
        {
            if(cmbGenero.SelectedIndex > -1)
            {
                try
                {
                    long selId = idGeneros[cmbGenero.SelectedIndex];

                    string nome, sigla, msgErro = "Não foi possível gerar o código do seu livro!";
                    long count;

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    string sql = "SELECT nome, sigla FROM public.genero WHERE id_genero  = " + selId + ";";

                    NpgsqlDataReader dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        nome = dr.GetString(0);
                        sigla = dr.GetString(1);
                    }
                    else
                        throw new Exception(msgErro);

                    con.Close();

                    con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                    sql = "SELECT COUNT(*) FROM public.livro WHERE genero = '" + nome + "';";

                    dr = con.Select(sql);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        count = dr.GetInt64(0) + 1;
                    }
                    else
                        throw new Exception(msgErro);

                    txtCodigo.Text = sigla + "-" + count;

                }
                catch (Exception ex)
                {
                    util.Msg("Algo deu errado!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtCodigo.Text = "";
            }
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            genCodigo();
            txtGenero.Text = cmbGenero.Text;
        }

        private void txtAnoPublicacao_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}
