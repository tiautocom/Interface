namespace CONTROLE.OTICA
{
    partial class frmRelatorioEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQtde = new System.Windows.Forms.ToolStripStatusLabel();
            this.COD_BARRA_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_INT_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRICAO_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECO_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNID_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REDUCAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTO_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTOQUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EST_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUM_DEPAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECLA_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRANEL_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STRIB_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STRIB_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATUALIZA_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMBAL_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTO_CX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIXO_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT_AJUSTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTDE_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SETOR_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALIDADE_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECLA_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INDIC_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MARGEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QT_COM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT_COM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_PIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_PIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_CONFINS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFOP_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_AUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_COFINS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORIGEM_PRODUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICMS_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICMS_CST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCM_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSolicitarPedido = new System.Windows.Forms.Button();
            this.btnImprimirRelatorio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduto.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProduto.CausesValidation = false;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COD_BARRA_,
            this.COD_INT_,
            this.DESCRICAO_,
            this.PRECO_,
            this.UNID_,
            this.DESC_,
            this.TRIB,
            this.REDUCAO,
            this.CUSTO_,
            this.ESTOQUE,
            this.EST_MIN,
            this.NUM_DEPAR,
            this.TECLA_,
            this.GRANEL_,
            this.DEPARTAM,
            this.STRIB_A,
            this.STRIB_B,
            this.ATUALIZA_,
            this.EMBAL_,
            this.CUSTO_CX,
            this.LIXO_,
            this.DT_AJUSTE,
            this.QTDE_DESC,
            this.SETOR_,
            this.VALIDADE_,
            this.TECLA_B,
            this.INDIC_B,
            this.MARGEM,
            this.QT_COM,
            this.DT_COM,
            this.VALOR_PIS,
            this.CST_PIS,
            this.VALOR_CONFINS,
            this.CFOP_,
            this.DESC_AUTO,
            this.CST_COFINS,
            this.ORIGEM_PRODUTO,
            this.ICMS_,
            this.ICMS_CST,
            this.NCM_,
            this.colCest});
            this.dgvProduto.Location = new System.Drawing.Point(5, 52);
            this.dgvProduto.MultiSelect = false;
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.RowHeadersVisible = false;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(1219, 492);
            this.dgvProduto.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 153;
            this.label1.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(5, 24);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(185, 23);
            this.txtPesquisar.TabIndex = 151;
            this.txtPesquisar.Text = "03";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(198, 21);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(153, 28);
            this.btnPesquisar.TabIndex = 152;
            this.btnPesquisar.Text = "Pesquisar Estoque";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblQtde});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1230, 25);
            this.statusStrip1.TabIndex = 154;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(185, 20);
            this.toolStripStatusLabel1.Text = "QUANTIDADE REGISTROS:";
            // 
            // lblQtde
            // 
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(41, 20);
            this.lblQtde.Text = "0000";
            // 
            // COD_BARRA_
            // 
            this.COD_BARRA_.DataPropertyName = "COD_BARRA";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COD_BARRA_.DefaultCellStyle = dataGridViewCellStyle2;
            this.COD_BARRA_.HeaderText = "COD. BARRA";
            this.COD_BARRA_.Name = "COD_BARRA_";
            this.COD_BARRA_.ReadOnly = true;
            this.COD_BARRA_.Width = 120;
            // 
            // COD_INT_
            // 
            this.COD_INT_.DataPropertyName = "COD_INT";
            this.COD_INT_.HeaderText = "COD_INT";
            this.COD_INT_.Name = "COD_INT_";
            this.COD_INT_.ReadOnly = true;
            this.COD_INT_.Visible = false;
            // 
            // DESCRICAO_
            // 
            this.DESCRICAO_.DataPropertyName = "DESCRICAO";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DESCRICAO_.DefaultCellStyle = dataGridViewCellStyle3;
            this.DESCRICAO_.HeaderText = "DESCRICAO";
            this.DESCRICAO_.Name = "DESCRICAO_";
            this.DESCRICAO_.ReadOnly = true;
            this.DESCRICAO_.Width = 500;
            // 
            // PRECO_
            // 
            this.PRECO_.DataPropertyName = "PRECO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0,00";
            this.PRECO_.DefaultCellStyle = dataGridViewCellStyle4;
            this.PRECO_.HeaderText = "PRECO";
            this.PRECO_.Name = "PRECO_";
            this.PRECO_.ReadOnly = true;
            this.PRECO_.Width = 120;
            // 
            // UNID_
            // 
            this.UNID_.DataPropertyName = "UNID";
            this.UNID_.HeaderText = "UNID";
            this.UNID_.Name = "UNID_";
            this.UNID_.ReadOnly = true;
            // 
            // DESC_
            // 
            this.DESC_.DataPropertyName = "DESC";
            this.DESC_.HeaderText = "DESC";
            this.DESC_.Name = "DESC_";
            this.DESC_.ReadOnly = true;
            this.DESC_.Visible = false;
            // 
            // TRIB
            // 
            this.TRIB.DataPropertyName = "TRIB";
            this.TRIB.HeaderText = "TRIB";
            this.TRIB.Name = "TRIB";
            this.TRIB.ReadOnly = true;
            this.TRIB.Visible = false;
            // 
            // REDUCAO
            // 
            this.REDUCAO.DataPropertyName = "REDUCAO";
            this.REDUCAO.HeaderText = "REDUCAO";
            this.REDUCAO.Name = "REDUCAO";
            this.REDUCAO.ReadOnly = true;
            this.REDUCAO.Visible = false;
            // 
            // CUSTO_
            // 
            this.CUSTO_.DataPropertyName = "CUSTO";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0,00";
            this.CUSTO_.DefaultCellStyle = dataGridViewCellStyle5;
            this.CUSTO_.HeaderText = "CUSTO";
            this.CUSTO_.Name = "CUSTO_";
            this.CUSTO_.ReadOnly = true;
            this.CUSTO_.Width = 120;
            // 
            // ESTOQUE
            // 
            this.ESTOQUE.DataPropertyName = "ESTOQUE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0,00";
            this.ESTOQUE.DefaultCellStyle = dataGridViewCellStyle6;
            this.ESTOQUE.HeaderText = "ESTOQUE";
            this.ESTOQUE.Name = "ESTOQUE";
            this.ESTOQUE.ReadOnly = true;
            this.ESTOQUE.Width = 120;
            // 
            // EST_MIN
            // 
            this.EST_MIN.DataPropertyName = "EST_MIN";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0,00";
            this.EST_MIN.DefaultCellStyle = dataGridViewCellStyle7;
            this.EST_MIN.HeaderText = "EST_MIN";
            this.EST_MIN.Name = "EST_MIN";
            this.EST_MIN.ReadOnly = true;
            // 
            // NUM_DEPAR
            // 
            this.NUM_DEPAR.DataPropertyName = "NUM_DEPAR";
            this.NUM_DEPAR.HeaderText = "NUM_DEPAR";
            this.NUM_DEPAR.Name = "NUM_DEPAR";
            this.NUM_DEPAR.ReadOnly = true;
            this.NUM_DEPAR.Visible = false;
            // 
            // TECLA_
            // 
            this.TECLA_.DataPropertyName = "TECLA";
            this.TECLA_.HeaderText = "TECLA";
            this.TECLA_.Name = "TECLA_";
            this.TECLA_.ReadOnly = true;
            this.TECLA_.Visible = false;
            // 
            // GRANEL_
            // 
            this.GRANEL_.DataPropertyName = "GRANEL";
            this.GRANEL_.HeaderText = "GRANEL";
            this.GRANEL_.Name = "GRANEL_";
            this.GRANEL_.ReadOnly = true;
            this.GRANEL_.Visible = false;
            // 
            // DEPARTAM
            // 
            this.DEPARTAM.DataPropertyName = "DEPARTAM";
            this.DEPARTAM.HeaderText = "DEPARTAM";
            this.DEPARTAM.Name = "DEPARTAM";
            this.DEPARTAM.ReadOnly = true;
            this.DEPARTAM.Visible = false;
            // 
            // STRIB_A
            // 
            this.STRIB_A.DataPropertyName = "STRIB_A";
            this.STRIB_A.HeaderText = "STRIB_A";
            this.STRIB_A.Name = "STRIB_A";
            this.STRIB_A.ReadOnly = true;
            this.STRIB_A.Visible = false;
            // 
            // STRIB_B
            // 
            this.STRIB_B.DataPropertyName = "STRIB_B";
            this.STRIB_B.HeaderText = "STRIB_B";
            this.STRIB_B.Name = "STRIB_B";
            this.STRIB_B.ReadOnly = true;
            this.STRIB_B.Visible = false;
            // 
            // ATUALIZA_
            // 
            this.ATUALIZA_.DataPropertyName = "ATUALIZA";
            this.ATUALIZA_.HeaderText = "ATUALIZA";
            this.ATUALIZA_.Name = "ATUALIZA_";
            this.ATUALIZA_.ReadOnly = true;
            this.ATUALIZA_.Visible = false;
            // 
            // EMBAL_
            // 
            this.EMBAL_.DataPropertyName = "EMBAL";
            this.EMBAL_.HeaderText = "EMBAL";
            this.EMBAL_.Name = "EMBAL_";
            this.EMBAL_.ReadOnly = true;
            this.EMBAL_.Visible = false;
            // 
            // CUSTO_CX
            // 
            this.CUSTO_CX.DataPropertyName = "CUSTO_CX";
            this.CUSTO_CX.HeaderText = "CUSTO_CX";
            this.CUSTO_CX.Name = "CUSTO_CX";
            this.CUSTO_CX.ReadOnly = true;
            this.CUSTO_CX.Visible = false;
            // 
            // LIXO_
            // 
            this.LIXO_.DataPropertyName = "LIXO";
            this.LIXO_.HeaderText = "LIXO";
            this.LIXO_.Name = "LIXO_";
            this.LIXO_.ReadOnly = true;
            this.LIXO_.Visible = false;
            // 
            // DT_AJUSTE
            // 
            this.DT_AJUSTE.DataPropertyName = "DT_AJUSTE";
            this.DT_AJUSTE.HeaderText = "DT_AJUSTE";
            this.DT_AJUSTE.Name = "DT_AJUSTE";
            this.DT_AJUSTE.ReadOnly = true;
            this.DT_AJUSTE.Visible = false;
            // 
            // QTDE_DESC
            // 
            this.QTDE_DESC.DataPropertyName = "QTDE_DESC";
            this.QTDE_DESC.HeaderText = "QTDE_DESC";
            this.QTDE_DESC.Name = "QTDE_DESC";
            this.QTDE_DESC.ReadOnly = true;
            this.QTDE_DESC.Visible = false;
            // 
            // SETOR_
            // 
            this.SETOR_.DataPropertyName = "SETOR";
            this.SETOR_.HeaderText = "SETOR";
            this.SETOR_.Name = "SETOR_";
            this.SETOR_.ReadOnly = true;
            this.SETOR_.Visible = false;
            // 
            // VALIDADE_
            // 
            this.VALIDADE_.DataPropertyName = "VALIDADE";
            this.VALIDADE_.HeaderText = "VALIDADE";
            this.VALIDADE_.Name = "VALIDADE_";
            this.VALIDADE_.ReadOnly = true;
            this.VALIDADE_.Visible = false;
            // 
            // TECLA_B
            // 
            this.TECLA_B.DataPropertyName = "TECLA_B";
            this.TECLA_B.HeaderText = "TECLA_B";
            this.TECLA_B.Name = "TECLA_B";
            this.TECLA_B.ReadOnly = true;
            this.TECLA_B.Visible = false;
            // 
            // INDIC_B
            // 
            this.INDIC_B.DataPropertyName = "INDIC_B";
            this.INDIC_B.HeaderText = "INDIC_B";
            this.INDIC_B.Name = "INDIC_B";
            this.INDIC_B.ReadOnly = true;
            this.INDIC_B.Visible = false;
            // 
            // MARGEM
            // 
            this.MARGEM.DataPropertyName = "MARGEM";
            this.MARGEM.HeaderText = "MARGEM";
            this.MARGEM.Name = "MARGEM";
            this.MARGEM.ReadOnly = true;
            this.MARGEM.Visible = false;
            // 
            // QT_COM
            // 
            this.QT_COM.DataPropertyName = "QT_COM";
            this.QT_COM.HeaderText = "QT_COM";
            this.QT_COM.Name = "QT_COM";
            this.QT_COM.ReadOnly = true;
            this.QT_COM.Visible = false;
            // 
            // DT_COM
            // 
            this.DT_COM.DataPropertyName = "DT_COM";
            this.DT_COM.HeaderText = "DT_COM";
            this.DT_COM.Name = "DT_COM";
            this.DT_COM.ReadOnly = true;
            this.DT_COM.Visible = false;
            // 
            // VALOR_PIS
            // 
            this.VALOR_PIS.DataPropertyName = "VALOR_PIS";
            this.VALOR_PIS.HeaderText = "VALOR_PIS";
            this.VALOR_PIS.Name = "VALOR_PIS";
            this.VALOR_PIS.ReadOnly = true;
            this.VALOR_PIS.Visible = false;
            // 
            // CST_PIS
            // 
            this.CST_PIS.DataPropertyName = "CST_PIS";
            this.CST_PIS.HeaderText = "CST_PIS";
            this.CST_PIS.Name = "CST_PIS";
            this.CST_PIS.ReadOnly = true;
            this.CST_PIS.Visible = false;
            // 
            // VALOR_CONFINS
            // 
            this.VALOR_CONFINS.DataPropertyName = "VALOR_CONFINS";
            this.VALOR_CONFINS.HeaderText = "VALOR_CONFINS";
            this.VALOR_CONFINS.Name = "VALOR_CONFINS";
            this.VALOR_CONFINS.ReadOnly = true;
            this.VALOR_CONFINS.Visible = false;
            // 
            // CFOP_
            // 
            this.CFOP_.DataPropertyName = "CFOP";
            this.CFOP_.HeaderText = "CFOP";
            this.CFOP_.Name = "CFOP_";
            this.CFOP_.ReadOnly = true;
            this.CFOP_.Visible = false;
            // 
            // DESC_AUTO
            // 
            this.DESC_AUTO.DataPropertyName = "DESC_AUTO";
            this.DESC_AUTO.HeaderText = "DESC_AUTO";
            this.DESC_AUTO.Name = "DESC_AUTO";
            this.DESC_AUTO.ReadOnly = true;
            this.DESC_AUTO.Visible = false;
            // 
            // CST_COFINS
            // 
            this.CST_COFINS.DataPropertyName = "CST_COFINS";
            this.CST_COFINS.HeaderText = "CST_COFINS";
            this.CST_COFINS.Name = "CST_COFINS";
            this.CST_COFINS.ReadOnly = true;
            this.CST_COFINS.Visible = false;
            // 
            // ORIGEM_PRODUTO
            // 
            this.ORIGEM_PRODUTO.DataPropertyName = "ORIGEM_PRODUTO";
            this.ORIGEM_PRODUTO.HeaderText = "ORIGEM_PRODUTO";
            this.ORIGEM_PRODUTO.Name = "ORIGEM_PRODUTO";
            this.ORIGEM_PRODUTO.ReadOnly = true;
            this.ORIGEM_PRODUTO.Visible = false;
            // 
            // ICMS_
            // 
            this.ICMS_.DataPropertyName = "ICMS";
            this.ICMS_.HeaderText = "ICMS";
            this.ICMS_.Name = "ICMS_";
            this.ICMS_.ReadOnly = true;
            this.ICMS_.Visible = false;
            // 
            // ICMS_CST
            // 
            this.ICMS_CST.DataPropertyName = "ICMS_CST";
            this.ICMS_CST.HeaderText = "ICMS_CST";
            this.ICMS_CST.Name = "ICMS_CST";
            this.ICMS_CST.ReadOnly = true;
            this.ICMS_CST.Visible = false;
            // 
            // NCM_
            // 
            this.NCM_.DataPropertyName = "NCM";
            this.NCM_.HeaderText = "NCM";
            this.NCM_.Name = "NCM_";
            this.NCM_.ReadOnly = true;
            this.NCM_.Visible = false;
            // 
            // colCest
            // 
            this.colCest.DataPropertyName = "CEST";
            this.colCest.HeaderText = "CEST";
            this.colCest.Name = "colCest";
            this.colCest.ReadOnly = true;
            this.colCest.Visible = false;
            // 
            // btnSolicitarPedido
            // 
            this.btnSolicitarPedido.Location = new System.Drawing.Point(954, 552);
            this.btnSolicitarPedido.Margin = new System.Windows.Forms.Padding(4);
            this.btnSolicitarPedido.Name = "btnSolicitarPedido";
            this.btnSolicitarPedido.Size = new System.Drawing.Size(270, 31);
            this.btnSolicitarPedido.TabIndex = 155;
            this.btnSolicitarPedido.Text = "SOLICITAR PEDIDO";
            this.btnSolicitarPedido.UseVisualStyleBackColor = true;
            // 
            // btnImprimirRelatorio
            // 
            this.btnImprimirRelatorio.Location = new System.Drawing.Point(676, 552);
            this.btnImprimirRelatorio.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirRelatorio.Name = "btnImprimirRelatorio";
            this.btnImprimirRelatorio.Size = new System.Drawing.Size(270, 31);
            this.btnImprimirRelatorio.TabIndex = 156;
            this.btnImprimirRelatorio.Text = "IMPRIMIR RELATORIO";
            this.btnImprimirRelatorio.UseVisualStyleBackColor = true;
            // 
            // frmRelatorioEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 612);
            this.Controls.Add(this.btnImprimirRelatorio);
            this.Controls.Add(this.btnSolicitarPedido);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgvProduto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelatorioEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATORIO PRODUTO BAIXO ESTOQUE";
            this.Load += new System.EventHandler(this.frmRelatorioEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_BARRA_;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_INT_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRICAO_;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECO_;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNID_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn REDUCAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTO_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTOQUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EST_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM_DEPAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECLA_;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRANEL_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STRIB_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn STRIB_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATUALIZA_;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMBAL_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTO_CX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIXO_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT_AJUSTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTDE_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SETOR_;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALIDADE_;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECLA_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn INDIC_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn MARGEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QT_COM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT_COM;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR_PIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_PIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR_CONFINS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFOP_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_AUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_COFINS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORIGEM_PRODUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICMS_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICMS_CST;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCM_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCest;
        private System.Windows.Forms.Button btnSolicitarPedido;
        private System.Windows.Forms.Button btnImprimirRelatorio;
    }
}