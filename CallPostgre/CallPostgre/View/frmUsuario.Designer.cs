namespace CallPostgre.View
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.lblUsuarioRegistro = new System.Windows.Forms.Label();
            this.lblUsuarioNome = new System.Windows.Forms.Label();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioNome = new System.Windows.Forms.TextBox();
            this.txtUsuarioNovaSenha = new System.Windows.Forms.TextBox();
            this.lblUsuarioNovaSenha = new System.Windows.Forms.Label();
            this.lblUsuarioConfimarSenha = new System.Windows.Forms.Label();
            this.txtUsuarioConfirmarSenha = new System.Windows.Forms.TextBox();
            this.grpUsuarioSenha = new System.Windows.Forms.GroupBox();
            this.btnUsuarioSalvarSenha = new System.Windows.Forms.Button();
            this.btnUsuarioExcluir = new System.Windows.Forms.Button();
            this.btnUsuarioCadastrar = new System.Windows.Forms.Button();
            this.btnUsuarioAlterarSenha = new System.Windows.Forms.Button();
            this.grpUsuarioSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioRegistro
            // 
            this.lblUsuarioRegistro.AutoSize = true;
            this.lblUsuarioRegistro.Location = new System.Drawing.Point(12, 22);
            this.lblUsuarioRegistro.Name = "lblUsuarioRegistro";
            this.lblUsuarioRegistro.Size = new System.Drawing.Size(46, 13);
            this.lblUsuarioRegistro.TabIndex = 0;
            this.lblUsuarioRegistro.Text = "Registro";
            // 
            // lblUsuarioNome
            // 
            this.lblUsuarioNome.AutoSize = true;
            this.lblUsuarioNome.Location = new System.Drawing.Point(12, 70);
            this.lblUsuarioNome.Name = "lblUsuarioNome";
            this.lblUsuarioNome.Size = new System.Drawing.Size(35, 13);
            this.lblUsuarioNome.TabIndex = 2;
            this.lblUsuarioNome.Text = "Nome";
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.White;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(64, 19);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.ReadOnly = true;
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioNome
            // 
            this.txtUsuarioNome.BackColor = System.Drawing.Color.White;
            this.txtUsuarioNome.Enabled = false;
            this.txtUsuarioNome.Location = new System.Drawing.Point(64, 67);
            this.txtUsuarioNome.Name = "txtUsuarioNome";
            this.txtUsuarioNome.ReadOnly = true;
            this.txtUsuarioNome.Size = new System.Drawing.Size(436, 20);
            this.txtUsuarioNome.TabIndex = 3;
            // 
            // txtUsuarioNovaSenha
            // 
            this.txtUsuarioNovaSenha.Location = new System.Drawing.Point(6, 45);
            this.txtUsuarioNovaSenha.Name = "txtUsuarioNovaSenha";
            this.txtUsuarioNovaSenha.Size = new System.Drawing.Size(200, 20);
            this.txtUsuarioNovaSenha.TabIndex = 9;
            this.txtUsuarioNovaSenha.UseSystemPasswordChar = true;
            // 
            // lblUsuarioNovaSenha
            // 
            this.lblUsuarioNovaSenha.AutoSize = true;
            this.lblUsuarioNovaSenha.Location = new System.Drawing.Point(6, 26);
            this.lblUsuarioNovaSenha.Name = "lblUsuarioNovaSenha";
            this.lblUsuarioNovaSenha.Size = new System.Drawing.Size(67, 13);
            this.lblUsuarioNovaSenha.TabIndex = 8;
            this.lblUsuarioNovaSenha.Text = "Nova Senha";
            // 
            // lblUsuarioConfimarSenha
            // 
            this.lblUsuarioConfimarSenha.AutoSize = true;
            this.lblUsuarioConfimarSenha.Location = new System.Drawing.Point(277, 26);
            this.lblUsuarioConfimarSenha.Name = "lblUsuarioConfimarSenha";
            this.lblUsuarioConfimarSenha.Size = new System.Drawing.Size(85, 13);
            this.lblUsuarioConfimarSenha.TabIndex = 10;
            this.lblUsuarioConfimarSenha.Text = "Confirmar Senha";
            // 
            // txtUsuarioConfirmarSenha
            // 
            this.txtUsuarioConfirmarSenha.Location = new System.Drawing.Point(280, 45);
            this.txtUsuarioConfirmarSenha.Name = "txtUsuarioConfirmarSenha";
            this.txtUsuarioConfirmarSenha.Size = new System.Drawing.Size(200, 20);
            this.txtUsuarioConfirmarSenha.TabIndex = 11;
            this.txtUsuarioConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // grpUsuarioSenha
            // 
            this.grpUsuarioSenha.Controls.Add(this.btnUsuarioSalvarSenha);
            this.grpUsuarioSenha.Controls.Add(this.lblUsuarioNovaSenha);
            this.grpUsuarioSenha.Controls.Add(this.txtUsuarioConfirmarSenha);
            this.grpUsuarioSenha.Controls.Add(this.txtUsuarioNovaSenha);
            this.grpUsuarioSenha.Controls.Add(this.lblUsuarioConfimarSenha);
            this.grpUsuarioSenha.Location = new System.Drawing.Point(12, 170);
            this.grpUsuarioSenha.Name = "grpUsuarioSenha";
            this.grpUsuarioSenha.Size = new System.Drawing.Size(488, 123);
            this.grpUsuarioSenha.TabIndex = 7;
            this.grpUsuarioSenha.TabStop = false;
            this.grpUsuarioSenha.Text = "Senha";
            this.grpUsuarioSenha.Visible = false;
            // 
            // btnUsuarioSalvarSenha
            // 
            this.btnUsuarioSalvarSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioSalvarSenha.BackgroundImage = global::CallPostgre.Properties.Resources.verde;
            this.btnUsuarioSalvarSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioSalvarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioSalvarSenha.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioSalvarSenha.Location = new System.Drawing.Point(189, 87);
            this.btnUsuarioSalvarSenha.Name = "btnUsuarioSalvarSenha";
            this.btnUsuarioSalvarSenha.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioSalvarSenha.TabIndex = 12;
            this.btnUsuarioSalvarSenha.Text = "Salvar";
            this.btnUsuarioSalvarSenha.UseVisualStyleBackColor = false;
            // 
            // btnUsuarioExcluir
            // 
            this.btnUsuarioExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioExcluir.BackgroundImage = global::CallPostgre.Properties.Resources.vermelho;
            this.btnUsuarioExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioExcluir.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioExcluir.Location = new System.Drawing.Point(391, 117);
            this.btnUsuarioExcluir.Name = "btnUsuarioExcluir";
            this.btnUsuarioExcluir.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioExcluir.TabIndex = 6;
            this.btnUsuarioExcluir.Text = "Excluir Usuário";
            this.btnUsuarioExcluir.UseVisualStyleBackColor = false;
            // 
            // btnUsuarioCadastrar
            // 
            this.btnUsuarioCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioCadastrar.BackgroundImage = global::CallPostgre.Properties.Resources.azul;
            this.btnUsuarioCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarioCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioCadastrar.Location = new System.Drawing.Point(12, 117);
            this.btnUsuarioCadastrar.Name = "btnUsuarioCadastrar";
            this.btnUsuarioCadastrar.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioCadastrar.TabIndex = 4;
            this.btnUsuarioCadastrar.Text = "Cadastrar Usuário";
            this.btnUsuarioCadastrar.UseVisualStyleBackColor = false;
            // 
            // btnUsuarioAlterarSenha
            // 
            this.btnUsuarioAlterarSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioAlterarSenha.BackgroundImage = global::CallPostgre.Properties.Resources.laranja;
            this.btnUsuarioAlterarSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioAlterarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioAlterarSenha.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioAlterarSenha.Location = new System.Drawing.Point(201, 117);
            this.btnUsuarioAlterarSenha.Name = "btnUsuarioAlterarSenha";
            this.btnUsuarioAlterarSenha.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioAlterarSenha.TabIndex = 5;
            this.btnUsuarioAlterarSenha.Text = "Alterar Senha";
            this.btnUsuarioAlterarSenha.UseVisualStyleBackColor = false;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 303);
            this.Controls.Add(this.grpUsuarioSenha);
            this.Controls.Add(this.btnUsuarioExcluir);
            this.Controls.Add(this.btnUsuarioCadastrar);
            this.Controls.Add(this.btnUsuarioAlterarSenha);
            this.Controls.Add(this.txtUsuarioNome);
            this.Controls.Add(this.txtUsuarioRegistro);
            this.Controls.Add(this.lblUsuarioNome);
            this.Controls.Add(this.lblUsuarioRegistro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmUsuario";
            this.Text = "Acesso ao Sistema";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.grpUsuarioSenha.ResumeLayout(false);
            this.grpUsuarioSenha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioRegistro;
        private System.Windows.Forms.Label lblUsuarioNome;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioNome;
        private System.Windows.Forms.Button btnUsuarioAlterarSenha;
        private System.Windows.Forms.Button btnUsuarioCadastrar;
        private System.Windows.Forms.Button btnUsuarioExcluir;
        private System.Windows.Forms.TextBox txtUsuarioNovaSenha;
        private System.Windows.Forms.Label lblUsuarioNovaSenha;
        private System.Windows.Forms.Label lblUsuarioConfimarSenha;
        private System.Windows.Forms.TextBox txtUsuarioConfirmarSenha;
        private System.Windows.Forms.GroupBox grpUsuarioSenha;
        private System.Windows.Forms.Button btnUsuarioSalvarSenha;
    }
}