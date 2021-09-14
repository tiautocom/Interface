using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using ACESSO_DADOS;
using System.Data;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class ProdutoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        public string idRetorno = "";

        string dns = Dns.GetHostName();

        public DataTable PesquisaProdutoCodigoBarras(ProdutoC produtoC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", produtoC.codBarra);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarCodigoBarras", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarProdutoEstoque(Decimal qtdeMin)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ESTOQUE", qtdeMin);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPesquisarEstoqueMimnimo", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarProdutoNome(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarNome", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarCodigoInterno()
        {
            try
            {
                try
                {
                    conexaoSqlServer.LimparParametros();
                    DataTable dadosTabela = new DataTable();
                    dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPequisarUltimoCodigoIteno", dns);
                    return dadosTabela;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarProdutoId(int idProduto)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_INTERNO", idProduto);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarId", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaProdutoCodigoBarras_(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarCodigoBarras", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarBaixaEstoqueProduto(int idProduto, decimal estoqueAtual)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@COD_INT", idProduto);
                conexaoSqlServer.AdicionarParametros("@ESTOQUE", estoqueAtual);
                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoBaixaEstoque", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PesquisarCodigoBarras()
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                int idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoCodgoBarras", dns));

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Salvar(ProdutoC produto, int tipo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@COD_BARRA", produto.codBarra);
                conexaoSqlServer.AdicionarParametros("@NUM_DEPAR", produto.numDepartamento);
                conexaoSqlServer.AdicionarParametros("@DEPARTAM", produto.DepartamentoDesc);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", produto.descricao);
                conexaoSqlServer.AdicionarParametros("@ESTOQUE", produto.estoque);
                conexaoSqlServer.AdicionarParametros("@PRECO", produto.preco);
                conexaoSqlServer.AdicionarParametros("@UNID", produto.unid);
                conexaoSqlServer.AdicionarParametros("@CUSTO", produto.custo);
                conexaoSqlServer.AdicionarParametros("@TRIB", produto.trib);
                conexaoSqlServer.AdicionarParametros("@REDUCAO", produto.reducao);
                conexaoSqlServer.AdicionarParametros("@DESCONTO", produto.desc);
                conexaoSqlServer.AdicionarParametros("@EST_MIN", produto.estoqueMin);
                conexaoSqlServer.AdicionarParametros("@TECLA", produto.tecla);
                conexaoSqlServer.AdicionarParametros("@GRANEL", produto.granel);
                conexaoSqlServer.AdicionarParametros("@DESC_AUTO", produto.qtdeAutomatica);
                conexaoSqlServer.AdicionarParametros("@QTDE_DESC", produto.qtdeDesc);
                conexaoSqlServer.AdicionarParametros("@ATUALIZA", produto.atualiza);
                conexaoSqlServer.AdicionarParametros("@EMBAL", produto.embal);
                conexaoSqlServer.AdicionarParametros("@CUSTO_CX", produto.custoCaixa);
                conexaoSqlServer.AdicionarParametros("@LIXO", produto.lixo);
                conexaoSqlServer.AdicionarParametros("@DT_AJUSTE", DateTime.Now.ToString());
                conexaoSqlServer.AdicionarParametros("@SETOR", produto.setor);
                conexaoSqlServer.AdicionarParametros("@VALIDADE", produto.validade);
                conexaoSqlServer.AdicionarParametros("@VENCIMENTO", produto.vencimento);
                conexaoSqlServer.AdicionarParametros("@MARGEM", produto.margem);
                conexaoSqlServer.AdicionarParametros("@QT_COM", produto.qtdeCom);
                conexaoSqlServer.AdicionarParametros("@DT_COM", produto.dtCom);
                conexaoSqlServer.AdicionarParametros("@VALOR_PIS", produto.valorPis);
                conexaoSqlServer.AdicionarParametros("@CST_PIS", produto.cstPis);
                conexaoSqlServer.AdicionarParametros("@VALOR_CONFINS", produto.valorCofins);
                conexaoSqlServer.AdicionarParametros("@CFOP", produto.cfop);
                conexaoSqlServer.AdicionarParametros("@CST_COFINS", produto.cstCofins);
                conexaoSqlServer.AdicionarParametros("@ORIGEM_PRODUTO", produto.origemProduto);
                conexaoSqlServer.AdicionarParametros("@ICMS", produto.icms);
                conexaoSqlServer.AdicionarParametros("@NCM", produto.ncm);
                conexaoSqlServer.AdicionarParametros("@ICMS_CST", produto.cstIcms);
                conexaoSqlServer.AdicionarParametros("@CST_IPI", produto.cstPis);
                conexaoSqlServer.AdicionarParametros("@IPI", produto.percIpi.ToString());
                conexaoSqlServer.AdicionarParametros("@CEST", produto.cest);
                conexaoSqlServer.AdicionarParametros("@GTIN", produto.gTin);

                if (tipo == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoSalvar", dns).ToString();
                }
                else
                {
                    conexaoSqlServer.AdicionarParametros("@COD_INT", produto.idProduto);

                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoAlterar", dns).ToString();
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                return "";

                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarDescricao(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarCodigoBarrasDescricao", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarCodBarrasProd(string codigo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", codigo);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoPesquisarCodigoBarrasDescricao1", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarBaixaEstoqueProduto(List<VENDAS> lista)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                decimal novoEstoque = 0;

                foreach (var item in lista)
                {
                    conexaoSqlServer.AdicionarParametros("@COD_INT", item.idProd);
                    conexaoSqlServer.AdicionarParametros("@QTDE", Convert.ToDecimal(item.qtde));

                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspBaixaEstoque", dns).ToString();

                    conexaoSqlServer.LimparParametros();
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
