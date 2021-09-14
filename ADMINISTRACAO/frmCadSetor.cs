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
    public partial class frmCadSetor : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadSetor(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvSetor.AutoGenerateColumns = false;
        }

        #region CLASSES E OBJETOS

        SetorRegraNegocios setorRegraNegocios;
        Setor setor;

        #endregion

        #region VARIAVEIS

        public int idSetor = 0;

        #endregion

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadSetor_Load(object sender, EventArgs e)
        {
            Limpar();
            ListarSetor();
        }

        public void ListarSetor()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                setorRegraNegocios = new SetorRegraNegocios();

                dadosTabela = setorRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvSetor.DataSource = null;
                    dgvSetor.DataSource = dadosTabela;
                }
                else
                {
                    dgvSetor.DataSource = null;
                }

                lblQtde.Text = dgvSetor.Rows.Count.ToString().PadLeft(3, '0').Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public void Limpar()
        {
            idSetor = 0;
            txtDescricao.Text = "";
            txtDescricao.Focus();
            txtDescricao.SelectAll();
        }

        public void Salvar()
        {
            try
            {
                if (txtDescricao.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Descrição do Setor não Pode ser Nulou ou Vázio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
                else
                {
                    setorRegraNegocios = new SetorRegraNegocios();
                    setor = new Setor();

                    int idRet = 0;

                    setor.Id = idSetor;
                    setor.Descricao = txtDescricao.Text.Trim();

                    try
                    {
                        if (idSetor > 0)
                        {
                            if (MessageBox.Show("Realmente Deseja Alterar Setor Selecionado?.", "Confirmação de Alteração Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                idRet = Convert.ToInt32(setorRegraNegocios.Salvar(setor, 2));

                                MessageBox.Show("Novo Setor foi Salvo com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            idRet = Convert.ToInt32(setorRegraNegocios.Salvar(setor, 1));

                            MessageBox.Show("Novo Setor foi Salvo com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        if (idRet > 0)
                        {
                            Limpar();

                            ListarSetor();
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

        private void dgvSetor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSetor = Convert.ToInt32(dgvSetor.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                if (dgvSetor.Columns[e.ColumnIndex].Name.Trim().Equals("colDel"))
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Setor: " + dgvSetor.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim(), "Confirmação de Deletar Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DeletarSetor();
                    }
                }

                if (dgvSetor.Columns[e.ColumnIndex].Name.Trim().Equals("colAlt"))
                {
                    txtDescricao.Text = dgvSetor.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim();

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeletarSetor()
        {
            try
            {
                setorRegraNegocios = new SetorRegraNegocios();

                try
                {
                    int idRet = Convert.ToInt32(setorRegraNegocios.Deletar(idSetor));

                    MessageBox.Show("Setor Selecionado foi Deletado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListarSetor();

                    Limpar();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
    }
}
