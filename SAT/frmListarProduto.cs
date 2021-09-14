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
    public partial class frmListarProduto : Form
    {
        frmVenda frmVenda;

        public frmListarProduto(frmVenda fVenda)
        {
            InitializeComponent();

            gdvProduto.AutoGenerateColumns = false;
            gdvProduto.RowTemplate.Height = 40;

            this.frmVenda = fVenda;
        }

        #region CLASSES

        ProdutoC produtoC = new ProdutoC();
        ProdutoRegraNegocios produtoRegraNegocios = new ProdutoRegraNegocios();

        #endregion

        public string descricao = "";
        public int estoqueAt = 0;

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            descricao = txtPesquisa.Text;
            PesquisarProdutoNome();
        }

        public void PesquisarProdutoNome()
        {
            try
            {
                produtoC = new ProdutoC();
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabelaProduto = new DataTable();

                dadosTabelaProduto = produtoRegraNegocios.PesquisarProdutoNome(descricao);

                if (dadosTabelaProduto.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabelaProduto;
                    lblQtde.Text = gdvProduto.Rows.Count.ToString();

                    for (int i = 0; i < gdvProduto.Rows.Count; i++)
                    {
                        try
                        {
                            estoqueAt = Convert.ToInt32(gdvProduto.Rows[i].Cells["colEstoque"].Value);

                            if (estoqueAt < 0)
                            {
                                gdvProduto.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                        catch
                        {
                            estoqueAt = 0;
                            break;
                        }
                    }
                }
                else
                {
                    gdvProduto.DataSource = null;
                    lblQtde.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarProdutoCodigoBarras()
        {
            try
            {
                produtoRegraNegocios = new ProdutoRegraNegocios();
                DataTable dadosTabelaProduto = new DataTable();

                dadosTabelaProduto = produtoRegraNegocios.PesquisaProdutoCodigoBarras_(descricao);

                if (dadosTabelaProduto.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabelaProduto;
                    lblQtde.Text = gdvProduto.Rows.Count.ToString();

                    for (int i = 0; i < gdvProduto.Rows.Count; i++)
                    {
                        try
                        {
                            estoqueAt = Convert.ToInt32(gdvProduto.Rows[i].Cells["colEstoque"].Value);

                            if (estoqueAt < 0)
                            {
                                gdvProduto.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                        catch
                        {
                            estoqueAt = 0;
                            break;
                        }
                    }
                }
                else
                {
                    gdvProduto.DataSource = null;
                    lblQtde.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void frmListarProduto_Load(object sender, EventArgs e)
        {
            PesquisarProdutoNome();
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmVenda.codigoBarrasProduto = "";
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                gdvProduto.Focus();
            }

            if (e.KeyCode == Keys.Down)
            {
                gdvProduto.Focus();
            }
        }

        private void gdvProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LimparCampos();
                txtPesquisa.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {

                if (gdvProduto.Rows.Count > 0)
                {
                    int n = Convert.ToInt32(gdvProduto.CurrentRow.Index);

                    frmVenda.codigoBarrasProduto = gdvProduto.Rows[n].Cells["colCodBarras"].Value.ToString().Trim();

                    this.Close();
                    this.Refresh();
                }
                else
                {
                    LimparCampos();

                    txtPesquisa.Focus();
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                try
                {
                    txtValor.Text = Convert.ToDecimal(gdvProduto.Rows[gdvProduto.CurrentRow.Index - 1].Cells["colPreco"].Value.ToString()).ToString("N2");
                }
                catch
                {
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    txtValor.Text = Convert.ToDecimal(gdvProduto.Rows[gdvProduto.CurrentRow.Index + 1].Cells["colPreco"].Value.ToString()).ToString("N2");
                }
                catch
                {
                }
            }
        }

        public void LimparCampos()
        {
            txtPesquisa.Clear();
        }

        private void gdvProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmVenda.codigoBarrasProduto = gdvProduto.Rows[e.RowIndex].Cells["colCodBarras"].Value.ToString();

                this.Close();
                this.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Error.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gdvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdvProduto.Columns[e.ColumnIndex].Name.Trim().Equals("colAlt"))
                {
                    int idProduto = Convert.ToInt32(gdvProduto.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                }

                txtValor.Text = gdvProduto.Rows[e.RowIndex].Cells["colPreco"].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nCaso Problema Persistir entre em Contao com Administrador", "Erro Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
