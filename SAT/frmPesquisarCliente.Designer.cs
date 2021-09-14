namespace SAT
{
    partial class frmPesquisarCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotalCliente = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTelefone = new System.Windows.Forms.RadioButton();
            this.rbRgIe = new System.Windows.Forms.RadioButton();
            this.rbCpf = new System.Windows.Forms.RadioButton();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gdvCliente = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CLIENTE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FANTASIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_END = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_FONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF_CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RG_INSC_EST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT_CADASTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT_NASC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BLOQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GASTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalCliente
            // 
            this.lblTotalCliente.Name = "lblTotalCliente";
            this.lblTotalCliente.Size = new System.Drawing.Size(13, 17);
            this.lblTotalCliente.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "Total de Cliente:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTelefone);
            this.groupBox1.Controls.Add(this.rbRgIe);
            this.groupBox1.Controls.Add(this.rbCpf);
            this.groupBox1.Controls.Add(this.rbNome);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1278, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Pesquisas";
            // 
            // rbTelefone
            // 
            this.rbTelefone.AutoSize = true;
            this.rbTelefone.Location = new System.Drawing.Point(223, 31);
            this.rbTelefone.Name = "rbTelefone";
            this.rbTelefone.Size = new System.Drawing.Size(81, 17);
            this.rbTelefone.TabIndex = 3;
            this.rbTelefone.Text = "TELEFONE";
            this.rbTelefone.UseVisualStyleBackColor = true;
            this.rbTelefone.CheckedChanged += new System.EventHandler(this.rbTelefone_CheckedChanged);
            // 
            // rbRgIe
            // 
            this.rbRgIe.AutoSize = true;
            this.rbRgIe.Location = new System.Drawing.Point(158, 31);
            this.rbRgIe.Name = "rbRgIe";
            this.rbRgIe.Size = new System.Drawing.Size(59, 17);
            this.rbRgIe.TabIndex = 2;
            this.rbRgIe.Text = "RG/IE:";
            this.rbRgIe.UseVisualStyleBackColor = true;
            this.rbRgIe.CheckedChanged += new System.EventHandler(this.rbRgIe_CheckedChanged);
            // 
            // rbCpf
            // 
            this.rbCpf.AutoSize = true;
            this.rbCpf.Location = new System.Drawing.Point(72, 31);
            this.rbCpf.Name = "rbCpf";
            this.rbCpf.Size = new System.Drawing.Size(80, 17);
            this.rbCpf.TabIndex = 1;
            this.rbCpf.Text = "CPF/CNPJ:";
            this.rbCpf.UseVisualStyleBackColor = true;
            this.rbCpf.CheckedChanged += new System.EventHandler(this.rbCpf_CheckedChanged);
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Checked = true;
            this.rbNome.Location = new System.Drawing.Point(10, 31);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(60, 17);
            this.rbNome.TabIndex = 0;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "NOME:";
            this.rbNome.UseVisualStyleBackColor = true;
            this.rbNome.CheckedChanged += new System.EventHandler(this.rbNome_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTotalCliente});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1288, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gdvCliente
            // 
            this.gdvCliente.AllowUserToAddRows = false;
            this.gdvCliente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gdvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvCliente.BackgroundColor = System.Drawing.Color.White;
            this.gdvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLIENTE_ID,
            this.NOMES,
            this.FANTASIA,
            this.ID_END,
            this.ID_FONE,
            this.CPF_CNPJ,
            this.RG_INSC_EST,
            this.DT_CADASTRO,
            this.DT_NASC,
            this.BLOQ,
            this.LIMITE,
            this.GASTO,
            this.colStatus});
            this.gdvCliente.Location = new System.Drawing.Point(3, 122);
            this.gdvCliente.MultiSelect = false;
            this.gdvCliente.Name = "gdvCliente";
            this.gdvCliente.ReadOnly = true;
            this.gdvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvCliente.Size = new System.Drawing.Size(1279, 453);
            this.gdvCliente.TabIndex = 5;
            this.gdvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvCliente_CellContentClick);
            this.gdvCliente.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvCliente_CellContentDoubleClick);
            this.gdvCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvCliente_KeyDown);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(4, 87);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(1278, 29);
            this.txtPesquisa.TabIndex = 4;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "* Dê Duplo Click para Selecionar o Cliente.";
            // 
            // CLIENTE_ID
            // 
            this.CLIENTE_ID.DataPropertyName = "CLIENTE_ID";
            this.CLIENTE_ID.HeaderText = "Codigo";
            this.CLIENTE_ID.Name = "CLIENTE_ID";
            this.CLIENTE_ID.ReadOnly = true;
            this.CLIENTE_ID.Visible = false;
            // 
            // NOMES
            // 
            this.NOMES.DataPropertyName = "NOME";
            this.NOMES.HeaderText = "NOME";
            this.NOMES.Name = "NOMES";
            this.NOMES.ReadOnly = true;
            this.NOMES.Width = 400;
            // 
            // FANTASIA
            // 
            this.FANTASIA.DataPropertyName = "APELIDO_FANTAZIA";
            this.FANTASIA.HeaderText = "FANTASIA";
            this.FANTASIA.Name = "FANTASIA";
            this.FANTASIA.ReadOnly = true;
            this.FANTASIA.Width = 400;
            // 
            // ID_END
            // 
            this.ID_END.DataPropertyName = "ID_END";
            this.ID_END.HeaderText = "Codigo End.";
            this.ID_END.Name = "ID_END";
            this.ID_END.ReadOnly = true;
            this.ID_END.Visible = false;
            // 
            // ID_FONE
            // 
            this.ID_FONE.DataPropertyName = "ID_FONE";
            this.ID_FONE.HeaderText = "Codigo Tel.";
            this.ID_FONE.Name = "ID_FONE";
            this.ID_FONE.ReadOnly = true;
            this.ID_FONE.Visible = false;
            // 
            // CPF_CNPJ
            // 
            this.CPF_CNPJ.DataPropertyName = "CPF_CNPJ";
            this.CPF_CNPJ.HeaderText = "CPF/CNPJ";
            this.CPF_CNPJ.Name = "CPF_CNPJ";
            this.CPF_CNPJ.ReadOnly = true;
            this.CPF_CNPJ.Width = 130;
            // 
            // RG_INSC_EST
            // 
            this.RG_INSC_EST.DataPropertyName = "RG_INSC_EST";
            this.RG_INSC_EST.HeaderText = "RG/IE";
            this.RG_INSC_EST.Name = "RG_INSC_EST";
            this.RG_INSC_EST.ReadOnly = true;
            this.RG_INSC_EST.Width = 130;
            // 
            // DT_CADASTRO
            // 
            this.DT_CADASTRO.DataPropertyName = "DT_CADASTRO";
            this.DT_CADASTRO.HeaderText = "DT_CADASTRO";
            this.DT_CADASTRO.Name = "DT_CADASTRO";
            this.DT_CADASTRO.ReadOnly = true;
            this.DT_CADASTRO.Visible = false;
            // 
            // DT_NASC
            // 
            this.DT_NASC.DataPropertyName = "DT_NASC";
            this.DT_NASC.HeaderText = "DT_NASC";
            this.DT_NASC.Name = "DT_NASC";
            this.DT_NASC.ReadOnly = true;
            this.DT_NASC.Visible = false;
            // 
            // BLOQ
            // 
            this.BLOQ.DataPropertyName = "BLOQ";
            this.BLOQ.HeaderText = "BLOQ";
            this.BLOQ.Name = "BLOQ";
            this.BLOQ.ReadOnly = true;
            this.BLOQ.Visible = false;
            // 
            // LIMITE
            // 
            this.LIMITE.DataPropertyName = "LIMITE";
            dataGridViewCellStyle2.NullValue = "0,00";
            this.LIMITE.DefaultCellStyle = dataGridViewCellStyle2;
            this.LIMITE.HeaderText = "LIMITE";
            this.LIMITE.Name = "LIMITE";
            this.LIMITE.ReadOnly = true;
            this.LIMITE.Visible = false;
            // 
            // GASTO
            // 
            this.GASTO.DataPropertyName = "GASTO";
            dataGridViewCellStyle3.NullValue = "0,00";
            this.GASTO.DefaultCellStyle = dataGridViewCellStyle3;
            this.GASTO.HeaderText = "GASTO";
            this.GASTO.Name = "GASTO";
            this.GASTO.ReadOnly = true;
            this.GASTO.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 120;
            // 
            // frmPesquisarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1288, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gdvCliente);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Clientes";
            this.Load += new System.EventHandler(this.frmPesquisarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel lblTotalCliente;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRgIe;
        private System.Windows.Forms.RadioButton rbCpf;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView gdvCliente;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FANTASIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_END;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_FONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF_CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RG_INSC_EST;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT_CADASTRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT_NASC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BLOQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIMITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GASTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}