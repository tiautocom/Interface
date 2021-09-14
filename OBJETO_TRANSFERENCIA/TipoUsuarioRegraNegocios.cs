using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACESSO_DADOS;
using System.Data;
using System.Net;

namespace OBJETO_TRANSFERENCIA
{
    public class TipoUsuarioRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PopularCbTipoUsuario()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspTipoUsuarioListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarTipoUsuario(TipoUsuarioC tipoUsuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", tipoUsuarioC.tipoUsuario);
                conexaoSqlServer.AdicionarParametros("@ID", tipoUsuarioC.idTipoUsuario);
                conexaoSqlServer.AdicionarParametros("@PERMISSAO", tipoUsuarioC.permissao);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspTipoUsuarioAlterar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarTipoUsuario(TipoUsuarioC tipoUsuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", tipoUsuarioC.tipoUsuario);
                conexaoSqlServer.AdicionarParametros("@PERMISSAO", tipoUsuarioC.permissao);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspTipoUsuarioCadastrar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarTipoUsuario(string idTipoUsuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                conexaoSqlServer.AdicionarParametros("@ID", idTipoUsuario);
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspTipoUsuarioPesquisarId", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
