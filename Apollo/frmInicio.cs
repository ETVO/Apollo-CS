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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        Utilities util = new Utilities("Apollo");

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (util.ConfirmaMsg("Deseja realmente fechar o aplicativo?"))
                this.Close();
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            frmCadastroUser caduser = new frmCadastroUser(3);
            this.Hide();
            caduser.ShowDialog();
            this.Close();
        }
    }
}
