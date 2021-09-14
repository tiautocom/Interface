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
    public partial class frmLoginUsuario : Form
    {
        frmVenda frmVenda;

        public frmLoginUsuario(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
        }

        #region VARIVEIS

        int idUsuario = 0;
        int idUsuarioLogado = 0;
        bool ativo;

        #endregion

        #region CLASSE E OBJETOS

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        #endregion

        private void frmLoginUsuario_Load(object sender, EventArgs e)
        {
            idUsuarioLogado = frmVenda.idUsuario;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }

            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PesquisarLogin()
        {
            try
            {
                if (txtSenha.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Informe Senha do Usuário", "Campo em Branco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSenha.Focus();
                }
                else
                {
                    usuarioC = new UsuarioC();
                    usuarioRegraNegocios = new UsuarioRegraNegocios();
                    DataTable dadosTabelaUsuario = new DataTable();

                    usuarioC.senha = txtSenha.Text.Trim();
                    usuarioC.numCaixa = frmVenda.numCaixa;

                    dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        ativo = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());

                        if (ativo == true)
                        {
                            idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                            if (idUsuario == idUsuarioLogado)
                            {
                                btnEntrar.Enabled = true;
                                btnEntrar.Text = "Alterar";

                                MessageBox.Show("Informe Nova Senha Usuário", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtSenha.Text = dadosTabelaUsuario.Rows[0]["SENHA"].ToString().Trim();
                                txtSenha.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Usuário não está não Permitido para Realizar Cancelamento de Venda, Verifique sua Senha está Correta.", "Usuario Não logado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSenha.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário Está ''Destivado'', Por favor Entre em Contato com seu Gerente ou Administrado", "Ussário Desativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public void AlterarSenhaUsuario()
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Alterar Senha de Acesso ao Usuário", "Alterar Senha", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (txtSenha.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Informe Senha do Usuário", "Campo em Branco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Focus();
                    }
                    else
                    {
                        usuarioC = new UsuarioC();
                        usuarioRegraNegocios = new UsuarioRegraNegocios();

                        usuarioC.idUsuario = idUsuario;
                        usuarioC.senha = txtSenha.Text.Trim();

                        string idRetorno = usuarioRegraNegocios.AlterarSenhaUsuario(usuarioC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);
                            MessageBox.Show("Senha de Acesso ao Usuário foi Alterado com Sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Alterar Senha de Acesso ao Usuário", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (btnEntrar.Text == "Entrar")
            {
                PesquisarLogin();
            }
            else if (btnEntrar.Text == "Alterar")
            {
                AlterarSenhaUsuario();
            }
        }
    }
}
