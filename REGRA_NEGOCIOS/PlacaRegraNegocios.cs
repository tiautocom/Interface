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
    public class PlacaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public string CadastrarPlaca(PlacaC placaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_VENDA", placaC.idVenda);
                conexaoSqlServer.AdicionarParametros("@PLACA", placaC.placa);
                conexaoSqlServer.AdicionarParametros("@KM", placaC.km);
                conexaoSqlServer.AdicionarParametros("@DATA", placaC.dtCadastro);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPlacaCadastrar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarPlaca(int numVenda)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_VENDA", numVenda);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPlacaPesquisarPlaca", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarPlaca(PlacaC placaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_VENDA", placaC.idVenda);
                conexaoSqlServer.AdicionarParametros("@PLACA", placaC.placa);
                conexaoSqlServer.AdicionarParametros("@KM", placaC.km);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPlacaAlterar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
