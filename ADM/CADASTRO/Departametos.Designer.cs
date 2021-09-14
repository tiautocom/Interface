namespace ADM.CADASTRO
{
    partial class Departametos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Departametos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cbBebidas = new System.Windows.Forms.CheckBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnp = new System.Windows.Forms.TextBox();
            this.txtCest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQtde = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtNcm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddNovoDepartamento = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNcm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAviso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AllowUserToAddRows = false;
            this.dgvDepartamentos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvDepartamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEditar,
            this.colDeletar,
            this.colDescricao,
            this.colIdDep,
            this.colAnp,
            this.colCest,
            this.colNcm,
            this.colAviso});
            this.dgvDepartamentos.Location = new System.Drawing.Point(7, 128);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersVisible = false;
            this.dgvDepartamentos.Size = new System.Drawing.Size(817, 371);
            this.dgvDepartamentos.TabIndex = 9;
            this.dgvDepartamentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartamentos_CellContentClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblQtde});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(7, 30);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(815, 29);
            this.txtDescricao.TabIndex = 0;
            this.txtDescricao.TextChanged += new System.EventHandler(this.txtDescricao_TextChanged);
            // 
            // cbBebidas
            // 
            this.cbBebidas.AutoSize = true;
            this.cbBebidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBebidas.Location = new System.Drawing.Point(756, 85);
            this.cbBebidas.Name = "cbBebidas";
            this.cbBebidas.Size = new System.Drawing.Size(66, 20);
            this.cbBebidas.TabIndex = 6;
            this.cbBebidas.Text = "Aviso";
            this.cbBebidas.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(709, 506);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(115, 28);
            this.btnNovo.TabIndex = 8;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightGreen;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(586, 506);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 28);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 16);
            this.label1.TabIndex = 157;
            this.label1.Text = "*DESCRIÇÃO DEPARTAMENTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(368, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 158;
            this.label2.Text = "ANP";
            // 
            // txtAnp
            // 
            this.txtAnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnp.Location = new System.Drawing.Point(368, 81);
            this.txtAnp.Name = "txtAnp";
            this.txtAnp.Size = new System.Drawing.Size(336, 29);
            this.txtAnp.TabIndex = 5;
            // 
            // txtCest
            // 
            this.txtCest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCest.Location = new System.Drawing.Point(7, 81);
            this.txtCest.Name = "txtCest";
            this.txtCest.Size = new System.Drawing.Size(156, 29);
            this.txtCest.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 160;
            this.label3.Text = "*CEST";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(139, 17);
            this.toolStripStatusLabel1.Text = "Quantidade de Registros:";
            // 
            // lblQtde
            // 
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(37, 17);
            this.lblQtde.Text = "00000";
            // 
            // txtNcm
            // 
            this.txtNcm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNcm.Location = new System.Drawing.Point(206, 81);
            this.txtNcm.Name = "txtNcm";
            this.txtNcm.Size = new System.Drawing.Size(156, 29);
            this.txtNcm.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(206, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 162;
            this.label4.Text = "*CEST";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ADM.Properties.Resources.Pencil_icon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::ADM.Properties.Resources.Status_dialog_error_icon;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // btnAddNovoDepartamento
            // 
            this.btnAddNovoDepartamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNovoDepartamento.Image")));
            this.btnAddNovoDepartamento.Location = new System.Drawing.Point(166, 81);
            this.btnAddNovoDepartamento.Name = "btnAddNovoDepartamento";
            this.btnAddNovoDepartamento.Size = new System.Drawing.Size(32, 29);
            this.btnAddNovoDepartamento.TabIndex = 3;
            this.btnAddNovoDepartamento.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(684, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(138, 16);
            this.label24.TabIndex = 163;
            this.label24.Text = "(*) Campo Obrigatório";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(9, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 30);
            this.button1.TabIndex = 164;
            this.button1.Text = "Pesquisar Cest";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "";
            this.colEditar.Image = global::ADM.Properties.Resources.Pencil_icon;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditar.Width = 40;
            // 
            // colDeletar
            // 
            this.colDeletar.HeaderText = "";
            this.colDeletar.Image = global::ADM.Properties.Resources.Status_dialog_error_icon;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.ReadOnly = true;
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.Width = 40;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "DESCRICAO";
            this.colDescricao.HeaderText = "DESCRIÇÃO DEPARTAMENTO";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 400;
            // 
            // colIdDep
            // 
            this.colIdDep.DataPropertyName = "ID";
            this.colIdDep.HeaderText = "ID";
            this.colIdDep.Name = "colIdDep";
            this.colIdDep.ReadOnly = true;
            this.colIdDep.Visible = false;
            // 
            // colAnp
            // 
            this.colAnp.DataPropertyName = "ANP";
            dataGridViewCellStyle2.NullValue = "000000";
            this.colAnp.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAnp.HeaderText = "ANP";
            this.colAnp.Name = "colAnp";
            this.colAnp.ReadOnly = true;
            this.colAnp.Width = 70;
            // 
            // colCest
            // 
            this.colCest.DataPropertyName = "CEST";
            dataGridViewCellStyle3.NullValue = "0000000";
            this.colCest.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCest.HeaderText = "CEST";
            this.colCest.Name = "colCest";
            this.colCest.ReadOnly = true;
            this.colCest.Width = 90;
            // 
            // colNcm
            // 
            this.colNcm.DataPropertyName = "NCM";
            dataGridViewCellStyle4.NullValue = "0000";
            this.colNcm.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNcm.HeaderText = "NCM";
            this.colNcm.Name = "colNcm";
            this.colNcm.ReadOnly = true;
            // 
            // colAviso
            // 
            this.colAviso.DataPropertyName = "AVISO";
            this.colAviso.HeaderText = "AVISO";
            this.colAviso.Name = "colAviso";
            this.colAviso.ReadOnly = true;
            this.colAviso.Width = 60;
            // 
            // Departametos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnAddNovoDepartamento);
            this.Controls.Add(this.txtNcm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAnp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cbBebidas);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvDepartamentos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Departametos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE DEPARTAMENTOS";
            this.Load += new System.EventHandler(this.Departametos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.CheckBox cbBebidas;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnp;
        private System.Windows.Forms.TextBox txtCest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblQtde;
        private System.Windows.Forms.TextBox txtNcm;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnAddNovoDepartamento;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNcm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAviso;
    }
}