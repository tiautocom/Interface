using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using ACESSO_DADOS;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class UrlRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();
        ConexaoNet conexaoSqlServerWeb = new ConexaoNet();

        string dns = Dns.GetHostName();

        public DataTable PesquisaUrl(Url url)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_AMBIENTE", url.IdAmbiente);
                conexaoSqlServer.AdicionarParametros("@SERVICO", url.Servico);
                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUrlPesquisar", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaUrl(int idTipoAmbiente, string Servico)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_AMBIENTE", idTipoAmbiente);
                conexaoSqlServer.AdicionarParametros("@SERVICO", Servico);
                DataTable dadosTabela = new DataTable();

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUrlPesquisar", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
