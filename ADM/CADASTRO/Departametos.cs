using REGRA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM.CADASTRO
{
    public partial class Departametos : Form
    {
        frmPrincipal frmPrincipal;

        public Departametos(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvDepartamentos.AutoGenerateColumns = false;
        }

        DepartamentoRegraNegocios departamentoRegraNegocios;

        public string descricao = "";
        public int idDepartamento = 0;

        private void Departametos_Load(object sender, EventArgs e)
        {
            PesquisarDepartamentos();
        }

        public void PesquisarDepartamentos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.CarreagarComboDepartamento(txtDescricao.Text);

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvDepartamentos.DataSource = null;
                    dgvDepartamentos.DataSource = dadosTabela;
                }
                else
                {
                    dgvDepartamentos.DataSource = null;
                }

                lblQtde.Text = dgvDepartamentos.Rows.Count.ToString().PadLeft(5, '0');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LimparCampos()
        {
            txtDescricao.Text = "";
            txtAnp.Text = "";
            txtCest.Text = "";
            txtNcm.Text = "";
            cbBebidas.Checked = false;

            txtDescricao.Focus();
            txtDescricao.SelectAll();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDepartamentos.Columns[e.ColumnIndex].Name.Trim().Equals("colDeletar"))
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Departamento: " + dgvDepartamentos.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim() + ". ", "Confirmação de Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        idDepartamento = Convert.ToInt32(dgvDepartamentos.Rows[e.RowIndex].Cells["colIdDep"].Value.ToString());

                        int idRet = Convert.ToInt32(departamentoRegraNegocios.Deletar(idDepartamento));

                        if (idRet > 0)
                        {
                            MessageBox.Show("Novo Departemento Foi Cadastrado com Sucesso.", "Sucesso Novo Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            OnLoad(e);

                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Deletar Departamento Selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (dgvDepartamentos.Columns[e.ColumnIndex].Name.Trim().Equals("colEditar"))
                {
                    idDepartamento = Convert.ToInt32(dgvDepartamentos.Rows[e.RowIndex].Cells["colIdDep"].Value.ToString());
                    txtDescricao.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim();
                    txtCest.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colCest"].Value.ToString().Trim() ?? "0000";
                    txtNcm.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colNcm"].Value.ToString().Trim() ?? "";
                    txtAnp.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colAnp"].Value.ToString().Trim() ?? "";
                    cbBebidas.Checked = Convert.ToBoolean(dgvDepartamentos.Rows[e.RowIndex].Cells["colAviso"].Value.ToString().Trim());

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            PesquisarDepartamentos();
        }
    }
}
