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

namespace SAT
{
    public partial class frmLoginConfiguracao : Form
    {
        frmVenda frmVenda;

        public frmLoginConfiguracao(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
        }

        #region CLASSES E OBJETOS

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        #endregion

        #region VARIAVEIS

        int idUsuario = 0;
        int idUsuariologado = 0;
        bool ativo;

        #endregion


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        public void Logar()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();
                DataTable dadosTabelaUsuario = new DataTable();

                if (txtSenha.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Senha não Pode ser Nulo ou Vazio", "Campos Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Focus();
                }
                else
                {
                    usuarioC.senha = txtSenha.Text.Trim();
                    usuarioC.numCaixa = frmVenda.numCaixa;

                    dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        ativo = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());
                        idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                        if (ativo == true)
                        {
                            idUsuariologado = frmVenda.idUsuario;

                            if (idUsuario == idUsuariologado)
                            {
                                frmParametro fParametro = new frmParametro(frmVenda);
                                fParametro.ShowDialog();

                                this.Close();
                                idUsuario = 0;
                            }
                            else
                            {
                                MessageBox.Show("Usuário não está não Permitido para Realizar Cancelamento de Venda, Verifique sua Senha está Correta.", "Usuario Não logado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSenha.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário Está ''Destivado'', Por favor Entre em Contato com seu Gerente ou Administrador do Sistema.", "Usário Desativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senha ou Usuario Inválido", "Senha Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSenha.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }

            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }
    }
}
