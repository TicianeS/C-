using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Callcenter.DAO;
using Callcenter.Model;

namespace Callcenter.View
{
    
    public partial class frmPrincipal : Form
    {
        frmEntrar entrar;
        public frmPrincipal(frmEntrar x)
        {
            entrar = x;
            InitializeComponent();
        }

        private void mnPCadastros_Click(object sender, EventArgs e)
        {
            frmCadastro frmCad = new frmCadastro(this);
            frmRelatorios frmRel = new frmRelatorios(this);
            frmRel.Hide();
            frmCad.MdiParent = this;
            frmCad.Show();
        }

        private void mnPRelatorios_Click(object sender, EventArgs e)
        {
            if (lblTipoUsu.Text.Equals("Usuario"))
            {
                MessageBox.Show("Acesso negado.");
            }
            else
            {
                frmRelatorios frmRel = new frmRelatorios(this);
                frmCadastro frmCad = new frmCadastro(this);
                frmCad.Hide();
                frmRel.MdiParent = this;
                frmRel.Show();
            }
         
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            lblLoginUsu.Text = entrar.txtLogin.Text;
            string login = lblLoginUsu.Text;

            Usuario Usuario = new Usuario();
            Usuario = UsuarioDAO.ObterUsuarioLogin(login);
            lblTipoUsu.Text = Usuario.Tipo;

            lblFuncID.Text = Usuario.Funcionario.Id.ToString();
               
        }


    }
}
