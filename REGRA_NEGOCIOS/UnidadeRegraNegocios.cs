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
    public class UnidadeRegraNegocios
    {
        string idRetorno;

        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public string Salvar(Unidade unidade, int tipo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", unidade.Id);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", unidade.Descricao);

                if (tipo == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUnidadesalvar", dns).ToString();
                }
                else if (tipo == 2)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUnidadeAlterar", dns).ToString();
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Listar(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();

                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUnidadePesquisarDescricao", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object Deletar(int idUniade)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", idUniade);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUnidadeDeletar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
