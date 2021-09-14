namespace SAT
{
    partial class frmVendaXmlSat
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
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.colSel = new System.Windows.Forms.DataGridViewImageColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmdereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumCaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQtde = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEndPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEndResp = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtNumCupom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarVenda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSel,
            this.colId,
            this.colEmdereco,
            this.colNumCaixa});
            this.dgvVendas.Location = new System.Drawing.Point(6, 53);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.RowHeadersVisible = false;
            this.dgvVendas.Size = new System.Drawing.Size(585, 265);
            this.dgvVendas.TabIndex = 0;
            this.dgvVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendas_CellContentClick);
            // 
            // colSel
            // 
            this.colSel.HeaderText = "";
            this.colSel.Image = global::SAT.Properties.Resources.impressora1;
            this.colSel.Name = "colSel";
            this.colSel.ReadOnly = true;
            this.colSel.Width = 50;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "CODIGO";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colEmdereco
            // 
            this.colEmdereco.DataPropertyName = "Endereco";
            this.colEmdereco.HeaderText = "NUMERO VENDA";
            this.colEmdereco.Name = "colEmdereco";
            this.colEmdereco.ReadOnly = true;
            this.colEmdereco.Width = 300;
            // 
            // colNumCaixa
            // 
            this.colNumCaixa.DataPropertyName = "NumCaixa";
            this.colNumCaixa.HeaderText = "Nº CAIXA";
            this.colNumCaixa.Name = "colNumCaixa";
            this.colNumCaixa.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblQtde,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblEndPath,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.lblEndResp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "Qtde:";
            // 
            // lblQtde
            // 
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(25, 17);
            this.lblQtde.Text = "000";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel2.Text = "||";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel3.Text = "Endereço Path:";
            // 
            // lblEndPath
            // 
            this.lblEndPath.Name = "lblEndPath";
            this.lblEndPath.Size = new System.Drawing.Size(16, 17);
            this.lblEndPath.Text = "...";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel4.Text = "||";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel5.Text = "Endereço Resposta:";
            // 
            // lblEndResp
            // 
            this.lblEndResp.Name = "lblEndResp";
            this.lblEndResp.Size = new System.Drawing.Size(16, 17);
            this.lblEndResp.Text = "...";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Image = global::SAT.Properties.Resources.impressora;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(421, 324);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(170, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar e Imprimir";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtNumCupom
            // 
            this.txtNumCupom.Location = new System.Drawing.Point(6, 26);
            this.txtNumCupom.Name = "txtNumCupom";
            this.txtNumCupom.Size = new System.Drawing.Size(585, 24);
            this.txtNumCupom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nº CUPOM";
            // 
            // btnExportarVenda
            // 
            this.btnExportarVenda.BackColor = System.Drawing.Color.White;
            this.btnExportarVenda.Image = global::SAT.Properties.Resources.import_export_icon__1_;
            this.btnExportarVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarVenda.Location = new System.Drawing.Point(6, 324);
            this.btnExportarVenda.Name = "btnExportarVenda";
            this.btnExportarVenda.Size = new System.Drawing.Size(388, 32);
            this.btnExportarVenda.TabIndex = 5;
            this.btnExportarVenda.Text = "Exportar Venda";
            this.btnExportarVenda.UseVisualStyleBackColor = false;
            this.btnExportarVenda.Click += new System.EventHandler(this.btnExportarVenda_Click);
            // 
            // frmVendaXmlSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 381);
            this.Controls.Add(this.btnExportarVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumCupom);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvVendas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVendaXmlSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venda XML";
            this.Load += new System.EventHandler(this.frmVendaXmlSat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblQtde;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblEndPath;
        private System.Windows.Forms.DataGridViewImageColumn colSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmdereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumCaixa;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblEndResp;
        private System.Windows.Forms.TextBox txtNumCupom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarVenda;
    }
}