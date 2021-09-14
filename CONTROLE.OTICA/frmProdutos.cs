using OBJETO_TRANSFERENCIA;
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

namespace CONTROLE.OTICA
{
    public partial class frmProdutos : Form
    {
        frmPedidoSaida frmPedidoSaida;

        public frmProdutos(frmPedidoSaida fPedidoSaida)
        {
            InitializeComponent();

            this.frmPedidoSaida = fPedidoSaida;

            this.gdvProduto.AutoGenerateColumns = false;
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

            try
            {
                int _descricao = Convert.ToInt32(descricao);

                PesquisarProdutoCodigoBarras();
            }
            catch
            {
                PesquisarProdutoNome();
            }
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

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            PesquisarProdutoNome();
        }

        private void gdvProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmPedidoSaida.codigoBarrasProduto = gdvProduto.Rows[e.RowIndex].Cells["colCodBarras"].Value.ToString();
                frmPedidoSaida.PesquisarCodigoBarras();

                this.Close();
                this.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Error.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = gdvProduto.CurrentRow.Index;

                try
                {
                    frmPedidoSaida.codigoBarrasProduto = gdvProduto.Rows[index].Cells["colCodBarras"].Value.ToString();

                    frmPedidoSaida.PesquisarCodigoBarras();

                    this.Close();
                    this.Refresh();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                gdvProduto.Focus();
            }

            if (e.KeyCode == Keys.Up)
            {
                gdvProduto.Focus();
            }
        }
    }
}
