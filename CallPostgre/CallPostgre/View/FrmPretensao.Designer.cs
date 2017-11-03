namespace CallPostgre.View
{
    partial class FrmPretensao
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
            this.txtPretensaoRegistro = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblPretensaoRegistro = new System.Windows.Forms.Label();
            this.lblPretensaoNome = new System.Windows.Forms.Label();
            this.lblPretensaoTurno = new System.Windows.Forms.Label();
            this.lblPretensaoAno = new System.Windows.Forms.Label();
            this.lblPretensaoDtInicio = new System.Windows.Forms.Label();
            this.lblPretensaoDtFinal = new System.Windows.Forms.Label();
            this.cboPretensaoAno = new System.Windows.Forms.ComboBox();
            this.txtPretensaoDtInicio = new System.Windows.Forms.TextBox();
            this.txtPretensaoDtFinal = new System.Windows.Forms.TextBox();
            this.dtgPret = new System.Windows.Forms.DataGridView();
            this.dtgPretClOpcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl1pInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl1pFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl1pTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl2pInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl2pFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretCl2pTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPretClTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPret)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPretensaoRegistro
            // 
            this.txtPretensaoRegistro.BackColor = System.Drawing.Color.White;
            this.txtPretensaoRegistro.Location = new System.Drawing.Point(12, 34);
            this.txtPretensaoRegistro.Name = "txtPretensaoRegistro";
            this.txtPretensaoRegistro.ReadOnly = true;
            this.txtPretensaoRegistro.Size = new System.Drawing.Size(100, 20);
            this.txtPretensaoRegistro.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(160, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(373, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(608, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // lblPretensaoRegistro
            // 
            this.lblPretensaoRegistro.AutoSize = true;
            this.lblPretensaoRegistro.Location = new System.Drawing.Point(12, 15);
            this.lblPretensaoRegistro.Name = "lblPretensaoRegistro";
            this.lblPretensaoRegistro.Size = new System.Drawing.Size(46, 13);
            this.lblPretensaoRegistro.TabIndex = 3;
            this.lblPretensaoRegistro.Text = "Registro";
            // 
            // lblPretensaoNome
            // 
            this.lblPretensaoNome.AutoSize = true;
            this.lblPretensaoNome.Location = new System.Drawing.Point(160, 15);
            this.lblPretensaoNome.Name = "lblPretensaoNome";
            this.lblPretensaoNome.Size = new System.Drawing.Size(35, 13);
            this.lblPretensaoNome.TabIndex = 4;
            this.lblPretensaoNome.Text = "Nome";
            // 
            // lblPretensaoTurno
            // 
            this.lblPretensaoTurno.AutoSize = true;
            this.lblPretensaoTurno.Location = new System.Drawing.Point(605, 15);
            this.lblPretensaoTurno.Name = "lblPretensaoTurno";
            this.lblPretensaoTurno.Size = new System.Drawing.Size(35, 13);
            this.lblPretensaoTurno.TabIndex = 5;
            this.lblPretensaoTurno.Text = "Turno";
            // 
            // lblPretensaoAno
            // 
            this.lblPretensaoAno.AutoSize = true;
            this.lblPretensaoAno.Location = new System.Drawing.Point(14, 75);
            this.lblPretensaoAno.Name = "lblPretensaoAno";
            this.lblPretensaoAno.Size = new System.Drawing.Size(26, 13);
            this.lblPretensaoAno.TabIndex = 6;
            this.lblPretensaoAno.Text = "Ano";
            // 
            // lblPretensaoDtInicio
            // 
            this.lblPretensaoDtInicio.AutoSize = true;
            this.lblPretensaoDtInicio.Location = new System.Drawing.Point(162, 75);
            this.lblPretensaoDtInicio.Name = "lblPretensaoDtInicio";
            this.lblPretensaoDtInicio.Size = new System.Drawing.Size(59, 13);
            this.lblPretensaoDtInicio.TabIndex = 7;
            this.lblPretensaoDtInicio.Text = "Data inicial";
            // 
            // lblPretensaoDtFinal
            // 
            this.lblPretensaoDtFinal.AutoSize = true;
            this.lblPretensaoDtFinal.Location = new System.Drawing.Point(345, 75);
            this.lblPretensaoDtFinal.Name = "lblPretensaoDtFinal";
            this.lblPretensaoDtFinal.Size = new System.Drawing.Size(52, 13);
            this.lblPretensaoDtFinal.TabIndex = 8;
            this.lblPretensaoDtFinal.Text = "Data final";
            // 
            // cboPretensaoAno
            // 
            this.cboPretensaoAno.FormattingEnabled = true;
            this.cboPretensaoAno.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cboPretensaoAno.Location = new System.Drawing.Point(14, 92);
            this.cboPretensaoAno.Name = "cboPretensaoAno";
            this.cboPretensaoAno.Size = new System.Drawing.Size(100, 21);
            this.cboPretensaoAno.TabIndex = 9;
            // 
            // txtPretensaoDtInicio
            // 
            this.txtPretensaoDtInicio.Location = new System.Drawing.Point(162, 92);
            this.txtPretensaoDtInicio.Name = "txtPretensaoDtInicio";
            this.txtPretensaoDtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtPretensaoDtInicio.TabIndex = 10;
            // 
            // txtPretensaoDtFinal
            // 
            this.txtPretensaoDtFinal.Location = new System.Drawing.Point(348, 93);
            this.txtPretensaoDtFinal.Name = "txtPretensaoDtFinal";
            this.txtPretensaoDtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtPretensaoDtFinal.TabIndex = 11;
            // 
            // dtgPret
            // 
            this.dtgPret.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPret.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgPretClOpcao,
            this.dtgPretCl1pInicio,
            this.dtgPretCl1pFim,
            this.dtgPretCl1pTotal,
            this.dtgPretCl2pInicio,
            this.dtgPretCl2pFim,
            this.dtgPretCl2pTotal,
            this.dtgPretClTotal});
            this.dtgPret.Location = new System.Drawing.Point(12, 276);
            this.dtgPret.Name = "dtgPret";
            this.dtgPret.Size = new System.Drawing.Size(696, 150);
            this.dtgPret.TabIndex = 12;
            // 
            // dtgPretClOpcao
            // 
            this.dtgPretClOpcao.HeaderText = "Opção";
            this.dtgPretClOpcao.Name = "dtgPretClOpcao";
            this.dtgPretClOpcao.ReadOnly = true;
            this.dtgPretClOpcao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPretClOpcao.Width = 60;
            // 
            // dtgPretCl1pInicio
            // 
            this.dtgPretCl1pInicio.HeaderText = "Início";
            this.dtgPretCl1pInicio.Name = "dtgPretCl1pInicio";
            this.dtgPretCl1pInicio.ReadOnly = true;
            // 
            // dtgPretCl1pFim
            // 
            this.dtgPretCl1pFim.HeaderText = "Fim";
            this.dtgPretCl1pFim.Name = "dtgPretCl1pFim";
            this.dtgPretCl1pFim.ReadOnly = true;
            // 
            // dtgPretCl1pTotal
            // 
            this.dtgPretCl1pTotal.HeaderText = "Dias";
            this.dtgPretCl1pTotal.Name = "dtgPretCl1pTotal";
            this.dtgPretCl1pTotal.ReadOnly = true;
            this.dtgPretCl1pTotal.Width = 60;
            // 
            // dtgPretCl2pInicio
            // 
            this.dtgPretCl2pInicio.HeaderText = "Início";
            this.dtgPretCl2pInicio.Name = "dtgPretCl2pInicio";
            this.dtgPretCl2pInicio.ReadOnly = true;
            // 
            // dtgPretCl2pFim
            // 
            this.dtgPretCl2pFim.HeaderText = "Fim";
            this.dtgPretCl2pFim.Name = "dtgPretCl2pFim";
            this.dtgPretCl2pFim.ReadOnly = true;
            // 
            // dtgPretCl2pTotal
            // 
            this.dtgPretCl2pTotal.HeaderText = "Dias";
            this.dtgPretCl2pTotal.Name = "dtgPretCl2pTotal";
            this.dtgPretCl2pTotal.ReadOnly = true;
            this.dtgPretCl2pTotal.Width = 60;
            // 
            // dtgPretClTotal
            // 
            this.dtgPretClTotal.HeaderText = "Total";
            this.dtgPretClTotal.Name = "dtgPretClTotal";
            this.dtgPretClTotal.ReadOnly = true;
            this.dtgPretClTotal.Width = 70;
            // 
            // FrmPretensao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 438);
            this.Controls.Add(this.dtgPret);
            this.Controls.Add(this.txtPretensaoDtFinal);
            this.Controls.Add(this.txtPretensaoDtInicio);
            this.Controls.Add(this.cboPretensaoAno);
            this.Controls.Add(this.lblPretensaoDtFinal);
            this.Controls.Add(this.lblPretensaoDtInicio);
            this.Controls.Add(this.lblPretensaoAno);
            this.Controls.Add(this.lblPretensaoTurno);
            this.Controls.Add(this.lblPretensaoNome);
            this.Controls.Add(this.lblPretensaoRegistro);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtPretensaoRegistro);
            this.Name = "FrmPretensao";
            this.Text = "FrmPretensao";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPretensaoRegistro;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblPretensaoRegistro;
        private System.Windows.Forms.Label lblPretensaoNome;
        private System.Windows.Forms.Label lblPretensaoTurno;
        private System.Windows.Forms.Label lblPretensaoAno;
        private System.Windows.Forms.Label lblPretensaoDtInicio;
        private System.Windows.Forms.Label lblPretensaoDtFinal;
        private System.Windows.Forms.ComboBox cboPretensaoAno;
        private System.Windows.Forms.TextBox txtPretensaoDtInicio;
        private System.Windows.Forms.TextBox txtPretensaoDtFinal;
        private System.Windows.Forms.DataGridView dtgPret;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretClOpcao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl1pInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl1pFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl1pTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl2pInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl2pFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretCl2pTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPretClTotal;
    }
}