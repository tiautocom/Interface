using ACESSO_DADOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class PedidoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarNumPedido()
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPeidoPesquisarNumero", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Salvar(Pedido pedido)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_CLIENTE", pedido.idCliente);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", pedido.IdUsuario);
                conexaoSqlServer.AdicionarParametros("@DATA_CAD", pedido.DataCadastro);
                conexaoSqlServer.AdicionarParametros("@OBSERVACAO", pedido.Observacao);
                conexaoSqlServer.AdicionarParametros("@NUMERO", pedido.Numero);

                conexaoSqlServer.AdicionarParametros("@ESF_OD_LONGE", pedido.EsfODLonge);
                conexaoSqlServer.AdicionarParametros("@ESF_OE_LONGE", pedido.EsfOEPerto);
                conexaoSqlServer.AdicionarParametros("@ESF_OD_PERTO", pedido.EsfODPerto);
                conexaoSqlServer.AdicionarParametros("@ESF_OE_PERTO", pedido.EsfOEPerto);

                conexaoSqlServer.AdicionarParametros("@CILI_OD_LONGE", pedido.CiliODLonge);
                conexaoSqlServer.AdicionarParametros("@CILI_OE_LONGE", pedido.CiliOELonge);
                conexaoSqlServer.AdicionarParametros("@CILI_OD_PERTO", pedido.CiliODPerto);
                conexaoSqlServer.AdicionarParametros("@CILI_OE_PERTO", pedido.CiliOEPerto);

                conexaoSqlServer.AdicionarParametros("@EIXO_OD_LONGE", pedido.EixoODLonge);
                conexaoSqlServer.AdicionarParametros("@EIXO_OE_LONGE", pedido.EixoOElonge);
                conexaoSqlServer.AdicionarParametros("@EIXO_OD_PERTO", pedido.EixoODPerto);
                conexaoSqlServer.AdicionarParametros("@EIXO_OE_PERTO", pedido.EixoOEPerto);

                conexaoSqlServer.AdicionarParametros("@DP_OD_LONGE", pedido.DpODLonge);
                conexaoSqlServer.AdicionarParametros("@DP_OE_LONGE", pedido.DpOELonge);
                conexaoSqlServer.AdicionarParametros("@DP_OD_PERTO", pedido.DpODPerto);
                conexaoSqlServer.AdicionarParametros("@DP_OE_PERTO", pedido.DpOEPerto);

                conexaoSqlServer.AdicionarParametros("@ALT_OD_LONGE", pedido.AltODLonge);
                conexaoSqlServer.AdicionarParametros("@ALT_OE_LONGE", pedido.AltOELonge);
                conexaoSqlServer.AdicionarParametros("@ALT_OD_PERTO", pedido.AltODPerto);
                conexaoSqlServer.AdicionarParametros("@ALT_OE_PERTO", pedido.AltOEPerto);

                conexaoSqlServer.AdicionarParametros("@NUM_RECEITA", pedido.NumReceita);
                conexaoSqlServer.AdicionarParametros("@OTICO", pedido.Otico);

                conexaoSqlServer.AdicionarParametros("@MEDICO", pedido.Medico.Nome);
                conexaoSqlServer.AdicionarParametros("@CRM", pedido.Medico.NumCrm);

                conexaoSqlServer.AdicionarParametros("@STATUS", pedido.Status);
                conexaoSqlServer.AdicionarParametros("@URL", pedido.Url);

                int idRetorno = 0;

                if (pedido.Id == 0)
                {
                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoSalvar", dns).ToString());
                }
                else
                {
                    conexaoSqlServer.AdicionarParametros("@ID", pedido.Id);

                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoAlterar", dns).ToString());
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPedidoFechado(string Numero, string status)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUMERO", Numero);
                conexaoSqlServer.AdicionarParametros("@STATUS", status);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPesquisarPedidoFechado", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeletarPedido(int idPedido)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@ID", idPedido);

                int idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoSaidaDeletar", dns).ToString());

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPedidoAberto(string Numero, string status)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUMERO", Numero);
                conexaoSqlServer.AdicionarParametros("@STATUS", status);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPesquisarPedidoAberto", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPedidoNum(int idPedido)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", idPedido);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPedidoPesquisaId", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPedidoIdCliente(int idCliente)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_CLIENTE", idCliente);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPedidoPesquisaIdCliente", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SalvarPedidoSaida(PedidoSaida pedidoSaida)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@NUM_PEDIDO", pedidoSaida.NumPedido);
                conexaoSqlServer.AdicionarParametros("@DATA", pedidoSaida.Data);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", pedidoSaida.IdUsuario);
                conexaoSqlServer.AdicionarParametros("@QTDE", pedidoSaida.Qtde);
                conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", pedidoSaida.IdProduto);
                conexaoSqlServer.AdicionarParametros("@STATUS", pedidoSaida.Status);
                conexaoSqlServer.AdicionarParametros("@OBSERVACAO", pedidoSaida.Obs);

                int idRetorno = 0;

                if (pedidoSaida.Id == 0)
                {
                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoSaidaSalvar", dns).ToString());
                }
                else
                {
                    conexaoSqlServer.AdicionarParametros("@ID", pedidoSaida.Id);

                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoSaidaAlterar", dns).ToString());
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPedidoSaidaNum(int num)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_PEDIDO", num);

                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPedidoSaidaPesquisaNumero", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int BaixaEstoqueProdutoPedido(List<PedidoSaida> listaPedido, string obs)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                int idRetorno = 0;

                foreach (var item in listaPedido)
                {
                    conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", item.IdProduto);
                    conexaoSqlServer.AdicionarParametros("@ESTOQUE", (item.Estoque - item.Qtde));
                    conexaoSqlServer.AdicionarParametros("@ID_USUARIO", item.IdUsuario);
                    conexaoSqlServer.AdicionarParametros("@QTDE", item.Qtde);
                    conexaoSqlServer.AdicionarParametros("@NUM_PEDIDO", item.NumPedido);
                    conexaoSqlServer.AdicionarParametros("@OBS", obs);

                    idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidoBaixaEstoqueProduto", dns).ToString());

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
