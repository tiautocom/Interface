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
    public partial class frmCadDepartamentos : Form
    {
        frmPrincipal frmPrincipal;

        public frmCadDepartamentos(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvDepartamentos.AutoGenerateColumns = false;
        }

        #region CLASSES E OBJETOS

        DepartamentoC deparatmento;
        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        public int idDepartamento = 0;

        #endregion

        private void frmCadDepartamentos_Load(object sender, EventArgs e)
        {
            LoadTela();
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
            idDepartamento = 0;
            txtDescricao.Text = "";
            txtCest.Text = "";
            txtAnp.Text = "";
            cbxAviso.Checked = false;
            txtDescricao.Focus();
            txtDescricao.SelectAll();
        }

        public void LoadTela()
        {
            Limpar();
            ListarDepartementos();
        }

        private void ListarDepartementos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.Listar(txtDescricao.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvDepartamentos.DataSource = null;
                    dgvDepartamentos.DataSource = dadosTabela;
                }
                else
                {
                    dgvDepartamentos.DataSource = null;
                }

                lblQtde.Text = dgvDepartamentos.Rows.Count.ToString().PadLeft(3,'0').Trim();
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
                    departamentoRegraNegocios = new DepartamentoRegraNegocios();
                    deparatmento = new DepartamentoC();

                    int idRet = 0;

                    deparatmento.Id = idDepartamento;
                    deparatmento.DepartamentoDesc = txtDescricao.Text.Trim();
                    deparatmento.Anp = txtAnp.Text.Trim();
                    deparatmento.cest = txtCest.Text.Trim();
                    deparatmento.Aviso = cbxAviso.Checked;

                    try
                    {
                        if (idDepartamento > 0)
                        {
                            if (MessageBox.Show("Realmente Deseja Alterar Departamento Selecionado?.", "Confirmação de Alteração Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                idRet = Convert.ToInt32(departamentoRegraNegocios.Salvar(deparatmento, 2));

                                MessageBox.Show("Departamento foi Alterado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            idRet = Convert.ToInt32(departamentoRegraNegocios.Salvar(deparatmento, 1));

                            MessageBox.Show("Novo Departamento foi Salvo com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        if (idRet > 0)
                        {
                            Limpar();

                            ListarDepartementos();
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

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idDepartamento = Convert.ToInt32(dgvDepartamentos.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                if (dgvDepartamentos.Columns[e.ColumnIndex].Name.Trim().Equals("colDel"))
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Departamento: " + dgvDepartamentos.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim(), "Confirmação de Deletar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DeletarDepartamento();
                    }
                }

                if (dgvDepartamentos.Columns[e.ColumnIndex].Name.Trim().Equals("colAlt"))
                {
                    txtDescricao.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim();
                    txtAnp.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colAnp"].Value.ToString().Trim();
                    txtCest.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["colCest"].Value.ToString().Trim();

                    bool aviso = Convert.ToBoolean(dgvDepartamentos.Rows[e.RowIndex].Cells["colAviso"].Value.ToString().Trim());

                    if (aviso == true)
                    {

                        cbxAviso.Text = "AVISAR";
                    }
                    else
                    {
                        cbxAviso.Text = "NÃO AVISAR";
                    }

                    cbxAviso.Checked = aviso;

                    txtDescricao.Focus();
                    txtDescricao.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeletarDepartamento()
        {
            try
            {
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                try
                {
                    int idRet = Convert.ToInt32(departamentoRegraNegocios.Deletar(idDepartamento));

                    MessageBox.Show("Departamento Selecionado foi Deletado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();

                    ListarDepartementos();
                }
                catch
                {
                    MessageBox.Show("Erro ao Deletar Departamento Selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxAviso_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAviso.Checked == true)
            {
                cbxAviso.Text = "AVISAR";
            }
            else
            {
                cbxAviso.Text = "NÃO AVISAR";
            }
        }
    }
}
