namespace SAT
{
    partial class frmParametro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.estabelecimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estabelecimentoToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.usuárioToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.fecharCaixaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menuStrip1_KeyDown);
            this.menuStrip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.menuStrip1_KeyPress);
            // 
            // estabelecimentoToolStripMenuItem
            // 
            this.estabelecimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dadosToolStripMenuItem});
            this.estabelecimentoToolStripMenuItem.Name = "estabelecimentoToolStripMenuItem";
            this.estabelecimentoToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.estabelecimentoToolStripMenuItem.Text = "Estabelecimento";
            // 
            // dadosToolStripMenuItem
            // 
            this.dadosToolStripMenuItem.Name = "dadosToolStripMenuItem";
            this.dadosToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.dadosToolStripMenuItem.Text = "Dados";
            this.dadosToolStripMenuItem.Click += new System.EventHandler(this.dadosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dadosClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // dadosClienteToolStripMenuItem
            // 
            this.dadosClienteToolStripMenuItem.Name = "dadosClienteToolStripMenuItem";
            this.dadosClienteToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.dadosClienteToolStripMenuItem.Text = "Dados Cliente";
            this.dadosClienteToolStripMenuItem.Click += new System.EventHandler(this.dadosClienteToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesUsuárioToolStripMenuItem,
            this.tipoUsuárioToolStripMenuItem});
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.usuárioToolStripMenuItem.Text = "Usuário";
            // 
            // configuraçõesUsuárioToolStripMenuItem
            // 
            this.configuraçõesUsuárioToolStripMenuItem.Name = "configuraçõesUsuárioToolStripMenuItem";
            this.configuraçõesUsuárioToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.configuraçõesUsuárioToolStripMenuItem.Text = "Configurações Usuário";
            this.configuraçõesUsuárioToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesUsuárioToolStripMenuItem_Click);
            // 
            // tipoUsuárioToolStripMenuItem
            // 
            this.tipoUsuárioToolStripMenuItem.Name = "tipoUsuárioToolStripMenuItem";
            this.tipoUsuárioToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.tipoUsuárioToolStripMenuItem.Text = "Tipo Usuário";
            this.tipoUsuárioToolStripMenuItem.Click += new System.EventHandler(this.tipoUsuárioToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem,
            this.dadosXMLToolStripMenuItem,
            this.toolStripMenuItem1,
            this.consultarSatToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // dadosXMLToolStripMenuItem
            // 
            this.dadosXMLToolStripMenuItem.Name = "dadosXMLToolStripMenuItem";
            this.dadosXMLToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.dadosXMLToolStripMenuItem.Text = "Dados XML Num Caixa";
            this.dadosXMLToolStripMenuItem.Click += new System.EventHandler(this.dadosXMLToolStripMenuItem_Click);
            // 
            // consultarSatToolStripMenuItem
            // 
            this.consultarSatToolStripMenuItem.Name = "consultarSatToolStripMenuItem";
            this.consultarSatToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.consultarSatToolStripMenuItem.Text = "Consultar Sat";
            this.consultarSatToolStripMenuItem.Click += new System.EventHandler(this.consultarSatToolStripMenuItem_Click);
            // 
            // fecharCaixaToolStripMenuItem
            // 
            this.fecharCaixaToolStripMenuItem.Name = "fecharCaixaToolStripMenuItem";
            this.fecharCaixaToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.fecharCaixaToolStripMenuItem.Text = "Fechar Caixa";
            this.fecharCaixaToolStripMenuItem.Click += new System.EventHandler(this.fecharCaixaToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1071, 541);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 24);
            this.toolStripMenuItem1.Text = "URLs NFCe";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // frmParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1071, 569);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParametro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurções";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmParametro_FormClosed);
            this.Load += new System.EventHandler(this.frmParametro_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmParametro_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem estabelecimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharCaixaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}