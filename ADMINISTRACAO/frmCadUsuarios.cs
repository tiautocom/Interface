using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;

namespace ADMINISTRACAO
{
    public partial class frmCadUsuarios : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadUsuarios(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.gdvUsuario.AutoGenerateColumns = false;
        }

        public int tipoUsuario = 0;
        public bool ativo, status, pemissao;

        UsuarioC usuario;
        UsuarioRegraNegocios usuarioRegraNegocios;

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadUsuarios_Load(object sender, EventArgs e)
        {
            LimparCampos();
            ListarUsuarios();
            ListarTipoUsuarios();
        }

        public void ListarUsuarios()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                usuarioRegraNegocios = new UsuarioRegraNegocios();

                dadosTabela = usuarioRegraNegocios.ListarUsuariosAll();

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvUsuario.DataSource = null;
                    gdvUsuario.DataSource = dadosTabela;
                }
                else
                {
                    gdvUsuario.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ListarTipoUsuarios()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                usuarioRegraNegocios = new UsuarioRegraNegocios();

                dadosTabela = usuarioRegraNegocios.ListarTipoUsuario();

                if (dadosTabela.Rows.Count > 0)
                {
                    cbbTipo.DataSource = null;
                    cbbTipo.DataSource = dadosTabela;
                    cbbTipo.DisplayMember = "DESCRICAO";
                    cbbTipo.ValueMember = "ID";
                }
                else
                {
                    cbbTipo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            cbPeriodo.Text = "";
            txtCodigo.Text = "0";
            txtUsuario.Focus();
            btnAlterar.Enabled = false;
            btnSalvar.Enabled = true;

            txtSenha.UseSystemPasswordChar = false;

            txtUsuario.Focus();
            txtUsuario.SelectAll();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                if (String.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Campo Usuário em Branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                }
                else if (String.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Campo Senha em Branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtSenha.Focus();
                    txtSenha.SelectAll();
                }
                else if (cbbTipo.Text.Equals(""))
                {
                    MessageBox.Show("Campo Senha em Branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtSenha.Focus();
                    txtSenha.SelectAll();
                }
                else if (String.IsNullOrEmpty(cbPeriodo.Text))
                {
                    MessageBox.Show("Campo Periodo em Branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    cbPeriodo.Focus();
                    cbPeriodo.SelectAll();
                }
                else
                {
                    tipoUsuario = Convert.ToInt32(cbbTipo.SelectedValue);

                    if (cbStatus.Text.Substring(0, 1).Trim().Equals("0"))
                    {
                        ativo = false;
                    }
                    else
                    {
                        ativo = true;
                    }

                    if (cbStatus.Text.Substring(1, 0).Trim().Equals("0"))
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }

                    if (cbPermissao.Text.Substring(0, 1).Trim().Equals("0"))
                    {
                        pemissao = false;
                    }
                    else
                    {
                        pemissao = true;
                    }

                    usuario = new UsuarioC();

                    usuario.idUsuario = Convert.ToInt32(txtCodigo.Text);
                    usuario.nomeUsuario = txtUsuario.Text.Trim();
                    usuario.senha = txtSenha.Text.Trim();
                    usuario.ativo = ativo;
                    usuario.idTipoUsuario = tipoUsuario;
                    usuario.periodo = cbPeriodo.Text.Trim();
                    usuario.statusUsuario = status;
                    usuario.permissao = pemissao;
                    usuario.numCaixa = Convert.ToInt32(txtNumCaixa.Text.Trim());

                    int idRet = 0;

                    try
                    {
                        if (Convert.ToInt32(txtCodigo.Text) == 0)
                        {
                            idRet = usuarioRegraNegocios.CadastrarUsuario(usuario);
                        }
                        else
                        {
                            if (MessageBox.Show("Realmente Deseja Realizar Alteração do Usuário Selecionado ?.", "Alteração de Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                try
                                {
                                    idRet = Convert.ToInt32(usuarioRegraNegocios.AlterarUsuarios(usuario));

                                    MessageBox.Show("Usuário Salvo com Sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    ListarUsuarios();

                                    LimparCampos();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Erro ao Alterar Usuário Selecionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    txtUsuario.Focus();
                                    txtUsuario.SelectAll();
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Salvar Usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvUsuario.Columns[e.ColumnIndex].Name.Trim().Equals("colEdit"))
            {
                if (MessageBox.Show("Usuário Selecionado: " + gdvUsuario.Rows[e.RowIndex].Cells["colNome"].Value.ToString() + ".", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    txtCodigo.Text = gdvUsuario.Rows[e.RowIndex].Cells["colIdUsuario"].Value.ToString().Trim();
                    txtUsuario.Text = gdvUsuario.Rows[e.RowIndex].Cells["colNome"].Value.ToString().Trim();
                    txtSenha.Text = gdvUsuario.Rows[e.RowIndex].Cells["colSenha"].Value.ToString().Trim();
                    cbbTipo.Text = gdvUsuario.Rows[e.RowIndex].Cells["colTipoUser"].Value.ToString().Trim();
                    cbPeriodo.Text = gdvUsuario.Rows[e.RowIndex].Cells["colPeriodo"].Value.ToString().Trim();
                    //cbStatus.Text= gdvUsuario.Rows[e.RowIndex].Cells["colStatus"].Value.ToString().Trim();
                    //cbPermissao.Text= gdvUsuario.Rows[e.RowIndex].Cells["colPermissao"].Value.ToString().Trim();
                    txtNumCaixa.Text = gdvUsuario.Rows[e.RowIndex].Cells["colNumCaixa"].Value.ToString().Trim();

                    if (Convert.ToBoolean(gdvUsuario.Rows[e.RowIndex].Cells["colPermissao"].Value.ToString().Trim()) == true)
                    {
                        cbPermissao.Text = "1 - ATIVO";
                    }
                    else
                    {
                        cbPermissao.Text = "0 - INATIVO";
                    }

                    if (Convert.ToBoolean(gdvUsuario.Rows[e.RowIndex].Cells["colStatus"].Value.ToString().Trim()) == true)
                    {
                        cbStatus.Text = "1 - ATIVO";
                    }
                    else
                    {
                        cbStatus.Text = "0 - INATIVO";
                    }

                    btnSalvar.Enabled = false;
                    btnAlterar.Enabled = true;
                    txtSenha.UseSystemPasswordChar = true;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNovoDepartamento_Click(object sender, EventArgs e)
        {
            frmTipoUsuario frmTipoUsuario = new frmTipoUsuario(frmPrincipal);
            frmTipoUsuario.ShowDialog();

            this.OnLoad(e);
        }

        private void cbxSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
    }
}
