using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallPostgre.DAO;
using CallPostgre.Model;
using CallPostgre.Util;
using CallPostgre.View;


namespace CallPostgre
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Divisao div = new Divisao();

            div = DivisaoDAO.ObterDivisaoId(1);
            if (div != null)
            {
                MessageBox.Show(div.nome);
            }
        }

        private void btnLoginEntrar_Click(object sender, EventArgs e)
        {
            if (txtLoginRegistro.Text.Equals("") || mskLoginSenha.Text.Equals(""))
            {
                MessageBox.Show("Por favor, informe seu registro e senha.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int reg = Conversor.ConverterParaInt(txtLoginRegistro.Text);
                
                Usuario Usuario = new Usuario();
                Usuario = UsuarioDAO.ObterUsuarioRegistro(reg);

                string senha = mskLoginSenha.Text;

               if (Usuario == null)
                {
                    MessageBox.Show("Login ou senha incorretos.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               else
                {
                    if (Usuario.senha.Equals(senha))
                    {
                        string nome = Usuario.funcionarios.nome;

                        MessageBox.Show("BEM-VINDO (A) " + Usuario.funcionarios.nome + " !");
                        FrmPrincipal frmPri = new FrmPrincipal(this);
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

        private void linkLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicite sua senha de acesso para o seu monitor.");
        }
    }
}
