using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using ACESSO_DADOS;
using System.Globalization;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class CofinsRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        public string pCofins = "";

        string dns = Dns.GetHostName();

        public DataTable PesquisarAliquotaPis(COFINS cofins)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", cofins.descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspCofinsPesquisarAliquota", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlCofins(string cstCofins, string preco, string qtde, string crt)
        {
            try
            {
                StringBuilder vDadosEnvio = new StringBuilder();

                double valorCofins = 0;

                Pesquisarcofins(cstCofins);

                if (crt == "1")
                {
                    if ((cstCofins == "01") || (cstCofins == "02") || (cstCofins == "05"))
                    {
                        valorCofins = Convert.ToDouble(pCofins);

                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSAliq>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("<vBC>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pCOFINS>" + pCofins + "</pCOFINS>");
                        vDadosEnvio.Append("</COFINSAliq>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else if ((cstCofins == "03"))
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSQtde>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("<qBCProd>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</qBCProd>");
                        vDadosEnvio.Append("<vAliqProd>" + pCofins + "</vAliqProd>");
                        vDadosEnvio.Append("</COFINSQtde>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else if (cstCofins == "49")
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSSN>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("</COFINSSN>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else if ((cstCofins == "90"))
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSOutr>");
                        vDadosEnvio.Append("<vBC>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPis>" + cstCofins + "</pPis>");
                        vDadosEnvio.Append("<qBCProd>" + qtde + "</qBCProd>");
                        vDadosEnvio.Append("</COFINSOutr>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSNT>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("</COFINSNT>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                }
                else
                {
                    if ((cstCofins == "01") || (cstCofins == "02") || (cstCofins == "05"))
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSAliq>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");

                        valorCofins = Convert.ToDouble(pCofins);
                        vDadosEnvio.Append("<vBC>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");

                        vDadosEnvio.Append("<pCOFINS>" + pCofins + "</pCOFINS>");

                        vDadosEnvio.Append("</COFINSAliq>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else if ((cstCofins == "03"))
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSQtde>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("<qBCProd>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</qBCProd>");
                        vDadosEnvio.Append("<vAliqProd>" + pCofins + "</vAliqProd>");
                        vDadosEnvio.Append("</COFINSQtde>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else if ((cstCofins == "90"))
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSOutr>");
                        vDadosEnvio.Append("<vBC>" + valorCofins.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPis>" + cstCofins + "</pPis>");
                        vDadosEnvio.Append("<qBCProd>" + qtde + "</qBCProd>");
                        vDadosEnvio.Append("</COFINSOutr>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<COFINS>");
                        vDadosEnvio.Append("<COFINSNT>");
                        vDadosEnvio.Append("<CST>" + cstCofins + "</CST>");
                        vDadosEnvio.Append("</COFINSNT>");
                        vDadosEnvio.Append("</COFINS>");
                    }
                }

                return vDadosEnvio.ToString();
            }
            catch (Exception ex)
            {
                return "";

                throw new Exception(ex.Message);
            }
        }

        public void Pesquisarcofins(string cstPis)
        {
            try
            {
                COFINS cofins = new COFINS();
                CofinsRegraNegocios cofinsRegraNegocios = new CofinsRegraNegocios();
                DataTable dadosTabelaCofins = new DataTable();

                cofins.descricao = cstPis;
                dadosTabelaCofins = cofinsRegraNegocios.PesquisarAliquotaPis(cofins);

                if (dadosTabelaCofins.Rows.Count > 0)
                {
                    pCofins = dadosTabelaCofins.Rows[0]["ALIQ"].ToString().Trim().Replace(",", ".").Replace(" ", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
