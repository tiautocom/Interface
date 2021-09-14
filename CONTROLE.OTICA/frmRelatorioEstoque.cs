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

namespace CONTROLE.OTICA
{
    public partial class frmRelatorioEstoque : Form
    {
        public frmRelatorioEstoque()
        {
            InitializeComponent();

            this.dgvProduto.AutoGenerateColumns = false;
            this.dgvProduto.RowTemplate.Height = 50;
        }

        ProdutoRegraNegocios produtoRegraNegocios;

        private void frmRelatorioEstoque_Load(object sender, EventArgs e)
        {
            PesquisarProduto();
        }

        public void PesquisarProduto()
        {
            try
            {
                if (Convert.ToDecimal(txtPesquisar.Text) >= 0)
                {
                    DataTable dadosTabela = new DataTable();

                    produtoRegraNegocios = new ProdutoRegraNegocios();

                    dadosTabela = produtoRegraNegocios.PesquisarProdutoEstoque(Convert.ToDecimal(txtPesquisar.Text));

                    if (dadosTabela.Rows.Count > 0)
                    {
                        dgvProduto.DataSource = null;
                        dgvProduto.DataSource = dadosTabela;
                    }
                    else
                    {
                        dgvProduto.DataSource = null;
                    }

                    lblQtde.Text = dgvProduto.Rows.Count.ToString().PadLeft(4, '0').Trim();
                }
                else
                {
                    MessageBox.Show("Informe Numero de Estoque Minimo para Pesquisar Relatorio Desejado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarProduto();
        }
    }
}
