using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apollo
{
    public partial class frmConsultaLivro : Form
    {
        public frmConsultaLivro()
        {
            InitializeComponent();
        }

        Connection con;
        Utilities util = new Utilities("Apollo - Livros");

        private void frmConsultaLivro_Load(object sender, EventArgs e)
        {
            grid(false);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            grid(true);
        }

        void grid(bool filterOn)
        {
            /*dgvLivro.DataSource = null;
            try
            {
                con = new Connection("localhost", "5432", "postgres", "postgres", "admin");

                string sql = "SELECT id_livro, titulo, genero, (SELECT nome FROM public.autor WHERE public.autor.id_autor = l.id_autor), (SELECT nome FROM public.editora WHERE public.editora.id_editora = l.id_editora), ano_lancamento, codigo FROM public.livro AS l INNER JOIN public.autor AS a ON a.id_autor = l.id_autor INNER JOIN public.editora AS e ON e.id_editora = l.id_editora WHERE disponivel = TRUE";


                if (filterOn)
                {
                    string pesq;
                    if (txtPesquisa.Text.Length > 0)
                    {
                        pesq = txtPesquisa.Text.ToLower();
                        sql += " AND (lower(codigo) LIKE '%" + pesq + "%' OR lower(titulo) LIKE '%" + pesq + "%' OR lower(genero) LIKE '%" + pesq + "%') OR lower(a.nome) LIKE '%" + pesq + "%' OR lower(e.nome) LIKE '%" + pesq + "%'";
                    }
                }

                sql += " ORDER BY titulo ASC";

                DataTable dt = con.SelectDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    dgvLivro.DataSource = dt;

                    setToAutoFill(dgvLivro);

                    int i = 0;
                    dgvLivro.Columns[i++].HeaderText = "Id";
                    dgvLivro.Columns[i++].HeaderText = "Título";
                    dgvLivro.Columns[i++].HeaderText = "Gênero";
                    dgvLivro.Columns[i++].HeaderText = "Autor";
                    dgvLivro.Columns[i++].HeaderText = "Editora";
                    dgvLivro.Columns[i++].HeaderText = "Ano Lançamento";
                    dgvLivro.Columns[i++].HeaderText = "Código";

                    dgvLivro.Columns[0].Visible = false;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                util.Msg("Algo deu errado!\n\nTente novamente mais tarde!\n\nMais detalhes: " + ex.Message, MessageBoxIcon.Error);
                voltar();
            }

            dgvLivro.ClearSelection();*/
        }

        void setToAutoFill(DataGridView dgv)
        {
            DataGridViewAutoSizeColumnMode mode = DataGridViewAutoSizeColumnMode.Fill;

            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                dgv.Columns[j].AutoSizeMode = mode;
            }
        }
    }
}
