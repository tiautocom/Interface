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
    public partial class frmUsuarioConfiguracao : Form
    {
        frmVenda frmVenda;

        public frmUsuarioConfiguracao(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
            gdvUsuario.AutoGenerateColumns = false;
        }

        #region VARIVEIS

        int idUsuario, idUsuarioLogado, codigo, numCaixa, tipoUsuario = 0;
        string nome, perido, senha, idTipoUsuario = "";
        bool ativado, status;

        #endregion

        #region CLASSES E OBJETOS

        UsuarioC usuarioC = new UsuarioC();
        UsuarioRegraNegocios usuarioRegraNegocios = new UsuarioRegraNegocios();

        TipoUsuarioC tipoUsuarioC = new TipoUsuarioC();
        TipoUsuarioRegraNegocios tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();

        #endregion

        private void frmUsuarioConfiguracao_Load(object sender, EventArgs e)
        {
            idUsuarioLogado = frmVenda.idUsuario;

            PesquisarUsuario();

            PopularCbTipoUsuario();

            if (txtCodigo.Text == "0")
            {
                btnAlterar.Text = "Cadastrar";
            }
            else
            {
                btnAlterar.Text = "Alterar";
            }
        }

        public void PopularCbTipoUsuario()
        {
            try
            {
                tipoUsuarioC = new TipoUsuarioC();
                tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();

                DataTable dadosTabelaTipoUsuario = new DataTable();

                dadosTabelaTipoUsuario = tipoUsuarioRegraNegocios.PopularCbTipoUsuario();

                if (dadosTabelaTipoUsuario.Rows.Count > 0)
                {
                    for (int i = 0; i < dadosTabelaTipoUsuario.Rows.Count; i++)
                    {
                        txtTipoUsuario.DataSource = dadosTabelaTipoUsuario;
                        txtTipoUsuario.ValueMember = "ID_USUARIO";
                        txtTipoUsuario.DisplayMember = "TIPO_USUARIO";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarUsuario()
        {
            try
            {
                usuarioC = new UsuarioC();
                usuarioRegraNegocios = new UsuarioRegraNegocios();
                DataTable dadosTabelaUsuario = new DataTable();

                usuarioC.nomeUsuario = txtNome.Text;

                dadosTabelaUsuario = usuarioRegraNegocios.PesquisarUsuario(usuarioC);

                if (dadosTabelaUsuario.Rows.Count > 0)
                {
                    gdvUsuario.DataSource = null;
                    gdvUsuario.DataSource = dadosTabelaUsuario;
                    lblQtdeUsuario.Text = gdvUsuario.Rows.Count.ToString().PadLeft(3, '0');
                }
                else
                {
                    gdvUsuario.DataSource = null;
                    lblQtdeUsuario.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            PesquisarUsuario();
        }

        private void gdvUsuario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                codigo = Convert.ToInt32(gdvUsuario.Rows[e.RowIndex].Cells["colIdUsuario"].Value.ToString());
                nome = gdvUsuario.Rows[e.RowIndex].Cells["colNome"].Value.ToString();
                senha = gdvUsuario.Rows[e.RowIndex].Cells["colSenha"].Value.ToString().Trim();
                perido = gdvUsuario.Rows[e.RowIndex].Cells["colPeriodo"].Value.ToString().Trim();
                numCaixa = Convert.ToInt32(gdvUsuario.Rows[e.RowIndex].Cells["colNumCaixa"].Value.ToString());
                status = Convert.ToBoolean(gdvUsuario.Rows[e.RowIndex].Cells["colStatus"].Value.ToString());
                ativado = Convert.ToBoolean(gdvUsuario.Rows[e.RowIndex].Cells["colAtivado"].Value.ToString());
                idTipoUsuario = gdvUsuario.Rows[e.RowIndex].Cells["colTipoUsuario"].Value.ToString().Trim();

                tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();
                DataTable dadosTabelaTipoUsuario = new DataTable();

                dadosTabelaTipoUsuario = tipoUsuarioRegraNegocios.PesquisarTipoUsuario(idTipoUsuario);

                if (dadosTabelaTipoUsuario.Rows.Count > 0)
                {
                    txtTipoUsuario.Text = dadosTabelaTipoUsuario.Rows[0]["TIPO_USUARIO"].ToString().Trim();
                }

                txtCodigo.Text = codigo.ToString().PadLeft(3, '0');
                txtNome.Text = nome;
                txtSenha.Text = senha;
                txtPeriodo.Text = perido;
                txtNumCaixa.Text = numCaixa.ToString().PadLeft(3, '0');


                if (ativado == true)
                {
                    cbxAtivo.Checked = true;
                }
                else
                {
                    cbxAtivo.Checked = false;
                }

                if (status == true)
                {
                    cbxStatus.Checked = true;
                }
                else
                {
                    cbxStatus.Checked = false;
                }

                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    btnAlterar.Text = "Alterar";
                }
                else
                {
                    btnAlterar.Text = "Cadastrar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (btnAlterar.Text == "Alterar")
            {
                AlterarUsuario();
            }
            else
            {
                CadastrarTipoUsuario();
            }
        }

        public void AlterarUsuario()
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Alterar Configuração do Usuário.", "Alteração de Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(txtCodigo.Text) <= 0)
                    {
                        MessageBox.Show("Código do Produto não Pode ser Menor ou Igual a Zero.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (txtNome.Text.Equals(""))
                    {
                        MessageBox.Show("Campo Nome não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNome.Focus();
                    }
                    else if (txtSenha.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo Senha não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Focus();
                    }
                    else if (txtSenha.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo Peiodo não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPeriodo.Focus();
                    }
                    else if (Convert.ToInt32(txtNumCaixa.Text) <= 0)
                    {
                        MessageBox.Show("Numero do caixa não Pode ser Menor ou Igual a Zero.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumCaixa.Focus();
                    }
                    else
                    {
                        usuarioC = new UsuarioC();
                        usuarioRegraNegocios = new UsuarioRegraNegocios();

                        if (cbxAtivo.Checked == true)
                        {
                            usuarioC.ativo = true;
                        }
                        else
                        {
                            usuarioC.ativo = false;
                        }

                        if (cbxStatus.Checked == true)
                        {
                            usuarioC.statusUsuario = true;
                        }
                        else
                        {
                            usuarioC.statusUsuario = false;
                        }

                        usuarioC.idUsuario = Convert.ToInt32(txtCodigo.Text);
                        usuarioC.nomeUsuario = txtNome.Text;
                        usuarioC.senha = txtSenha.Text.Trim();
                        usuarioC.periodo = txtPeriodo.Text.Trim();
                        usuarioC.numCaixa = Convert.ToInt32(txtNumCaixa.Text);
                        usuarioC.idTipoUsuario = Convert.ToInt32(txtTipoUsuario.SelectedValue);

                        string idRetorno = usuarioRegraNegocios.AlterarUsuario(usuarioC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);
                            MessageBox.Show("Alteração do Usuário foi Realizado com Sucesso!!!.", "Alteração com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PesquisarUsuario();
                            LimparCampos();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Alterar Usuário.", "Erro Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "0";
            txtNome.Text = "";
            txtNumCaixa.Text = "000";
            txtPeriodo.Text = "Informe Periodo";
            txtSenha.Text = "";
            txtTipoUsuario.Text = "Informe Tipo Usuário";
            cbxAtivo.Checked = true;
            cbxStatus.Checked = false;
            btnAlterar.Text = "Cadastrar";
            txtNome.Focus();
        }

        private void btnCadastrarTipoUsuario_Click(object sender, EventArgs e)
        {
            frmTipoUsuario fTipoUsuario = new frmTipoUsuario();
            fTipoUsuario.ShowDialog();
        }

        public void CadastrarTipoUsuario()
        {
            try
            {
                if (txtNome.Text.Equals(""))
                {
                    MessageBox.Show("Campo Nome não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.Focus();
                }
                else if (txtSenha.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Senha não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSenha.Focus();
                }
                else if (txtSenha.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Peiodo não Pode ser Nulo ou Vázio.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPeriodo.Focus();
                }
                else if (Convert.ToInt32(txtNumCaixa.Text) <= 0)
                {
                    MessageBox.Show("Numero do caixa não Pode ser Menor ou Igual a Zero.", "Campo Vázio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumCaixa.Focus();
                }
                else
                {
                    usuarioC = new UsuarioC();
                    usuarioRegraNegocios = new UsuarioRegraNegocios();

                    if (cbxAtivo.Checked == true)
                    {
                        usuarioC.ativo = true;
                    }
                    else
                    {
                        usuarioC.ativo = false;
                    }

                    if (cbxStatus.Checked == true)
                    {
                        usuarioC.statusUsuario = true;
                    }
                    else
                    {
                        usuarioC.statusUsuario = false;
                    }

                    usuarioC.idUsuario = Convert.ToInt32(txtCodigo.Text);
                    usuarioC.nomeUsuario = txtNome.Text;
                    usuarioC.senha = txtSenha.Text.Trim();
                    usuarioC.periodo = txtPeriodo.Text.Trim();
                    usuarioC.numCaixa = frmVenda.numCaixa;
                    usuarioC.idTipoUsuario = Convert.ToInt32(txtTipoUsuario.SelectedValue);

                    string idRetorno = usuarioRegraNegocios.Cadastrar(usuarioC);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);
                        MessageBox.Show("Usuário foi Cadastrado com Sucesso!!!.", "Cadastro com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisarUsuario();
                        LimparCampos();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Cadastrar Usuário.", "Erro Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
