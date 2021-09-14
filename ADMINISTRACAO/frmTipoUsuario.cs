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

namespace ADMINISTRACAO
{
    public partial class frmTipoUsuario : Form
    {
        frmPrincipal frmPrincipal;

        public frmTipoUsuario(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
            this.dgvTipoUsuario.AutoGenerateColumns = false;
        }

        #region CLASSES E OBJETOS

        UsuarioRegraNegocios usuarioRegraNegocios;

        #endregion

        #region VARIAVEIS

        public int idTipoUsuario = 0;
        public int idRet = 0;

        #endregion

        private void frmTipoUsuario_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void LoadTela()
        {
            LimparCampos();
            ListarTipo();
        }

        public void ListarTipo()
        {
            DataTable dadosTabela = new DataTable();
            usuarioRegraNegocios = new UsuarioRegraNegocios();

            dadosTabela = usuarioRegraNegocios.ListarTipoUsuario();

            if (dadosTabela.Rows.Count > 0)
            {
                dgvTipoUsuario.DataSource = null;
                dgvTipoUsuario.DataSource = dadosTabela;
            }
            else
            {
                dgvTipoUsuario.DataSource = null;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                if (txtUsuario.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Tipo de Usuário não Pode ser Nulo ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                }
                else
                {
                    usuarioRegraNegocios = new UsuarioRegraNegocios();

                    idTipoUsuario = Convert.ToInt32(txtCodigo.Text);

                    idRet = 0;

                    if (Convert.ToInt32(idTipoUsuario) == 0)
                    {
                        try
                        {
                            idRet = Convert.ToInt32(usuarioRegraNegocios.CadastrarTipoUsuario(txtUsuario.Text.Trim()));

                            MessageBox.Show("Novo Tipo de Usuário foi Cadastrado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadTela();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Salvar Novo Tipo de Usuário.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtUsuario.Focus();
                            txtUsuario.SelectAll();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Realmente Deseja Alterar Tipo de Usuário Selecionado.", "Conformação de Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            try
                            {
                                idRet = Convert.ToInt32(usuarioRegraNegocios.CadastrarTipoUsuario(idTipoUsuario, txtUsuario.Text.Trim()));

                                MessageBox.Show("Novo Tipo de Usuário foi Alterado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadTela();
                            }
                            catch
                            {
                                MessageBox.Show("Erro ao Alterar Novo Tipo de Usuário.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtUsuario.Focus();
                                txtUsuario.SelectAll();
                            }
                        }
                        else
                        {
                            LimparCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "0";
            txtUsuario.Text = "";

            txtUsuario.Focus();
            txtUsuario.SelectAll();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            brnExcluir.Enabled = false;
        }

        private void dgvTipoUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTipoUsuario.Columns[e.ColumnIndex].Name.Trim().Equals("colSel"))
            {
                txtCodigo.Text = dgvTipoUsuario.Rows[e.RowIndex].Cells["colId"].Value.ToString().Trim();
                txtUsuario.Text = dgvTipoUsuario.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim();

                btnSalvar.Enabled = false;
                btnAlterar.Enabled = true;
                brnExcluir.Enabled = true;

                txtUsuario.Focus();
                txtUsuario.SelectAll();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void brnExcluir_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        public void Deletar()
        {
            try
            {
                idTipoUsuario = Convert.ToInt32(txtCodigo.Text);

                if (idTipoUsuario == 0)
                {
                    MessageBox.Show("Código do Tipo de Usuário não Pode ser Zero ou Nulo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                }
                else
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Tipo de Usuário: " + txtUsuario.Text.ToString().Trim() + "? ", "Confirmação para Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        idRet = 0;

                        try
                        {
                            idRet = Convert.ToInt32(usuarioRegraNegocios.DeletarTipoUsuario(idTipoUsuario));

                            MessageBox.Show("Tipo de Usuário foi Deletado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadTela();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Deletar Tipo de Usuário Selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
