namespace CONTROLE.OTICA
{
    partial class frmSaidaPedido
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIdUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblArquivos = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVenda = new System.Windows.Forms.DataGridView();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDpOEPerto = new System.Windows.Forms.TextBox();
            this.txtEixoOEPerto = new System.Windows.Forms.TextBox();
            this.txtCiliOEPerto = new System.Windows.Forms.TextBox();
            this.txtEsfOEPerto = new System.Windows.Forms.TextBox();
            this.txtDpODPerto = new System.Windows.Forms.TextBox();
            this.txtEixoODPerto = new System.Windows.Forms.TextBox();
            this.txtCiliODPerto = new System.Windows.Forms.TextBox();
            this.txtEsfODPerto = new System.Windows.Forms.TextBox();
            this.txtDpOELonge = new System.Windows.Forms.TextBox();
            this.txtEixoOELonge = new System.Windows.Forms.TextBox();
            this.txtCiliOELonge = new System.Windows.Forms.TextBox();
            this.txtEsfOELonge = new System.Windows.Forms.TextBox();
            this.txtDpODLonge = new System.Windows.Forms.TextBox();
            this.txtEixoODLonge = new System.Windows.Forms.TextBox();
            this.txtCiliODLonge = new System.Windows.Forms.TextBox();
            this.txtEsfODLonge = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colIdProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCodBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblIdUsuario,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblArquivos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1130, 22);
            this.statusStrip1.TabIndex = 49;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "COD.USUARIO:";
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(25, 17);
            this.lblIdUsuario.Text = "000";
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel3.Text = "Arquivo:";
            // 
            // lblArquivos
            // 
            this.lblArquivos.Name = "lblArquivos";
            this.lblArquivos.Size = new System.Drawing.Size(16, 17);
            this.lblArquivos.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvVenda);
            this.groupBox2.Controls.Add(this.txtCodigoBarras);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtObservacao);
            this.groupBox2.Location = new System.Drawing.Point(556, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 442);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DADOS DA SAIDA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "CODIGOS";
            // 
            // dgvVenda
            // 
            this.dgvVenda.AllowUserToAddRows = false;
            this.dgvVenda.AllowUserToDeleteRows = false;
            this.dgvVenda.BackgroundColor = System.Drawing.Color.White;
            this.dgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProd,
            this.colId,
            this.colDel,
            this.colCodBarras,
            this.colDescricao,
            this.colQtde,
            this.colEstoque});
            this.dgvVenda.Location = new System.Drawing.Point(14, 116);
            this.dgvVenda.Name = "dgvVenda";
            this.dgvVenda.ReadOnly = true;
            this.dgvVenda.RowHeadersVisible = false;
            this.dgvVenda.Size = new System.Drawing.Size(549, 240);
            this.dgvVenda.TabIndex = 1;
            this.dgvVenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenda_CellContentClick);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarras.ForeColor = System.Drawing.Color.Yellow;
            this.txtCodigoBarras.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCodigoBarras.Location = new System.Drawing.Point(14, 45);
            this.txtCodigoBarras.MaxLength = 14;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(548, 65);
            this.txtCodigoBarras.TabIndex = 0;
            this.txtCodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "OBSERVAÇÃO";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(14, 381);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(548, 61);
            this.txtObservacao.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(432, 98);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(164, 20);
            this.lblEmail.TabIndex = 53;
            this.lblEmail.Text = "email@hotmail.com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(370, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "E-Mail:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(232, 98);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(127, 20);
            this.lblTel.TabIndex = 51;
            this.lblTel.Text = "(00)0000-0000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(195, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Tel:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Teal;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(561, 577);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(551, 37);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Cadastro de Saida";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDpOEPerto);
            this.groupBox1.Controls.Add(this.txtEixoOEPerto);
            this.groupBox1.Controls.Add(this.txtCiliOEPerto);
            this.groupBox1.Controls.Add(this.txtEsfOEPerto);
            this.groupBox1.Controls.Add(this.txtDpODPerto);
            this.groupBox1.Controls.Add(this.txtEixoODPerto);
            this.groupBox1.Controls.Add(this.txtCiliODPerto);
            this.groupBox1.Controls.Add(this.txtEsfODPerto);
            this.groupBox1.Controls.Add(this.txtDpOELonge);
            this.groupBox1.Controls.Add(this.txtEixoOELonge);
            this.groupBox1.Controls.Add(this.txtCiliOELonge);
            this.groupBox1.Controls.Add(this.txtEsfOELonge);
            this.groupBox1.Controls.Add(this.txtDpODLonge);
            this.groupBox1.Controls.Add(this.txtEixoODLonge);
            this.groupBox1.Controls.Add(this.txtCiliODLonge);
            this.groupBox1.Controls.Add(this.txtEsfODLonge);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(3, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 492);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DESCRIÇÃO DE LENTES";
            // 
            // txtDpOEPerto
            // 
            this.txtDpOEPerto.BackColor = System.Drawing.Color.White;
            this.txtDpOEPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpOEPerto.Location = new System.Drawing.Point(447, 426);
            this.txtDpOEPerto.Multiline = true;
            this.txtDpOEPerto.Name = "txtDpOEPerto";
            this.txtDpOEPerto.ReadOnly = true;
            this.txtDpOEPerto.Size = new System.Drawing.Size(74, 34);
            this.txtDpOEPerto.TabIndex = 15;
            this.txtDpOEPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEixoOEPerto
            // 
            this.txtEixoOEPerto.BackColor = System.Drawing.Color.White;
            this.txtEixoOEPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEixoOEPerto.Location = new System.Drawing.Point(355, 426);
            this.txtEixoOEPerto.Multiline = true;
            this.txtEixoOEPerto.Name = "txtEixoOEPerto";
            this.txtEixoOEPerto.ReadOnly = true;
            this.txtEixoOEPerto.Size = new System.Drawing.Size(86, 34);
            this.txtEixoOEPerto.TabIndex = 14;
            this.txtEixoOEPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCiliOEPerto
            // 
            this.txtCiliOEPerto.BackColor = System.Drawing.Color.White;
            this.txtCiliOEPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiliOEPerto.Location = new System.Drawing.Point(234, 426);
            this.txtCiliOEPerto.Multiline = true;
            this.txtCiliOEPerto.Name = "txtCiliOEPerto";
            this.txtCiliOEPerto.ReadOnly = true;
            this.txtCiliOEPerto.Size = new System.Drawing.Size(115, 34);
            this.txtCiliOEPerto.TabIndex = 13;
            this.txtCiliOEPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsfOEPerto
            // 
            this.txtEsfOEPerto.BackColor = System.Drawing.Color.White;
            this.txtEsfOEPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfOEPerto.Location = new System.Drawing.Point(130, 426);
            this.txtEsfOEPerto.Multiline = true;
            this.txtEsfOEPerto.Name = "txtEsfOEPerto";
            this.txtEsfOEPerto.ReadOnly = true;
            this.txtEsfOEPerto.Size = new System.Drawing.Size(99, 34);
            this.txtEsfOEPerto.TabIndex = 12;
            this.txtEsfOEPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDpODPerto
            // 
            this.txtDpODPerto.BackColor = System.Drawing.Color.White;
            this.txtDpODPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpODPerto.Location = new System.Drawing.Point(447, 387);
            this.txtDpODPerto.Multiline = true;
            this.txtDpODPerto.Name = "txtDpODPerto";
            this.txtDpODPerto.ReadOnly = true;
            this.txtDpODPerto.Size = new System.Drawing.Size(74, 34);
            this.txtDpODPerto.TabIndex = 11;
            this.txtDpODPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEixoODPerto
            // 
            this.txtEixoODPerto.BackColor = System.Drawing.Color.White;
            this.txtEixoODPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEixoODPerto.Location = new System.Drawing.Point(355, 387);
            this.txtEixoODPerto.Multiline = true;
            this.txtEixoODPerto.Name = "txtEixoODPerto";
            this.txtEixoODPerto.ReadOnly = true;
            this.txtEixoODPerto.Size = new System.Drawing.Size(86, 34);
            this.txtEixoODPerto.TabIndex = 10;
            this.txtEixoODPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCiliODPerto
            // 
            this.txtCiliODPerto.BackColor = System.Drawing.Color.White;
            this.txtCiliODPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiliODPerto.Location = new System.Drawing.Point(234, 387);
            this.txtCiliODPerto.Multiline = true;
            this.txtCiliODPerto.Name = "txtCiliODPerto";
            this.txtCiliODPerto.ReadOnly = true;
            this.txtCiliODPerto.Size = new System.Drawing.Size(115, 34);
            this.txtCiliODPerto.TabIndex = 9;
            this.txtCiliODPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsfODPerto
            // 
            this.txtEsfODPerto.BackColor = System.Drawing.Color.White;
            this.txtEsfODPerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfODPerto.Location = new System.Drawing.Point(130, 387);
            this.txtEsfODPerto.Multiline = true;
            this.txtEsfODPerto.Name = "txtEsfODPerto";
            this.txtEsfODPerto.ReadOnly = true;
            this.txtEsfODPerto.Size = new System.Drawing.Size(99, 34);
            this.txtEsfODPerto.TabIndex = 8;
            this.txtEsfODPerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDpOELonge
            // 
            this.txtDpOELonge.BackColor = System.Drawing.Color.White;
            this.txtDpOELonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpOELonge.Location = new System.Drawing.Point(447, 350);
            this.txtDpOELonge.Multiline = true;
            this.txtDpOELonge.Name = "txtDpOELonge";
            this.txtDpOELonge.ReadOnly = true;
            this.txtDpOELonge.Size = new System.Drawing.Size(74, 34);
            this.txtDpOELonge.TabIndex = 7;
            this.txtDpOELonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEixoOELonge
            // 
            this.txtEixoOELonge.BackColor = System.Drawing.Color.White;
            this.txtEixoOELonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEixoOELonge.Location = new System.Drawing.Point(355, 350);
            this.txtEixoOELonge.Multiline = true;
            this.txtEixoOELonge.Name = "txtEixoOELonge";
            this.txtEixoOELonge.ReadOnly = true;
            this.txtEixoOELonge.Size = new System.Drawing.Size(86, 34);
            this.txtEixoOELonge.TabIndex = 6;
            this.txtEixoOELonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCiliOELonge
            // 
            this.txtCiliOELonge.BackColor = System.Drawing.Color.White;
            this.txtCiliOELonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiliOELonge.Location = new System.Drawing.Point(234, 350);
            this.txtCiliOELonge.Multiline = true;
            this.txtCiliOELonge.Name = "txtCiliOELonge";
            this.txtCiliOELonge.ReadOnly = true;
            this.txtCiliOELonge.Size = new System.Drawing.Size(115, 34);
            this.txtCiliOELonge.TabIndex = 5;
            this.txtCiliOELonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsfOELonge
            // 
            this.txtEsfOELonge.BackColor = System.Drawing.Color.White;
            this.txtEsfOELonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfOELonge.Location = new System.Drawing.Point(130, 350);
            this.txtEsfOELonge.Multiline = true;
            this.txtEsfOELonge.Name = "txtEsfOELonge";
            this.txtEsfOELonge.ReadOnly = true;
            this.txtEsfOELonge.Size = new System.Drawing.Size(99, 34);
            this.txtEsfOELonge.TabIndex = 4;
            this.txtEsfOELonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDpODLonge
            // 
            this.txtDpODLonge.BackColor = System.Drawing.Color.White;
            this.txtDpODLonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpODLonge.Location = new System.Drawing.Point(447, 312);
            this.txtDpODLonge.Multiline = true;
            this.txtDpODLonge.Name = "txtDpODLonge";
            this.txtDpODLonge.ReadOnly = true;
            this.txtDpODLonge.Size = new System.Drawing.Size(74, 34);
            this.txtDpODLonge.TabIndex = 3;
            this.txtDpODLonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEixoODLonge
            // 
            this.txtEixoODLonge.BackColor = System.Drawing.Color.White;
            this.txtEixoODLonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEixoODLonge.Location = new System.Drawing.Point(355, 312);
            this.txtEixoODLonge.Multiline = true;
            this.txtEixoODLonge.Name = "txtEixoODLonge";
            this.txtEixoODLonge.ReadOnly = true;
            this.txtEixoODLonge.Size = new System.Drawing.Size(86, 34);
            this.txtEixoODLonge.TabIndex = 2;
            this.txtEixoODLonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCiliODLonge
            // 
            this.txtCiliODLonge.BackColor = System.Drawing.Color.White;
            this.txtCiliODLonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiliODLonge.Location = new System.Drawing.Point(234, 312);
            this.txtCiliODLonge.Multiline = true;
            this.txtCiliODLonge.Name = "txtCiliODLonge";
            this.txtCiliODLonge.ReadOnly = true;
            this.txtCiliODLonge.Size = new System.Drawing.Size(115, 34);
            this.txtCiliODLonge.TabIndex = 1;
            this.txtCiliODLonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEsfODLonge
            // 
            this.txtEsfODLonge.BackColor = System.Drawing.Color.White;
            this.txtEsfODLonge.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfODLonge.Location = new System.Drawing.Point(130, 312);
            this.txtEsfODLonge.Multiline = true;
            this.txtEsfODLonge.Name = "txtEsfODLonge";
            this.txtEsfODLonge.ReadOnly = true;
            this.txtEsfODLonge.Size = new System.Drawing.Size(99, 34);
            this.txtEsfODLonge.TabIndex = 0;
            this.txtEsfODLonge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblNumPedido);
            this.panel1.Location = new System.Drawing.Point(838, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 80);
            this.panel1.TabIndex = 46;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(88, 43);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 25);
            this.lblData.TabIndex = 12;
            this.lblData.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "DATA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "NUMERO:";
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNumPedido.Location = new System.Drawing.Point(171, 5);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(100, 33);
            this.lblNumPedido.TabIndex = 9;
            this.lblNumPedido.Text = "00000";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(287, 62);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(33, 25);
            this.lblCliente.TabIndex = 48;
            this.lblCliente.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(380, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 33);
            this.label1.TabIndex = 45;
            this.label1.Text = "SAIDA DO PEDIDO";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::CONTROLE.OTICA.Properties.Resources.Alarm_Error_icon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = global::CONTROLE.OTICA.Properties.Resources.Finance_Invoice_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(838, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "F5 - PESQUISAR PRODUTOS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CONTROLE.OTICA.Properties.Resources.modelo_universal_de_receita_de_oculos;
            this.pictureBox2.Location = new System.Drawing.Point(6, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(530, 459);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::CONTROLE.OTICA.Properties.Resources.eye_icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // colIdProd
            // 
            this.colIdProd.DataPropertyName = "COD_INT";
            this.colIdProd.HeaderText = "ID_PRODUTO";
            this.colIdProd.Name = "colIdProd";
            this.colIdProd.ReadOnly = true;
            this.colIdProd.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ID";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "";
            this.colDel.Image = global::CONTROLE.OTICA.Properties.Resources.Alarm_Error_icon;
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Width = 50;
            // 
            // colCodBarras
            // 
            this.colCodBarras.DataPropertyName = "COD_BARRA";
            this.colCodBarras.HeaderText = "COD.BARRAS";
            this.colCodBarras.Name = "colCodBarras";
            this.colCodBarras.ReadOnly = true;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "DESCRICAO";
            this.colDescricao.HeaderText = "DESCRIÇÃO";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 390;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "QTDE";
            this.colQtde.HeaderText = "QTDE";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Visible = false;
            // 
            // colEstoque
            // 
            this.colEstoque.DataPropertyName = "ESTOQUE";
            this.colEstoque.HeaderText = "ESTOQUE";
            this.colEstoque.Name = "colEstoque";
            this.colEstoque.ReadOnly = true;
            this.colEstoque.Visible = false;
            // 
            // frmSaidaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1130, 647);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaidaPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSaidaPedido_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblIdUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblArquivos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDpOEPerto;
        private System.Windows.Forms.TextBox txtEixoOEPerto;
        private System.Windows.Forms.TextBox txtCiliOEPerto;
        private System.Windows.Forms.TextBox txtEsfOEPerto;
        private System.Windows.Forms.TextBox txtDpODPerto;
        private System.Windows.Forms.TextBox txtEixoODPerto;
        private System.Windows.Forms.TextBox txtCiliODPerto;
        private System.Windows.Forms.TextBox txtEsfODPerto;
        private System.Windows.Forms.TextBox txtDpOELonge;
        private System.Windows.Forms.TextBox txtEixoOELonge;
        private System.Windows.Forms.TextBox txtCiliOELonge;
        private System.Windows.Forms.TextBox txtEsfOELonge;
        private System.Windows.Forms.TextBox txtDpODLonge;
        private System.Windows.Forms.TextBox txtEixoODLonge;
        private System.Windows.Forms.TextBox txtCiliODLonge;
        private System.Windows.Forms.TextBox txtEsfODLonge;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.DataGridView dgvVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoque;
    }
}