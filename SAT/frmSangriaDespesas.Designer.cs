namespace SAT
{
    partial class frmSangriaDespesas
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
            this.cbxSangria = new System.Windows.Forms.CheckBox();
            this.lblQtde = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtMotivoSangria = new System.Windows.Forms.TextBox();
            this.gpSangria = new System.Windows.Forms.GroupBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtValorSangria = new System.Windows.Forms.TextBox();
            this.gpSangria.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxSangria
            // 
            this.cbxSangria.AutoSize = true;
            this.cbxSangria.Checked = true;
            this.cbxSangria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSangria.Location = new System.Drawing.Point(213, 55);
            this.cbxSangria.Name = "cbxSangria";
            this.cbxSangria.Size = new System.Drawing.Size(62, 17);
            this.cbxSangria.TabIndex = 78;
            this.cbxSangria.Text = "Sangria";
            this.cbxSangria.UseVisualStyleBackColor = true;
            this.cbxSangria.CheckedChanged += new System.EventHandler(this.cbxSangria_CheckedChanged);
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Location = new System.Drawing.Point(7, 209);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(19, 13);
            this.lblQtde.TabIndex = 83;
            this.lblQtde.Text = "00";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(118, 199);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 81;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtMotivoSangria
            // 
            this.txtMotivoSangria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivoSangria.Location = new System.Drawing.Point(7, 21);
            this.txtMotivoSangria.Multiline = true;
            this.txtMotivoSangria.Name = "txtMotivoSangria";
            this.txtMotivoSangria.Size = new System.Drawing.Size(256, 87);
            this.txtMotivoSangria.TabIndex = 0;
            this.txtMotivoSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotivoSangria_KeyPress);
            // 
            // gpSangria
            // 
            this.gpSangria.Controls.Add(this.txtMotivoSangria);
            this.gpSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpSangria.Location = new System.Drawing.Point(3, 74);
            this.gpSangria.Name = "gpSangria";
            this.gpSangria.Size = new System.Drawing.Size(277, 119);
            this.gpSangria.TabIndex = 82;
            this.gpSangria.TabStop = false;
            this.gpSangria.Text = "Motivo Sangria";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(4, 4);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(96, 18);
            this.lblValor.TabIndex = 80;
            this.lblValor.Text = "Valor Sangria";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(199, 199);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 79;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtValorSangria
            // 
            this.txtValorSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorSangria.Location = new System.Drawing.Point(3, 25);
            this.txtValorSangria.Name = "txtValorSangria";
            this.txtValorSangria.Size = new System.Drawing.Size(277, 24);
            this.txtValorSangria.TabIndex = 77;
            this.txtValorSangria.Text = "0,00";
            this.txtValorSangria.TextChanged += new System.EventHandler(this.txtValorSangria_TextChanged);
            this.txtValorSangria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorSangria_KeyDown);
            this.txtValorSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorSangria_KeyPress);
            // 
            // frmSangriaDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(287, 228);
            this.Controls.Add(this.cbxSangria);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.gpSangria);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtValorSangria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSangriaDespesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sangria & Despesas";
            this.Load += new System.EventHandler(this.frmSangriaDespesas_Load);
            this.gpSangria.ResumeLayout(false);
            this.gpSangria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxSangria;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtMotivoSangria;
        private System.Windows.Forms.GroupBox gpSangria;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtValorSangria;
    }
}