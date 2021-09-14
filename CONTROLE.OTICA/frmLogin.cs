using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REGRA_NEGOCIOS;

namespace CONTROLE.OTICA
{
    public partial class frmLogin : Form
    {
        frmPrincipal frmPrincipal;

        public frmLogin(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
        }

        public string usuario, senha = "";
        public int idUsuario = 0;

        UsuarioRegraNegocios novoUsuario;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            PesquisarLogin();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
                txtSenha.SelectAll();
            }

            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void btnSair_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void btnEntrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        public void PesquisarLogin()
        {
            try
            {
                usuario = txtUsuario.Text;
                senha = txtSenha.Text;

                if (!String.IsNullOrEmpty(usuario) && (!String.IsNullOrEmpty(senha)))
                {
                    novoUsuario = new UsuarioRegraNegocios();
                    DataTable dadosTabelaUsuario = new DataTable();
                    dadosTabelaUsuario = novoUsuario.PesquisarLogin(usuario, senha);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        frmPrincipal = new frmPrincipal(idUsuario, txtUsuario.Text.Trim());

                        MessageBox.Show("Olá, " + dadosTabelaUsuario.Rows[0]["NOME"].ToString() + ".\nBem-vindo ao sistema!", "Bem-vindo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmPrincipal.idUsuario = idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"]);
                        frmPrincipal.usuarioLogado = dadosTabelaUsuario.Rows[0]["NOME"].ToString();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha Incorreta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Campo Login ou Senha não pode ser em Branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
