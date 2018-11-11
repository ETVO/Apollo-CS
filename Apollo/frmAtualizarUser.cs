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
    public partial class frmAtualizarUser : Form
    {

        Int64 idUser;

        public frmAtualizarUser(Int64 id)
        {
            InitializeComponent();

            idUser = id;
        }

        Utilities util = new Utilities("Apollo - Atualizar Usuários");

        private void frmAtualizarUser_Load(object sender, EventArgs e)
        {
            util.Msg("Página em desenvolvimento.", MessageBoxIcon.Stop);
            frmDashboardAdm adm = new frmDashboardAdm(idUser);
            this.Hide();
            adm.ShowDialog();
            this.Close();
        }
    }
}
