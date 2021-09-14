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
using OBJETO_TRANSFERENCIA;

namespace ADMINISTRACAO
{
    public partial class frmCadUnidades : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadUnidades(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvUnidades.AutoGenerateColumns = false;
        }

        #region VARIAVEIS

        public int idUniade = 0;

        #endregion

        #region CLASSES E OBJETOS

        UnidadeRegraNegocios unidadeRegraNegocios;
        Unidade unidade;

        #endregion

        private void frmCadUnidades_Load(object sender, EventArgs e)
        {
            ListarUnidade();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public void Limpar()
        {
            idUniade = 0;
            txtDescricao.Text = "";
            txtDescricao.Focus();
            txtDescricao.SelectAll();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                if (txtDescricao.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Descrição do Unidade do Produto não Pode ser Nulou ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
                else
                {
                    unidadeRegraNegocios = new UnidadeRegraNegocios();
                    unidade = new Unidade();

                    int idRet = 0;

                    unidade.Id = idUniade;
                    unidade.Descricao = txtDescricao.Text.Trim();

                    try
                    {
                        if (idUniade > 0)
                        {
                            if (MessageBox.Show("Realmente Deseja Alterar Unidade de Produto Selecionado?.", "Confirmação de Alteração Unidade de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                idRet = Convert.ToInt32(unidadeRegraNegocios.Salvar(unidade, 2));

                                MessageBox.Show("Novo Unidade de Produto foi Alterado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            idRet = Convert.ToInt32(unidadeRegraNegocios.Salvar(unidade, 1));

                            MessageBox.Show("Nova Unidade de Produto foi Salvo com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (idRet > 0)
                        {
                            Limpar();

                            ListarUnidade();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Salvar um Novo Setor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ListarUnidade()
        {
            try
            {
                unidadeRegraNegocios = new UnidadeRegraNegocios();
                DataTable dadosTabela = new DataTable();

                dadosTabela = unidadeRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvUnidades.DataSource = null;
                    dgvUnidades.DataSource = dadosTabela;
                }
                else
                {
                    dgvUnidades.DataSource = null;
                }

                lblQtde.Text = dgvUnidades.Rows.Count.ToString().PadLeft(3, '0').Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUnidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idUniade = Convert.ToInt32(dgvUnidades.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                if (dgvUnidades.Columns[e.ColumnIndex].Name.Trim().Equals("colDel"))
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Setor: " + dgvUnidades.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim(), "Confirmação de Deletar Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DeletarUnidade();
                    }
                }

                if (dgvUnidades.Columns[e.ColumnIndex].Name.Trim().Equals("colAlt"))
                {
                    txtDescricao.Text = dgvUnidades.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim();

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeletarUnidade()
        {
            try
            {
                unidadeRegraNegocios = new UnidadeRegraNegocios();

                try
                {
                    int idRet = Convert.ToInt32(unidadeRegraNegocios.Deletar(idUniade));

                    MessageBox.Show("Setor Selecionado foi Deletado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();

                    ListarUnidade();
                }
                catch
                {
                    MessageBox.Show("Erro ao Deletar Setor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
