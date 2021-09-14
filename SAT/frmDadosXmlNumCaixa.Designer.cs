namespace SAT
{
    partial class frmDadosXmlNumCaixa
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
            this.lblValor = new System.Windows.Forms.Label();
            this.txtImpressora = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBondRoute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComBalanca = new System.Windows.Forms.ComboBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtNumCaixa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComImpressora = new System.Windows.Forms.ComboBox();
            this.txtCodigoXml = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPahtXmlCupom = new System.Windows.Forms.TextBox();
            this.txtPathXmlCupomResp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(9, 8);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(81, 18);
            this.lblValor.TabIndex = 82;
            this.lblValor.Text = "Num Caixa";
            // 
            // txtImpressora
            // 
            this.txtImpressora.FormattingEnabled = true;
            this.txtImpressora.Items.AddRange(new object[] {
            "BEMASAT",
            "BEMATECH",
            "COMUM",
            "DARUMA",
            "EPSON",
            "ELGIN",
            "ESCPOS",
            "MP 2500"});
            this.txtImpressora.Location = new System.Drawing.Point(9, 110);
            this.txtImpressora.Name = "txtImpressora";
            this.txtImpressora.Size = new System.Drawing.Size(269, 21);
            this.txtImpressora.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 86;
            this.label2.Text = "Impressora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "Bound Route";
            // 
            // txtBondRoute
            // 
            this.txtBondRoute.FormattingEnabled = true;
            this.txtBondRoute.Items.AddRange(new object[] {
            "2400",
            "9600"});
            this.txtBondRoute.Location = new System.Drawing.Point(9, 200);
            this.txtBondRoute.Name = "txtBondRoute";
            this.txtBondRoute.Size = new System.Drawing.Size(269, 21);
            this.txtBondRoute.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Porta COM Balança ";
            // 
            // txtComBalanca
            // 
            this.txtComBalanca.FormattingEnabled = true;
            this.txtComBalanca.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.txtComBalanca.Location = new System.Drawing.Point(9, 71);
            this.txtComBalanca.Name = "txtComBalanca";
            this.txtComBalanca.Size = new System.Drawing.Size(269, 21);
            this.txtComBalanca.TabIndex = 89;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(203, 318);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 91;
            this.btnAlterar.Text = "Salvar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtNumCaixa
            // 
            this.txtNumCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCaixa.Location = new System.Drawing.Point(9, 27);
            this.txtNumCaixa.Name = "txtNumCaixa";
            this.txtNumCaixa.Size = new System.Drawing.Size(80, 22);
            this.txtNumCaixa.TabIndex = 92;
            this.txtNumCaixa.Text = "000";
            this.txtNumCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 18);
            this.label4.TabIndex = 93;
            this.label4.Text = "Porta COM Impressora";
            // 
            // txtComImpressora
            // 
            this.txtComImpressora.FormattingEnabled = true;
            this.txtComImpressora.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.txtComImpressora.Location = new System.Drawing.Point(9, 156);
            this.txtComImpressora.Name = "txtComImpressora";
            this.txtComImpressora.Size = new System.Drawing.Size(266, 21);
            this.txtComImpressora.TabIndex = 94;
            // 
            // txtCodigoXml
            // 
            this.txtCodigoXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoXml.Location = new System.Drawing.Point(198, 27);
            this.txtCodigoXml.Name = "txtCodigoXml";
            this.txtCodigoXml.Size = new System.Drawing.Size(80, 22);
            this.txtCodigoXml.TabIndex = 96;
            this.txtCodigoXml.Text = "0";
            this.txtCodigoXml.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "Cód.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 97;
            this.label6.Text = "Path XML Cupom";
            // 
            // txtPahtXmlCupom
            // 
            this.txtPahtXmlCupom.Location = new System.Drawing.Point(9, 245);
            this.txtPahtXmlCupom.Name = "txtPahtXmlCupom";
            this.txtPahtXmlCupom.Size = new System.Drawing.Size(269, 20);
            this.txtPahtXmlCupom.TabIndex = 98;
            // 
            // txtPathXmlCupomResp
            // 
            this.txtPathXmlCupomResp.Location = new System.Drawing.Point(9, 292);
            this.txtPathXmlCupomResp.Name = "txtPathXmlCupomResp";
            this.txtPathXmlCupomResp.Size = new System.Drawing.Size(269, 20);
            this.txtPathXmlCupomResp.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 18);
            this.label7.TabIndex = 99;
            this.label7.Text = "Path XML Cupom Resp";
            // 
            // frmDadosXmlNumCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 345);
            this.Controls.Add(this.txtPathXmlCupomResp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPahtXmlCupom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodigoXml);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComImpressora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumCaixa);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComBalanca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBondRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImpressora);
            this.Controls.Add(this.lblValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDadosXmlNumCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDadosXmlNumCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox txtImpressora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtBondRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtComBalanca;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtNumCaixa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtComImpressora;
        private System.Windows.Forms.TextBox txtCodigoXml;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPahtXmlCupom;
        private System.Windows.Forms.TextBox txtPathXmlCupomResp;
        private System.Windows.Forms.Label label7;
    }
}