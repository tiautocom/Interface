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
    public class PagamentoVendaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public string CadastrarPagamentoVenda(PagamentoVendaC pagamentoVendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_CLIENTE", pagamentoVendaC.idCliente);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", pagamentoVendaC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@TIPO_PAGAMENTO", pagamentoVendaC.tipoPagamento);
                conexaoSqlServer.AdicionarParametros("@VALOR", pagamentoVendaC.valor);
                conexaoSqlServer.AdicionarParametros("@CNPJ", pagamentoVendaC.cnpj);
                conexaoSqlServer.AdicionarParametros("@NUM_CUPOM", pagamentoVendaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", pagamentoVendaC.baixado);
                conexaoSqlServer.AdicionarParametros("@DT", pagamentoVendaC.data);
                conexaoSqlServer.AdicionarParametros("@TROCO", pagamentoVendaC.troco);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", pagamentoVendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECHADO", pagamentoVendaC.fechado);
                conexaoSqlServer.AdicionarParametros("@TAG", pagamentoVendaC.tag);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPagamentoVendaCadastrar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FecharStatusPagamentoVenda(PagamentoVendaC pagamentoVendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@FECHADO", pagamentoVendaC.fechado);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", pagamentoVendaC.baixado);
                conexaoSqlServer.AdicionarParametros("@NUM_CUPOM", pagamentoVendaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", pagamentoVendaC.numCaixa);
                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPagamentoVendAlterarStatusFechado", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPagamentoVenda(PagamentoVendaC pagamentoVendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", pagamentoVendaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", pagamentoVendaC.numCaixa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPagamentoVendaPesquisar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarPagamentoVenda(PagamentoVendaC pagamentoVendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", pagamentoVendaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@BAIXADO", pagamentoVendaC.fechado);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPagamentoVendaListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FecharPagamentoVendaBaixado(PagamentoVendaC pagamentoVendaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@BAIXADO", pagamentoVendaC.baixado);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", pagamentoVendaC.numCaixa);
                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPagamentoVendAlterarStatusBaixado", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarPagamentoVendaRZ(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPagamentoVendaListarRZ", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarPagamentoVendaFechamentoDia(int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixaFechamentoDia", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
