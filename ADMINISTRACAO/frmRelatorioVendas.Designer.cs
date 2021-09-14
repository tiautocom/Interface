namespace ADMINISTRACAO
{
    partial class frmRelatorioVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQtde = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvPesquisaVendas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtFim = new System.Windows.Forms.DateTimePicker();
            this.txtDtInici = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGerarRelatorios = new System.Windows.Forms.Button();
            this.cbTipoRelatorios = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPesquisarNumCAixa = new System.Windows.Forms.Button();
            this.cbNumCaixa = new System.Windows.Forms.ComboBox();
            this.btnPesquisarGerais = new System.Windows.Forms.Button();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExportarDados = new System.Windows.Forms.Button();
            this.cbImports = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbGBUsuarios = new System.Windows.Forms.RadioButton();
            this.rbGBCodBarras = new System.Windows.Forms.RadioButton();
            this.rbGBDescricao = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaVendas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblQtde});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1343, 22);
            this.statusStrip1.TabIndex = 160;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "QTDE DE REGISTROS:";
            // 
            // lblQtde
            // 
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(31, 17);
            this.lblQtde.Text = "0000";
            // 
            // dgvPesquisaVendas
            // 
            this.dgvPesquisaVendas.AllowUserToAddRows = false;
            this.dgvPesquisaVendas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvPesquisaVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPesquisaVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaVendas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPesquisaVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPesquisaVendas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPesquisaVendas.Location = new System.Drawing.Point(3, 87);
            this.dgvPesquisaVendas.Name = "dgvPesquisaVendas";
            this.dgvPesquisaVendas.ReadOnly = true;
            this.dgvPesquisaVendas.Size = new System.Drawing.Size(1336, 516);
            this.dgvPesquisaVendas.TabIndex = 161;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDtFim);
            this.groupBox1.Controls.Add(this.txtDtInici);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 75);
            this.groupBox1.TabIndex = 162;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PESQUISAR VENDA DATAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "FINAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "INICIO";
            // 
            // txtDtFim
            // 
            this.txtDtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtFim.Location = new System.Drawing.Point(128, 43);
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.Size = new System.Drawing.Size(113, 20);
            this.txtDtFim.TabIndex = 1;
            // 
            // txtDtInici
            // 
            this.txtDtInici.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtInici.Location = new System.Drawing.Point(9, 43);
            this.txtDtInici.Name = "txtDtInici";
            this.txtDtInici.Size = new System.Drawing.Size(113, 20);
            this.txtDtInici.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnGerarRelatorios);
            this.groupBox2.Controls.Add(this.cbTipoRelatorios);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(258, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 75);
            this.groupBox2.TabIndex = 163;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RELATÓRIOS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "SELECIONE TIPO DESEJADO";
            // 
            // btnGerarRelatorios
            // 
            this.btnGerarRelatorios.BackColor = System.Drawing.Color.White;
            this.btnGerarRelatorios.Image = global::ADMINISTRACAO.Properties.Resources.Zoom_icon;
            this.btnGerarRelatorios.Location = new System.Drawing.Point(294, 42);
            this.btnGerarRelatorios.Name = "btnGerarRelatorios";
            this.btnGerarRelatorios.Size = new System.Drawing.Size(44, 23);
            this.btnGerarRelatorios.TabIndex = 5;
            this.btnGerarRelatorios.UseVisualStyleBackColor = false;
            this.btnGerarRelatorios.Click += new System.EventHandler(this.btnGerarRelatorios_Click);
            // 
            // cbTipoRelatorios
            // 
            this.cbTipoRelatorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoRelatorios.FormattingEnabled = true;
            this.cbTipoRelatorios.Items.AddRange(new object[] {
            "1 - GERAL",
            "2 - ABC",
            "3 - DEPARTAMENTO",
            "4 - CAIXAS"});
            this.cbTipoRelatorios.Location = new System.Drawing.Point(6, 43);
            this.cbTipoRelatorios.Name = "cbTipoRelatorios";
            this.cbTipoRelatorios.Size = new System.Drawing.Size(282, 21);
            this.cbTipoRelatorios.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnPesquisarNumCAixa);
            this.groupBox3.Controls.Add(this.cbNumCaixa);
            this.groupBox3.Controls.Add(this.btnPesquisarGerais);
            this.groupBox3.Controls.Add(this.cbUsuario);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(612, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 75);
            this.groupBox3.TabIndex = 164;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GERAIS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(273, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "CAIXAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "USUÁRIOS";
            // 
            // btnPesquisarNumCAixa
            // 
            this.btnPesquisarNumCAixa.BackColor = System.Drawing.Color.White;
            this.btnPesquisarNumCAixa.Image = global::ADMINISTRACAO.Properties.Resources.Zoom_icon;
            this.btnPesquisarNumCAixa.Location = new System.Drawing.Point(386, 42);
            this.btnPesquisarNumCAixa.Name = "btnPesquisarNumCAixa";
            this.btnPesquisarNumCAixa.Size = new System.Drawing.Size(44, 23);
            this.btnPesquisarNumCAixa.TabIndex = 9;
            this.btnPesquisarNumCAixa.UseVisualStyleBackColor = false;
            this.btnPesquisarNumCAixa.Click += new System.EventHandler(this.btnPesquisarNumCAixa_Click);
            // 
            // cbNumCaixa
            // 
            this.cbNumCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumCaixa.FormattingEnabled = true;
            this.cbNumCaixa.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04"});
            this.cbNumCaixa.Location = new System.Drawing.Point(273, 43);
            this.cbNumCaixa.Name = "cbNumCaixa";
            this.cbNumCaixa.Size = new System.Drawing.Size(109, 21);
            this.cbNumCaixa.TabIndex = 8;
            // 
            // btnPesquisarGerais
            // 
            this.btnPesquisarGerais.BackColor = System.Drawing.Color.White;
            this.btnPesquisarGerais.Image = global::ADMINISTRACAO.Properties.Resources.Zoom_icon;
            this.btnPesquisarGerais.Location = new System.Drawing.Point(221, 42);
            this.btnPesquisarGerais.Name = "btnPesquisarGerais";
            this.btnPesquisarGerais.Size = new System.Drawing.Size(44, 23);
            this.btnPesquisarGerais.TabIndex = 7;
            this.btnPesquisarGerais.UseVisualStyleBackColor = false;
            this.btnPesquisarGerais.Click += new System.EventHandler(this.btnPesquisarGerais_Click);
            // 
            // cbUsuario
            // 
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(6, 43);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(212, 21);
            this.cbUsuario.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnExportarDados);
            this.groupBox4.Controls.Add(this.cbImports);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1055, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 75);
            this.groupBox4.TabIndex = 165;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EXPORTAR DADOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "SELECIONE TIPO DESEJADO";
            // 
            // btnExportarDados
            // 
            this.btnExportarDados.BackColor = System.Drawing.Color.White;
            this.btnExportarDados.Image = global::ADMINISTRACAO.Properties.Resources.Zoom_icon;
            this.btnExportarDados.Location = new System.Drawing.Point(225, 42);
            this.btnExportarDados.Name = "btnExportarDados";
            this.btnExportarDados.Size = new System.Drawing.Size(44, 23);
            this.btnExportarDados.TabIndex = 7;
            this.btnExportarDados.UseVisualStyleBackColor = false;
            this.btnExportarDados.Click += new System.EventHandler(this.btnExportarDados_Click);
            // 
            // cbImports
            // 
            this.cbImports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImports.FormattingEnabled = true;
            this.cbImports.Items.AddRange(new object[] {
            "1 -EXECEL",
            "2 - PDF",
            "3 - WORD"});
            this.cbImports.Location = new System.Drawing.Point(6, 43);
            this.cbImports.Name = "cbImports";
            this.cbImports.Size = new System.Drawing.Size(211, 21);
            this.cbImports.TabIndex = 6;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1100, 615);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(234, 31);
            this.txtTotal.TabIndex = 166;
            this.txtTotal.Text = "0,00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(971, 618);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 24);
            this.label3.TabIndex = 167;
            this.label3.Text = "Venda Total:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbGBUsuarios);
            this.groupBox5.Controls.Add(this.rbGBCodBarras);
            this.groupBox5.Controls.Add(this.rbGBDescricao);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(3, 609);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(489, 46);
            this.groupBox5.TabIndex = 168;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AGRUPAR PESQUISA";
            // 
            // rbGBUsuarios
            // 
            this.rbGBUsuarios.AutoSize = true;
            this.rbGBUsuarios.Location = new System.Drawing.Point(239, 23);
            this.rbGBUsuarios.Name = "rbGBUsuarios";
            this.rbGBUsuarios.Size = new System.Drawing.Size(89, 17);
            this.rbGBUsuarios.TabIndex = 3;
            this.rbGBUsuarios.TabStop = true;
            this.rbGBUsuarios.Text = "USUÁRIOS";
            this.rbGBUsuarios.UseVisualStyleBackColor = true;
            this.rbGBUsuarios.CheckedChanged += new System.EventHandler(this.rbGBUsuarios_CheckedChanged);
            // 
            // rbGBCodBarras
            // 
            this.rbGBCodBarras.AutoSize = true;
            this.rbGBCodBarras.Location = new System.Drawing.Point(128, 23);
            this.rbGBCodBarras.Name = "rbGBCodBarras";
            this.rbGBCodBarras.Size = new System.Drawing.Size(105, 17);
            this.rbGBCodBarras.TabIndex = 1;
            this.rbGBCodBarras.TabStop = true;
            this.rbGBCodBarras.Text = "CÓD.BARRAS";
            this.rbGBCodBarras.UseVisualStyleBackColor = true;
            this.rbGBCodBarras.CheckedChanged += new System.EventHandler(this.rbGBCodBarras_CheckedChanged);
            // 
            // rbGBDescricao
            // 
            this.rbGBDescricao.AutoSize = true;
            this.rbGBDescricao.Location = new System.Drawing.Point(12, 23);
            this.rbGBDescricao.Name = "rbGBDescricao";
            this.rbGBDescricao.Size = new System.Drawing.Size(96, 17);
            this.rbGBDescricao.TabIndex = 0;
            this.rbGBDescricao.TabStop = true;
            this.rbGBDescricao.Text = "DESCRIÇÃO";
            this.rbGBDescricao.UseVisualStyleBackColor = true;
            this.rbGBDescricao.CheckedChanged += new System.EventHandler(this.rbGBDescricao_CheckedChanged);
            // 
            // frmRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 680);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPesquisaVendas);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório  de Vendas";
            this.Load += new System.EventHandler(this.frmRelatorioVendas_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaVendas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblQtde;
        private System.Windows.Forms.DataGridView dgvPesquisaVendas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtFim;
        private System.Windows.Forms.DateTimePicker txtDtInici;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGerarRelatorios;
        private System.Windows.Forms.ComboBox cbTipoRelatorios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPesquisarGerais;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExportarDados;
        private System.Windows.Forms.ComboBox cbImports;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPesquisarNumCAixa;
        private System.Windows.Forms.ComboBox cbNumCaixa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbGBUsuarios;
        private System.Windows.Forms.RadioButton rbGBCodBarras;
        private System.Windows.Forms.RadioButton rbGBDescricao;
    }
}