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
using CallPostgre.Model;
using CallPostgre.DAO;

namespace CallPostgre.View
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin log;
        public FrmPrincipal(FrmLogin x)
        {
            log = x;
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
            lblFrmPrincipalRegistro.Text = log.txtLoginRegistro.Text;
            int reg = Conversor.ConverterParaInt(lblFrmPrincipalRegistro.Text);

            Funcionario f = new Funcionario();

            f = FuncionarioDAO.ObterFuncionarioId(reg);
            lblFrmPrincipalNome.Text = f.nome;
            lblFrmPrincipalCargo.Text = f.cargos.nome;

            if (lblFrmPrincipalCargo.Text.Contains("TELEATENDENTE"))
            {
                mnTeleatendente.Enabled = true;
                mnMonitor.Enabled = false;
                mnSupervisor.Enabled = false;
            }
            else
            {
                if (lblFrmPrincipalCargo.Text.Contains("MONITOR") || reg == 43387)
                {
                    mnTeleatendente.Enabled = false;
                    mnMonitor.Enabled = true;
                    mnSupervisor.Enabled = false;
                }
                else
                {
                    if (reg == 51482)
                    {
                        mnTeleatendente.Enabled = false;
                        mnMonitor.Enabled = false;
                        mnSupervisor.Enabled = true;
                    }
                    else
                    {
                        mnTeleatendente.Enabled = false;
                        mnMonitor.Enabled = false;
                        mnSupervisor.Enabled = false;
                    }
                }
            }
        }

        private void mnTeleAcessoAlterarSenha_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsu = new FrmUsuario(this);
            frmUsu.Show();
        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
