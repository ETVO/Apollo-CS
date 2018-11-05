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
    public partial class frmCadastroUser : Form
    {
        public frmCadastroUser()
        {
            InitializeComponent();
        }

        Utilities util = new Utilities("Apollo - Cadastro de Usuário");

        private void frmCadastroUser_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            panelReload();
        }

        void panelReload()
        {
            if(cmbTipo.SelectedIndex == 0)
            {
                panelAluno.Visible = true;
                panelOutro.Visible = !panelAluno.Visible;
                this.Height = 585;
            }
            else
            {
                panelAluno.Visible = false;
                panelOutro.Visible = !panelAluno.Visible;
                this.Height = 462;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelReload();
        }

        private void btnCriaAluno_Click(object sender, EventArgs e)
        {

        }
    }
}
