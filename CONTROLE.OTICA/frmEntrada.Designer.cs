namespace CONTROLE.OTICA
{
    partial class frmEntrada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgvSaida = new System.Windows.Forms.DataGridView();
            this.colNumSaida = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEsfODLonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEsfOELonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEsfODPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEsfOEPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiliODLonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiliOELonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiliOEPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiliODPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEixoODLonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEixoOELonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEixoODPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEixoOEPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDpODLonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDPOELonge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDPODPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDpOEPerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioLogado = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 18);
            this.label10.TabIndex = 37;
            this.label10.Text = "INFORME NUMERO DO PEDIDO";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(12, 29);
            this.txtPesquisar.Multiline = true;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(1039, 27);
            this.txtPesquisar.TabIndex = 36;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // dgvSaida
            // 
            this.dgvSaida.AllowUserToAddRows = false;
            this.dgvSaida.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaida.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaida.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSaida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumSaida,
            this.colNome,
            this.colEmail,
            this.colTelefone,
            this.colData,
            this.colEsfODLonge,
            this.colEsfOELonge,
            this.colEsfODPerto,
            this.colEsfOEPerto,
            this.colCiliODLonge,
            this.colCiliOELonge,
            this.colCiliOEPerto,
            this.colCiliODPerto,
            this.colEixoODLonge,
            this.colEixoOELonge,
            this.colEixoODPerto,
            this.colEixoOEPerto,
            this.colDpODLonge,
            this.colDPOELonge,
            this.colDPODPerto,
            this.colDpOEPerto});
            this.dgvSaida.Location = new System.Drawing.Point(12, 156);
            this.dgvSaida.Name = "dgvSaida";
            this.dgvSaida.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaida.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSaida.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaida.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSaida.Size = new System.Drawing.Size(1249, 438);
            this.dgvSaida.TabIndex = 38;
            this.dgvSaida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaida_CellContentClick);
            // 
            // colNumSaida
            // 
            this.colNumSaida.DataPropertyName = "NUMERO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumSaida.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNumSaida.HeaderText = "SAIDA";
            this.colNumSaida.Name = "colNumSaida";
            this.colNumSaida.ReadOnly = true;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "NOME";
            this.colNome.HeaderText = "NOME CLIENTE";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Visible = false;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "EMAIL";
            this.colEmail.HeaderText = "E-MAIL";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Visible = false;
            // 
            // colTelefone
            // 
            this.colTelefone.DataPropertyName = "TELEFONE";
            this.colTelefone.HeaderText = "TELEFONE";
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.ReadOnly = true;
            this.colTelefone.Visible = false;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "DATA_CAD";
            this.colData.HeaderText = "DATA";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 150;
            // 
            // colEsfODLonge
            // 
            this.colEsfODLonge.DataPropertyName = "ESF_OD_LONGE";
            this.colEsfODLonge.HeaderText = "ESF. OD LONGE";
            this.colEsfODLonge.Name = "colEsfODLonge";
            this.colEsfODLonge.ReadOnly = true;
            // 
            // colEsfOELonge
            // 
            this.colEsfOELonge.DataPropertyName = "ESF_OE_LONGE";
            this.colEsfOELonge.HeaderText = "ESF. OE LONGE";
            this.colEsfOELonge.Name = "colEsfOELonge";
            this.colEsfOELonge.ReadOnly = true;
            // 
            // colEsfODPerto
            // 
            this.colEsfODPerto.DataPropertyName = "ESF_OD_PERTO";
            this.colEsfODPerto.HeaderText = "ESF. OD PERTO";
            this.colEsfODPerto.Name = "colEsfODPerto";
            this.colEsfODPerto.ReadOnly = true;
            // 
            // colEsfOEPerto
            // 
            this.colEsfOEPerto.DataPropertyName = "ESF_OE_PERTO";
            this.colEsfOEPerto.HeaderText = "ESF. OE PERTO";
            this.colEsfOEPerto.Name = "colEsfOEPerto";
            this.colEsfOEPerto.ReadOnly = true;
            // 
            // colCiliODLonge
            // 
            this.colCiliODLonge.DataPropertyName = "CILI_OD_LONGE";
            this.colCiliODLonge.HeaderText = "CILI OD LONGE";
            this.colCiliODLonge.Name = "colCiliODLonge";
            this.colCiliODLonge.ReadOnly = true;
            // 
            // colCiliOELonge
            // 
            this.colCiliOELonge.DataPropertyName = "CILI_OE_LONGE";
            this.colCiliOELonge.HeaderText = "CILI OE LONGE";
            this.colCiliOELonge.Name = "colCiliOELonge";
            this.colCiliOELonge.ReadOnly = true;
            // 
            // colCiliOEPerto
            // 
            this.colCiliOEPerto.DataPropertyName = "CILI_OE_PERTO";
            this.colCiliOEPerto.HeaderText = "CILI OE PERTO";
            this.colCiliOEPerto.Name = "colCiliOEPerto";
            this.colCiliOEPerto.ReadOnly = true;
            // 
            // colCiliODPerto
            // 
            this.colCiliODPerto.DataPropertyName = "CILI_OD_PERTO";
            this.colCiliODPerto.HeaderText = "CILI OD PERTO";
            this.colCiliODPerto.Name = "colCiliODPerto";
            this.colCiliODPerto.ReadOnly = true;
            // 
            // colEixoODLonge
            // 
            this.colEixoODLonge.DataPropertyName = "EIXO_OD_LONGE";
            this.colEixoODLonge.HeaderText = "EIXO OD LONGE";
            this.colEixoODLonge.Name = "colEixoODLonge";
            this.colEixoODLonge.ReadOnly = true;
            // 
            // colEixoOELonge
            // 
            this.colEixoOELonge.DataPropertyName = "EIXO_OE_LONGE";
            this.colEixoOELonge.HeaderText = "EIXO OE LONGE";
            this.colEixoOELonge.Name = "colEixoOELonge";
            this.colEixoOELonge.ReadOnly = true;
            // 
            // colEixoODPerto
            // 
            this.colEixoODPerto.DataPropertyName = "EIXO_OD_PERTO";
            this.colEixoODPerto.HeaderText = "EIXO OD PERTO";
            this.colEixoODPerto.Name = "colEixoODPerto";
            this.colEixoODPerto.ReadOnly = true;
            // 
            // colEixoOEPerto
            // 
            this.colEixoOEPerto.DataPropertyName = "EIXO_OE_PERTO";
            this.colEixoOEPerto.HeaderText = "EIXO OE PERTO";
            this.colEixoOEPerto.Name = "colEixoOEPerto";
            this.colEixoOEPerto.ReadOnly = true;
            // 
            // colDpODLonge
            // 
            this.colDpODLonge.DataPropertyName = "DP_OD_LONGE";
            this.colDpODLonge.HeaderText = "DP OD LONGE";
            this.colDpODLonge.Name = "colDpODLonge";
            this.colDpODLonge.ReadOnly = true;
            // 
            // colDPOELonge
            // 
            this.colDPOELonge.DataPropertyName = "DP_OE_LONGE";
            this.colDPOELonge.HeaderText = "DP OE LONGE";
            this.colDPOELonge.Name = "colDPOELonge";
            this.colDPOELonge.ReadOnly = true;
            // 
            // colDPODPerto
            // 
            this.colDPODPerto.DataPropertyName = "DP_OD_PERTO";
            this.colDPODPerto.HeaderText = "DP OD PERTO";
            this.colDPODPerto.Name = "colDPODPerto";
            this.colDPODPerto.ReadOnly = true;
            // 
            // colDpOEPerto
            // 
            this.colDpOEPerto.DataPropertyName = "DP_OE_PERTO";
            this.colDpOEPerto.HeaderText = "DP OE PERTO";
            this.colDpOEPerto.Name = "colDpOEPerto";
            this.colDpOEPerto.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "DATA";
            // 
            // txtDataHora
            // 
            this.txtDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataHora.Location = new System.Drawing.Point(12, 83);
            this.txtDataHora.Multiline = true;
            this.txtDataHora.Name = "txtDataHora";
            this.txtDataHora.Size = new System.Drawing.Size(228, 27);
            this.txtDataHora.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "OPERADOR(A)";
            // 
            // txtUsuarioLogado
            // 
            this.txtUsuarioLogado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioLogado.Location = new System.Drawing.Point(246, 83);
            this.txtUsuarioLogado.Multiline = true;
            this.txtUsuarioLogado.Name = "txtUsuarioLogado";
            this.txtUsuarioLogado.Size = new System.Drawing.Size(805, 27);
            this.txtUsuarioLogado.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::CONTROLE.OTICA.Properties.Resources.Clothing_Glasses_icon;
            this.pictureBox1.Location = new System.Drawing.Point(1070, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // frmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1265, 655);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuarioLogado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataHora);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvSaida);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPesquisar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOLICITACAO DE PEDIDO";
            this.Load += new System.EventHandler(this.frmEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgvSaida;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioLogado;
        private System.Windows.Forms.DataGridViewButtonColumn colNumSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEsfODLonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEsfOELonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEsfODPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEsfOEPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiliODLonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiliOELonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiliOEPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiliODPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEixoODLonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEixoOELonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEixoODPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEixoOEPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDpODLonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDPOELonge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDPODPerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDpOEPerto;
    }
}