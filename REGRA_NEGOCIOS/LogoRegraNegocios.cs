using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACESSO_DADOS;
using System.Data;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class LogoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public string SalvarImagem(byte[] foto)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@FOTO", foto);
                string idRetorno;

                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspSalvarImagemLogo", dns).ToString();

                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string LimparImagem()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                string idRetorno;
                idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspLogoLimparImagem", dns).ToString();
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
