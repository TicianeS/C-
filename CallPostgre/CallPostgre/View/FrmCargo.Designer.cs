namespace CallPostgre.View
{
    partial class FrmCargo
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
            this.tabCargo = new System.Windows.Forms.TabControl();
            this.tabCargoConsultar = new System.Windows.Forms.TabPage();
            this.tabCargoCadastrar = new System.Windows.Forms.TabPage();
            this.grpCargoConsultar = new System.Windows.Forms.GroupBox();
            this.rbtCargoPesquisar = new System.Windows.Forms.RadioButton();
            this.rbtCargoListar = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCargoPesqNome = new System.Windows.Forms.Label();
            this.dtgCargoPesq = new System.Windows.Forms.DataGridView();
            this.btnUsuarioCadastrar = new System.Windows.Forms.Button();
            this.dtgCargoPesqCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCargoPesqNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnUsuarioExcluir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUsuarioAlterarSenha = new System.Windows.Forms.Button();
            this.tabCargo.SuspendLayout();
            this.tabCargoConsultar.SuspendLayout();
            this.tabCargoCadastrar.SuspendLayout();
            this.grpCargoConsultar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargoPesq)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCargo
            // 
            this.tabCargo.Controls.Add(this.tabCargoConsultar);
            this.tabCargo.Controls.Add(this.tabCargoCadastrar);
            this.tabCargo.Location = new System.Drawing.Point(12, 20);
            this.tabCargo.Name = "tabCargo";
            this.tabCargo.SelectedIndex = 0;
            this.tabCargo.Size = new System.Drawing.Size(504, 339);
            this.tabCargo.TabIndex = 1;
            // 
            // tabCargoConsultar
            // 
            this.tabCargoConsultar.Controls.Add(this.dtgCargoPesq);
            this.tabCargoConsultar.Controls.Add(this.grpCargoConsultar);
            this.tabCargoConsultar.Location = new System.Drawing.Point(4, 22);
            this.tabCargoConsultar.Name = "tabCargoConsultar";
            this.tabCargoConsultar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargoConsultar.Size = new System.Drawing.Size(496, 313);
            this.tabCargoConsultar.TabIndex = 0;
            this.tabCargoConsultar.Text = "Consultar";
            this.tabCargoConsultar.UseVisualStyleBackColor = true;
            // 
            // tabCargoCadastrar
            // 
            this.tabCargoCadastrar.Controls.Add(this.btnUsuarioExcluir);
            this.tabCargoCadastrar.Controls.Add(this.button1);
            this.tabCargoCadastrar.Controls.Add(this.btnUsuarioAlterarSenha);
            this.tabCargoCadastrar.Controls.Add(this.label1);
            this.tabCargoCadastrar.Controls.Add(this.textBox2);
            this.tabCargoCadastrar.Location = new System.Drawing.Point(4, 22);
            this.tabCargoCadastrar.Name = "tabCargoCadastrar";
            this.tabCargoCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargoCadastrar.Size = new System.Drawing.Size(496, 313);
            this.tabCargoCadastrar.TabIndex = 1;
            this.tabCargoCadastrar.Text = "Cadastrar";
            this.tabCargoCadastrar.UseVisualStyleBackColor = true;
            // 
            // grpCargoConsultar
            // 
            this.grpCargoConsultar.Controls.Add(this.btnUsuarioCadastrar);
            this.grpCargoConsultar.Controls.Add(this.lblCargoPesqNome);
            this.grpCargoConsultar.Controls.Add(this.textBox1);
            this.grpCargoConsultar.Controls.Add(this.rbtCargoListar);
            this.grpCargoConsultar.Controls.Add(this.rbtCargoPesquisar);
            this.grpCargoConsultar.Location = new System.Drawing.Point(21, 25);
            this.grpCargoConsultar.Name = "grpCargoConsultar";
            this.grpCargoConsultar.Size = new System.Drawing.Size(452, 100);
            this.grpCargoConsultar.TabIndex = 0;
            this.grpCargoConsultar.TabStop = false;
            this.grpCargoConsultar.Text = "Cargos";
            // 
            // rbtCargoPesquisar
            // 
            this.rbtCargoPesquisar.AutoSize = true;
            this.rbtCargoPesquisar.Location = new System.Drawing.Point(7, 30);
            this.rbtCargoPesquisar.Name = "rbtCargoPesquisar";
            this.rbtCargoPesquisar.Size = new System.Drawing.Size(71, 17);
            this.rbtCargoPesquisar.TabIndex = 1;
            this.rbtCargoPesquisar.TabStop = true;
            this.rbtCargoPesquisar.Text = "Pesquisar";
            this.rbtCargoPesquisar.UseVisualStyleBackColor = true;
            // 
            // rbtCargoListar
            // 
            this.rbtCargoListar.AutoSize = true;
            this.rbtCargoListar.Location = new System.Drawing.Point(167, 30);
            this.rbtCargoListar.Name = "rbtCargoListar";
            this.rbtCargoListar.Size = new System.Drawing.Size(128, 17);
            this.rbtCargoListar.TabIndex = 2;
            this.rbtCargoListar.TabStop = true;
            this.rbtCargoListar.Text = "Listar todos os cargos";
            this.rbtCargoListar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(47, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 4;
            // 
            // lblCargoPesqNome
            // 
            this.lblCargoPesqNome.AutoSize = true;
            this.lblCargoPesqNome.Location = new System.Drawing.Point(6, 67);
            this.lblCargoPesqNome.Name = "lblCargoPesqNome";
            this.lblCargoPesqNome.Size = new System.Drawing.Size(35, 13);
            this.lblCargoPesqNome.TabIndex = 3;
            this.lblCargoPesqNome.Text = "Nome";
            // 
            // dtgCargoPesq
            // 
            this.dtgCargoPesq.AllowUserToAddRows = false;
            this.dtgCargoPesq.AllowUserToDeleteRows = false;
            this.dtgCargoPesq.AllowUserToOrderColumns = true;
            this.dtgCargoPesq.AllowUserToResizeColumns = false;
            this.dtgCargoPesq.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgCargoPesq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCargoPesq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgCargoPesqCod,
            this.dtgCargoPesqNome});
            this.dtgCargoPesq.Location = new System.Drawing.Point(21, 144);
            this.dtgCargoPesq.Name = "dtgCargoPesq";
            this.dtgCargoPesq.Size = new System.Drawing.Size(452, 150);
            this.dtgCargoPesq.TabIndex = 6;
            // 
            // btnUsuarioCadastrar
            // 
            this.btnUsuarioCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioCadastrar.BackgroundImage = global::CallPostgre.Properties.Resources.azul;
            this.btnUsuarioCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarioCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioCadastrar.Location = new System.Drawing.Point(328, 61);
            this.btnUsuarioCadastrar.Name = "btnUsuarioCadastrar";
            this.btnUsuarioCadastrar.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioCadastrar.TabIndex = 5;
            this.btnUsuarioCadastrar.Text = "Pesquisar";
            this.btnUsuarioCadastrar.UseVisualStyleBackColor = false;
            // 
            // dtgCargoPesqCod
            // 
            this.dtgCargoPesqCod.HeaderText = "Código";
            this.dtgCargoPesqCod.Name = "dtgCargoPesqCod";
            this.dtgCargoPesqCod.Width = 50;
            // 
            // dtgCargoPesqNome
            // 
            this.dtgCargoPesqNome.HeaderText = "Nome";
            this.dtgCargoPesqNome.Name = "dtgCargoPesqNome";
            this.dtgCargoPesqNome.Width = 355;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(52, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(422, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btnUsuarioExcluir
            // 
            this.btnUsuarioExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioExcluir.BackgroundImage = global::CallPostgre.Properties.Resources.vermelho;
            this.btnUsuarioExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioExcluir.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioExcluir.Location = new System.Drawing.Point(365, 85);
            this.btnUsuarioExcluir.Name = "btnUsuarioExcluir";
            this.btnUsuarioExcluir.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioExcluir.TabIndex = 4;
            this.btnUsuarioExcluir.Text = "Excluir";
            this.btnUsuarioExcluir.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::CallPostgre.Properties.Resources.verde;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cadastrar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnUsuarioAlterarSenha
            // 
            this.btnUsuarioAlterarSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarioAlterarSenha.BackgroundImage = global::CallPostgre.Properties.Resources.laranja;
            this.btnUsuarioAlterarSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarioAlterarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioAlterarSenha.ForeColor = System.Drawing.Color.White;
            this.btnUsuarioAlterarSenha.Location = new System.Drawing.Point(188, 85);
            this.btnUsuarioAlterarSenha.Name = "btnUsuarioAlterarSenha";
            this.btnUsuarioAlterarSenha.Size = new System.Drawing.Size(109, 25);
            this.btnUsuarioAlterarSenha.TabIndex = 3;
            this.btnUsuarioAlterarSenha.Text = "Alterar";
            this.btnUsuarioAlterarSenha.UseVisualStyleBackColor = false;
            // 
            // FrmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 378);
            this.Controls.Add(this.tabCargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos";
            this.tabCargo.ResumeLayout(false);
            this.tabCargoConsultar.ResumeLayout(false);
            this.tabCargoCadastrar.ResumeLayout(false);
            this.tabCargoCadastrar.PerformLayout();
            this.grpCargoConsultar.ResumeLayout(false);
            this.grpCargoConsultar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargoPesq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCargo;
        private System.Windows.Forms.TabPage tabCargoConsultar;
        private System.Windows.Forms.TabPage tabCargoCadastrar;
        private System.Windows.Forms.DataGridView dtgCargoPesq;
        private System.Windows.Forms.GroupBox grpCargoConsultar;
        private System.Windows.Forms.Label lblCargoPesqNome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbtCargoListar;
        private System.Windows.Forms.RadioButton rbtCargoPesquisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCargoPesqCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCargoPesqNome;
        private System.Windows.Forms.Button btnUsuarioCadastrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnUsuarioExcluir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUsuarioAlterarSenha;
    }
}