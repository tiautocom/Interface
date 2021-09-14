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
    public partial class frmSaidaPedido : Form
    {
        frmEntrada frmEntrada;
        frmPedidoSaida frmPedidoSaida;

        public frmSaidaPedido(int numSaida, string nome, string email, string tel, int idUsuario, string EsfODLonge, string EsfODPerto, string EsfOELonge, string EsfOEPerto, string CiliODLonge, string CiliOELonge, string CiliODPerto, string CiliOEPerto, string EixoODLonge, string EixoOElonge, string EixoOEPerto, string EixoODPerto, string DpODLonge, string DpOELonge, string DpODPerto, string DpOEPerto, frmEntrada fEntrada)
        {
            InitializeComponent();

            this.numSaida = numSaida;
            this.nome = nome;
            this.email = email;
            this.telefone = tel;
            this.idUsuario = idUsuario;

            this.EsfODLonge = EsfODLonge;
            this.EsfODPerto = EsfODPerto;
            this.EsfOELonge = EsfOELonge;
            this.EsfOEPerto = EsfOEPerto;

            this.CiliODLonge = CiliODLonge;
            this.CiliOELonge = CiliOELonge;
            this.CiliODPerto = CiliODPerto;
            this.CiliOEPerto = CiliOEPerto;

            this.EixoODLonge = EixoODLonge;
            this.EixoOElonge = EixoOElonge;
            this.EixoOEPerto = EixoOEPerto;
            this.EixoODPerto = EixoODPerto;

            this.DpODLonge = DpODLonge;
            this.DpOELonge = DpOELonge;
            this.DpODPerto = DpODPerto;
            this.DpOEPerto = DpOEPerto;

            this.dgvVenda.AutoGenerateColumns = false;
            this.dgvVenda.RowTemplate.Height = 70;

            this.frmEntrada = fEntrada;
        }

        public int numSaida = 0;
        public string nome = "";
        public string email = "";
        public string telefone = "";
        public int idCliente = 0;

        //PRODUTO
        public string codigoBarrasProduto = "";
        public int idProduto, produtoId, vendaId, itemVenda, setor, numDeparatmento = 0;
        public decimal precoProd, qtdeProd, totalVenda, subTotal, custo, desc, estoqueMin, estoqueAtual, qtdeDesc = 0;
        public string estoque = "0,00";
        public string reducao, descricaoProduto, unid, aliquota, ncm, cfop, tecla, granel, atualiza, embal, custoCaixa, lixo, validade, vencimento, margem, qtdeCom, dtCom = "";


        //PEDIDOS
        public int idPedido = 0;

        public string valorPis = "";
        public DateTime datavenda, dtAjuste;



        public bool baixado, fech, descAutomatico;
        public int numVenda;
        public string precototal, departam = "";

        public int idUsuario, numCaixa = 1;

        public decimal somaVenda = 0;
        public bool agruparVenda = false;

        public string EsfODLonge, EsfODPerto, EsfOELonge, EsfOEPerto = "";
        public string CiliODLonge, CiliOELonge, CiliODPerto, CiliOEPerto = "";
        public string EixoODLonge, EixoOElonge, EixoOEPerto, EixoODPerto = "";
        public string DpODLonge, DpOELonge, DpODPerto, DpOEPerto = "";

        PedidoRegraNegocios pedidoRegraNegocios;
        ProdutoRegraNegocios produtoRegraNegocios;
        VendaRegraNegocios vendaRegraNegocios;
        PedidoSaida pedidoSaida;

        ProdutoC produto;
        VendaC venda;

        private void frmSaidaPedido_Load(object sender, EventArgs e)
        {
            GetDadosPedido();

        }

        public void GetDadosPedido()
        {
            txtEsfODLonge.Text = EsfODLonge;
            txtEsfODPerto.Text = EsfODPerto;
            txtEsfOELonge.Text = EsfOELonge;
            txtEsfOEPerto.Text = EsfOEPerto;

            txtCiliODLonge.Text = CiliODLonge;
            txtCiliOELonge.Text = CiliOELonge;
            txtCiliODPerto.Text = CiliODPerto;
            txtCiliOEPerto.Text = CiliOEPerto;

            txtEixoODLonge.Text = EixoODLonge;
            txtEixoOELonge.Text = EixoOElonge;
            txtEixoOEPerto.Text = EixoOEPerto;
            txtEixoODPerto.Text = EixoODPerto;

            txtDpODLonge.Text = DpODLonge;
            txtDpOELonge.Text = DpOELonge;
            txtDpODPerto.Text = DpODPerto;
            txtDpOEPerto.Text = DpOEPerto;

            lblCliente.Text = nome.ToString().Trim();
            lblTel.Text = telefone.Trim();
            lblEmail.Text = email.Trim();
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblNumPedido.Text = numSaida.ToString().PadLeft(5, '0');

            PesquisarPedidoSaidaNumero();

            LimparCampos();
        }

        public void PesquisarNumPedido()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoAberto("", "1 - ENTRADA");

                if (dadosTabela.Rows.Count > 0)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProdutos frmProdutos = new frmProdutos(frmPedidoSaida);
            frmProdutos.ShowDialog();
        }


        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                codigoBarrasProduto = txtCodigoBarras.Text.Trim();

                PesquisarCodigoBarras();
            }

            if (e.KeyCode == Keys.F5)
            {
                button1_Click(sender, e);
            }

            if (e.KeyCode == Keys.Space)
            {
                btnSalvar_Click(sender, e);
            }
        }

        private void dgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void LimparCampos()
        {
            txtCodigoBarras.Text = "";
            txtCodigoBarras.Focus();
            txtCodigoBarras.SelectAll();
        }

        public void PedidoSaidaSalvar()
        {
            try
            {
                pedidoSaida = new PedidoSaida();

                pedidoSaida.NumPedido = Convert.ToInt32(lblNumPedido.Text);
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

        public void VenderItem(ProdutoC produto)
        {
            try
            {
                idUsuario = 1;
                numVenda = 1;

                if (string.IsNullOrEmpty(produto.codBarra))
                {
                    MessageBox.Show("Código de Barras não Pode ser Nulo ou Vázio", "Atenção");
                    txtCodigoBarras.Focus();
                }
                else if (string.IsNullOrEmpty(produto.descricao))
                {
                    MessageBox.Show("Produto não Pode ser Nulo ou Vázio", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (qtdeProd <= 0)
                {
                    MessageBox.Show("Quantidade de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (subTotal <= 0)
                {
                    MessageBox.Show("Total de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }
                else if (produto.ItemVenda == 0)
                {
                    MessageBox.Show("Item de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (datavenda == null)
                {
                    MessageBox.Show("Data da Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (produto.idProduto <= 0)
                {
                    MessageBox.Show("Codigo do Produto não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (idUsuario <= 0)
                {
                    MessageBox.Show("Codigo do Usuário não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }

                else if (numVenda <= 0)
                {
                    MessageBox.Show("Numero de Venda não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }
                else if (numCaixa <= 0)
                {
                    MessageBox.Show("Numro do Caixa não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }
                else if (precoProd <= 0)
                {
                    MessageBox.Show("Preço do Produto não Pode ser Menor ou Igual a Zero", "Atenção");
                    txtCodigoBarras.Focus();
                }
                else
                {
                    vendaRegraNegocios = new VendaRegraNegocios();

                    int item = dgvVenda.Rows.Count + 1;
                    decimal qtde = Math.Round(qtdeProd, 5);
                    decimal preco = Math.Round(precoProd, 3);
                    decimal somas = Math.Round((qtde * preco), 3);

                    string idRetornoVenda = vendaRegraNegocios.VenderItem(produto, qtde, preco, somas, item, idUsuario, numVenda, numCaixa);

                    try
                    {
                        Convert.ToInt32(idRetornoVenda);

                        //VenderItemTxt();
                        dgvVenda.Refresh();
                        dgvVenda.Update();
                        //LimparCampos();
                        //ListarGrid();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Cadastrar Venda, Verifique se Exite(m) dados com valor(es) Obrigatório, ou entre em Contato com seu Administrador", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }


        public List<VENDAS> listaVendas = new List<VENDAS>();

        public void ListarGrid()
        {
            try
            {
                somaVenda = 0;
                int linha = 0;

                venda = new VendaC();
                vendaRegraNegocios = new VendaRegraNegocios();
                DataTable dadosTabelaVenda = new DataTable();

                if (agruparVenda == true)
                {
                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVendaAgrupada(numCaixa, numVenda);
                }
                else
                {
                    dadosTabelaVenda = vendaRegraNegocios.PesquisarVenda(numCaixa, numVenda);
                }

                if (dadosTabelaVenda.Rows.Count > 0)
                {
                    listaVendas = new List<VENDAS>();

                    for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                    {
                        linha = (i + 1);

                        listaVendas.Add(new VENDAS()
                        {
                            itemVenda = linha.ToString(),
                            idProd = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ID_PROD"].ToString()),
                            qtde = Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QUANT"].ToString()).ToString(),
                            IdVenda = Convert.ToInt32(dadosTabelaVenda.Rows[i]["ID"].ToString()),
                        });
                    }

                    //GetVenda(listaVendas);

                    dgvVenda.DataSource = null;
                    dgvVenda.DataSource = dadosTabelaVenda;
                }
                else
                {
                    dgvVenda.DataSource = null;
                }

                if (dgvVenda.Rows.Count > 0)
                {
                    decimal soma = 0;

                    for (int i = 0; i < dgvVenda.Rows.Count; i++)
                    {
                        string va = Convert.ToDecimal(dgvVenda.Rows[i].Cells["colTotal"].Value.ToString()).ToString("N2");

                        soma += Convert.ToDecimal(va);

                        dgvVenda.Rows[i].Cells["colItem"].Value = (i + 1).ToString().PadLeft(3, '0');
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarPedidoSaidaNumero()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoSaidaNum(Convert.ToInt32(lblNumPedido.Text));

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
            if (dgvVenda.Rows.Count == 0)
            {
                MessageBox.Show("Informe o(s) Produto(s) para Realizar Cadastro de Saido do Pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                LimparCampos();
            }
            else if (MessageBox.Show("Realmente Deseja Salvar Saida do Pedido Selecionado?", "Confirmação Saida Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SalvarPedido();
            }
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
                        NumPedido = Convert.ToInt32(lblNumPedido.Text),
                        IdUsuario = idUsuario,
                        IdProduto = Convert.ToInt32(dgvVenda.Rows[i].Cells["colIdProd"].Value.ToString()),
                        Qtde = Convert.ToDecimal(dgvVenda.Rows[i].Cells["colQtde"].Value.ToString()),
                        Estoque = Convert.ToDecimal(dgvVenda.Rows[i].Cells["colEstoque"].Value.ToString()),
                    });
                }

                int idRet = pedidoRegraNegocios.BaixaEstoqueProdutoPedido(listaPedido, txtObservacao.Text.Trim());

                if (idRet > 0)
                {
                    frmEntrada.PesquisarPedido();

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
