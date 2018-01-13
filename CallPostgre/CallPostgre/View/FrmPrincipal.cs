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
        FrmCargo frmCargo;
        FrmPretensao frmPret;
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
            int reg = Util.Tools.ConverterParaInt(lblFrmPrincipalRegistro.Text);

            Funcionario f = new Funcionario();

            f = FuncionarioDAO.ObterFuncionarioId(reg);
            lblFrmPrincipalNome.Text = f.nome;

            Usuario u = new Usuario();
            u = UsuarioDAO.ObterUsuarioRegistro(reg);
            lblFrmPrincipalPerfil.Text = u.perfil;

            if (lblFrmPrincipalPerfil.Text.Equals("TELEATENDENTE"))
            {
                mnTeleatendente.Enabled = true;
                mnMonitor.Enabled = false;
                mnSupervisor.Enabled = false;
                mnTeleatendente.Visible= true;
                mnMonitor.Visible = false;
                mnSupervisor.Visible = false;
            }
            else
            {
                if (lblFrmPrincipalPerfil.Text.Equals("MONITOR") || lblFrmPrincipalPerfil.Text.Equals("APOIO MONITOR"))
                {
                    mnTeleatendente.Enabled = false;
                    mnMonitor.Enabled = true;
                    mnSupervisor.Enabled = false;
                }
                else
                {
                    if (lblFrmPrincipalPerfil.Text.Equals("APOIO SUPERVISOR") || lblFrmPrincipalPerfil.Text.Equals("SUPERVISOR") || lblFrmPrincipalPerfil.Text.Equals("GERENTE"))
                    {
                        mnTeleatendente.Enabled = false;
                        mnMonitor.Enabled = false;
                        mnSupervisor.Enabled = true;
                    }
                    else
                    {
                        if (lblFrmPrincipalPerfil.Text.Equals("ADMINISTRADOR"))
                        {
                            mnTeleatendente.Enabled = true;
                            mnTeleatendente.Visible = true;
                            mnMonitor.Enabled = false;
                            mnMonitor.Visible = false;
                            mnSupervisor.Enabled = false;
                            mnSupervisor.Visible = false;
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

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCargo == null || frmCargo.IsDisposed)
            {
               frmCargo = new FrmCargo(this);
               frmCargo.MdiParent = this;
               frmCargo.Show();
            }
            
        }

        private void pretensõesDeFériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPret == null || frmPret.IsDisposed)
            {
                frmPret = new FrmPretensao(this);
                frmPret.MdiParent = this;
                frmPret.Show();
            }
        }

        private void pretensõesDeFériasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmPret == null || frmPret.IsDisposed)
            {
                frmPret = new FrmPretensao(this);
                frmPret.MdiParent = this;
                frmPret.Show();
            }
        }

        private void pretensõesDeFériasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmPret == null || frmPret.IsDisposed)
            {
                frmPret = new FrmPretensao(this);
                frmPret.MdiParent = this;
                frmPret.Show();
            }
        }
    }
}
