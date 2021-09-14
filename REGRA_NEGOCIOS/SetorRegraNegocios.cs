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
    public class SetorRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable Listar(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();

                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspSetorPesquisarDescricao", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Deletar(int idSetor)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", idSetor);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspsetorDeletar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        string idRetorno;

        public string Salvar(Setor setor, int tipo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", setor.Id);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", setor.Descricao);

                if (tipo == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspSetorsalvar", dns).ToString();
                }
                else if (tipo == 2)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspSetorAlterar", dns).ToString();
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
