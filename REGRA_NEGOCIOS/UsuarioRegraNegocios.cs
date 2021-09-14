using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using System.Data;
using ACESSO_DADOS;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class UsuarioRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarLoginUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioPesqusiarlogin", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarLogin(UsuarioC usuarioC, int idUsuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ATIVADO", usuarioC.statusUsuario);
                conexaoSqlServer.AdicionarParametros("@LOGADO", true);
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", idUsuario);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioPesquisarLoginOperante", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarLogin(string usuario, string senha)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                conexaoSqlServer.AdicionarParametros("@NOME", usuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", senha);
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioLogin", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarUsuariosAll()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioListarAll", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarTipoUsuario()
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

        public string CadastrarTipoUsuario(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspTipoUsuarioSalvar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarTipoUsuario(int idTipoUsuario, string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);
                conexaoSqlServer.AdicionarParametros("@ID", idTipoUsuario);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspTipoUsuarioAlterar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarSenhaUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", usuarioC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioAlterarSenha", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NOME", usuarioC.nomeUsuario);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioPesquisarUsuario", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AbrirLogin(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", usuarioC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@STATUS", usuarioC.statusUsuario);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioAbrirLogin", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", usuarioC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@NOME", usuarioC.nomeUsuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);
                conexaoSqlServer.AdicionarParametros("@PERIODO", usuarioC.periodo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@STATUS", usuarioC.statusUsuario);
                conexaoSqlServer.AdicionarParametros("@ATIVADO", usuarioC.ativo);
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", usuarioC.idTipoUsuario);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspAlterarUsuario", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeletarTipoUsuario(int idTipoUsuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", idTipoUsuario);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspDeletarTipoUsuario", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                return "";

                throw new Exception(ex.Message);
            }
        }

        public string AlterarUsuarios(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", usuarioC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@NOME", usuarioC.nomeUsuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);
                conexaoSqlServer.AdicionarParametros("@PERIODO", usuarioC.periodo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ATIVADO", usuarioC.ativo);
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", usuarioC.idTipoUsuario);
                conexaoSqlServer.AdicionarParametros("@PERMISSAO", usuarioC.permissao);
                conexaoSqlServer.AdicionarParametros("@LOGADO", 0);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspAlterarUsuario", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                return " ";

                throw new Exception(ex.Message);
            }
        }

        public string Cadastrar(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NOME", usuarioC.nomeUsuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);
                conexaoSqlServer.AdicionarParametros("@PERIODO", usuarioC.periodo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@STATUS", usuarioC.statusUsuario);
                conexaoSqlServer.AdicionarParametros("@ATIVADO", usuarioC.ativo);
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", usuarioC.idTipoUsuario);
                conexaoSqlServer.AdicionarParametros("@PERMISSAO", usuarioC.permissao);
                conexaoSqlServer.AdicionarParametros("@LOGADO", 0);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioCadastrar", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CadastrarUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NOME", usuarioC.nomeUsuario);
                conexaoSqlServer.AdicionarParametros("@SENHA", usuarioC.senha);
                conexaoSqlServer.AdicionarParametros("@PERIODO", usuarioC.periodo);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                conexaoSqlServer.AdicionarParametros("@ATIVADO", usuarioC.ativo);
                conexaoSqlServer.AdicionarParametros("@TIPO_USUARIO", usuarioC.idTipoUsuario);
                conexaoSqlServer.AdicionarParametros("@PERMISSAO", usuarioC.permissao);
                conexaoSqlServer.AdicionarParametros("@LOGADO", 0);

                int idRetorno;

                idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioCadastrar", dns));

                return idRetorno;
            }
            catch (Exception ex)
            {
                return 0;

                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarUsuario(int idUsuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", idUsuario);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioPesquisarId", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarStatusUsuario(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_USUARIO", usuarioC.idUsuario);
                conexaoSqlServer.AdicionarParametros("@STATUS", usuarioC.statusUsuario);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);
                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioAlterarStatusFechado", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FechaLogin(UsuarioC usuarioC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@LOGADO", usuarioC.statusUsuario);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", usuarioC.numCaixa);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioFecharLogin", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
