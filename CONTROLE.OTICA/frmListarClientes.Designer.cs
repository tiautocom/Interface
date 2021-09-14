namespace CONTROLE.OTICA
{
    partial class frmListarClientes
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.colIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeRazao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCpfCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRgIe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDadosPesquisa = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSel = new System.Windows.Forms.DataGridViewImageColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPEsquisarCelular = new System.Windows.Forms.Button();
            this.btnPesquisarEmail = new System.Windows.Forms.Button();
            this.btnPesquisarCpfCnpj = new System.Windows.Forms.Button();
            this.btnPEsquisarNome = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSel,
            this.colIdCliente,
            this.colNomeRazao,
            this.colCpfCnpj,
            this.colRgIe,
            this.colTel,
            this.colEmail});
            this.dgvClientes.Location = new System.Drawing.Point(11, 120);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.Size = new System.Drawing.Size(1325, 528);
            this.dgvClientes.TabIndex = 9;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // colIdCliente
            // 
            this.colIdCliente.DataPropertyName = "CLIENTE_ID";
            dataGridViewCellStyle2.NullValue = "000";
            this.colIdCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIdCliente.HeaderText = "CÓDIGO";
            this.colIdCliente.Name = "colIdCliente";
            this.colIdCliente.ReadOnly = true;
            this.colIdCliente.Width = 70;
            // 
            // colNomeRazao
            // 
            this.colNomeRazao.DataPropertyName = "NOME";
            this.colNomeRazao.HeaderText = "NOME/RAZÃO";
            this.colNomeRazao.Name = "colNomeRazao";
            this.colNomeRazao.ReadOnly = true;
            this.colNomeRazao.Width = 730;
            // 
            // colCpfCnpj
            // 
            this.colCpfCnpj.DataPropertyName = "CPF_CNPJ";
            this.colCpfCnpj.HeaderText = "CPF/CNPJ";
            this.colCpfCnpj.Name = "colCpfCnpj";
            this.colCpfCnpj.ReadOnly = true;
            this.colCpfCnpj.Width = 130;
            // 
            // colRgIe
            // 
            this.colRgIe.DataPropertyName = "RG_INSC_EST";
            this.colRgIe.HeaderText = "RG/I.E";
            this.colRgIe.Name = "colRgIe";
            this.colRgIe.ReadOnly = true;
            this.colRgIe.Width = 130;
            // 
            // colTel
            // 
            this.colTel.DataPropertyName = "TELEFONE";
            this.colTel.HeaderText = "TELEFONE";
            this.colTel.Name = "colTel";
            this.colTel.ReadOnly = true;
            this.colTel.Visible = false;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "EMAIL";
            this.colEmail.HeaderText = "E-MAIL";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel2.Text = "000";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel1.Text = "CODIGO USUARIO:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1348, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDadosPesquisa
            // 
            this.lblDadosPesquisa.AutoSize = true;
            this.lblDadosPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDadosPesquisa.Location = new System.Drawing.Point(531, 33);
            this.lblDadosPesquisa.Name = "lblDadosPesquisa";
            this.lblDadosPesquisa.Size = new System.Drawing.Size(214, 16);
            this.lblDadosPesquisa.TabIndex = 5;
            this.lblDadosPesquisa.Text = "DADOS DE PESQUISA NOME";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(531, 56);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(632, 38);
            this.txtPesquisar.TabIndex = 0;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblDadosPesquisa);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Controls.Add(this.btnPEsquisarCelular);
            this.groupBox1.Controls.Add(this.btnPesquisarEmail);
            this.groupBox1.Controls.Add(this.btnPesquisarCpfCnpj);
            this.groupBox1.Controls.Add(this.btnPEsquisarNome);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1325, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE PESQUISAS";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "FICHA CREDITO";
            this.dataGridViewImageColumn1.Image = global::CONTROLE.OTICA.Properties.Resources.credit_cards_icon__1_;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 120;
            // 
            // colSel
            // 
            this.colSel.HeaderText = "";
            this.colSel.Image = global::CONTROLE.OTICA.Properties.Resources.Actions_user_group_new_icon__2_;
            this.colSel.Name = "colSel";
            this.colSel.ReadOnly = true;
            this.colSel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSel.Width = 40;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::CONTROLE.OTICA.Properties.Resources.Actions_user_group_new_icon__1_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(1182, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 61);
            this.button1.TabIndex = 6;
            this.button1.Tag = "4";
            this.button1.Text = "NOVO CLIENTE";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPEsquisarCelular
            // 
            this.btnPEsquisarCelular.BackColor = System.Drawing.Color.White;
            this.btnPEsquisarCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPEsquisarCelular.Image = global::CONTROLE.OTICA.Properties.Resources.whatsapp_icon;
            this.btnPEsquisarCelular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPEsquisarCelular.Location = new System.Drawing.Point(398, 33);
            this.btnPEsquisarCelular.Name = "btnPEsquisarCelular";
            this.btnPEsquisarCelular.Size = new System.Drawing.Size(122, 61);
            this.btnPEsquisarCelular.TabIndex = 4;
            this.btnPEsquisarCelular.Tag = "4";
            this.btnPEsquisarCelular.Text = "CELULAR";
            this.btnPEsquisarCelular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPEsquisarCelular.UseVisualStyleBackColor = false;
            this.btnPEsquisarCelular.Click += new System.EventHandler(this.btnPEsquisarCelular_Click);
            // 
            // btnPesquisarEmail
            // 
            this.btnPesquisarEmail.BackColor = System.Drawing.Color.White;
            this.btnPesquisarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarEmail.Image = global::CONTROLE.OTICA.Properties.Resources.Mail_icon;
            this.btnPesquisarEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPesquisarEmail.Location = new System.Drawing.Point(268, 33);
            this.btnPesquisarEmail.Name = "btnPesquisarEmail";
            this.btnPesquisarEmail.Size = new System.Drawing.Size(122, 61);
            this.btnPesquisarEmail.TabIndex = 3;
            this.btnPesquisarEmail.Tag = "3";
            this.btnPesquisarEmail.Text = "EMAIL";
            this.btnPesquisarEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPesquisarEmail.UseVisualStyleBackColor = false;
            this.btnPesquisarEmail.Click += new System.EventHandler(this.btnPesquisarEmail_Click);
            // 
            // btnPesquisarCpfCnpj
            // 
            this.btnPesquisarCpfCnpj.BackColor = System.Drawing.Color.White;
            this.btnPesquisarCpfCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarCpfCnpj.Image = global::CONTROLE.OTICA.Properties.Resources.User_Files_icon;
            this.btnPesquisarCpfCnpj.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPesquisarCpfCnpj.Location = new System.Drawing.Point(138, 33);
            this.btnPesquisarCpfCnpj.Name = "btnPesquisarCpfCnpj";
            this.btnPesquisarCpfCnpj.Size = new System.Drawing.Size(122, 61);
            this.btnPesquisarCpfCnpj.TabIndex = 2;
            this.btnPesquisarCpfCnpj.Tag = "2";
            this.btnPesquisarCpfCnpj.Text = "CPF/CNPJ";
            this.btnPesquisarCpfCnpj.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPesquisarCpfCnpj.UseVisualStyleBackColor = false;
            this.btnPesquisarCpfCnpj.Click += new System.EventHandler(this.btnPesquisarCpfCnpj_Click);
            // 
            // btnPEsquisarNome
            // 
            this.btnPEsquisarNome.BackColor = System.Drawing.Color.White;
            this.btnPEsquisarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPEsquisarNome.Image = global::CONTROLE.OTICA.Properties.Resources.name_card_icon;
            this.btnPEsquisarNome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPEsquisarNome.Location = new System.Drawing.Point(8, 33);
            this.btnPEsquisarNome.Name = "btnPEsquisarNome";
            this.btnPEsquisarNome.Size = new System.Drawing.Size(122, 61);
            this.btnPEsquisarNome.TabIndex = 1;
            this.btnPEsquisarNome.Tag = "1";
            this.btnPEsquisarNome.Text = "NOME";
            this.btnPEsquisarNome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPEsquisarNome.UseVisualStyleBackColor = false;
            this.btnPEsquisarNome.Click += new System.EventHandler(this.btnPEsquisarNome_Click);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "RECEITAS";
            this.dataGridViewImageColumn2.Image = global::CONTROLE.OTICA.Properties.Resources.medical_report_icon;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 120;
            // 
            // frmListarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 679);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PESQUISAR CLIENTES";
            this.Load += new System.EventHandler(this.frmListarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPEsquisarCelular;
        private System.Windows.Forms.Button btnPesquisarEmail;
        private System.Windows.Forms.Button btnPEsquisarNome;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnPesquisarCpfCnpj;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblDadosPesquisa;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewImageColumn colSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeRazao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCpfCnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRgIe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Button button1;
    }
}