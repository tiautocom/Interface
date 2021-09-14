using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAT
{
    public partial class frmCancelarUltimaVenda : Form
    {
        frmVenda frmvenda;

        public frmCancelarUltimaVenda(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmvenda = fVenda;
            this.idUsuariologado = frmvenda.idUsuario;
            this.autorizado = frmvenda.autorizado;
        }

        #region VARIAVEIS

        int idUsuario, idUsuariologado = 0;
        public int tipo = 0;
        bool ativo;
        bool autorizado;

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmCancelarUltimaVenda_Load(object sender, EventArgs e)
        {

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
                    usuarioC.numCaixa = frmvenda.numCaixa;
                    usuarioC.nomeUsuario = frmvenda.nomeOperador;

                    dadosTabelaUsuario = usuarioRegraNegocios.PesquisarLoginUsuario(usuarioC);

                    if (dadosTabelaUsuario.Rows.Count > 0)
                    {
                        ativo = Convert.ToBoolean(dadosTabelaUsuario.Rows[0]["ATIVADO"].ToString());

                        if (ativo == true)
                        {
                            idUsuario = Convert.ToInt32(dadosTabelaUsuario.Rows[0]["ID_USUARIO"].ToString());

                            if (idUsuario == idUsuariologado)
                            {
                                frmvenda.autorizado = true;

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Usuário Está ''Destivado'', Por favor Entre em Contato com seu Gerente ou Administrador do Sistema.", "Usário Desativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
    }
}
