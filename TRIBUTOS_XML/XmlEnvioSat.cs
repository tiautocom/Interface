using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;

namespace TRIBUTOS_XML
{
    public class XmlEnvioSat
    {
        public void GerarXml(SoftwareHouse softwareHouse, int numCaixa, string cnpjEmitente, string ieEmitente, string imEmitente, string cnpjDest, List<VENDAS> listaVenda)
        {
            try
            {
                StringBuilder vDadosEnvio = new StringBuilder();

                vDadosEnvio.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                vDadosEnvio.Append("<CFe>");
                vDadosEnvio.Append("<infCFe versaoDadosEnt=\"0.07\">");

                //IDE
                vDadosEnvio.AppendFormat("<ide>");

                vDadosEnvio.Append("<CNPJ>" + softwareHouse.cnpjSH.Replace("-", "").Replace("/", "").Replace(" ", "") + "</CNPJ>");
                vDadosEnvio.Append("<signAC>" + softwareHouse.assinatuaDigital + "</signAC>");
                vDadosEnvio.Append("<numeroCaixa>" + numCaixa.ToString().PadLeft(3, '0') + "</numeroCaixa>");

                vDadosEnvio.Append("</ide>");


                //EMIT
                vDadosEnvio.AppendFormat("<emit>");

                vDadosEnvio.Append("<CNPJ>" + cnpjEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</CNPJ>");
                vDadosEnvio.Append("<IE>" + ieEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</IE>");
                vDadosEnvio.Append("<IM>" + imEmitente.Replace("-", "").Replace("/", "").Replace(" ", "") + "</IM>");
                vDadosEnvio.Append("<indRatISSQN>" + "N" + "</indRatISSQN>");

                vDadosEnvio.Append("</emit>");

                //DEST
                if (cnpjDest != "")
                {
                    if (cnpjDest.Length > 11)
                    {
                        vDadosEnvio.AppendFormat("<dest>");
                        vDadosEnvio.Append("<CNPJ>" + cnpjDest.Replace(".", "").Replace("/", "").Replace("-", "").Trim() + "</CNPJ>");
                        vDadosEnvio.Append("</dest>");
                    }
                    else
                    {
                        vDadosEnvio.AppendFormat("<dest>");
                        vDadosEnvio.Append("<CPF>" + cnpjDest.Replace(".", "").Replace("/", "").Replace("-", "").Trim() + "</CPF>");
                        vDadosEnvio.Append("</dest>");
                    }
                }
                else
                {
                    vDadosEnvio.Append("<dest/>");
                }

                //VENDAS

                foreach (var v in listaVenda)
                {
                    string preco = float.Parse(v.precoProd).ToString("N3").Replace(".", "").Replace(",", ".").Trim();
                    string qtde = float.Parse(v.qtde).ToString("N4").Replace(".", "").Replace(",", ".").Trim();

                    //CST PRODUTO
                    string cstProduto = v.cst.Trim();

                    vDadosEnvio.Append("<det nItem=\"" + listaVenda.Count + "\">");

                    //PROD
                    vDadosEnvio.Append("<prod>");
                    vDadosEnvio.Append("<cProd>" + v.codoBarra + "</cProd>");
                    vDadosEnvio.Append("<xProd>" + v.descricao + "</xProd>");
                    vDadosEnvio.Append("<NCM>" + v.ncm + "</NCM>");
                    vDadosEnvio.Append("<CFOP>" + v.cfop + "</CFOP>");
                    vDadosEnvio.Append("<uCom>" + v.unid.Replace(",", ".") + "</uCom>");
                    vDadosEnvio.Append("<qCom>" + qtde + "</qCom>");
                    vDadosEnvio.Append("<vUnCom>" + preco + "</vUnCom>");

                    if (v.unid.Trim().Equals("LT"))
                    {
                        vDadosEnvio.Append("<indRegra>T</indRegra>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<indRegra>A</indRegra>");
                    }

                    //OBSERVACAO
                    if (v.unid.Trim().Equals("LT"))
                    {
                        vDadosEnvio.Append("<obsFiscoDet xCampoDet=\"Cod.Produto ANP\">");
                        vDadosEnvio.Append("<xTextoDet>810101001</xTextoDet>");
                    }
                    else
                    {
                        vDadosEnvio.Append("<obsFiscoDet xCampoDet=\"Cod.CEST\">");
                        vDadosEnvio.Append("<xTextoDet>Texto1</xTextoDet>");
                    }

                    vDadosEnvio.Append("</obsFiscoDet>");

                    vDadosEnvio.Append("</prod>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
