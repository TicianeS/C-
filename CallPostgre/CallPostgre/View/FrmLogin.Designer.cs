namespace CallPostgre
{
    partial class FrmLogin
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
            this.lblLoginRegistro = new System.Windows.Forms.Label();
            this.lblLoginSenha = new System.Windows.Forms.Label();
            this.mskLoginSenha = new System.Windows.Forms.MaskedTextBox();
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.btnLoginEntrar = new System.Windows.Forms.Button();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.txtLoginRegistro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoginRegistro
            // 
            this.lblLoginRegistro.AutoSize = true;
            this.lblLoginRegistro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginRegistro.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginRegistro.Location = new System.Drawing.Point(112, 26);
            this.lblLoginRegistro.Name = "lblLoginRegistro";
            this.lblLoginRegistro.Size = new System.Drawing.Size(60, 16);
            this.lblLoginRegistro.TabIndex = 0;
            this.lblLoginRegistro.Text = "Registro";
            // 
            // lblLoginSenha
            // 
            this.lblLoginSenha.AutoSize = true;
            this.lblLoginSenha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginSenha.Location = new System.Drawing.Point(117, 92);
            this.lblLoginSenha.Name = "lblLoginSenha";
            this.lblLoginSenha.Size = new System.Drawing.Size(49, 16);
            this.lblLoginSenha.TabIndex = 2;
            this.lblLoginSenha.Text = "Senha";
            // 
            // mskLoginSenha
            // 
            this.mskLoginSenha.Location = new System.Drawing.Point(86, 116);
            this.mskLoginSenha.Name = "mskLoginSenha";
            this.mskLoginSenha.PasswordChar = '*';
            this.mskLoginSenha.PromptChar = ' ';
            this.mskLoginSenha.Size = new System.Drawing.Size(110, 20);
            this.mskLoginSenha.TabIndex = 3;
            this.mskLoginSenha.UseSystemPasswordChar = true;
            // 
            // linkLogin
            // 
            this.linkLogin.AutoSize = true;
            this.linkLogin.LinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLogin.Location = new System.Drawing.Point(13, 210);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(108, 13);
            this.linkLogin.TabIndex = 5;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Esqueci minha senha";
            this.linkLogin.Click += new System.EventHandler(this.linkLogin_Click);
            // 
            // btnLoginEntrar
            // 
            this.btnLoginEntrar.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginEntrar.BackgroundImage = global::CallPostgre.Properties.Resources.verde;
            this.btnLoginEntrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoginEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginEntrar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginEntrar.ForeColor = System.Drawing.Color.White;
            this.btnLoginEntrar.Location = new System.Drawing.Point(95, 158);
            this.btnLoginEntrar.Name = "btnLoginEntrar";
            this.btnLoginEntrar.Size = new System.Drawing.Size(94, 27);
            this.btnLoginEntrar.TabIndex = 4;
            this.btnLoginEntrar.Text = "Entrar";
            this.btnLoginEntrar.UseVisualStyleBackColor = false;
            this.btnLoginEntrar.Click += new System.EventHandler(this.btnLoginEntrar_Click);
            // 
            // picLogin
            // 
            this.picLogin.BackgroundImage = global::CallPostgre.Properties.Resources.copel;
            this.picLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogin.Location = new System.Drawing.Point(181, 201);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(100, 37);
            this.picLogin.TabIndex = 6;
            this.picLogin.TabStop = false;
            // 
            // txtLoginRegistro
            // 
            this.txtLoginRegistro.Location = new System.Drawing.Point(86, 48);
            this.txtLoginRegistro.MaxLength = 6;
            this.txtLoginRegistro.Name = "txtLoginRegistro";
            this.txtLoginRegistro.Size = new System.Drawing.Size(110, 20);
            this.txtLoginRegistro.TabIndex = 1;
            this.txtLoginRegistro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginRegistro_KeyPress);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 252);
            this.Controls.Add(this.txtLoginRegistro);
            this.Controls.Add(this.picLogin);
            this.Controls.Add(this.linkLogin);
            this.Controls.Add(this.btnLoginEntrar);
            this.Controls.Add(this.mskLoginSenha);
            this.Controls.Add(this.lblLoginSenha);
            this.Controls.Add(this.lblLoginRegistro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Férias VATD";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginRegistro;
        private System.Windows.Forms.Label lblLoginSenha;
        private System.Windows.Forms.MaskedTextBox mskLoginSenha;
        private System.Windows.Forms.LinkLabel linkLogin;
        private System.Windows.Forms.PictureBox picLogin;
        public System.Windows.Forms.Button btnLoginEntrar;
        public System.Windows.Forms.TextBox txtLoginRegistro;
    }
}

