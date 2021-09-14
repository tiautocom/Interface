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
    public class ParametroRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable Listar()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspParametroListar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarServicos(ParametroC parametroC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@CUPOM_IMAGEM", parametroC.cupomImagem);
                conexaoSqlServer.AdicionarParametros("@HOMOLOGACAO_TESTE", parametroC.homologacaoTeste);
                conexaoSqlServer.AdicionarParametros("@PLACA", parametroC.placa);
                conexaoSqlServer.AdicionarParametros("@ID_PARAMETRO", parametroC.idParametro);
                conexaoSqlServer.AdicionarParametros("@VENDA_XML", parametroC.vendaXml);
                conexaoSqlServer.AdicionarParametros("@PAGTO_VENDA_XML", parametroC.pgtoVendaXml);
                conexaoSqlServer.AdicionarParametros("@TIME_TELA_DESC", parametroC.timeTelaDesc);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", parametroC.Numcaixa);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspParametroAlterarServicos", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SalvarServicosEndereco(ParametroC parametroC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_PARAMETRO", parametroC.idParametro);
                conexaoSqlServer.AdicionarParametros("@RAZAO_SOCIAL", parametroC.razaoSocial);
                conexaoSqlServer.AdicionarParametros("@NOME_FANTASIA", parametroC.nomeFantasia);
                conexaoSqlServer.AdicionarParametros("@ENDERECO_EMPRESA", parametroC.endereco);
                conexaoSqlServer.AdicionarParametros("@NUMERO", parametroC.numero);
                conexaoSqlServer.AdicionarParametros("@BAIRRO", parametroC.bairro);
                conexaoSqlServer.AdicionarParametros("@CEP", parametroC.cep);
                conexaoSqlServer.AdicionarParametros("@CIDADE", parametroC.cidade);
                conexaoSqlServer.AdicionarParametros("@UF", parametroC.uf);
                conexaoSqlServer.AdicionarParametros("@TELEFONE", parametroC.telefone);
                conexaoSqlServer.AdicionarParametros("@IE", parametroC.ie);
                conexaoSqlServer.AdicionarParametros("@CNPJ", parametroC.cnpj);
                conexaoSqlServer.AdicionarParametros("@IM", parametroC.im);
                conexaoSqlServer.AdicionarParametros("@CRT", parametroC.crt);

                int idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspParametroSalvarCliente", dns).ToString());

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AlterarCupom(bool status, int numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@BANDEIRA", status);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa);

                int idRetorno = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspParametroAlterarCupom", dns).ToString());

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
