using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;

namespace SAT
{
    public partial class frmCancelarItemVenda : Form
    {
        frmVenda frmVenda;

        public frmCancelarItemVenda(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
        }

        #region VARIAVEIS

        int idUsuario, idUsuariologado = 0;
        public int tipo = 0;
        public int linha;
        bool ativo;

        #endregion

        #region CLASSES E OBJETOS

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        #endregion

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void frmCancelarItemVenda_Load(object sender, EventArgs e)
        {
            idUsuariologado = frmVenda.idUsuario;

            if (frmVenda.tipoCancelamento == 1)
            {
                lblCancelamentos.Text = "Cancelar Venda";
            }
            else if (frmVenda.tipoCancelamento == 2)
            {
                lblCancelamentos.Text = "Cancelar Item de Venda";
            }
        }

        public void Logar()
        {
            try
            {
                if (txtSenha.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Senha não Pode ser Nulo ou Vazio", "Campos Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Focus();
                }
                else
                {
                    usuarioC = new UsuarioC();
                    usuarioRegraNegocios = new UsuarioRegraNegocios();
                    DataTable dadosTabelaUsuario = new DataTable();

                    usuarioC.senha = txtSenha.Text;
                    usuarioC.numCaixa = frmVenda.numCaixa;

                    dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        ativo = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());

                        if (ativo == true)
                        {
                            idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                            if (idUsuario == idUsuariologado)
                            {
                                if (frmVenda.tipoCancelamento == 1)
                                {
                                    frmVenda.CancelarVenda();
                                    frmVenda.LimparCampos();
                                    frmVenda.GerarVendaTXT();
                                    frmVenda.LoadTela();

                                    this.Close();
                                }
                                else
                                {
                                    frmVenda.CancelarItemVenda(frmVenda.idvenda);

                                    //  frmVenda.AtualizaItemGrid();
                                    frmVenda.LimparCampos();
                                    frmVenda.LoadTela();

                                    if (frmVenda.cancelarVenda == true)
                                    {
                                        MessageBox.Show("Item Selecionado foi Deletado com Sucesso.", "Item de venda Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário Está ''Destivado'' OU Diferente do LOGADO, Por favor Entre em Contato com seu Gerente ou Administrador do Sistema.", "Usário Desativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário não está não Permitido para Realizar Cancelamento de Venda, Verifique sua Senha está Correta.", "Usuario Não logado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtSenha.Focus();
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
