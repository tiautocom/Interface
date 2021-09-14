namespace SAT
{
    partial class frmCpfCnpj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCpfCnpj));
            this.RBCnpj = new System.Windows.Forms.RadioButton();
            this.rbCpf = new System.Windows.Forms.RadioButton();
            this.btnCpfCliente = new System.Windows.Forms.Button();
            this.btnCancelarCpfCnpj = new System.Windows.Forms.Button();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.pbNotaPaulista = new System.Windows.Forms.PictureBox();
            this.rbTelefone = new System.Windows.Forms.RadioButton();
            this.txtNome = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotaPaulista)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RBCnpj
            // 
            this.RBCnpj.AutoSize = true;
            this.RBCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBCnpj.Location = new System.Drawing.Point(238, 7);
            this.RBCnpj.Name = "RBCnpj";
            this.RBCnpj.Size = new System.Drawing.Size(56, 17);
            this.RBCnpj.TabIndex = 13;
            this.RBCnpj.Text = "CNPJ";
            this.RBCnpj.UseVisualStyleBackColor = true;
            this.RBCnpj.CheckedChanged += new System.EventHandler(this.RBCnpj_CheckedChanged);
            // 
            // rbCpf
            // 
            this.rbCpf.AutoSize = true;
            this.rbCpf.Checked = true;
            this.rbCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCpf.Location = new System.Drawing.Point(185, 7);
            this.rbCpf.Name = "rbCpf";
            this.rbCpf.Size = new System.Drawing.Size(48, 17);
            this.rbCpf.TabIndex = 12;
            this.rbCpf.TabStop = true;
            this.rbCpf.Text = "CPF";
            this.rbCpf.UseVisualStyleBackColor = true;
            this.rbCpf.CheckedChanged += new System.EventHandler(this.rbCpf_CheckedChanged);
            // 
            // btnCpfCliente
            // 
            this.btnCpfCliente.BackColor = System.Drawing.Color.White;
            this.btnCpfCliente.Location = new System.Drawing.Point(12, 164);
            this.btnCpfCliente.Name = "btnCpfCliente";
            this.btnCpfCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCpfCliente.TabIndex = 11;
            this.btnCpfCliente.Text = "&Cadastrar";
            this.btnCpfCliente.UseVisualStyleBackColor = false;
            this.btnCpfCliente.Click += new System.EventHandler(this.btnCpfCliente_Click);
            // 
            // btnCancelarCpfCnpj
            // 
            this.btnCancelarCpfCnpj.BackColor = System.Drawing.Color.White;
            this.btnCancelarCpfCnpj.Location = new System.Drawing.Point(98, 164);
            this.btnCancelarCpfCnpj.Name = "btnCancelarCpfCnpj";
            this.btnCancelarCpfCnpj.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCpfCnpj.TabIndex = 10;
            this.btnCancelarCpfCnpj.Text = "Cancelar";
            this.btnCancelarCpfCnpj.UseVisualStyleBackColor = false;
            this.btnCancelarCpfCnpj.Click += new System.EventHandler(this.btnCancelarCpfCnpj_Click);
            // 
            // txtCnpj
            // 
            this.txtCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpj.Location = new System.Drawing.Point(185, 53);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(192, 27);
            this.txtCnpj.TabIndex = 9;
            this.txtCnpj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCnpj_KeyDown);
            this.txtCnpj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnpj_KeyPress);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(185, 30);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(43, 20);
            this.lblDescricao.TabIndex = 8;
            this.lblDescricao.Text = "CPF";
            // 
            // pbNotaPaulista
            // 
            this.pbNotaPaulista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbNotaPaulista.Image = ((System.Drawing.Image)(resources.GetObject("pbNotaPaulista.Image")));
            this.pbNotaPaulista.Location = new System.Drawing.Point(4, 7);
            this.pbNotaPaulista.Name = "pbNotaPaulista";
            this.pbNotaPaulista.Size = new System.Drawing.Size(175, 152);
            this.pbNotaPaulista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotaPaulista.TabIndex = 59;
            this.pbNotaPaulista.TabStop = false;
            // 
            // rbTelefone
            // 
            this.rbTelefone.AutoSize = true;
            this.rbTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTelefone.Location = new System.Drawing.Point(298, 7);
            this.rbTelefone.Name = "rbTelefone";
            this.rbTelefone.Size = new System.Drawing.Size(89, 17);
            this.rbTelefone.TabIndex = 60;
            this.rbTelefone.Text = "TELEFONE";
            this.rbTelefone.UseVisualStyleBackColor = true;
            this.rbTelefone.CheckedChanged += new System.EventHandler(this.rbTelefone_CheckedChanged);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(185, 106);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(436, 27);
            this.txtNome.TabIndex = 62;
            this.txtNome.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Nome:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(185, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(436, 27);
            this.txtEmail.TabIndex = 64;
            this.txtEmail.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "E-Mail";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 197);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(629, 22);
            this.statusStrip1.TabIndex = 65;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "Nota Fiscal Paulista";
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.BackColor = System.Drawing.Color.White;
            this.btnPesquisarCliente.Location = new System.Drawing.Point(381, 53);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(132, 27);
            this.btnPesquisarCliente.TabIndex = 66;
            this.btnPesquisarCliente.Text = "Pesquisar Cliente";
            this.btnPesquisarCliente.UseVisualStyleBackColor = false;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            // 
            // frmCpfCnpj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 219);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbTelefone);
            this.Controls.Add(this.pbNotaPaulista);
            this.Controls.Add(this.RBCnpj);
            this.Controls.Add(this.rbCpf);
            this.Controls.Add(this.btnCpfCliente);
            this.Controls.Add(this.btnCancelarCpfCnpj);
            this.Controls.Add(this.txtCnpj);
            this.Controls.Add(this.lblDescricao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCpfCnpj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCpfCnpj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNotaPaulista)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBCnpj;
        private System.Windows.Forms.RadioButton rbCpf;
        private System.Windows.Forms.Button btnCpfCliente;
        private System.Windows.Forms.Button btnCancelarCpfCnpj;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.PictureBox pbNotaPaulista;
        private System.Windows.Forms.RadioButton rbTelefone;
        private System.Windows.Forms.MaskedTextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnPesquisarCliente;
    }
}