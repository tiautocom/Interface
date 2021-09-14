namespace SAT
{
    partial class frmBandeiras
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
            this.pbBandRed = new System.Windows.Forms.PictureBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pbBandVerde = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBandRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBandVerde)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBandRed
            // 
            this.pbBandRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbBandRed.Image = global::SAT.Properties.Resources.Flag_red_icon;
            this.pbBandRed.Location = new System.Drawing.Point(143, 8);
            this.pbBandRed.Name = "pbBandRed";
            this.pbBandRed.Size = new System.Drawing.Size(80, 67);
            this.pbBandRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBandRed.TabIndex = 1;
            this.pbBandRed.TabStop = false;
            this.pbBandRed.Visible = false;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(6, 24);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(132, 20);
            this.txtCnpj.TabIndex = 2;
            this.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtCnpj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCnpj_KeyDown);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(6, 50);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(132, 23);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pbBandVerde
            // 
            this.pbBandVerde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbBandVerde.Image = global::SAT.Properties.Resources.Flag_green_icon;
            this.pbBandVerde.Location = new System.Drawing.Point(143, 8);
            this.pbBandVerde.Name = "pbBandVerde";
            this.pbBandVerde.Size = new System.Drawing.Size(80, 67);
            this.pbBandVerde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBandVerde.TabIndex = 4;
            this.pbBandVerde.TabStop = false;
            this.pbBandVerde.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SENHA";
            // 
            // frmBandeiras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(229, 78);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbBandVerde);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtCnpj);
            this.Controls.Add(this.pbBandRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBandeiras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBandeiras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBandRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBandVerde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBandRed;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox pbBandVerde;
        private System.Windows.Forms.Label label1;
    }
}