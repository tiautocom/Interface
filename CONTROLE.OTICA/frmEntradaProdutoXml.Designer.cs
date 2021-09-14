namespace CONTROLE.OTICA
{
    partial class frmEntradaProdutoXml
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gdvProdutoXml = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUcom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colqCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvUnTrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvUnCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNcm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumeroNota = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtvalorBoleto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPathArquivo = new System.Windows.Forms.Button();
            this.txtEnderecoXml = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdvProdutoXml)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvProdutoXml
            // 
            this.gdvProdutoXml.AllowUserToAddRows = false;
            this.gdvProdutoXml.AllowUserToDeleteRows = false;
            this.gdvProdutoXml.BackgroundColor = System.Drawing.Color.White;
            this.gdvProdutoXml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvProdutoXml.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.cProd,
            this.cEAN,
            this.xProd,
            this.colUcom,
            this.colqCom,
            this.colvUnTrib,
            this.colvProd,
            this.colvUnCom,
            this.colCst,
            this.colCfop,
            this.colCest,
            this.colNcm});
            this.gdvProdutoXml.Location = new System.Drawing.Point(4, 102);
            this.gdvProdutoXml.Name = "gdvProdutoXml";
            this.gdvProdutoXml.ReadOnly = true;
            this.gdvProdutoXml.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gdvProdutoXml.Size = new System.Drawing.Size(1285, 480);
            this.gdvProdutoXml.TabIndex = 1;
            // 
            // check
            // 
            this.check.DataPropertyName = "check";
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Visible = false;
            this.check.Width = 30;
            // 
            // cProd
            // 
            this.cProd.DataPropertyName = "cProd";
            this.cProd.HeaderText = "CÓD.";
            this.cProd.Name = "cProd";
            this.cProd.ReadOnly = true;
            // 
            // cEAN
            // 
            this.cEAN.DataPropertyName = "cEAN";
            this.cEAN.HeaderText = "COD.BARRAS";
            this.cEAN.Name = "cEAN";
            this.cEAN.ReadOnly = true;
            this.cEAN.Width = 130;
            // 
            // xProd
            // 
            this.xProd.DataPropertyName = "xProd";
            this.xProd.HeaderText = "DESCRIÇÃO PRODUTO";
            this.xProd.Name = "xProd";
            this.xProd.ReadOnly = true;
            this.xProd.Width = 210;
            // 
            // colUcom
            // 
            this.colUcom.DataPropertyName = "uCom";
            this.colUcom.HeaderText = "Unid";
            this.colUcom.Name = "colUcom";
            this.colUcom.ReadOnly = true;
            this.colUcom.Width = 40;
            // 
            // colqCom
            // 
            this.colqCom.DataPropertyName = "qCom";
            this.colqCom.HeaderText = "Qtde";
            this.colqCom.Name = "colqCom";
            this.colqCom.ReadOnly = true;
            this.colqCom.Width = 60;
            // 
            // colvUnTrib
            // 
            this.colvUnTrib.DataPropertyName = "vUnTrib";
            this.colvUnTrib.HeaderText = "Custo";
            this.colvUnTrib.Name = "colvUnTrib";
            this.colvUnTrib.ReadOnly = true;
            this.colvUnTrib.Width = 70;
            // 
            // colvProd
            // 
            this.colvProd.DataPropertyName = "vProd";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.colvProd.DefaultCellStyle = dataGridViewCellStyle11;
            this.colvProd.HeaderText = "Total";
            this.colvProd.Name = "colvProd";
            this.colvProd.ReadOnly = true;
            this.colvProd.Width = 70;
            // 
            // colvUnCom
            // 
            this.colvUnCom.DataPropertyName = "vUnCom";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.colvUnCom.DefaultCellStyle = dataGridViewCellStyle12;
            this.colvUnCom.HeaderText = "Preço";
            this.colvUnCom.Name = "colvUnCom";
            this.colvUnCom.ReadOnly = true;
            this.colvUnCom.Width = 70;
            // 
            // colCst
            // 
            this.colCst.DataPropertyName = "CST";
            this.colCst.HeaderText = "CST";
            this.colCst.Name = "colCst";
            this.colCst.ReadOnly = true;
            // 
            // colCfop
            // 
            this.colCfop.DataPropertyName = "CFOP";
            this.colCfop.HeaderText = "CFOP";
            this.colCfop.Name = "colCfop";
            this.colCfop.ReadOnly = true;
            // 
            // colCest
            // 
            this.colCest.DataPropertyName = "CEST";
            this.colCest.HeaderText = "CEST";
            this.colCest.Name = "colCest";
            this.colCest.ReadOnly = true;
            // 
            // colNcm
            // 
            this.colNcm.DataPropertyName = "NCM";
            this.colNcm.HeaderText = "NCM";
            this.colNcm.Name = "colNcm";
            this.colNcm.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "CNPJ";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(340, 73);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(146, 22);
            this.txtCnpj.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Fornecedor";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(6, 29);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(619, 22);
            this.txtFornecedor.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(492, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Telefone";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(492, 73);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(133, 22);
            this.txtTelefone.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Nº Nota Entrada";
            // 
            // txtNumeroNota
            // 
            this.txtNumeroNota.Location = new System.Drawing.Point(6, 73);
            this.txtNumeroNota.Name = "txtNumeroNota";
            this.txtNumeroNota.Size = new System.Drawing.Size(138, 22);
            this.txtNumeroNota.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "Valor Boleto";
            // 
            // txtvalorBoleto
            // 
            this.txtvalorBoleto.Location = new System.Drawing.Point(150, 73);
            this.txtvalorBoleto.Name = "txtvalorBoleto";
            this.txtvalorBoleto.Size = new System.Drawing.Size(134, 22);
            this.txtvalorBoleto.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(631, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "End. Arquivo do Xml";
            // 
            // btnPathArquivo
            // 
            this.btnPathArquivo.Location = new System.Drawing.Point(1189, 29);
            this.btnPathArquivo.Name = "btnPathArquivo";
            this.btnPathArquivo.Size = new System.Drawing.Size(100, 23);
            this.btnPathArquivo.TabIndex = 31;
            this.btnPathArquivo.Text = "Localizar Arquivo";
            this.btnPathArquivo.UseVisualStyleBackColor = true;
            // 
            // txtEnderecoXml
            // 
            this.txtEnderecoXml.Location = new System.Drawing.Point(631, 29);
            this.txtEnderecoXml.Name = "txtEnderecoXml";
            this.txtEnderecoXml.Size = new System.Drawing.Size(552, 22);
            this.txtEnderecoXml.TabIndex = 30;
            // 
            // frmEntradaProdutoXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 699);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPathArquivo);
            this.Controls.Add(this.txtEnderecoXml);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtvalorBoleto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumeroNota);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCnpj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.gdvProdutoXml);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEntradaProdutoXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENTRADA PRODUTO XML";
            ((System.ComponentModel.ISupportInitialize)(this.gdvProdutoXml)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvProdutoXml;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn xProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUcom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colqCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvUnTrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvUnCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNcm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumeroNota;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtvalorBoleto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPathArquivo;
        private System.Windows.Forms.TextBox txtEnderecoXml;
    }
}