namespace CallPostgre.View
{
    partial class frmDepartamento
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
            this.dtgDepto = new System.Windows.Forms.DataGridView();
            this.dtgDepRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDepNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDepHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDepMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDepMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepto)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDepto
            // 
            this.dtgDepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDepto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgDepRegistro,
            this.dtgDepNome,
            this.dtgDepHorario,
            this.dtgDepMonitor,
            this.dtgDepMes});
            this.dtgDepto.Location = new System.Drawing.Point(12, 172);
            this.dtgDepto.Name = "dtgDepto";
            this.dtgDepto.Size = new System.Drawing.Size(588, 196);
            this.dtgDepto.TabIndex = 0;
            // 
            // dtgDepRegistro
            // 
            this.dtgDepRegistro.HeaderText = "Registro";
            this.dtgDepRegistro.Name = "dtgDepRegistro";
            this.dtgDepRegistro.ReadOnly = true;
            // 
            // dtgDepNome
            // 
            this.dtgDepNome.HeaderText = "Nome";
            this.dtgDepNome.Name = "dtgDepNome";
            this.dtgDepNome.ReadOnly = true;
            // 
            // dtgDepHorario
            // 
            this.dtgDepHorario.HeaderText = "Horário";
            this.dtgDepHorario.Name = "dtgDepHorario";
            this.dtgDepHorario.ReadOnly = true;
            // 
            // dtgDepMonitor
            // 
            this.dtgDepMonitor.HeaderText = "Monitor";
            this.dtgDepMonitor.Name = "dtgDepMonitor";
            this.dtgDepMonitor.ReadOnly = true;
            // 
            // dtgDepMes
            // 
            this.dtgDepMes.HeaderText = "Mês";
            this.dtgDepMes.Name = "dtgDepMes";
            this.dtgDepMes.ReadOnly = true;
            // 
            // frmDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 380);
            this.Controls.Add(this.dtgDepto);
            this.Name = "frmDepartamento";
            this.Text = "frmDepartamento";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDepto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDepRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDepNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDepHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDepMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDepMes;
    }
}