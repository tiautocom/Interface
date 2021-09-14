using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SAT
{
    public partial class frmParametro : Form
    {
        frmVenda frmVenda;
      public  int sessao = 0;

        public frmParametro(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
        }

        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracoes fConfiguracao = new frmConfiguracoes();
            fConfiguracao.ShowDialog();
        }

        private void dadosClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuraçõesUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarioConfiguracao fUsuarioConfig = new frmUsuarioConfiguracao(frmVenda);
            fUsuarioConfig.ShowDialog();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSistema fSistemas = new frmSistema(frmVenda);
            fSistemas.ShowDialog();
        }

        private void tipoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoUsuario fTipoUsuario = new frmTipoUsuario();
            fTipoUsuario.ShowDialog();
        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFechamentoCaixa fFechamentoCaixa = new frmFechamentoCaixa(frmVenda);
            fFechamentoCaixa.ShowDialog();

            frmVenda.LoadTela();
        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void menuStrip1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                fecharCaixaToolStripMenuItem_Click(sender, e);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParametro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dadosXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosXmlNumCaixa frmDadosXmlNumCaixa = new frmDadosXmlNumCaixa();
            frmDadosXmlNumCaixa.ShowDialog();
        }

        private void frmParametro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmVenda.LoadTela();
        }

        private void consultarSatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getNumberRandom();

            string ret = Marshal.PtrToStringAnsi(IMPRESSORA.BematechImpressora.ConsultarSAT(sessao));

            MessageBox.Show(ret);
        }

        public int getNumberRandom()
        {
            Random number = new Random();
            int retorno = number.Next(999999);
            sessao = retorno;
            return retorno;
        }

        private void frmParametro_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
