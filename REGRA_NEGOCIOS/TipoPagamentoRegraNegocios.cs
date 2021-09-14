using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ACESSO_DADOS;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class TipoPagamentoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable ListarTipoPagamento()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspTipopagamentoListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
