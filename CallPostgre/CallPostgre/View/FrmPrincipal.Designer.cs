namespace CallPostgre.View
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnTeleatendente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTeleAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTeleAcessoAlterarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.fériasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fériasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pretensõesDeFériasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarFériasAutorizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMoniAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMoniAcessoGerUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosPessoaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fériasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pretensõesDeFériasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarFériasAutorizadasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSupervisor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSuperAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSuperAcessoGerUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosPessoaisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fériasToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pretensõesDeFériasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarFériasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarVagasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarDatasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSuperDepCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFrmPrincipalCargo = new System.Windows.Forms.Label();
            this.lblFrmPrincipalNome = new System.Windows.Forms.Label();
            this.lblFrmPrincipalRegistro = new System.Windows.Forms.Label();
            this.mnPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTeleatendente,
            this.mnMonitor,
            this.mnSupervisor,
            this.mnSair});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(1047, 24);
            this.mnPrincipal.TabIndex = 1;
            this.mnPrincipal.Text = "menuStrip1";
            // 
            // mnTeleatendente
            // 
            this.mnTeleatendente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTeleAcesso,
            this.fériasToolStripMenuItem,
            this.fériasToolStripMenuItem1});
            this.mnTeleatendente.Name = "mnTeleatendente";
            this.mnTeleatendente.Size = new System.Drawing.Size(59, 20);
            this.mnTeleatendente.Text = "Opções";
            // 
            // mnTeleAcesso
            // 
            this.mnTeleAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTeleAcessoAlterarSenha});
            this.mnTeleAcesso.Name = "mnTeleAcesso";
            this.mnTeleAcesso.Size = new System.Drawing.Size(170, 22);
            this.mnTeleAcesso.Text = "Acesso ao sistema";
            // 
            // mnTeleAcessoAlterarSenha
            // 
            this.mnTeleAcessoAlterarSenha.Name = "mnTeleAcessoAlterarSenha";
            this.mnTeleAcessoAlterarSenha.Size = new System.Drawing.Size(143, 22);
            this.mnTeleAcessoAlterarSenha.Text = "Alterar senha";
            this.mnTeleAcessoAlterarSenha.Click += new System.EventHandler(this.mnTeleAcessoAlterarSenha_Click);
            // 
            // fériasToolStripMenuItem
            // 
            this.fériasToolStripMenuItem.Name = "fériasToolStripMenuItem";
            this.fériasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.fériasToolStripMenuItem.Text = "Dados pessoais";
            this.fériasToolStripMenuItem.Click += new System.EventHandler(this.fériasToolStripMenuItem_Click);
            // 
            // fériasToolStripMenuItem1
            // 
            this.fériasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretensõesDeFériasToolStripMenuItem,
            this.consultarFériasAutorizadasToolStripMenuItem});
            this.fériasToolStripMenuItem1.Name = "fériasToolStripMenuItem1";
            this.fériasToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.fériasToolStripMenuItem1.Text = "Férias";
            // 
            // pretensõesDeFériasToolStripMenuItem
            // 
            this.pretensõesDeFériasToolStripMenuItem.Name = "pretensõesDeFériasToolStripMenuItem";
            this.pretensõesDeFériasToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.pretensõesDeFériasToolStripMenuItem.Text = "Pretensões de férias";
            this.pretensõesDeFériasToolStripMenuItem.Click += new System.EventHandler(this.pretensõesDeFériasToolStripMenuItem_Click);
            // 
            // consultarFériasAutorizadasToolStripMenuItem
            // 
            this.consultarFériasAutorizadasToolStripMenuItem.Name = "consultarFériasAutorizadasToolStripMenuItem";
            this.consultarFériasAutorizadasToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.consultarFériasAutorizadasToolStripMenuItem.Text = "Consultar férias autorizadas";
            // 
            // mnMonitor
            // 
            this.mnMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMoniAcesso,
            this.dadosPessoaisToolStripMenuItem,
            this.fériasToolStripMenuItem2,
            this.timesToolStripMenuItem});
            this.mnMonitor.Name = "mnMonitor";
            this.mnMonitor.Size = new System.Drawing.Size(59, 20);
            this.mnMonitor.Text = "Opções";
            // 
            // mnMoniAcesso
            // 
            this.mnMoniAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMoniAcessoGerUsuario});
            this.mnMoniAcesso.Name = "mnMoniAcesso";
            this.mnMoniAcesso.Size = new System.Drawing.Size(170, 22);
            this.mnMoniAcesso.Text = "Acesso ao sistema";
            // 
            // mnMoniAcessoGerUsuario
            // 
            this.mnMoniAcessoGerUsuario.Name = "mnMoniAcessoGerUsuario";
            this.mnMoniAcessoGerUsuario.Size = new System.Drawing.Size(172, 22);
            this.mnMoniAcessoGerUsuario.Text = "Gerenciar Usuários";
            // 
            // dadosPessoaisToolStripMenuItem
            // 
            this.dadosPessoaisToolStripMenuItem.Name = "dadosPessoaisToolStripMenuItem";
            this.dadosPessoaisToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dadosPessoaisToolStripMenuItem.Text = "Funcionários";
            // 
            // fériasToolStripMenuItem2
            // 
            this.fériasToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretensõesDeFériasToolStripMenuItem1,
            this.consultarFériasAutorizadasToolStripMenuItem1});
            this.fériasToolStripMenuItem2.Name = "fériasToolStripMenuItem2";
            this.fériasToolStripMenuItem2.Size = new System.Drawing.Size(170, 22);
            this.fériasToolStripMenuItem2.Text = "Férias";
            // 
            // pretensõesDeFériasToolStripMenuItem1
            // 
            this.pretensõesDeFériasToolStripMenuItem1.Name = "pretensõesDeFériasToolStripMenuItem1";
            this.pretensõesDeFériasToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.pretensõesDeFériasToolStripMenuItem1.Text = "Pretensões de férias";
            this.pretensõesDeFériasToolStripMenuItem1.Click += new System.EventHandler(this.pretensõesDeFériasToolStripMenuItem1_Click);
            // 
            // consultarFériasAutorizadasToolStripMenuItem1
            // 
            this.consultarFériasAutorizadasToolStripMenuItem1.Name = "consultarFériasAutorizadasToolStripMenuItem1";
            this.consultarFériasAutorizadasToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.consultarFériasAutorizadasToolStripMenuItem1.Text = "Consultar férias autorizadas";
            // 
            // timesToolStripMenuItem
            // 
            this.timesToolStripMenuItem.Name = "timesToolStripMenuItem";
            this.timesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.timesToolStripMenuItem.Text = "Times";
            // 
            // mnSupervisor
            // 
            this.mnSupervisor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSuperAcesso,
            this.dadosPessoaisToolStripMenuItem1,
            this.fériasToolStripMenuItem3,
            this.timesToolStripMenuItem1,
            this.departamentoToolStripMenuItem});
            this.mnSupervisor.Name = "mnSupervisor";
            this.mnSupervisor.Size = new System.Drawing.Size(59, 20);
            this.mnSupervisor.Text = "Opções";
            // 
            // mnSuperAcesso
            // 
            this.mnSuperAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSuperAcessoGerUsuario});
            this.mnSuperAcesso.Name = "mnSuperAcesso";
            this.mnSuperAcesso.Size = new System.Drawing.Size(170, 22);
            this.mnSuperAcesso.Text = "Acesso ao sistema";
            // 
            // mnSuperAcessoGerUsuario
            // 
            this.mnSuperAcessoGerUsuario.Name = "mnSuperAcessoGerUsuario";
            this.mnSuperAcessoGerUsuario.Size = new System.Drawing.Size(172, 22);
            this.mnSuperAcessoGerUsuario.Text = "Gerenciar Usuários";
            // 
            // dadosPessoaisToolStripMenuItem1
            // 
            this.dadosPessoaisToolStripMenuItem1.Name = "dadosPessoaisToolStripMenuItem1";
            this.dadosPessoaisToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.dadosPessoaisToolStripMenuItem1.Text = "Funcionários";
            // 
            // fériasToolStripMenuItem3
            // 
            this.fériasToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretensõesDeFériasToolStripMenuItem2,
            this.gerenciarFériasToolStripMenuItem,
            this.gerenciarToolStripMenuItem,
            this.datasToolStripMenuItem});
            this.fériasToolStripMenuItem3.Name = "fériasToolStripMenuItem3";
            this.fériasToolStripMenuItem3.Size = new System.Drawing.Size(170, 22);
            this.fériasToolStripMenuItem3.Text = "Férias";
            // 
            // pretensõesDeFériasToolStripMenuItem2
            // 
            this.pretensõesDeFériasToolStripMenuItem2.Name = "pretensõesDeFériasToolStripMenuItem2";
            this.pretensõesDeFériasToolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
            this.pretensõesDeFériasToolStripMenuItem2.Text = "Pretensões de férias";
            this.pretensõesDeFériasToolStripMenuItem2.Click += new System.EventHandler(this.pretensõesDeFériasToolStripMenuItem2_Click);
            // 
            // gerenciarFériasToolStripMenuItem
            // 
            this.gerenciarFériasToolStripMenuItem.Name = "gerenciarFériasToolStripMenuItem";
            this.gerenciarFériasToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.gerenciarFériasToolStripMenuItem.Text = "Férias";
            // 
            // gerenciarToolStripMenuItem
            // 
            this.gerenciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarVagasToolStripMenuItem});
            this.gerenciarToolStripMenuItem.Name = "gerenciarToolStripMenuItem";
            this.gerenciarToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.gerenciarToolStripMenuItem.Text = "Vagas";
            // 
            // gerenciarVagasToolStripMenuItem
            // 
            this.gerenciarVagasToolStripMenuItem.Name = "gerenciarVagasToolStripMenuItem";
            this.gerenciarVagasToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.gerenciarVagasToolStripMenuItem.Text = "Gerenciar vagas";
            // 
            // datasToolStripMenuItem
            // 
            this.datasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarDatasToolStripMenuItem});
            this.datasToolStripMenuItem.Name = "datasToolStripMenuItem";
            this.datasToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.datasToolStripMenuItem.Text = "Datas";
            // 
            // gerenciarDatasToolStripMenuItem
            // 
            this.gerenciarDatasToolStripMenuItem.Name = "gerenciarDatasToolStripMenuItem";
            this.gerenciarDatasToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.gerenciarDatasToolStripMenuItem.Text = "Gerenciar datas ";
            // 
            // timesToolStripMenuItem1
            // 
            this.timesToolStripMenuItem1.Name = "timesToolStripMenuItem1";
            this.timesToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.timesToolStripMenuItem1.Text = "Times";
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divisãoToolStripMenuItem,
            this.mnSuperDepCargos});
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            // 
            // divisãoToolStripMenuItem
            // 
            this.divisãoToolStripMenuItem.Name = "divisãoToolStripMenuItem";
            this.divisãoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.divisãoToolStripMenuItem.Text = "Divisões";
            // 
            // mnSuperDepCargos
            // 
            this.mnSuperDepCargos.Name = "mnSuperDepCargos";
            this.mnSuperDepCargos.Size = new System.Drawing.Size(117, 22);
            this.mnSuperDepCargos.Text = "Cargos";
            this.mnSuperDepCargos.Click += new System.EventHandler(this.cargosToolStripMenuItem_Click);
            // 
            // mnSair
            // 
            this.mnSair.Name = "mnSair";
            this.mnSair.Size = new System.Drawing.Size(38, 20);
            this.mnSair.Text = "Sair";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // lblFrmPrincipalCargo
            // 
            this.lblFrmPrincipalCargo.AutoSize = true;
            this.lblFrmPrincipalCargo.Location = new System.Drawing.Point(469, 7);
            this.lblFrmPrincipalCargo.Name = "lblFrmPrincipalCargo";
            this.lblFrmPrincipalCargo.Size = new System.Drawing.Size(44, 13);
            this.lblFrmPrincipalCargo.TabIndex = 2;
            this.lblFrmPrincipalCargo.Text = "PERFIL";
            this.lblFrmPrincipalCargo.Visible = false;
            // 
            // lblFrmPrincipalNome
            // 
            this.lblFrmPrincipalNome.AutoSize = true;
            this.lblFrmPrincipalNome.BackColor = System.Drawing.SystemColors.Control;
            this.lblFrmPrincipalNome.Location = new System.Drawing.Point(666, 7);
            this.lblFrmPrincipalNome.Name = "lblFrmPrincipalNome";
            this.lblFrmPrincipalNome.Size = new System.Drawing.Size(35, 13);
            this.lblFrmPrincipalNome.TabIndex = 3;
            this.lblFrmPrincipalNome.Text = "Nome";
            // 
            // lblFrmPrincipalRegistro
            // 
            this.lblFrmPrincipalRegistro.AutoSize = true;
            this.lblFrmPrincipalRegistro.Location = new System.Drawing.Point(405, 7);
            this.lblFrmPrincipalRegistro.Name = "lblFrmPrincipalRegistro";
            this.lblFrmPrincipalRegistro.Size = new System.Drawing.Size(31, 13);
            this.lblFrmPrincipalRegistro.TabIndex = 4;
            this.lblFrmPrincipalRegistro.Text = "0000";
            this.lblFrmPrincipalRegistro.Visible = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 611);
            this.Controls.Add(this.lblFrmPrincipalRegistro);
            this.Controls.Add(this.lblFrmPrincipalNome);
            this.Controls.Add(this.lblFrmPrincipalCargo);
            this.Controls.Add(this.mnPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnPrincipal;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnTeleatendente;
        private System.Windows.Forms.ToolStripMenuItem mnTeleAcesso;
        private System.Windows.Forms.ToolStripMenuItem fériasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnMonitor;
        private System.Windows.Forms.ToolStripMenuItem mnSupervisor;
        private System.Windows.Forms.ToolStripMenuItem mnTeleAcessoAlterarSenha;
        private System.Windows.Forms.ToolStripMenuItem fériasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pretensõesDeFériasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarFériasAutorizadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnMoniAcesso;
        private System.Windows.Forms.ToolStripMenuItem mnMoniAcessoGerUsuario;
        private System.Windows.Forms.ToolStripMenuItem dadosPessoaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fériasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pretensõesDeFériasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarFériasAutorizadasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnSuperAcesso;
        private System.Windows.Forms.ToolStripMenuItem mnSuperAcessoGerUsuario;
        private System.Windows.Forms.ToolStripMenuItem dadosPessoaisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fériasToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pretensõesDeFériasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem gerenciarFériasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnSair;
        public System.Windows.Forms.Label lblFrmPrincipalRegistro;
        public System.Windows.Forms.Label lblFrmPrincipalCargo;
        public System.Windows.Forms.Label lblFrmPrincipalNome;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnSuperDepCargos;
        private System.Windows.Forms.ToolStripMenuItem gerenciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarVagasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarDatasToolStripMenuItem;
    }
}