using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACESSO_DADOS;
using System.Data;
using OBJETO_TRANSFERENCIA;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class VendaRegraNegocios
    {
        #region CLASSES E OBJETOS

        Conexao conexaoSqlServer = new Conexao();
        ConexaoNet conexaoSqlServerWeb = new ConexaoNet();

        string dns = Dns.GetHostName();

        #endregion

        public string VenderItem(VendaC venda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", venda.codBarra);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO_PRODUTO", venda.descricao);
                conexaoSqlServer.AdicionarParametros("@QUANT", venda.qtde);
                conexaoSqlServer.AdicionarParametros("@TOTAL", venda.subTotal);
                conexaoSqlServer.AdicionarParametros("@ITEM", venda.item);
                conexaoSqlServer.AdicionarParametros("@DATA", DateTime.Now);
                conexaoSqlServer.AdicionarParametros("@ID_PROD", venda.idProduto);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", venda.idUsuario);
                conexaoSqlServer.AdicionarParametros("@CUSTO", venda.custo);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", venda.baixado);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", venda.numVenda);
                conexaoSqlServer.AdicionarParametros("@ALIQUOTA", venda.aliquota);
                conexaoSqlServer.AdicionarParametros("@PRECO", venda.precoProduto);
                conexaoSqlServer.AdicionarParametros("@CST_PIS", venda.cstPis);
                conexaoSqlServer.AdicionarParametros("@VALOR_PIS", venda.valorPis);
                conexaoSqlServer.AdicionarParametros("@CST_COFINS", venda.cstCofins);
                conexaoSqlServer.AdicionarParametros("@VALOR_COFINS", venda.valorCofins);
                conexaoSqlServer.AdicionarParametros("@CFOP", venda.cfop);
                conexaoSqlServer.AdicionarParametros("@NCM", venda.ncm);
                conexaoSqlServer.AdicionarParametros("@ORIGEM_PRODUTO", venda.origemProduto);
                conexaoSqlServer.AdicionarParametros("@ICM_CST", venda.icmsCst);
                conexaoSqlServer.AdicionarParametros("@FECH", venda.fech);
                conexaoSqlServer.AdicionarParametros("@CEST", venda.cest);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", venda.numCaixa);
                conexaoSqlServer.AdicionarParametros("@TAG", venda.tag);
                conexaoSqlServer.AdicionarParametros("@UNID", venda.unid);
                conexaoSqlServer.AdicionarParametros("@ANP", venda.anp);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaItem", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaRelatorios(string dtIni, string dtFim, int tipoPesquisaRel)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);

                DataTable dadosTabela = new DataTable();

                if (tipoPesquisaRel == 1)
                {
                    dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarTotal", dns);
                }
                else if (tipoPesquisaRel == 2)
                {
                    dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaCurvaABC", dns);
                }
                else if (tipoPesquisaRel == 3)
                {
                    dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaDepartamentos", dns);
                }
                else if (tipoPesquisaRel == 4)
                {
                    dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaCaixa", dns);
                }

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVenda(string dtIni, string dtFim)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);
                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarTotal", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVendaIdUsuario(string dtIni, string dtFim, int idUsuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaUsuarios", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVenda(int numCaixa, int numVenda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarNum", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaAgrupada(int numCaixa, int numVenda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarNum", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CancelarItemVenda(VendaC venda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", venda.vendaId);
                conexaoSqlServer.AdicionarParametros("@COD_INT", venda.idProduto);
                conexaoSqlServer.AdicionarParametros("@QTDE", venda.qtde);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCancelarItens", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizaItemGrid(VendaC venda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@ITEM", venda.item);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", venda.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ID", venda.vendaId);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaAtualizaItemGrid", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FecharStatusVenda(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@ID", vendaC.vendaId);
                conexaoSqlServer.AdicionarParametros("@FECH", vendaC.fech);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", vendaC.baixado);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaFecharStatus", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVendaNumCaixa(string dtIni, string dtFim, int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaNumCaixa", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaDinheiro(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarDinheiro", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarUltimaVenda(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", vendaC.numVenda);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarNum", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarRelatorioTotalMesTotalAliquota(object numCaixa, int mes, int ano)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@DATA", mes);
                conexaoSqlServer.AdicionarParametros("@DATAY", ano);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarAliquotaMesAnterior", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVenda(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", vendaC.fech);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisar", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string VenderItem(ProdutoC produto, decimal qtde, decimal preco, decimal somas, int item, int idUsuario, int numVenda, int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", produto.codBarra);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO_PRODUTO", produto.descricao);
                conexaoSqlServer.AdicionarParametros("@QUANT", qtde);
                conexaoSqlServer.AdicionarParametros("@TOTAL", (qtde * preco));
                conexaoSqlServer.AdicionarParametros("@ITEM", item);
                conexaoSqlServer.AdicionarParametros("@DATA", produto.dtAjuste);
                conexaoSqlServer.AdicionarParametros("@ID_PROD", produto.idProduto);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", idUsuario);
                conexaoSqlServer.AdicionarParametros("@CUSTO", produto.custo);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", true);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);
                conexaoSqlServer.AdicionarParametros("@ALIQUOTA", produto.aliquota);
                conexaoSqlServer.AdicionarParametros("@PRECO", produto.preco);
                conexaoSqlServer.AdicionarParametros("@CST_PIS", produto.cstPis);
                conexaoSqlServer.AdicionarParametros("@VALOR_PIS", produto.valorPis);
                conexaoSqlServer.AdicionarParametros("@CST_COFINS", produto.cstCofins);
                conexaoSqlServer.AdicionarParametros("@VALOR_COFINS", produto.valorCofins);
                conexaoSqlServer.AdicionarParametros("@CFOP", produto.cfop);
                conexaoSqlServer.AdicionarParametros("@NCM", produto.ncm);
                conexaoSqlServer.AdicionarParametros("@ORIGEM_PRODUTO", produto.origemProduto);
                conexaoSqlServer.AdicionarParametros("@ICM_CST", produto.icmsCst);
                conexaoSqlServer.AdicionarParametros("@FECH", false);
                conexaoSqlServer.AdicionarParametros("@CEST", produto.cest);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@TAG", "");
                conexaoSqlServer.AdicionarParametros("@UNID", produto.unid);
                conexaoSqlServer.AdicionarParametros("@ANP", "");

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaItem", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int FormatarItemVendas(List<VENDAS> lista)
        {
            try
            {
                int idRetorno = 0;

                foreach (var item in lista)
                {
                    conexaoSqlServer.LimparParametros();

                    conexaoSqlServer.AdicionarParametros("@ITEM", item.itemVenda);
                    conexaoSqlServer.AdicionarParametros("@ID", item.IdVenda);

                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaFormatarItemVendas", dns).ToString());
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaDetalhes(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", vendaC.fech);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarTotalDetalhes", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string BaixarVenda(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", vendaC.baixado);
                conexaoSqlServer.AdicionarParametros("@FECH", vendaC.fech);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaFecharBaixado", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CadastrarVendaFechamento(VendaFechamento vendaFechamento, DataTable dadosTabelaVenda)
        {
            try
            {
                conexaoSqlServerWeb.LimparParametros();

                conexaoSqlServerWeb.AdicionarParametros("@CNPJ", vendaFechamento.Cnpj);
                conexaoSqlServerWeb.AdicionarParametros("@DATA", vendaFechamento.Data);
                conexaoSqlServerWeb.AdicionarParametros("@NUM_CAIXA", vendaFechamento.NumCaixa);
                conexaoSqlServerWeb.AdicionarParametros("@ID_USUARIO", vendaFechamento.IdUsuario);

                int idRetorno = Convert.ToInt32(conexaoSqlServerWeb.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaFechamentoCadastrar", dns).ToString());

                if (idRetorno > 0)
                {
                    if (dadosTabelaVenda != null)
                    {
                        for (int i = 0; i < dadosTabelaVenda.Rows.Count; i++)
                        {
                            conexaoSqlServerWeb.LimparParametros();

                            conexaoSqlServerWeb.AdicionarParametros("@ID_FECHAMENTO", idRetorno);
                            conexaoSqlServerWeb.AdicionarParametros("@COD", dadosTabelaVenda.Rows[i]["COD"].ToString().Trim());
                            conexaoSqlServerWeb.AdicionarParametros("@DESCRICAO", dadosTabelaVenda.Rows[i]["DESCRICAO"].ToString().Trim());
                            conexaoSqlServerWeb.AdicionarParametros("@QTDE", Convert.ToDecimal(dadosTabelaVenda.Rows[i]["QTDE"].ToString().Trim()));
                            conexaoSqlServerWeb.AdicionarParametros("@PRECO", Convert.ToDecimal(dadosTabelaVenda.Rows[i]["PRECO"].ToString().Trim()));
                            conexaoSqlServerWeb.AdicionarParametros("@TOTAL", Convert.ToDecimal(dadosTabelaVenda.Rows[i]["TOTAL"].ToString().Trim()));

                            int idRet = Convert.ToInt32(conexaoSqlServerWeb.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaFechamentoItemCadastrar", dns).ToString());

                            idRet = 0;
                        }
                    }
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaSetor(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECH", vendaC.fech);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarSetor", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarVendaFiscal(int numCaixa, int numVenda, bool tag)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);
                conexaoSqlServer.AdicionarParametros("@TAG", tag);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaAlterarVendaFiscal", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaTotalEstoque(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarTotalEstoque", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaTotal(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarTotal", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendas(VendaC vendaC, string setor)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@SETOR", setor);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasPesquisarSetor", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendas(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasPesquisar", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarUltimaItemVendido(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECH", vendaC.fech);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", vendaC.numVenda);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarUltimaItemVendido", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendasCanceladasDetalhes(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarCancelada", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendasCanceladas(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarCancelada", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendasCanceladas(VendaC vendaC, string dt)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DT", dt);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarCanceladaFechada", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaDepartamentos(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarDepartamento", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaNum(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", vendaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@FECH", vendaC.fech);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarVendaNum", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaDepartamentosRZ(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarDepartamentoRZ", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaTotalRZ(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasPesquisarRZ", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaEstoqueTotalRZ(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasEstoquePesquisarRZ", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CancelarVendaNum(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", vendaC.codBarra);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO_PRODUTO", vendaC.descricao);
                conexaoSqlServer.AdicionarParametros("@QUANT", vendaC.qtde);
                conexaoSqlServer.AdicionarParametros("@TOTAL", vendaC.total);
                conexaoSqlServer.AdicionarParametros("@ITEM", vendaC.item);
                conexaoSqlServer.AdicionarParametros("@DATA", DateTime.Now);
                conexaoSqlServer.AdicionarParametros("@ID_PROD", vendaC.idProduto);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@CUSTO", vendaC.custo);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", vendaC.baixado);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", vendaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@ALIQUOTA", vendaC.trib);
                conexaoSqlServer.AdicionarParametros("@PRECO", vendaC.preco);
                conexaoSqlServer.AdicionarParametros("@CST_PIS", "");
                conexaoSqlServer.AdicionarParametros("@VALOR_PIS", "");
                conexaoSqlServer.AdicionarParametros("@CST_COFINS", "");
                conexaoSqlServer.AdicionarParametros("@VALOR_COFINS", "");
                conexaoSqlServer.AdicionarParametros("@CFOP", vendaC.cfop);
                conexaoSqlServer.AdicionarParametros("@NCM", "");
                conexaoSqlServer.AdicionarParametros("@ORIGEM_PRODUTO", "");
                conexaoSqlServer.AdicionarParametros("@ICM_CST", "");
                conexaoSqlServer.AdicionarParametros("@FECH", false);
                conexaoSqlServer.AdicionarParametros("@CEST", "");
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@TAG", vendaC.tag);
                conexaoSqlServer.AdicionarParametros("@UNID", vendaC.unid);
                conexaoSqlServer.AdicionarParametros("@ANP", vendaC.anp);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaItem", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BaixaEstoque(int idProd, decimal estoque, decimal qtde)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                decimal novoEst = (estoque - qtde);

                conexaoSqlServer.AdicionarParametros("@ESTOQUE", novoEst);
                conexaoSqlServer.AdicionarParametros("@COD_INT", idProd);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoBaixaEstoque", dns).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVendaAgrupadoUsuarios(string dtIni, string dtFim)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarAgrupadoUsuarios", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaSetorRZ(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasSetorRZ", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarVendaTributosRZ(int numCaixa, string data)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@DATA", data);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendasTributoRZ", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarSetor()
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspSetorAll", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVendaAgrupadoCodBarras(string dtIni, string dtFim)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarAgrupadoCodBarras", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaVendaAgrupadoDescricao(string dtIni, string dtFim)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DATA_INI", dtIni);
                conexaoSqlServer.AdicionarParametros("@DATA_FIM", dtFim);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarAgrupadoDescricao", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaNum(int numVenda, int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendas", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarTotalEstoque(VendaC vendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", vendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", vendaC.idUsuario);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspEstoquePesquisarTotal", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarNumVenda(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspNumVendaPesquisarCaixa", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarNumVendas(int numCaixa, int numVenda, int item)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_VENDA", item);


                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaPesquisarCaixaItem", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AdicionarVendatemp(List<VENDAS> listaVendas)
        {
            try
            {
                int idRetorno = 0;

                foreach (var item in listaVendas)
                {
                    conexaoSqlServer.LimparParametros();

                    conexaoSqlServer.AdicionarParametros("@ITEM", item.itemVenda);
                    conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", item.idProd);
                    conexaoSqlServer.AdicionarParametros("@QUANTIDADE", item.qtde);
                    conexaoSqlServer.AdicionarParametros("@ID_VENDA", item.IdVenda);

                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaTemp", dns).ToString());
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CancelarItemVenda(int numCaixa, int idvenda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@ID", idvenda);

                int idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaDeletarItem", dns).ToString());

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarVendaNaoAgrupada(int numCaixa, int numVenda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numVenda);
                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspVendaListarNumSAgrup", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CadastrarVendaChaveWeb(VendaChaveAcesso vendaChaveAcesso, List<VendaC> lista)
        {
            try
            {
                conexaoSqlServerWeb.LimparParametros();

                conexaoSqlServerWeb.AdicionarParametros("@CNPJ_EMITENTE", vendaChaveAcesso.CnpjEmitente);
                conexaoSqlServerWeb.AdicionarParametros("@CNPJ_CLIENTE", vendaChaveAcesso.CnpjDestinatario);
                conexaoSqlServerWeb.AdicionarParametros("@CONDUTOR", vendaChaveAcesso.Condutor);
                conexaoSqlServerWeb.AdicionarParametros("@PLACA", vendaChaveAcesso.Placa);
                conexaoSqlServerWeb.AdicionarParametros("@NUM_VENDA", vendaChaveAcesso.NumVenda);
                conexaoSqlServerWeb.AdicionarParametros("@CHAVE", vendaChaveAcesso.ChaveCFe);
                conexaoSqlServerWeb.AdicionarParametros("@FECHADO", vendaChaveAcesso.Fechado);
                conexaoSqlServerWeb.AdicionarParametros("@DATA", vendaChaveAcesso.Data);
                conexaoSqlServerWeb.AdicionarParametros("@VALOR", vendaChaveAcesso.Valor);

                int idRetorno = Convert.ToInt32(conexaoSqlServerWeb.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaCadastrarChave", dns).ToString());

                if (idRetorno > 0)
                {
                    if (lista != null)
                    {
                        foreach (var item in lista)
                        {
                            conexaoSqlServerWeb.LimparParametros();

                            conexaoSqlServerWeb.AdicionarParametros("@QTDE", item.qtde);
                            conexaoSqlServerWeb.AdicionarParametros("@PRECO", item.preco);
                            conexaoSqlServerWeb.AdicionarParametros("@DESCRICAO", item.descricao);
                            conexaoSqlServerWeb.AdicionarParametros("@COD_BARRAS", item.codBarra);
                            conexaoSqlServerWeb.AdicionarParametros("@UNIDADE", item.unid);
                            conexaoSqlServerWeb.AdicionarParametros("@ID_VENDA_CHAVE", idRetorno);
                            conexaoSqlServerWeb.AdicionarParametros("@CNPJ_CLIENTE", vendaChaveAcesso.CnpjDestinatario);
                            conexaoSqlServerWeb.AdicionarParametros("@EMITIDO", 0);

                            int idRet = Convert.ToInt32(conexaoSqlServerWeb.ExecutarManipulacao(CommandType.StoredProcedure, "uspVendaItemCadastrarChave", dns).ToString());

                            idRet = 0;
                        }
                    }
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
