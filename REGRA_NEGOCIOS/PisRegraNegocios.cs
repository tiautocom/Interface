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
    public class PisRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public double pppis_ = 0;
        public string ppis = "";
        public string pCofins = "";
        public string vv = "";
        public string qv = "";

        public DataTable PesquisarAliquotaPis(PIS pis)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", pis.descricao);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPisPesquisarAliquota", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlPis(string cstPis, string preco, string qtde, string ppis, string crt)
        {
            try
            {
                StringBuilder vDadosEnvio = new StringBuilder();

                ppis = PesquisarCstPis(cstPis);

                vv = "";
                qv = "";

                if (crt == "1")
                {
                    if ((cstPis == "01") || (cstPis == "02") || (cstPis == "05"))
                    {
                        vv = preco.Replace(".", ",");
                        qv = qtde.Replace(".", ",");

                        pppis_ = (Convert.ToDouble(vv) * Convert.ToDouble(qv));

                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISAliq>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<vBC>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPIS>" + ppis + "</pPIS>");
                        vDadosEnvio.Append("</PISAliq>");
                        vDadosEnvio.Append("</PIS>");

                        //TAG PISST
                        vDadosEnvio.Append("<PISST>");
                        vDadosEnvio.Append("<vBC>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPIS>" + ppis + "</pPIS>");
                        vDadosEnvio.Append("</PISST>");
                    }
                    else if (cstPis == "03")
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISQtde>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<qBCProd>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</qBCProd>");
                        vDadosEnvio.Append("<vAliqProd>" + ppis + "</vAliqProd>");
                        vDadosEnvio.Append("</PISQtde>");
                        vDadosEnvio.Append("</PIS>");
                    }
                    else if (cstPis == "49")
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISSN>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("</PISSN>");
                        vDadosEnvio.Append("</PIS>");
                    }
                    else if (cstPis == "90")
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISOutr>");
                        vDadosEnvio.Append("<vBC>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<pPis>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</pPis>");
                        vDadosEnvio.Append("<qBCProd>" + ppis + "</qBCProd>");
                        vDadosEnvio.Append("</PISOutr>");
                        vDadosEnvio.Append("</PIS>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISNT>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("</PISNT>");
                        vDadosEnvio.Append("</PIS>");
                    }
                }
                else
                {
                    if ((cstPis == "01") || (cstPis == "02") || (cstPis == "05"))
                    {
                        vv = preco.Replace(".", ",");
                        qv = qtde.Replace(".", ",");

                        pppis_ = (Convert.ToDouble(vv) * Convert.ToDouble(qv));

                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISAliq>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<vBC>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPIS>" + ppis + "</pPIS>");
                        vDadosEnvio.Append("</PISAliq>");
                        vDadosEnvio.Append("</PIS>");

                        //TAG PISST
                        vDadosEnvio.Append("<PISST>");
                        vDadosEnvio.Append("<vBC>" + pppis_.ToString("0.00", new CultureInfo("en-US")) + "</vBC>");
                        vDadosEnvio.Append("<pPIS>" + ppis + "</pPIS>");
                        vDadosEnvio.Append("</PISST>");
                    }
                    else if (cstPis == "03")
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISQtde>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<qBCProd>" + cstPis + "</qBCProd>");
                        vDadosEnvio.Append("<vAliqProd>" + cstPis + "</vAliqProd>");
                        vDadosEnvio.Append("<vPis>" + cstPis + "</vPis>");
                        vDadosEnvio.Append("</PISQtde>");
                        vDadosEnvio.Append("</PIS>");
                    }
                    else if (cstPis == "90")
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISOutr>");
                        vDadosEnvio.Append("<vBC>" + cstPis + "</CST>");
                        vDadosEnvio.Append("<pPis>" + cstPis + "</pPis>");
                        vDadosEnvio.Append("<qBCProd>" + cstPis + "</qBCProd>");
                        vDadosEnvio.Append("<vAliqProd>" + cstPis + "</vAliqProd>");
                        vDadosEnvio.Append("</PISOutr>");
                        vDadosEnvio.Append("</PIS>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<PIS>");
                        vDadosEnvio.Append("<PISNT>");
                        vDadosEnvio.Append("<CST>" + cstPis + "</CST>");
                        vDadosEnvio.Append("</PISNT>");
                        vDadosEnvio.Append("</PIS>");
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

        public string PesquisarCstPis(string cstPis)
        {
            try
            {
                PIS pis = new PIS();
                PisRegraNegocios pisRegraNegocios = new PisRegraNegocios();
                DataTable dadostabelaPis = new DataTable();

                pis.descricao = cstPis;

                dadostabelaPis = pisRegraNegocios.PesquisarAliquotaPis(pis);

                if (dadostabelaPis.Rows.Count > 0)
                {
                    ppis = dadostabelaPis.Rows[0]["ALIQ"].ToString().Trim().Replace(",", ".").Replace(" ", "");
                }
                else
                {
                    ppis = "";
                }

                return ppis;
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception(ex.Message);
            }
        }
    }
}
