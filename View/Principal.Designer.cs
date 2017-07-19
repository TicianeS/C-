namespace Callcenter.View
{
    partial class frmPrincipal
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
            this.mnPCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLoginUsu = new System.Windows.Forms.Label();
            this.lblTipoUsu = new System.Windows.Forms.Label();
            this.lblFuncID = new System.Windows.Forms.Label();
            this.mnPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPCadastros,
            this.mnPRelatorios});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(955, 24);
            this.mnPrincipal.TabIndex = 0;
            this.mnPrincipal.Text = "menuStrip1";
            // 
            // mnPCadastros
            // 
            this.mnPCadastros.Name = "mnPCadastros";
            this.mnPCadastros.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.mnPCadastros.Size = new System.Drawing.Size(71, 20);
            this.mnPCadastros.Text = "&Cadastros";
            this.mnPCadastros.Click += new System.EventHandler(this.mnPCadastros_Click);
            // 
            // mnPRelatorios
            // 
            this.mnPRelatorios.Name = "mnPRelatorios";
            this.mnPRelatorios.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnPRelatorios.Size = new System.Drawing.Size(71, 20);
            this.mnPRelatorios.Text = "&Relatórios";
            this.mnPRelatorios.Click += new System.EventHandler(this.mnPRelatorios_Click);
            // 
            // lblLoginUsu
            // 
            this.lblLoginUsu.AutoSize = true;
            this.lblLoginUsu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoginUsu.Location = new System.Drawing.Point(704, 9);
            this.lblLoginUsu.Name = "lblLoginUsu";
            this.lblLoginUsu.Size = new System.Drawing.Size(0, 13);
            this.lblLoginUsu.TabIndex = 2;
            // 
            // lblTipoUsu
            // 
            this.lblTipoUsu.AutoSize = true;
            this.lblTipoUsu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTipoUsu.Location = new System.Drawing.Point(851, 9);
            this.lblTipoUsu.Name = "lblTipoUsu";
            this.lblTipoUsu.Size = new System.Drawing.Size(0, 13);
            this.lblTipoUsu.TabIndex = 3;
            // 
            // lblFuncID
            // 
            this.lblFuncID.AutoSize = true;
            this.lblFuncID.Location = new System.Drawing.Point(844, 76);
            this.lblFuncID.Name = "lblFuncID";
            this.lblFuncID.Size = new System.Drawing.Size(0, 13);
            this.lblFuncID.TabIndex = 5;
            this.lblFuncID.Visible = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(955, 487);
            this.Controls.Add(this.lblFuncID);
            this.Controls.Add(this.lblTipoUsu);
            this.Controls.Add(this.lblLoginUsu);
            this.Controls.Add(this.mnPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Callcenter";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnPCadastros;
        private System.Windows.Forms.ToolStripMenuItem mnPRelatorios;
        private System.Windows.Forms.Label lblLoginUsu;
        public System.Windows.Forms.Label lblFuncID;
        public System.Windows.Forms.Label lblTipoUsu;
    }
}