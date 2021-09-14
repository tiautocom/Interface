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
    public class ClienteRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarCliente(string nome)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NOME", nome);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClientePesquisar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarClienteRg(string rgIe)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@RG_INSC_EST", rgIe);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClientePesquisarRg", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarClienteId(int idCliente)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@CLIENTE_ID", idCliente);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteIdPesquisarEndTelefone", dns);

                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarCpjCnpj(string CpfCnpj)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@CPF_CNPJ", CpfCnpj);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PesquisarClienteCpfCnpj", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarEmail(string email)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@EMAIL", email);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PesquisarClienteEmail", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarClienteTelefone(string telefone)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@TELEFONE", telefone);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PesquisarClienteTelefone", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarClienteId(ClienteC clienteC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@CLIENTE_ID", clienteC.idCliente);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PesquisarClienteId", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        string idRetorno;

        public string Salvar(ClienteC cliente, int tipo)
        {
            try
            {
                conexaoSqlServer.LimparParametros();

                //CLIENTE
                conexaoSqlServer.AdicionarParametros("@NOME", cliente.nome);
                conexaoSqlServer.AdicionarParametros("@APELIDO_FANTAZIA", cliente.apelidoFantasia);
                conexaoSqlServer.AdicionarParametros("@CPF_CNPJ", cliente.cpfCnpj);
                conexaoSqlServer.AdicionarParametros("@RG_INSC_EST", cliente.rgIe);
                conexaoSqlServer.AdicionarParametros("@DT_CADASTRO", cliente.dataCadastro);
                conexaoSqlServer.AdicionarParametros("@DT_NASC", cliente.datas);
                conexaoSqlServer.AdicionarParametros("@BLOQ", cliente.bloq);
                conexaoSqlServer.AdicionarParametros("@LIMITE", cliente.limite);
                conexaoSqlServer.AdicionarParametros("@GASTO", cliente.gasto);
                conexaoSqlServer.AdicionarParametros("@OBSERVACAO", cliente.observacao);

                //ENDERECO
                conexaoSqlServer.AdicionarParametros("@ID_CIDADE", 1);
                conexaoSqlServer.AdicionarParametros("@CIDADE", cliente.Endereco.cidade);
                conexaoSqlServer.AdicionarParametros("@LOGRADOURO", cliente.Endereco.logradouro);
                conexaoSqlServer.AdicionarParametros("@NUM", cliente.Endereco.numero);
                conexaoSqlServer.AdicionarParametros("@BAIRRO", cliente.Endereco.bairro);
                conexaoSqlServer.AdicionarParametros("@COMPLEMENTO", cliente.Endereco.complemento);
                conexaoSqlServer.AdicionarParametros("@CEP", cliente.Endereco.cep);
                conexaoSqlServer.AdicionarParametros("@UF", cliente.Endereco.uf);

                //TELEFONE
                conexaoSqlServer.AdicionarParametros("@TELEFONE", cliente.Telefone.telefone1);
                conexaoSqlServer.AdicionarParametros("@TELEFONE2", cliente.Telefone.telefone2);
                conexaoSqlServer.AdicionarParametros("@TELEFONE3", cliente.Telefone.celular);
                conexaoSqlServer.AdicionarParametros("@EMAIL", cliente.email);

                if (tipo == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteSalvar", dns).ToString();
                }
                else if (tipo == 2)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteAlterar", dns).ToString();
                }

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CreditarGastoCliente(decimal total, decimal gasto, int idCliente)
        {
            try
            {
                Decimal somar = (gasto + total);

                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@GASTO", somar);
                conexaoSqlServer.AdicionarParametros("@CLIENTE_ID", idCliente);

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteSalvaCreditarGastos", dns).ToString();

                return Convert.ToInt32(idRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
