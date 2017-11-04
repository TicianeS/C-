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
            this.dtgCargoPesq = new System.Windows.Forms.DataGridView();
            this.dtgCargoPesqCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCargoPesqNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCargoConsultar = new System.Windows.Forms.GroupBox();
            this.btnCargoPesquisar = new System.Windows.Forms.Button();
            this.lblCargoPesqNome = new System.Windows.Forms.Label();
            this.txtCargoConsultarNome = new System.Windows.Forms.TextBox();
            this.rbtCargoListar = new System.Windows.Forms.RadioButton();
            this.rbtCargoPesquisar = new System.Windows.Forms.RadioButton();
            this.tabCargoCadastrar = new System.Windows.Forms.TabPage();
            this.btnCargoExcluir = new System.Windows.Forms.Button();
            this.btnCargoCadastrar = new System.Windows.Forms.Button();
            this.btnCargoAlterar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCargoCadastrarNome = new System.Windows.Forms.TextBox();
            this.tabCargo.SuspendLayout();
            this.tabCargoConsultar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargoPesq)).BeginInit();
            this.grpCargoConsultar.SuspendLayout();
            this.tabCargoCadastrar.SuspendLayout();
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
            this.dtgCargoPesqNome.Width = 350;
            // 
            // grpCargoConsultar
            // 
            this.grpCargoConsultar.Controls.Add(this.btnCargoPesquisar);
            this.grpCargoConsultar.Controls.Add(this.lblCargoPesqNome);
            this.grpCargoConsultar.Controls.Add(this.txtCargoConsultarNome);
            this.grpCargoConsultar.Controls.Add(this.rbtCargoListar);
            this.grpCargoConsultar.Controls.Add(this.rbtCargoPesquisar);
            this.grpCargoConsultar.Location = new System.Drawing.Point(21, 25);
            this.grpCargoConsultar.Name = "grpCargoConsultar";
            this.grpCargoConsultar.Size = new System.Drawing.Size(452, 100);
            this.grpCargoConsultar.TabIndex = 0;
            this.grpCargoConsultar.TabStop = false;
            this.grpCargoConsultar.Text = "Cargos";
            // 
            // btnCargoPesquisar
            // 
            this.btnCargoPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btnCargoPesquisar.BackgroundImage = global::CallPostgre.Properties.Resources.azul;
            this.btnCargoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargoPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargoPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnCargoPesquisar.Location = new System.Drawing.Point(328, 61);
            this.btnCargoPesquisar.Name = "btnCargoPesquisar";
            this.btnCargoPesquisar.Size = new System.Drawing.Size(109, 25);
            this.btnCargoPesquisar.TabIndex = 5;
            this.btnCargoPesquisar.Text = "Pesquisar";
            this.btnCargoPesquisar.UseVisualStyleBackColor = false;
            this.btnCargoPesquisar.Click += new System.EventHandler(this.btnCargoPesquisar_Click);
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
            // txtCargoConsultarNome
            // 
            this.txtCargoConsultarNome.Enabled = false;
            this.txtCargoConsultarNome.Location = new System.Drawing.Point(47, 64);
            this.txtCargoConsultarNome.Name = "txtCargoConsultarNome";
            this.txtCargoConsultarNome.Size = new System.Drawing.Size(248, 20);
            this.txtCargoConsultarNome.TabIndex = 4;
            // 
            // rbtCargoListar
            // 
            this.rbtCargoListar.AutoSize = true;
            this.rbtCargoListar.Checked = true;
            this.rbtCargoListar.Location = new System.Drawing.Point(167, 30);
            this.rbtCargoListar.Name = "rbtCargoListar";
            this.rbtCargoListar.Size = new System.Drawing.Size(128, 17);
            this.rbtCargoListar.TabIndex = 2;
            this.rbtCargoListar.TabStop = true;
            this.rbtCargoListar.Text = "Listar todos os cargos";
            this.rbtCargoListar.UseVisualStyleBackColor = true;
            this.rbtCargoListar.CheckedChanged += new System.EventHandler(this.rbtCargoListar_CheckedChanged);
            // 
            // rbtCargoPesquisar
            // 
            this.rbtCargoPesquisar.AutoSize = true;
            this.rbtCargoPesquisar.Location = new System.Drawing.Point(7, 30);
            this.rbtCargoPesquisar.Name = "rbtCargoPesquisar";
            this.rbtCargoPesquisar.Size = new System.Drawing.Size(71, 17);
            this.rbtCargoPesquisar.TabIndex = 1;
            this.rbtCargoPesquisar.Text = "Pesquisar";
            this.rbtCargoPesquisar.UseVisualStyleBackColor = true;
            this.rbtCargoPesquisar.CheckedChanged += new System.EventHandler(this.rbtCargoPesquisar_CheckedChanged);
            // 
            // tabCargoCadastrar
            // 
            this.tabCargoCadastrar.Controls.Add(this.btnCargoExcluir);
            this.tabCargoCadastrar.Controls.Add(this.btnCargoCadastrar);
            this.tabCargoCadastrar.Controls.Add(this.btnCargoAlterar);
            this.tabCargoCadastrar.Controls.Add(this.label1);
            this.tabCargoCadastrar.Controls.Add(this.txtCargoCadastrarNome);
            this.tabCargoCadastrar.Location = new System.Drawing.Point(4, 22);
            this.tabCargoCadastrar.Name = "tabCargoCadastrar";
            this.tabCargoCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargoCadastrar.Size = new System.Drawing.Size(496, 313);
            this.tabCargoCadastrar.TabIndex = 1;
            this.tabCargoCadastrar.Text = "Cadastrar";
            this.tabCargoCadastrar.UseVisualStyleBackColor = true;
            // 
            // btnCargoExcluir
            // 
            this.btnCargoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnCargoExcluir.BackgroundImage = global::CallPostgre.Properties.Resources.vermelho;
            this.btnCargoExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoExcluir.ForeColor = System.Drawing.Color.White;
            this.btnCargoExcluir.Location = new System.Drawing.Point(365, 85);
            this.btnCargoExcluir.Name = "btnCargoExcluir";
            this.btnCargoExcluir.Size = new System.Drawing.Size(109, 25);
            this.btnCargoExcluir.TabIndex = 4;
            this.btnCargoExcluir.Text = "Excluir";
            this.btnCargoExcluir.UseVisualStyleBackColor = false;
            this.btnCargoExcluir.Visible = false;
            // 
            // btnCargoCadastrar
            // 
            this.btnCargoCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCargoCadastrar.BackgroundImage = global::CallPostgre.Properties.Resources.verde;
            this.btnCargoCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargoCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargoCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCargoCadastrar.Location = new System.Drawing.Point(14, 85);
            this.btnCargoCadastrar.Name = "btnCargoCadastrar";
            this.btnCargoCadastrar.Size = new System.Drawing.Size(109, 25);
            this.btnCargoCadastrar.TabIndex = 2;
            this.btnCargoCadastrar.Text = "Cadastrar";
            this.btnCargoCadastrar.UseVisualStyleBackColor = false;
            this.btnCargoCadastrar.Visible = false;
            this.btnCargoCadastrar.Click += new System.EventHandler(this.btnCargoCadastrar_Click);
            // 
            // btnCargoAlterar
            // 
            this.btnCargoAlterar.BackColor = System.Drawing.Color.Transparent;
            this.btnCargoAlterar.BackgroundImage = global::CallPostgre.Properties.Resources.laranja;
            this.btnCargoAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargoAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoAlterar.ForeColor = System.Drawing.Color.White;
            this.btnCargoAlterar.Location = new System.Drawing.Point(188, 85);
            this.btnCargoAlterar.Name = "btnCargoAlterar";
            this.btnCargoAlterar.Size = new System.Drawing.Size(109, 25);
            this.btnCargoAlterar.TabIndex = 3;
            this.btnCargoAlterar.Text = "Alterar";
            this.btnCargoAlterar.UseVisualStyleBackColor = false;
            this.btnCargoAlterar.Visible = false;
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
            // txtCargoCadastrarNome
            // 
            this.txtCargoCadastrarNome.Enabled = false;
            this.txtCargoCadastrarNome.Location = new System.Drawing.Point(52, 30);
            this.txtCargoCadastrarNome.Name = "txtCargoCadastrarNome";
            this.txtCargoCadastrarNome.Size = new System.Drawing.Size(422, 20);
            this.txtCargoCadastrarNome.TabIndex = 1;
            this.txtCargoCadastrarNome.Enter += new System.EventHandler(this.txtCargoCadastrarNome_Enter);
            this.txtCargoCadastrarNome.Leave += new System.EventHandler(this.txtCargoCadastrarNome_Leave);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargoPesq)).EndInit();
            this.grpCargoConsultar.ResumeLayout(false);
            this.grpCargoConsultar.PerformLayout();
            this.tabCargoCadastrar.ResumeLayout(false);
            this.tabCargoCadastrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCargo;
        private System.Windows.Forms.TabPage tabCargoConsultar;
        private System.Windows.Forms.TabPage tabCargoCadastrar;
        private System.Windows.Forms.DataGridView dtgCargoPesq;
        private System.Windows.Forms.GroupBox grpCargoConsultar;
        private System.Windows.Forms.Label lblCargoPesqNome;
        private System.Windows.Forms.TextBox txtCargoConsultarNome;
        private System.Windows.Forms.RadioButton rbtCargoListar;
        private System.Windows.Forms.RadioButton rbtCargoPesquisar;
        private System.Windows.Forms.Button btnCargoPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCargoCadastrarNome;
        private System.Windows.Forms.Button btnCargoExcluir;
        private System.Windows.Forms.Button btnCargoCadastrar;
        private System.Windows.Forms.Button btnCargoAlterar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCargoPesqCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCargoPesqNome;
    }
}