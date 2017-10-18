using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallPostgre.View
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin a;
        public FrmPrincipal(FrmLogin x)
        {
            a = x;
            InitializeComponent();
        }

        private void fériasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarPretensõesEnviadasPorUmTeleatendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblFrmPrincipalRegistro.Text = a.txtLoginRegistro.Text;
        }
    }
}
