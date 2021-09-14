namespace SAT
{
    partial class frmNFCeLogin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grvEmpresa = new System.Windows.Forms.DataGridView();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtCNPJEmpresa = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNomeEmpresa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_dadoscertificado = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmpresa)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvEmpresa
            // 
            this.grvEmpresa.AllowUserToAddRows = false;
            this.grvEmpresa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvEmpresa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grvEmpresa.BackgroundColor = System.Drawing.Color.White;
            this.grvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOME,
            this.Subject});
            this.grvEmpresa.Location = new System.Drawing.Point(3, 273);
            this.grvEmpresa.Name = "grvEmpresa";
            this.grvEmpresa.ReadOnly = true;
            this.grvEmpresa.RowHeadersVisible = false;
            this.grvEmpresa.Size = new System.Drawing.Size(1058, 217);
            this.grvEmpresa.TabIndex = 105;
            this.grvEmpresa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvEmpresa_CellContentClick);
            this.grvEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvEmpresa_KeyDown);
            // 
            // NOME
            // 
            this.NOME.DataPropertyName = "FriendlyName";
            this.NOME.HeaderText = "RAZÃO SOCIAL";
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            this.NOME.Width = 1050;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLogin.Image = global::SAT.Properties.Resources.download;
            this.btnLogin.Location = new System.Drawing.Point(3, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(311, 262);
            this.btnLogin.TabIndex = 106;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtCNPJEmpresa
            // 
            this.txtCNPJEmpresa.BackColor = System.Drawing.Color.White;
            this.txtCNPJEmpresa.Location = new System.Drawing.Point(11, 36);
            this.txtCNPJEmpresa.Mask = "00,000,000/0000-00";
            this.txtCNPJEmpresa.Name = "txtCNPJEmpresa";
            this.txtCNPJEmpresa.ReadOnly = true;
            this.txtCNPJEmpresa.Size = new System.Drawing.Size(121, 22);
            this.txtCNPJEmpresa.TabIndex = 107;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(11, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 109;
            this.label7.Text = "CNPJ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(138, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 110;
            this.label8.Text = "RAZÃO SOCIAL";
            // 
            // txtNomeEmpresa
            // 
            this.txtNomeEmpresa.BackColor = System.Drawing.Color.White;
            this.txtNomeEmpresa.Location = new System.Drawing.Point(138, 36);
            this.txtNomeEmpresa.MaxLength = 35;
            this.txtNomeEmpresa.Name = "txtNomeEmpresa";
            this.txtNomeEmpresa.ReadOnly = true;
            this.txtNomeEmpresa.Size = new System.Drawing.Size(597, 22);
            this.txtNomeEmpresa.TabIndex = 108;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(8, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(272, 15);
            this.label13.TabIndex = 112;
            this.label13.Text = "Informações do certificado digital selecionado:";
            // 
            // txt_dadoscertificado
            // 
            this.txt_dadoscertificado.BackColor = System.Drawing.Color.White;
            this.txt_dadoscertificado.Location = new System.Drawing.Point(329, 84);
            this.txt_dadoscertificado.Multiline = true;
            this.txt_dadoscertificado.Name = "txt_dadoscertificado";
            this.txt_dadoscertificado.ReadOnly = true;
            this.txt_dadoscertificado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_dadoscertificado.Size = new System.Drawing.Size(726, 175);
            this.txt_dadoscertificado.TabIndex = 111;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 20);
            this.statusStrip1.TabIndex = 113;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(111, 15);
            this.toolStripStatusLabel1.Text = "VERSÃO NFC-e 4.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCNPJEmpresa);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNomeEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(320, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 262);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DADOS DO CERTIFICADO";
            // 
            // frmNFCeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 522);
            this.Controls.Add(this.txt_dadoscertificado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.grvEmpresa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNFCeLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDV NFC-e - NOTA FISCAL CONSUMIDOR ELETRONICO";
            this.Load += new System.EventHandler(this.frmNFCeLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvEmpresa)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvEmpresa;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.MaskedTextBox txtCNPJEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeEmpresa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_dadoscertificado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
    }
}