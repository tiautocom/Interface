using ACESSO_DADOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using System.Globalization;
using System.Net;

namespace REGRA_NEGOCIOS
{
    public class CsosnregraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string dns = Dns.GetHostName();

        public DataTable PesquisarCSOSN(CSOSN csosnC)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@CST", csosnC.cst);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspCsosnPesquisar", dns);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string tipoCSOSN = "";
        public string aliquotas = "";

        public static string GerarXmlIcms(string cstProduto, string origemProduto, string crt, string tipoCSOSN, string aliquota, string preco, string qtdeCom)
        {
            try
            {
                StringBuilder vDadosEnvio = new StringBuilder();

                if (crt == "1")
                {
                    vDadosEnvio.Append("<vItem12741>0.00</vItem12741>");

                    if ((cstProduto == "40") || (cstProduto == "41") || (cstProduto == "50") || (cstProduto == "60"))
                    {
                        if ((tipoCSOSN == "102") || (tipoCSOSN == "300") || (tipoCSOSN == "400") || (tipoCSOSN == "500"))
                        {
                            //ICMS
                            vDadosEnvio.Append("<ICMS>");
                            vDadosEnvio.Append("<ICMSSN102>");

                            vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                            vDadosEnvio.Append("<CSOSN>" + tipoCSOSN + "</CSOSN>");

                            vDadosEnvio.Append("</ICMSSN102>");
                            vDadosEnvio.Append("</ICMS>");

                            if (tipoCSOSN == "900")
                            {
                                vDadosEnvio.Append("<ICMS>");
                                vDadosEnvio.Append("<ICMSSN900>");

                                vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                                vDadosEnvio.Append("<c>" + cstProduto + "</CSOSN>");

                                vDadosEnvio.Append("</ICMSSN900>");
                                vDadosEnvio.Append("</ICMS>");
                            }
                        }
                    }
                    else if ((cstProduto == "00") || (cstProduto == "20") || (cstProduto == "90"))
                    {
                        if ((tipoCSOSN == "102") || (tipoCSOSN == "300") || (tipoCSOSN == "500"))
                        {
                            vDadosEnvio.Append("<ICMS>");
                            vDadosEnvio.Append("<ICMSSN102>");

                            vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                            vDadosEnvio.Append("<CSOSN>" + tipoCSOSN + "</CSOSN>");

                            vDadosEnvio.Append("</ICMSSN102>");
                            vDadosEnvio.Append("</ICMS>");
                        }

                        if (tipoCSOSN == "900")
                        {
                            vDadosEnvio.Append("<ICMS>");
                            vDadosEnvio.Append("<ICMSSN900>");

                            vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                            vDadosEnvio.Append("<CSOSN>" + tipoCSOSN + "</CSOSN>");

                            vDadosEnvio.Append("</ICMSSN900>");
                            vDadosEnvio.Append("</ICMS>");
                        }
                    }

                    else if ((cstProduto.Trim().Equals("10")) || (cstProduto.Trim().Equals("30")) || (cstProduto.Trim().Equals("70")))
                    {
                        vDadosEnvio.Append("<ICMS>");
                        vDadosEnvio.Append("<ICMSSN00>");

                        vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                        vDadosEnvio.Append("<CSOSN>" + tipoCSOSN + "</CSOSN>");

                        vDadosEnvio.Append("</ICMSSN00>");
                        vDadosEnvio.Append("</ICMS>");
                    }
                }

                else if (crt == "3")
                {
                    double _vItem = 0.00;
                    double valorAprox = 0.00;

                    if ((aliquota == "II") || (aliquota == "FF") || (aliquota == "NN"))
                    {
                        vDadosEnvio.Append("<vItem12741>" + valorAprox.ToString("0.00", new CultureInfo("en-US")) + "</vItem12741>");

                        aliquota = "0.00";
                    }
                    else
                    {
                        string p = preco.ToString().Replace(".", ",");
                        string q = qtdeCom.ToString().Replace(".", ",");

                        double alic = Convert.ToDouble(aliquota);
                        double vp = (Convert.ToDouble(p) * Convert.ToDouble(q));

                        _vItem = ((alic * vp) / 100);

                        vDadosEnvio.Append("<vItem12741>" + _vItem.ToString("0.00", new CultureInfo("en-US")) + "</vItem12741>");
                    }

                    //ICMS
                    if ((cstProduto == "40") || (cstProduto == "41") || (cstProduto == "50") || (cstProduto == "60"))
                    {
                        vDadosEnvio.Append("<ICMS>");

                        vDadosEnvio.Append("<ICMS40>");

                        vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                        vDadosEnvio.Append("<CST>" + cstProduto + "</CST>");

                        vDadosEnvio.Append("</ICMS40>");

                        vDadosEnvio.Append("</ICMS>");
                    }

                    else
                    {
                        vDadosEnvio.Append("<ICMS>");

                        vDadosEnvio.Append("<ICMS00>");

                        vDadosEnvio.Append("<Orig>" + origemProduto + "</Orig>");
                        vDadosEnvio.Append("<CST>" + cstProduto + "</CST>");

                        string a = Convert.ToDouble(aliquota).ToString();

                        vDadosEnvio.Append("<pICMS>" + Convert.ToDecimal(a).ToString("0.00", new CultureInfo("en-US")) + "</pICMS>");

                        vDadosEnvio.Append("</ICMS00>");

                        vDadosEnvio.Append("</ICMS>");
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
    }
}
