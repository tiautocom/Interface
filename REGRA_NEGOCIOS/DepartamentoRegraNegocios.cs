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
    public class DepartamentoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string idRetorno;

        string dns = Dns.GetHostName();

        public DataTable CarreagarComboDepartamento()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarEstoqueDepartamento(DepartamentoC departamentoC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_DEPAR", departamentoC.numDepartamento);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoListarNumeros", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CarreagarComboDepartamento(string descricao)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoListarDescricao", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarEstoqueDepartamentos(DepartamentoC departamentoC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_DEPAR", departamentoC.numDepartamento);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoListarNumero", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarDeparatemntoProduto(DepartamentoC departamentoC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_DEPAR", departamentoC.idDepartamento);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoPesquisarAviso", dns);
                return dadosTabela;
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

                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoPesquisarDescricao", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarEstoqueDepartamentoId(int idDepartamento)
        {
            throw new NotImplementedException();
        }

        public string Salvar(DepartamentoC deparatmento, int tipo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", deparatmento.Id);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", deparatmento.DepartamentoDesc);
                conexaoSqlServer.AdicionarParametros("@ANP", deparatmento.Anp);
                conexaoSqlServer.AdicionarParametros("@CEST", deparatmento.cest);
                conexaoSqlServer.AdicionarParametros("@AVISO", deparatmento.Aviso);

                if (tipo == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspDepartamentoSalvar", dns).ToString();
                }
                else if (tipo == 2)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspDepartamentoAlterar", dns).ToString();
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Deletar(int idDepartamento)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID", idDepartamento);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspDepartamentoDeletar", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarEstoqueDepartamentosTotal(DepartamentoC departamentoC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_DEPAR", departamentoC.numDepartamento);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoListarNumerototal", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CarreagarComboSetor(int setor)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                //conexaoSqlServer.AdicionarParametros("@NUM_SETOR", setor);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspSetorListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
