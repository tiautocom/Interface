namespace ADMINISTRACAO
{
    partial class frmCadUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadUsuarios));
            this.gdvUsuario = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumCaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPermissao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLog = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNumCaixa = new System.Windows.Forms.TextBox();
            this.lblNumCaixa = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPermissao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddNovoDepartamento = new System.Windows.Forms.Button();
            this.cbxSenha = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvUsuario
            // 
            this.gdvUsuario.AllowUserToAddRows = false;
            this.gdvUsuario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gdvUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvUsuario.BackgroundColor = System.Drawing.Color.White;
            this.gdvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colIdUsuario,
            this.colNome,
            this.colPeriodo,
            this.colSenha,
            this.colNumCaixa,
            this.colTipoUser,
            this.colStatus,
            this.colPermissao,
            this.colLog});
            this.gdvUsuario.Location = new System.Drawing.Point(5, 135);
            this.gdvUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gdvUsuario.MultiSelect = false;
            this.gdvUsuario.Name = "gdvUsuario";
            this.gdvUsuario.ReadOnly = true;
            this.gdvUsuario.RowHeadersVisible = false;
            this.gdvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvUsuario.Size = new System.Drawing.Size(616, 256);
            this.gdvUsuario.TabIndex = 4;
            this.gdvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvUsuario_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::ADMINISTRACAO.Properties.Resources.Pencil_icon;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 40;
            // 
            // colIdUsuario
            // 
            this.colIdUsuario.DataPropertyName = "ID_USUARIO";
            this.colIdUsuario.HeaderText = "COD";
            this.colIdUsuario.Name = "colIdUsuario";
            this.colIdUsuario.ReadOnly = true;
            this.colIdUsuario.Width = 60;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "NOME";
            this.colNome.HeaderText = "NOME";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 210;
            // 
            // colPeriodo
            // 
            this.colPeriodo.DataPropertyName = "PERIODO";
            this.colPeriodo.HeaderText = "PERIODO";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.ReadOnly = true;
            this.colPeriodo.Width = 90;
            // 
            // colSenha
            // 
            this.colSenha.DataPropertyName = "SENHA";
            this.colSenha.HeaderText = "SENHA";
            this.colSenha.Name = "colSenha";
            this.colSenha.ReadOnly = true;
            this.colSenha.Visible = false;
            // 
            // colNumCaixa
            // 
            this.colNumCaixa.DataPropertyName = "NUM_CAIXA";
            this.colNumCaixa.HeaderText = "N. CAIXA";
            this.colNumCaixa.Name = "colNumCaixa";
            this.colNumCaixa.ReadOnly = true;
            this.colNumCaixa.Visible = false;
            this.colNumCaixa.Width = 70;
            // 
            // colTipoUser
            // 
            this.colTipoUser.DataPropertyName = "DESCRICAO";
            this.colTipoUser.HeaderText = "TIPO";
            this.colTipoUser.Name = "colTipoUser";
            this.colTipoUser.ReadOnly = true;
            this.colTipoUser.Width = 130;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "ATIVADO";
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.Width = 70;
            // 
            // colPermissao
            // 
            this.colPermissao.DataPropertyName = "PERMISSAO";
            this.colPermissao.HeaderText = "PERMISSÃO";
            this.colPermissao.Name = "colPermissao";
            this.colPermissao.ReadOnly = true;
            this.colPermissao.Visible = false;
            // 
            // colLog
            // 
            this.colLog.DataPropertyName = "LOGADO";
            this.colLog.HeaderText = "LOG";
            this.colLog.Name = "colLog";
            this.colLog.ReadOnly = true;
            this.colLog.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(5, 20);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 13;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Text = "0";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Código:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Location = new System.Drawing.Point(134, 20);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(487, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(131, 3);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 13);
            this.lblUsuario.TabIndex = 16;
            this.lblUsuario.Text = "Nome Usuário";
            // 
            // cbbTipo
            // 
            this.cbbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Location = new System.Drawing.Point(5, 61);
            this.cbbTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(304, 21);
            this.cbbTipo.TabIndex = 19;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(5, 44);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(79, 13);
            this.lblTipo.TabIndex = 18;
            this.lblTipo.Text = "Tipo Usuario";
            // 
            // txtNumCaixa
            // 
            this.txtNumCaixa.Location = new System.Drawing.Point(240, 105);
            this.txtNumCaixa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumCaixa.Name = "txtNumCaixa";
            this.txtNumCaixa.Size = new System.Drawing.Size(106, 20);
            this.txtNumCaixa.TabIndex = 20;
            this.txtNumCaixa.Text = "1";
            // 
            // lblNumCaixa
            // 
            this.lblNumCaixa.AutoSize = true;
            this.lblNumCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCaixa.Location = new System.Drawing.Point(237, 88);
            this.lblNumCaixa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumCaixa.Name = "lblNumCaixa";
            this.lblNumCaixa.Size = new System.Drawing.Size(67, 13);
            this.lblNumCaixa.TabIndex = 21;
            this.lblNumCaixa.Text = "Num Caixa";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Items.AddRange(new object[] {
            "MANHÃ",
            "TARDE",
            "NOITE"});
            this.cbPeriodo.Location = new System.Drawing.Point(356, 61);
            this.cbPeriodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(124, 21);
            this.cbPeriodo.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Periodo";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(356, 105);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(133, 20);
            this.txtSenha.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Senha";
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.White;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(111, 399);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(93, 35);
            this.btnAlterar.TabIndex = 27;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(10, 399);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(93, 35);
            this.btnSalvar.TabIndex = 26;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(317, 399);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(137, 35);
            this.btnNovo.TabIndex = 29;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(462, 399);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(159, 35);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "1 - ATIVO",
            "0 - INATIVO"});
            this.cbStatus.Location = new System.Drawing.Point(488, 61);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(133, 21);
            this.cbStatus.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(488, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Status";
            // 
            // cbPermissao
            // 
            this.cbPermissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPermissao.FormattingEnabled = true;
            this.cbPermissao.Items.AddRange(new object[] {
            "1 - ATIVO",
            "0 - INATIVO"});
            this.cbPermissao.Location = new System.Drawing.Point(5, 105);
            this.cbPermissao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPermissao.Name = "cbPermissao";
            this.cbPermissao.Size = new System.Drawing.Size(227, 21);
            this.cbPermissao.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Permissão";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ADMINISTRACAO.Properties.Resources.Pencil_icon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // btnAddNovoDepartamento
            // 
            this.btnAddNovoDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNovoDepartamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNovoDepartamento.Image")));
            this.btnAddNovoDepartamento.Location = new System.Drawing.Point(314, 60);
            this.btnAddNovoDepartamento.Name = "btnAddNovoDepartamento";
            this.btnAddNovoDepartamento.Size = new System.Drawing.Size(32, 23);
            this.btnAddNovoDepartamento.TabIndex = 191;
            this.btnAddNovoDepartamento.UseVisualStyleBackColor = true;
            this.btnAddNovoDepartamento.Click += new System.EventHandler(this.btnAddNovoDepartamento_Click);
            // 
            // cbxSenha
            // 
            this.cbxSenha.AutoSize = true;
            this.cbxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSenha.Location = new System.Drawing.Point(497, 107);
            this.cbxSenha.Name = "cbxSenha";
            this.cbxSenha.Size = new System.Drawing.Size(120, 17);
            this.cbxSenha.TabIndex = 192;
            this.cbxSenha.Text = "Visualizar Senha";
            this.cbxSenha.UseVisualStyleBackColor = true;
            this.cbxSenha.CheckedChanged += new System.EventHandler(this.cbxSenha_CheckedChanged);
            // 
            // frmCadUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 441);
            this.Controls.Add(this.cbxSenha);
            this.Controls.Add(this.btnAddNovoDepartamento);
            this.Controls.Add(this.cbPermissao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumCaixa);
            this.Controls.Add(this.txtNumCaixa);
            this.Controls.Add(this.cbbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdvUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuários";
            this.Load += new System.EventHandler(this.frmCadUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvUsuario;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtNumCaixa;
        private System.Windows.Forms.Label lblNumCaixa;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPermissao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.Button btnAddNovoDepartamento;
        private System.Windows.Forms.CheckBox cbxSenha;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPermissao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colLog;
    }
}