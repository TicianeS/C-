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
    public partial class frmEntrar : Form
    {
        public frmEntrar()
        {
            InitializeComponent();
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Equals("") || txtSenha.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe login e senha.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Usuario Usuario = new Usuario();
                Usuario.Login = txtLogin.Text;
                Usuario.Senha = txtSenha.Text;

                Usuario = UsuarioDAO.AutenticarUsuario(Usuario);
                if (Usuario != null)
                {
                    frmPrincipal frmPri = new frmPrincipal(this);
                    this.Hide();
                    frmPri.Show();
                }
                else
                {
                    MessageBox.Show("Login ou senha incorretos.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
