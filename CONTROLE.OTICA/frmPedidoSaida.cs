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
    public partial class frmPedidoSaida : Form
    {
        frmEntrada frmEntrada;

        public frmPedidoSaida()
        {
            InitializeComponent();

            this.dgvVenda.AutoGenerateColumns = false;
            this.dgvVenda.RowTemplate.Height = 50;
        }

        ProdutoRegraNegocios produtoRegraNegocios;
        PedidoRegraNegocios pedidoRegraNegocios;
        ProdutoC produto;
        PedidoSaida pedidoSaida;

        public int idProduto = 0;
        public decimal qtdeProd, precoProd, subTotal = 0;
        public int idUsuario, idCliente, idPedido = 0;

        //PRODUTO
        public string codigoBarrasProduto = "";

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                codigoBarrasProduto = txtCodigoBarras.Text.Trim();

                if (txtNumero.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Informe Numero do Pedido para Realizar Cadastro de Saido do Pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtNumero.Focus();
                    txtNumero.SelectAll();
                }
                else
                {
                    PesquisarCodigoBarras();
                }
            }

            if (e.KeyCode == Keys.F5)
            {
                btnPesquisarProduto_Click(sender, e);
            }

            if (e.KeyCode == Keys.Space)
            {
                btnSalvar_Click(sender, e);
            }
        }

        private void frmPedidoSaida_Load(object sender, EventArgs e)
        {

        }

        public void PesquisarPedidoSaidaNumero()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoSaidaNum(Convert.ToInt32(txtNumero.Text));

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvVenda.DataSource = null;
                    dgvVenda.DataSource = dadosTabela;
                }
                else
                {
                    dgvVenda.DataSource = dadosTabela;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNumero.Text.Trim()) <= 0)
            {
                MessageBox.Show("Informe Numero do Pedido para Realizar Cadastro de Saido do Pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (dgvVenda.Rows.Count == 0)
            {
                MessageBox.Show("Informe o(s) Produto(s) para Realizar Cadastro de Saido do Pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                LimparCampos();
            }
            else if (MessageBox.Show("Realmente Deseja Salvar Saida do Pedido Selecionado?", "Confirmação Saida Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SalvarPedido();
            }
        }

        public void PesquisarCodigoBarras()
        {
            try
            {
                if (codigoBarrasProduto.Trim() != "")
                {
                    produtoRegraNegocios = new ProdutoRegraNegocios();
                    produto = new ProdutoC();
                    DataTable dadosTabelaProduto = new DataTable();

                    txtCodigoBarras.Text = codigoBarrasProduto.Trim().PadLeft(13, '0');

                    produto.codBarra = codigoBarrasProduto = txtCodigoBarras.Text.Trim().PadLeft(13, '0');

                    dadosTabelaProduto = produtoRegraNegocios.PesquisaProdutoCodigoBarras(produto);

                    if (dadosTabelaProduto.Rows.Count > 0)
                    {
                        //DADOS TABELA PRODUTO
                        idProduto = 0;

                        produto.idProduto = idProduto = Convert.ToInt32(dadosTabelaProduto.Rows[0]["COD_INT"].ToString());
                        produto.numDepartamento = Convert.ToInt32(dadosTabelaProduto.Rows[0]["NUM_DEPAR"].ToString());
                        produto.codBarra = dadosTabelaProduto.Rows[0]["COD_BARRA"].ToString().Trim();
                        produto.DepartamentoDesc = dadosTabelaProduto.Rows[0]["DEPARTAM"].ToString().Trim();
                        produto.descricao = dadosTabelaProduto.Rows[0]["DESCRICAO"].ToString().Trim();
                        produto.preco = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["PRECO"].ToString());
                        produto.unid = dadosTabelaProduto.Rows[0]["UNID"].ToString().Trim();
                        produto.desc = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["DESC"].ToString());
                        produto.aliquota = dadosTabelaProduto.Rows[0]["TRIB"].ToString().Trim();
                        produto.reducao = Convert.ToString(dadosTabelaProduto.Rows[0]["REDUCAO"].ToString())?.ToString() ?? null;
                        produto.estoque = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["ESTOQUE"].ToString());
                        produto.estoqueMin = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["EST_MIN"].ToString());
                        produto.ncm = dadosTabelaProduto.Rows[0]["NCM"].ToString().Trim();
                        produto.cfop = dadosTabelaProduto.Rows[0]["CFOP"].ToString().Trim();
                        produto.tecla = Convert.ToDecimal(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["TECLA"].ToString().Trim()?.ToString() ?? null));
                        produto.granel = dadosTabelaProduto.Rows[0]["GRANEL"].ToString().Trim();
                        produto.descAuto = Convert.ToBoolean(dadosTabelaProduto.Rows[0]["DESC_AUTO"].ToString());
                        produto.qtdeDesc = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["QTDE_DESC"].ToString());
                        produto.custo = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["CUSTO"].ToString());
                        produto.atualiza = dadosTabelaProduto.Rows[0]["ATUALIZA"].ToString().Trim();
                        produto.embal = Convert.ToDecimal(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["EMBAL"].ToString().Trim()?.ToString() ?? null));
                        produto.custoCaixa = Convert.ToDecimal(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["CUSTO_CX"].ToString().Trim()?.ToString() ?? null));
                        produto.lixo = Convert.ToDecimal(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["LIXO"].ToString().Trim()?.ToString() ?? null));
                        produto.dtAjuste = DateTime.Now.Date;
                        produto.setor = Convert.ToInt32(dadosTabelaProduto.Rows[0]["SETOR"].ToString());
                        produto.validade = dadosTabelaProduto.Rows[0]["VALIDADE"].ToString().Trim();
                        produto.vencimento = dadosTabelaProduto.Rows[0]["VENCIMENTO"].ToString().Trim();

                        produto.margem = Convert.ToDecimal(dadosTabelaProduto.Rows[0]["MARGEM"].ToString().Trim());
                        produto.qtdeCom = Convert.ToDecimal(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["QT_COM"].ToString().Trim()?.ToString() ?? null));
                        produto.dtCom = Convert.ToString(string.IsNullOrEmpty(dadosTabelaProduto.Rows[0]["DT_COM"].ToString().Trim()?.ToString() ?? null));
                        produto.valorPis = dadosTabelaProduto.Rows[0]["VALOR_PIS"].ToString().ToString()?.ToString() ?? null;
                        produto.cstPis = dadosTabelaProduto.Rows[0]["CST_PIS"].ToString().Trim();
                        produto.valorCofins = dadosTabelaProduto.Rows[0]["VALOR_CONFINS"].ToString().Trim();
                        produto.cstCofins = dadosTabelaProduto.Rows[0]["CST_COFINS"].ToString().Trim();
                        produto.origemProduto = dadosTabelaProduto.Rows[0]["ORIGEM_PRODUTO"].ToString().Trim();
                        produto.icms = dadosTabelaProduto.Rows[0]["ICMS"].ToString().Trim();
                        produto.icmsCst = dadosTabelaProduto.Rows[0]["ICMS_CST"].ToString().Trim();
                        produto.cest = dadosTabelaProduto.Rows[0]["CEST"].ToString().Trim();
                        produto.ItemVenda = (dgvVenda.Rows.Count + 1);
                        produto.granel = "";

                        if ((produto.granel == "") || (produto.granel == null))
                        {
                            //ATRIBUIR VALORES AS VARIAVEIS
                            qtdeProd = Convert.ToDecimal(1);
                            precoProd = Convert.ToDecimal(produto.preco);
                            subTotal = (qtdeProd * precoProd);

                            string qtdeF = String.Format("{0:N3}", qtdeProd);

                            PedidoSaidaSalvar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto não Ecnontrado na Base de Dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {
                    if (MessageBox.Show("Produto Código de Barras " + codigoBarrasProduto + " não foi Encontrado...", "Produto não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        txtCodigoBarras.Text = "";
                        txtCodigoBarras.Focus();
                    }
                    else
                    {
                        PesquisarCodigoBarras();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                LimparCampos();
            }
        }

        public void PedidoSaidaSalvar()
        {
            try
            {
                pedidoSaida = new PedidoSaida();

                pedidoRegraNegocios = new PedidoRegraNegocios();

                pedidoSaida.NumPedido = Convert.ToInt32(txtNumero.Text);
                pedidoSaida.Data = DateTime.Now;
                pedidoSaida.IdUsuario = idUsuario;
                pedidoSaida.IdProduto = idProduto;
                pedidoSaida.IdCliente = idCliente;
                pedidoSaida.Qtde = 1;
                pedidoSaida.Status = false;
                pedidoSaida.Obs = txtObservacao.Text.Trim();

                int idRet = pedidoRegraNegocios.SalvarPedidoSaida(pedidoSaida);

                if (idRet > 0)
                {
                    PesquisarPedidoSaidaNumero();

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumero.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Informe Numero da Saida do Pedido.", "Atenção Campo Numero PEdido Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtNumero.Focus();
                    txtNumero.SelectAll();
                }
                else
                {
                    txtCodigoBarras.Focus();
                    txtCodigoBarras.SelectAll();
                }
            }
        }

        private void dgvVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtObservacao.Focus();
                txtObservacao.SelectAll();
            }
        }

        private void dgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVenda.Columns[e.ColumnIndex].Name.Trim().Equals("colDel"))
                {
                    if (MessageBox.Show("Realmente Deseja Deletar Item Produto : " + dgvVenda.Rows[e.RowIndex].Cells["colDescricao"].Value.ToString().Trim() + ".", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        idPedido = Convert.ToInt32(dgvVenda.Rows[e.RowIndex].Cells["colId"].Value);

                        pedidoRegraNegocios = new PedidoRegraNegocios();

                        int idRet = pedidoRegraNegocios.DeletarPedido(idPedido);

                        if (idRet > 0)
                        {
                            MessageBox.Show("Pedido Selecionado foi Deletado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            PesquisarPedidoSaidaNumero();

                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Erro oa Deletar Pedido Selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            frmProdutos frmProdutos = new frmProdutos(this);
            frmProdutos.ShowDialog();
        }

        private void LimparCampos()
        {
            txtCodigoBarras.Text = "";
            txtCodigoBarras.Focus();
            txtCodigoBarras.SelectAll();
        }

        public void SalvarPedido()
        {
            try
            {
                List<PedidoSaida> listaPedido = new List<PedidoSaida>();

                pedidoRegraNegocios = new PedidoRegraNegocios();

                for (int i = 0; i < dgvVenda.Rows.Count; i++)
                {
                    listaPedido.Add(new PedidoSaida()
                    {
                        Id = Convert.ToInt32(dgvVenda.Rows[i].Cells["colId"].Value.ToString()),
                        NumPedido = Convert.ToInt32(txtNumero.Text),
                        IdUsuario = idUsuario,
                        IdProduto = Convert.ToInt32(dgvVenda.Rows[i].Cells["colIdProd"].Value.ToString()),
                        Qtde = Convert.ToDecimal(dgvVenda.Rows[i].Cells["colQtde"].Value.ToString()),
                        Estoque = Convert.ToDecimal(dgvVenda.Rows[i].Cells["colEstoque"].Value.ToString()),
                    });
                }

                int idRet = pedidoRegraNegocios.BaixaEstoqueProdutoPedido(listaPedido, txtObservacao.Text.Trim());

                if (idRet > 0)
                {

                    MessageBox.Show("Cadastrar Saida foi Salvo com Sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao Cadastrar Saida de Pedido...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
