using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System.Xml;
using System.IO;

namespace SAT
{
    public partial class frmLogin : Form
    {
        frmVenda frmVenda;

        public frmLogin(frmVenda fVenda, int tipo)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
            this.tipo = tipo;
        }

        #region VARIAVEIS

        public int idUsuario, numCaixaUsuario;
        public string nomeUsuario, numcaixa = "";
        public string periodo = "";
        public bool statusUsuario, ativado, statusCaixa;
        public int tipo = 0;

        #endregion

        #region CLASSES E OBJETO

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        #endregion

        #region PATHs

        string pathNumCaixa = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\NUM_CAIXA.xml";

        #endregion

        public void PesquisarNumCaixaXml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathNumCaixa);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Num")
                        numcaixa = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int ret;

            if (txtSenha.Text.Equals(""))
            {
                MessageBox.Show("Campo Senha não Pode ser Nulo ou Vázio", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSenha.Focus();
            }
            else
            {
                frmVenda.senhaUsuario = txtSenha.Text;

                ret = frmVenda.Logar(tipo);

                if (ret == 1)
                {
                    this.Close();
                }
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Realmente Deseja Sair do Sistema.", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Sair do Sistema", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtSenha.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
