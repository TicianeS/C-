using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallPostgre.Util;

namespace CallPostgre.View
{
    public partial class FrmUsuario : Form
    {
        FrmPrincipal pri;
        public FrmUsuario(FrmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            int reg = Conversor.ConverterParaInt(lblUsuarioRegistro.Text);
            if (pri.lblFrmPrincipalCargo.Text.Contains("TELEATENDENTE")){

                btnUsuarioCadastrar.Enabled = false;
                btnUsuarioCadastrar.Visible = false;
                btnUsuarioExcluir.Enabled = false;
                btnUsuarioExcluir.Visible = false;

                txtUsuarioRegistro.Text = pri.lblFrmPrincipalRegistro.Text;
                txtUsuarioRegistro.Enabled = false;
                txtUsuarioRegistro.ReadOnly = true;

                txtUsuarioNome.Text = pri.lblFrmPrincipalNome.Text;

            } else {
                if (pri.lblFrmPrincipalCargo.Text.Contains("MONITOR"))
                {
                    btnUsuarioCadastrar.Enabled = false;
                    btnUsuarioCadastrar.Visible = false;
                    btnUsuarioExcluir.Enabled = false;
                    btnUsuarioExcluir.Visible = false;

                    txtUsuarioRegistro.Text = pri.lblFrmPrincipalRegistro.Text;
                    txtUsuarioRegistro.Enabled = true;
                    txtUsuarioRegistro.ReadOnly = false;

                    txtUsuarioNome.Text = pri.lblFrmPrincipalNome.Text;
                }
                else
                {
                    btnUsuarioCadastrar.Enabled = false;
                    btnUsuarioCadastrar.Visible = false;
                    btnUsuarioExcluir.Enabled = false;
                    btnUsuarioExcluir.Visible = false;
                    btnUsuarioAlterarSenha.Enabled = false;
                    btnUsuarioAlterarSenha.Visible = false;

                    txtUsuarioRegistro.Text = pri.lblFrmPrincipalRegistro.Text;
                    txtUsuarioRegistro.Enabled = false;
                    txtUsuarioRegistro.ReadOnly = true;

                    txtUsuarioNome.Text = pri.lblFrmPrincipalNome.Text;
                }
            }
            
        }
    }
}
