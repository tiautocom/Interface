namespace CONTROLE.OTICA
{
    partial class frmSaida
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.txtUsuarioLogado = new System.Windows.Forms.TextBox();
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
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNumReceita = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "OPERADOR(A)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "DATA";
            // 
            // txtDataHora
            // 
            this.txtDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataHora.Location = new System.Drawing.Point(5, 82);
            this.txtDataHora.Multiline = true;
            this.txtDataHora.Name = "txtDataHora";
            this.txtDataHora.Size = new System.Drawing.Size(228, 27);
            this.txtDataHora.TabIndex = 48;
            // 
            // txtUsuarioLogado
            // 
            this.txtUsuarioLogado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioLogado.Location = new System.Drawing.Point(239, 82);
            this.txtUsuarioLogado.Multiline = true;
            this.txtUsuarioLogado.Name = "txtUsuarioLogado";
            this.txtUsuarioLogado.Size = new System.Drawing.Size(805, 27);
            this.txtUsuarioLogado.TabIndex = 50;
            // 
            // dgvSaida
            // 
            this.dgvSaida.AllowUserToAddRows = false;
            this.dgvSaida.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaida.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaida.BackgroundColor = System.Drawing.Color.White;
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
            this.dgvSaida.Location = new System.Drawing.Point(5, 155);
            this.dgvSaida.Name = "dgvSaida";
            this.dgvSaida.ReadOnly = true;
            this.dgvSaida.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaida.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSaida.Size = new System.Drawing.Size(1249, 438);
            this.dgvSaida.TabIndex = 46;
            // 
            // colNumSaida
            // 
            this.colNumSaida.DataPropertyName = "NUMERO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumSaida.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNumSaida.HeaderText = "DETALHES";
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
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(368, 28);
            this.txtPesquisar.Multiline = true;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(358, 27);
            this.txtPesquisar.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(368, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 18);
            this.label10.TabIndex = 45;
            this.label10.Text = "INFORME NUMERO DO PEDIDO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::CONTROLE.OTICA.Properties.Resources.Clothing_Glasses_icon;
            this.pictureBox1.Location = new System.Drawing.Point(1063, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // txtNumReceita
            // 
            this.txtNumReceita.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumReceita.Location = new System.Drawing.Point(5, 28);
            this.txtNumReceita.Multiline = true;
            this.txtNumReceita.Name = "txtNumReceita";
            this.txtNumReceita.Size = new System.Drawing.Size(358, 27);
            this.txtNumReceita.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 18);
            this.label3.TabIndex = 53;
            this.label3.Text = "INFORME NUMERO DO RECEITA";
            // 
            // frmSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 625);
            this.Controls.Add(this.txtNumReceita);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataHora);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtUsuarioLogado);
            this.Controls.Add(this.dgvSaida);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATÓRIO DE PEDIDO SAIDA";
            this.Load += new System.EventHandler(this.frmSaida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataHora;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsuarioLogado;
        private System.Windows.Forms.DataGridView dgvSaida;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.TextBox txtNumReceita;
        private System.Windows.Forms.Label label3;
    }
}