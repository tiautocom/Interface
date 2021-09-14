using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OBJETO_TRANSFERENCIA;
using ACESSO_DADOS;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class numCaixaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarCaixaLogado(int numCaixaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixaC);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPesquisarStatusCaixa", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AbrirCaixa(NumCaixaC numCaixa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixa.numCaixa);
                conexaoSqlServer.AdicionarParametros("@STATUS_CAIXA", numCaixa.statusCaixa);

                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspNumCaixaAbrirCaixa", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AlterarNumVenda(NumCaixaC numCaixaC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@NUM_VENDA", numCaixaC.numVenda);
                conexaoSqlServer.AdicionarParametros("@NUM_CAIXA", numCaixaC.numCaixa);

                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspNumCaixaAlterarNumeroVenda", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
