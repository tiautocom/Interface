namespace SAT
{
    partial class frmSistema
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxPlaca = new System.Windows.Forms.CheckBox();
            this.btnManter = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxHomologacao = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCupomImagem = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxSalvarVendaXml = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxPgtoVendaXml = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMilsegundos = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxPlaca);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualizar Placa";
            // 
            // cbxPlaca
            // 
            this.cbxPlaca.AutoSize = true;
            this.cbxPlaca.Checked = true;
            this.cbxPlaca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPlaca.Location = new System.Drawing.Point(6, 30);
            this.cbxPlaca.Name = "cbxPlaca";
            this.cbxPlaca.Size = new System.Drawing.Size(43, 17);
            this.cbxPlaca.TabIndex = 0;
            this.cbxPlaca.Text = "Sim";
            this.cbxPlaca.UseVisualStyleBackColor = true;
            this.cbxPlaca.CheckedChanged += new System.EventHandler(this.cbxPlaca_CheckedChanged);
            // 
            // btnManter
            // 
            this.btnManter.Location = new System.Drawing.Point(274, 207);
            this.btnManter.Name = "btnManter";
            this.btnManter.Size = new System.Drawing.Size(75, 23);
            this.btnManter.TabIndex = 2;
            this.btnManter.Text = "Alterar";
            this.btnManter.UseVisualStyleBackColor = true;
            this.btnManter.Click += new System.EventHandler(this.btnManter_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(349, 207);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxHomologacao);
            this.groupBox2.Location = new System.Drawing.Point(145, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status Homologação";
            // 
            // cbxHomologacao
            // 
            this.cbxHomologacao.AutoSize = true;
            this.cbxHomologacao.Checked = true;
            this.cbxHomologacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxHomologacao.Location = new System.Drawing.Point(6, 30);
            this.cbxHomologacao.Name = "cbxHomologacao";
            this.cbxHomologacao.Size = new System.Drawing.Size(43, 17);
            this.cbxHomologacao.TabIndex = 0;
            this.cbxHomologacao.Text = "Sim";
            this.cbxHomologacao.UseVisualStyleBackColor = true;
            this.cbxHomologacao.CheckedChanged += new System.EventHandler(this.cbxHomologacao_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxCupomImagem);
            this.groupBox3.Location = new System.Drawing.Point(283, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 67);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Imprimir Cupom";
            // 
            // cbxCupomImagem
            // 
            this.cbxCupomImagem.AutoSize = true;
            this.cbxCupomImagem.Checked = true;
            this.cbxCupomImagem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCupomImagem.Location = new System.Drawing.Point(6, 30);
            this.cbxCupomImagem.Name = "cbxCupomImagem";
            this.cbxCupomImagem.Size = new System.Drawing.Size(43, 17);
            this.cbxCupomImagem.TabIndex = 0;
            this.cbxCupomImagem.Text = "Sim";
            this.cbxCupomImagem.UseVisualStyleBackColor = true;
            this.cbxCupomImagem.CheckedChanged += new System.EventHandler(this.cbxCupomImagem_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxSalvarVendaXml);
            this.groupBox4.Location = new System.Drawing.Point(7, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 67);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Salvar Venda XML";
            // 
            // cbxSalvarVendaXml
            // 
            this.cbxSalvarVendaXml.AutoSize = true;
            this.cbxSalvarVendaXml.Checked = true;
            this.cbxSalvarVendaXml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSalvarVendaXml.Location = new System.Drawing.Point(6, 30);
            this.cbxSalvarVendaXml.Name = "cbxSalvarVendaXml";
            this.cbxSalvarVendaXml.Size = new System.Drawing.Size(43, 17);
            this.cbxSalvarVendaXml.TabIndex = 0;
            this.cbxSalvarVendaXml.Text = "Sim";
            this.cbxSalvarVendaXml.UseVisualStyleBackColor = true;
            this.cbxSalvarVendaXml.CheckedChanged += new System.EventHandler(this.cbxSalvarVendaXml_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxPgtoVendaXml);
            this.groupBox5.Location = new System.Drawing.Point(145, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 67);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Salvar Pagto Venda XML";
            // 
            // cbxPgtoVendaXml
            // 
            this.cbxPgtoVendaXml.AutoSize = true;
            this.cbxPgtoVendaXml.Checked = true;
            this.cbxPgtoVendaXml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPgtoVendaXml.Location = new System.Drawing.Point(6, 30);
            this.cbxPgtoVendaXml.Name = "cbxPgtoVendaXml";
            this.cbxPgtoVendaXml.Size = new System.Drawing.Size(43, 17);
            this.cbxPgtoVendaXml.TabIndex = 0;
            this.cbxPgtoVendaXml.Text = "Sim";
            this.cbxPgtoVendaXml.UseVisualStyleBackColor = true;
            this.cbxPgtoVendaXml.CheckedChanged += new System.EventHandler(this.cbxPgtoVendaXml_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time Descaço Tela ( * Valor em Milesegundos)";
            // 
            // txtMilsegundos
            // 
            this.txtMilsegundos.Location = new System.Drawing.Point(7, 175);
            this.txtMilsegundos.Name = "txtMilsegundos";
            this.txtMilsegundos.Size = new System.Drawing.Size(132, 20);
            this.txtMilsegundos.TabIndex = 5;
            this.txtMilsegundos.Text = "0";
            this.txtMilsegundos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(431, 236);
            this.Controls.Add(this.txtMilsegundos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnManter);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema";
            this.Load += new System.EventHandler(this.frmSistema_Load);
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

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxPlaca;
        private System.Windows.Forms.Button btnManter;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxHomologacao;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxCupomImagem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbxSalvarVendaXml;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbxPgtoVendaXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMilsegundos;
    }
}