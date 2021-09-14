using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ACESSO_DADOS;
using OBJETO_TRANSFERENCIA;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class SangriaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarSomaTotalDia(SangriaC sangriaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", sangriaC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@TIPO", sangriaC.tipo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", sangriaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECHADO", sangriaC.fechado);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspSangriaContadorLinha", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarSangriaDespesas(SangriaC sangriaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", sangriaC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@VALOR", sangriaC.valor);
                conexaoSqlServer.AdicionarParametros("@DATA", sangriaC.data);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", sangriaC.descricao);
                conexaoSqlServer.AdicionarParametros("@TIPO", sangriaC.tipo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", sangriaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECHADO", sangriaC.fechado);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspSangriaCadastrar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarSangriaCaixa(int idUsuario, int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", idUsuario);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspSangriaPesquisarSangria", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FecharSangria(SangriaC sangriaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", sangriaC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", sangriaC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@FECHADO", sangriaC.fechado);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspSangriaFechar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
