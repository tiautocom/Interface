using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBJETO_TRANSFERENCIA;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace REGRA_NEGOCIOS
{
    public class XmlRegraNegocios
    {
        FILTRAR removerRegraNegocios;

        #region VARIAVEIS

        double vTotTrib = 0;
        string vfret = "";

        #endregion

        public static CultureInfo ptBR = new CultureInfo("pt-BR");

        public string GerarXmlCancelamento(string chaveCancel, SoftwareHouse softwareHouse, string numCaixa)
        {
            try
            {
                StringBuilder vDadosEnvio = new StringBuilder();

                vDadosEnvio.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

                vDadosEnvio.Append("<CFeCanc>");

                vDadosEnvio.Append("<infCFe chCanc=\"" + chaveCancel + "\">");

                vDadosEnvio.Append("<ide>");

                softwareHouse.cnpjSH = softwareHouse.cnpjSH.Replace("-", "").Replace("/", "").Replace(" ", "");

                vDadosEnvio.Append("<CNPJ>" + softwareHouse.cnpjSH + "</CNPJ>");
                vDadosEnvio.Append("<signAC>" + softwareHouse.assinatuaDigital + "</signAC>");
                vDadosEnvio.Append("<numeroCaixa>" + numCaixa.ToString().PadLeft(3, '0') + "</numeroCaixa>");

                vDadosEnvio.Append("</ide>");

                vDadosEnvio.Append("<emit/>");

                vDadosEnvio.Append("<dest/>");

                vDadosEnvio.Append("<total/>");

                vDadosEnvio.Append("</infCFe>");

                vDadosEnvio.Append("</CFeCanc>");

                return vDadosEnvio.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlStatusServicoNFe(string _versao, int _idTipoAmbiente, string _url, int _cUF, string _metodo, string _servico, string _uri, string pathEndereco)
        {
            try
            {
                XmlDocument XMLfile = new XmlDocument();
                StringBuilder xml = new StringBuilder();

                xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                xml.Append("<consStatServ versao=\"" + _versao + "\" xmlns=\"" + _uri + "\">");
                xml.Append("<tpAmb>" + _idTipoAmbiente + "</tpAmb>");
                xml.Append("<cUF>" + _cUF + "</cUF>");
                xml.Append("<xServ>" + _metodo + "</xServ>");
                xml.Append("</consStatServ>");

                XMLfile.LoadXml(xml.ToString());
                XMLfile.Save(pathEndereco + "\\XMLs\\SERVICOS\\STATUS\\ENVIO.xml");

                return xml.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public XmlDocument CreateSoap(string xmlStatus, string url_, string action_, string pathEndereco)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            sb.Append("<soap12:Body>");
            sb.Append("<nfeDadosMsg xmlns=\"http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4\">");
            sb.Append(xmlStatus.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", ""));
            sb.Append("</nfeDadosMsg>");
            sb.Append("</soap12:Body>");
            sb.Append("</soap12:Envelope>");

            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(sb.ToString());
            soapEnvelop.Save(pathEndereco + "\\XMLs\\SERVICOS\\STATUS\\ENVELOPE.xml");

            return soapEnvelop;
        }

        public XmlDocument GerarXmlVendaNFCe(Pessoa pessoa, string xmlProduto, string xmlPagamentos, string _xmlPagamento, string urlQrCode, string pathEndereco)
        {
            try
            {
                #region NFCE

                StringBuilder xml = new StringBuilder();

                xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

                xml.Append("<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
                xml.Append("<infNFe versao=\"" + pessoa.NFe.Versao + "\" Id=\"" + pessoa.NFe.Id.Trim() + "\">");

                #region DADOS NFE

                #region IDE

                //tag id
                xml.Append("<ide>");
                xml.Append("<cUF>" + pessoa.NFe.cUf.Substring(0, 2).Trim() + "</cUF>");
                xml.Append("<cNF>" + pessoa.NFe.cNF + "</cNF>");
                xml.Append("<natOp>" + pessoa.NFe.natOp + "</natOp>");
                xml.Append("<mod>" + pessoa.NFe.mod + "</mod>");
                xml.Append("<serie>" + pessoa.NFe.serie + "</serie>");
                xml.Append("<nNF>" + pessoa.NFe.nNF + "</nNF>");
                xml.Append("<dhEmi>" + pessoa.NFe.dhEmi + "</dhEmi>");
                xml.Append("<tpNF>" + pessoa.NFe.tpNF + "</tpNF>");
                xml.Append("<idDest>" + pessoa.NFe.idDest + "</idDest>");
                xml.Append("<cMunFG>" + pessoa.NFe.cMunFG + "</cMunFG>");
                xml.Append("<tpImp>" + pessoa.NFe.tpImp + "</tpImp>");
                xml.Append("<tpEmis>" + pessoa.NFe.tpEmis + "</tpEmis>");
                xml.Append("<cDV>" + pessoa.NFe.cDV + "</cDV>");
                xml.Append("<tpAmb>" + pessoa.NFe.tpAmb + "</tpAmb>");
                xml.Append("<finNFe>" + pessoa.NFe.finNFe + "</finNFe>");
                xml.Append("<indFinal>" + pessoa.NFe.indFinal + "</indFinal>");
                xml.Append("<indPres>" + pessoa.NFe.indPres + "</indPres>");
                xml.Append("<procEmi>" + pessoa.NFe.procEmi + "</procEmi>");
                xml.Append("<verProc>" + pessoa.NFe.verProc + "</verProc>");

                xml.Append("</ide>");

                #endregion

                #region EMITENTE

                //tag emit
                xml.Append("<emit>");
                xml.Append("<CNPJ>" + pessoa.Emitente.CpfCnpj + "</CNPJ>");
                xml.Append("<xNome>" + pessoa.Emitente.NomeRazaoSocial + "</xNome>");
                xml.Append("<xFant>" + pessoa.Emitente.NomeFantasia + "</xFant>");

                //tag endereco Emitente
                xml.Append("<enderEmit>");
                xml.Append("<xLgr>" + pessoa.Emitente.Endereco.logradouro + "</xLgr>");
                xml.Append("<nro>" + pessoa.Emitente.Endereco.numero + "</nro>");

                if ((pessoa.Emitente.Endereco.complemento.Trim().Equals("")) || (pessoa.Emitente.Endereco.complemento == null))
                {
                    xml.Append("<xCpl>S/C</xCpl>");
                }
                else
                {
                    xml.Append("<xCpl>" + pessoa.Emitente.Endereco.complemento.Trim() + "</xCpl>");
                }

                xml.Append("<xBairro>" + pessoa.Emitente.Endereco.bairro + "</xBairro>");
                xml.Append("<cMun>" + pessoa.Emitente.Endereco.ibge + "</cMun>");
                xml.Append("<xMun>" + pessoa.Emitente.Endereco.cidade + "</xMun>");
                xml.Append("<UF>" + pessoa.Emitente.Endereco.uf + "</UF>");
                xml.Append("<CEP>" + pessoa.Emitente.Endereco.cep + "</CEP>");
                xml.Append("<cPais>" + pessoa.Emitente.Endereco.codPAis + "</cPais>");
                xml.Append("<xPais>" + pessoa.Emitente.Endereco.pais + "</xPais>");
                xml.Append("<fone>" + pessoa.Emitente.Telefone + "</fone>");
                xml.Append("</enderEmit>");

                //tag IE
                xml.Append("<IE>" + pessoa.Emitente.IeRg + "</IE>");

                //tag CRT
                xml.Append("<CRT>" + pessoa.Emitente.CRT + "</CRT>");

                xml.Append("</emit>");

                #endregion

                #region DEST

                if (pessoa.Destinatario.TipoPessoa == 2)
                {
                    removerRegraNegocios = new FILTRAR();

                    //tag inicio Dest pessoa juridica
                    xml.Append("<dest>");
                    xml.Append("<CNPJ>" + pessoa.Destinatario.CpfCnpj + "</CNPJ>");
                    xml.Append("<xNome>" + pessoa.Destinatario.NomeRazaoSocial + "</xNome>");

                    #region ENDERECO

                    //tag endereco Destinatario
                    xml.Append("<enderDest>");

                    xml.Append("<xLgr>" + pessoa.Destinatario.Endereco.logradouro + "</xLgr>");
                    xml.Append("<nro>" + pessoa.Destinatario.Endereco.numero + "</nro>");

                    if ((pessoa.Destinatario.Endereco.complemento.Trim().Equals("")) || (pessoa.Destinatario.Endereco.complemento == null))
                    {
                        xml.Append("<xCpl>SC</xCpl>");
                    }
                    else
                    {
                        xml.Append("<xCpl>" + removerRegraNegocios.RemoverAcentos(pessoa.Destinatario.Endereco.complemento) + "</xCpl>");
                    }

                    xml.Append("<xBairro>" + removerRegraNegocios.RemoverCaracteres(pessoa.Destinatario.Endereco.bairro) + "</xBairro>");
                    xml.Append("<cMun>" + pessoa.Destinatario.Endereco.ibge + "</cMun>");
                    xml.Append("<xMun>" + pessoa.Destinatario.Endereco.cidade + "</xMun>");
                    xml.Append("<UF>" + pessoa.Destinatario.Endereco.uf + "</UF>");
                    xml.Append("<CEP>" + pessoa.Destinatario.Endereco.cep + "</CEP>");
                    xml.Append("<cPais>" + pessoa.Destinatario.Endereco.codPAis + "</cPais>");
                    xml.Append("<xPais>" + pessoa.Destinatario.Endereco.pais + "</xPais>");
                    xml.Append("<fone>" + pessoa.Destinatario.Telefone + "</fone>");

                    xml.Append("</enderDest>");

                    xml.Append("<indIEDest>9</indIEDest>");

                    #endregion


                    xml.Append("</dest>");
                }


                #endregion

                #region PRODUTO

                xml.Append(xmlProduto);

                #endregion

                #region ICMS TOTAL

                //tag TOTAL
                xml.Append("<total>");

                //tag ICMS TOTAL
                xml.Append("<ICMSTot>");

                xml.Append("<vBC>" + pessoa.Venda.VendaIcms.vBc + "</vBC>");
                xml.Append("<vICMS>" + pessoa.Venda.VendaIcms.vIcms + "</vICMS>");
                xml.Append("<vICMSDeson>" + pessoa.Venda.VendaIcms.vIcmsDeson + "</vICMSDeson>");
                xml.Append("<vFCPUFDest>" + pessoa.Venda.VendaIcms.vFCPUFDest + "</vFCPUFDest>");
                xml.Append("<vICMSUFDest>" + pessoa.Venda.VendaIcms.vICMSUFRemet + "</vICMSUFDest>");
                xml.Append("<vICMSUFRemet>" + pessoa.Venda.VendaIcms.vICMSUFRemet + "</vICMSUFRemet>");
                xml.Append("<vFCP>" + pessoa.Venda.VendaIcms.vFcp + "</vFCP>");
                xml.Append("<vBCST>" + pessoa.Venda.VendaIcms.vBcst + "</vBCST>");
                xml.Append("<vST>" + pessoa.Venda.VendaIcms.vSt + "</vST>");
                xml.Append("<vFCPST>" + pessoa.Venda.VendaIcms.vFcpst + "</vFCPST>");
                xml.Append("<vFCPSTRet>" + pessoa.Venda.VendaIcms.vFcpstRet + "</vFCPSTRet>");
                xml.Append("<vProd>" + pessoa.Venda.VendaIcms.vProd.ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</vProd>");
                xml.Append("<vFrete>" + pessoa.Venda.VendaIcms.vFrete.ToString().Trim() + "</vFrete>");
                xml.Append("<vSeg>" + pessoa.Venda.VendaIcms.vSeg + "</vSeg>");
                xml.Append("<vDesc>" + pessoa.Venda.VendaIcms.vDesc + "</vDesc>");
                xml.Append("<vII>" + pessoa.Venda.VendaIcms.vII + "</vII>");
                xml.Append("<vIPI>" + pessoa.Venda.VendaIcms.vIpi + "</vIPI>");
                xml.Append("<vIPIDevol>" + pessoa.Venda.VendaIcms.vIPIDevol + "</vIPIDevol>");
                xml.Append("<vPIS>" + pessoa.Venda.VendaIcms.vPis + "</vPIS>");
                xml.Append("<vCOFINS>" + pessoa.Venda.VendaIcms.vCofins.ToString().Trim() + "</vCOFINS>");
                xml.Append("<vOutro>" + pessoa.Venda.VendaIcms.vOutro.ToString() + "</vOutro>");
                xml.Append("<vNF>" + pessoa.Venda.VendaIcms.vNf.ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</vNF>");
                xml.Append("<vTotTrib>0.00</vTotTrib>");
                xml.Append("</ICMSTot>");
                xml.Append("</total>");

                #endregion

                #region TRANSPORTE

                if (pessoa.Venda.Transporte.modFrete.Substring(0, 1).Trim().Equals("9"))
                {
                    //tag trasnporte
                    xml.Append("<transp>");
                    xml.Append("<modFrete>" + pessoa.Venda.Transporte.modFrete.Substring(0, 1).Trim() + "</modFrete>");
                    xml.Append("</transp>");
                }
                else
                {
                    //tag trasnporte
                    xml.Append("<transp>");

                    xml.Append("<modFrete>" + pessoa.Venda.Transporte.modFrete.Substring(0, 1).Trim() + "</modFrete>");

                    xml.Append("<transporta>");

                    xml.Append("<CNPJ>" + pessoa.Venda.Transporte.cnpjTranportadora.Trim() + "</CNPJ>");
                    xml.Append("<xNome>" + pessoa.Venda.Transporte.xNome.Trim() + "</xNome>");
                    xml.Append("<IE>" + pessoa.Venda.Transporte.Ie.Trim() + "</IE>");
                    xml.Append("<xEnder>" + pessoa.Venda.Transporte.logradouro.Trim() + "</xEnder>");
                    xml.Append("<xMun>" + pessoa.Venda.Transporte.xMun.Trim() + "</xMun>");
                    xml.Append("<UF>" + pessoa.Venda.Transporte.UF.Trim() + "</UF>");

                    xml.Append("</transporta>");

                    if (pessoa.Venda.Transporte.placa != "")
                    {
                        xml.Append("<veicTransp>");
                        xml.Append("<placa>" + pessoa.Venda.Transporte.placa + "</placa>");
                        xml.Append("<UF>" + pessoa.Venda.Transporte.Ufplaca + "</UF>");
                        xml.Append("</veicTransp>");
                    }

                    xml.Append("<vol>");

                    xml.Append("<qVol>" + Convert.ToDouble(pessoa.Venda.Transporte.qVol).ToString().Trim().Replace(".", "").Replace(",", ".") + "</qVol>");

                    xml.Append("<esp>" + pessoa.Venda.Transporte.esp + "</esp>");

                    if (pessoa.Venda.Transporte.marca.Trim() != "")
                    {
                        xml.Append("<marca>" + pessoa.Venda.Transporte.marca + "</marca>");
                    }

                    xml.Append("<pesoL>" + Convert.ToDouble(pessoa.Venda.Transporte.pesoL).ToString("N3").Trim().Replace(".", "").Replace(",", ".") + "</pesoL>");
                    xml.Append("<pesoB>" + Convert.ToDouble(pessoa.Venda.Transporte.pesoB).ToString("N3").Trim().Replace(".", "").Replace(",", ".") + "</pesoB>");

                    xml.Append("</vol>");

                    xml.Append("</transp>");
                }

                #endregion

                #region PAGAMENTO

                xml.Append("<pag>");

                xml.Append(xmlPagamentos);

                xml.Append("</pag>");

                #endregion

                #endregion

                xml.Append("</infNFe>");

                xml.Append("<infNFeSupl>");

                xml.Append("<qrCode>");

                xml.Append(urlQrCode + pessoa.NFe.Id.ToString().Replace("NFe", "").Trim() + "|2|" + pessoa.NFe.tpAmb.Trim() + "|1|8adb06ac72026dc6b957412033eca2a09d2857d2");

                xml.Append("</qrCode>");

                xml.Append("<urlChave>" + urlQrCode.Replace("/nfce/qrcode?p=", "") + "</urlChave>");

                xml.Append("</infNFeSupl>");

                xml.Append("</NFe>");

                #region SALVAR  XML ARQUIVO ENVIAR

                XmlDocument xmlEnvio = new XmlDocument();
                xmlEnvio.LoadXml(xml.ToString());
                xmlEnvio.Save(pathEndereco + "\\XMLs\\SERVICOS\\EMITIR\\ENVIAR.xml");

                #endregion

                return xmlEnvio;

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlProdutosNFCe(Pessoa pessoa, string pathEndereco)
        {
            StringBuilder xmlListaProduto = new StringBuilder();

            //tag det nItem
            xmlListaProduto.AppendFormat("<det nItem=\"" + pessoa.Venda.Item + "\">");

            #region PRODUTO

            //TAG PRODUTO
            xmlListaProduto.Append("<prod>");

            xmlListaProduto.Append("<cProd>" + pessoa.Venda.Produto.codBarra + "</cProd>");
            xmlListaProduto.Append("<cEAN>SEM GTIN</cEAN>");
            xmlListaProduto.Append("<xProd>" + pessoa.Venda.Produto.descricao + "</xProd>");
            xmlListaProduto.Append("<NCM>" + pessoa.Venda.ProdutoTributos.Ncm + "</NCM>");
            xmlListaProduto.Append("<CEST>" + pessoa.Venda.ProdutoTributos.Cest + "</CEST>");
            xmlListaProduto.Append("<CFOP>" + pessoa.Venda.ProdutoTributos.Cfop + "</CFOP>");
            xmlListaProduto.Append("<uCom>" + pessoa.Venda.unid.ToString().Trim() + "</uCom>");
            xmlListaProduto.Append("<qCom>" + pessoa.Venda.qtde.ToString().Replace(".", "").Replace(",", ".") + "</qCom>");
            xmlListaProduto.Append("<vUnCom>" + pessoa.Venda.preco.ToString().Trim().Replace(".", "").Replace(",", ".") + "</vUnCom>");
            xmlListaProduto.Append("<vProd>" + string.Format("{0:0,0.00}", Convert.ToDecimal(pessoa.Venda.total).ToString("N2").Trim()).Replace(".", "").Replace(",", ".") + "</vProd>");
            xmlListaProduto.Append("<cEANTrib>SEM GTIN</cEANTrib>");
            xmlListaProduto.Append("<uTrib>" + pessoa.Venda.unid + "</uTrib>");
            xmlListaProduto.Append("<qTrib>" + pessoa.Venda.qtde.ToString().Trim().Replace(".", "").Replace(",", ".") + "</qTrib>");
            xmlListaProduto.Append("<vUnTrib>" + pessoa.Venda.preco.ToString().Trim().Replace(".", "").Replace(",", ".") + "</vUnTrib>");

            if (Convert.ToDouble(pessoa.Venda.vFrete) > 0)
            {
                string vfret = "";

                vfret = pessoa.Venda.vFrete.ToString().Trim();

                xmlListaProduto.Append("<vFrete>" + string.Format("{0:0,0.00}", vfret) + "</vFrete>");
            }

            xmlListaProduto.Append("<indTot>" + pessoa.Venda.indTot + "</indTot>");

            //fim tag Prod
            xmlListaProduto.Append("</prod>");

            #endregion

            #region IMPOSTOS

            if (pessoa.Emitente.CRT.Trim() == "1")
            {
                #region IMPOSTOS

                //IMPOSTOS
                vTotTrib += Convert.ToDouble(pessoa.Venda.ProdutoTributos.vTotaTrib.Trim());

                xmlListaProduto.Append("<imposto>");

                //tag vTotTrib
                xmlListaProduto.Append("<vTotTrib>" + pessoa.Venda.ProdutoTributos.vTotaTrib.Trim().Replace(".", "").Replace(",", ".") + "</vTotTrib>");

                #region IMPOSTO ICMS

                //tag ICMS
                xmlListaProduto.Append("<ICMS>");

                #region TRATAMENTO CST

                if (pessoa.Destinatario.indIEDest.Substring(0, 1) != "1")
                {
                    if ((pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim() == "20") || (pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim() == "00"))
                    {
                        string _icmsn = "ICMSSN102".ToString().Trim();
                        string _csosn = "";

                        if (pessoa.Destinatario.indIEDest.Trim().Substring(0, 1) == "2")
                        {
                            _csosn = "103";
                        }
                        else
                        {
                            _csosn = "102";
                        }

                        xmlListaProduto.Append("<" + _icmsn.Trim() + ">");
                        xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                        xmlListaProduto.Append("<CSOSN>" + _csosn + "</CSOSN>");

                        xmlListaProduto.Append("</" + _icmsn + ">");
                    }
                    else
                    {
                        XElement xml = XElement.Load(pathEndereco + "\\XMLs\\CST\\CST.xml");
                        XElement x = xml.Elements().Where(pXml => pXml.Element("ICMS_CST").Value.Equals(pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim())).FirstOrDefault();

                        string _icmsn = x.Element("ICMSSN").Value.ToString();
                        string _csosn = x.Element("CSOSN").Value.ToString();

                        xmlListaProduto.Append("<" + _icmsn + ">");
                        xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                        xmlListaProduto.Append("<CSOSN>" + _csosn + "</CSOSN>");

                        if ((pessoa.Venda.ProdutoTributos.IcmsCst.Substring(2, 0).Trim() == "20") || (pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim() == "00"))
                        {
                            xmlListaProduto.Append("<pCredSN>" + pessoa.Venda.AliqSn.ToString().Trim().Replace(",", ".") + "</pCredSN>");
                            xmlListaProduto.Append("<vCredICMSSN>" + (vTotTrib).ToString("N2").Replace(".", "").Replace(",", ".") + "</vCredICMSSN>");
                        }

                        xmlListaProduto.Append("</" + _icmsn + ">");
                    }
                }
                else
                {
                    //PESQUISAR TABELA CST
                    XElement xml = XElement.Load(pathEndereco + "\\XMLs\\CST\\CST.xml");

                    XElement x = xml.Elements().Where(pXml => pXml.Element("ICMS_CST").Value.Equals(pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim())).FirstOrDefault();

                    string _icmsn = x.Element("ICMSSN").Value.ToString();
                    string _csosn = x.Element("CSOSN").Value.ToString();

                    xmlListaProduto.Append("<" + _icmsn + ">");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem + "</orig>");
                    xmlListaProduto.Append("<CSOSN>" + _csosn + "</CSOSN>");

                    if ((pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim() == "20") || (pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim() == "00"))
                    {
                        xmlListaProduto.Append("<pCredSN>" + pessoa.Venda.AliqSn.ToString().Replace(".", "").Replace(",", ".") + "</pCredSN>");
                        xmlListaProduto.Append("<vCredICMSSN>" + (vTotTrib).ToString("N2").Replace(".", "").Replace(",", ".") + "</vCredICMSSN>");
                    }

                    if (pessoa.Venda.ProdutoTributos.IcmsCst.Substring(0, 2).Trim().Equals("90"))
                    {
                        xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                        xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.ToString().Replace(".", "").Replace(",", ".") + "</vBC>");
                        xmlListaProduto.Append("<pRedBC>" + Convert.ToDecimal(pessoa.Venda.ProdutoTributos.RedBC).ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</pRedBC>");
                        xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.Trib.ToString().Trim().Replace(".", "").Replace(",", ".") + "</pICMS>");
                        xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.Trim().Replace(".", "").Replace(",", ".") + "</vICMS>");
                        xmlListaProduto.Append("<pCredSN>" + Convert.ToDecimal(pessoa.Venda.ProdutoTributos.Trib).ToString("N2").Replace(".", "").Replace(",", ".") + "</pCredSN>");
                        xmlListaProduto.Append("<vCredICMSSN>" + (vTotTrib).ToString("N2").Replace(".", "").Replace(",", ".") + "</vCredICMSSN>");
                    }

                    xmlListaProduto.Append("</" + _icmsn + ">");
                }

                #endregion

                xmlListaProduto.Append("</ICMS>");

                #endregion

                #region IMPOSTO PIS

                //tag PIS
                xmlListaProduto.Append("<PIS>");

                xmlListaProduto.Append("<PISNT>");

                xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstPis.Trim() + "</CST>");

                xmlListaProduto.Append("</PISNT>");

                xmlListaProduto.Append("</PIS>");

                #endregion

                #region IMPOSTO COFINS

                //tag COFINS
                xmlListaProduto.Append("<COFINS>");

                xmlListaProduto.Append("<COFINSNT>");

                xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstCofins.Trim() + "</CST>");

                xmlListaProduto.Append("</COFINSNT>");

                xmlListaProduto.Append("</COFINS>");

                #endregion

                xmlListaProduto.Append("</imposto>");

                #endregion 
            }
            else if (pessoa.Emitente.CRT.Trim() == "3")
            {
                #region IMPOSTOS

                //tag impostos
                xmlListaProduto.Append("<imposto>");

                if ((pessoa.Venda.ProdutoTributos.vICMS.Trim() != "0.000000") & (pessoa.Venda.ProdutoTributos.vICMS.Trim() != "0.0000000"))
                {
                    xmlListaProduto.Append("<vTotTrib>" + pessoa.Venda.ProdutoTributos.vTotaTrib.Trim().Replace(".", "").Replace(",", ".") + "</vTotTrib>");
                }

                #region IMPOSTO ICMS

                //tag ICMS
                xmlListaProduto.Append("<ICMS>");

                #region ICMS00

                if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "00")
                {
                    xmlListaProduto.Append("<ICMS00>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                    xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.ToString().Replace(".", "").Replace(",", ".") + "</vBC>");
                    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.Trib.ToString().Trim().Replace(".", "").Replace(",", ".") + "</pICMS>");
                    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.Trim().Replace(".", "").Replace(",", ".") + "</vICMS>");
                    xmlListaProduto.Append("</ICMS00>");
                }

                #endregion

                #region ICMS10

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "10")
                {
                    xmlListaProduto.Append("<ICMS10>");

                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                    xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.ToString().Replace(",", ".") + "</vBC>");
                    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.Trib.ToString().Trim().Replace(",", ".") + "</pICMS>");
                    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.Trim().Replace(",", ".") + "</vICMS>");
                    xmlListaProduto.Append("<modBCST>" + pessoa.Venda.ProdutoTributos.modBCST.Trim().Replace(",", ".") + "</modBCST>");
                    xmlListaProduto.Append("<pMVAST>" + pessoa.Venda.ProdutoTributos.pMVAST.Trim().Replace(",", ".") + "</pMVAST>");
                    xmlListaProduto.Append("<vBCST>" + pessoa.Venda.ProdutoTributos.vBCST.Trim().Replace(",", ".") + "</vBCST>");
                    xmlListaProduto.Append("<pICMSST>" + pessoa.Venda.ProdutoTributos.pICMSST.Trim().Replace(",", ".") + "</pICMSST>");
                    xmlListaProduto.Append("<vICMSST>" + pessoa.Venda.ProdutoTributos.vICMSST.Trim().Replace(",", ".") + "</vICMSST>");

                    xmlListaProduto.Append("</ICMS10>");
                }

                #endregion

                #region ICMS20

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "20")
                {
                    xmlListaProduto.Append("<ICMS20>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                    xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.ProdutoTributos.RedBC.ToString().Trim().Replace(".", "").Replace(",", ".") + "</pRedBC>");
                    xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.Trim().ToString().Replace(".", "").Replace(",", ".") + "</vBC>");
                    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.Trib.Trim().ToString().Replace(".", "").Replace(",", ".") + "</pICMS>");
                    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.Trim().ToString().Replace(".", "").Replace(",", ".") + "</vICMS>");
                    xmlListaProduto.Append("</ICMS20>");
                }
                #endregion

                #region ICMS30

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "30")
                {
                    //obj_vBC=(Convert.ToDouble(vBC.ToString()));

                    xmlListaProduto.Append("<ICMS30>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("<modBCST>" + pessoa.Venda.ProdutoTributos.modBCST.Trim() + "</modBCST>");
                    xmlListaProduto.Append("<pMVAST>" + pessoa.Venda.ProdutoTributos.pMVAST.ToString().Trim().Replace(",", ".") + "</pMVAST>");
                    xmlListaProduto.Append("<pRedBCST>" + pessoa.Venda.ProdutoTributos.pRedBCST.Trim().Replace(",", ".") + "</pRedBCST>");
                    xmlListaProduto.Append("<vBCST>" + pessoa.Venda.ProdutoTributos.vBCST.Trim().Replace(",", ".") + "</vBCST>");
                    xmlListaProduto.Append("<pICMSST>" + pessoa.Venda.ProdutoTributos.pICMSST.Trim().Replace(",", ".") + "</pICMSST>");
                    xmlListaProduto.Append("<vICMSST>" + pessoa.Venda.ProdutoTributos.vICMSST.Trim().Replace(",", ".") + "</vICMSST>");
                    xmlListaProduto.Append("</ICMS30>");
                }
                #endregion

                #region ICMS 40

                if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "40")
                {
                    xmlListaProduto.Append("<ICMS40>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("</ICMS40>");
                }

                #endregion

                #region ICMS 41

                if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "41")
                {
                    xmlListaProduto.Append("<ICMS40>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("</ICMS40>");
                }

                #endregion

                #region ICMS 50

                if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "50")
                {
                    xmlListaProduto.Append("<ICMS50>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("</ICMS50>");
                }

                #endregion

                #region ICMS51

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "51")
                {
                    bool tipoIcms = true;

                    if (tipoIcms == true)
                    {
                        //tag icms 51
                        xmlListaProduto.Append("<ICMS51>");
                        xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                        xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                        xmlListaProduto.Append("</ICMS51>");
                    }
                    else if (tipoIcms == false)
                    {
                        //tag icms 51
                        xmlListaProduto.Append("<ICMS51>");
                        xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                        xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                        xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                        xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.ProdutoTributos.RedBC.ToString().Replace(".", "").Replace(",", ".") + "</pRedBC>");
                        xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.ToString().Replace(".", "").Replace(",", ".") + "</vBC>");
                        xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.pICMSST.ToString().Replace(".", "").Replace(",", ".") + "</pICMS>");
                        xmlListaProduto.Append("<vICMSOp>" + pessoa.Venda.ProdutoTributos.vICMSOp.ToString().Replace(".", "").Replace(",", ".") + "</vICMSOp>");
                        xmlListaProduto.Append("<pDif>" + pessoa.Venda.ProdutoTributos.pDif.ToString().Replace(".", "").Replace(",", ".") + "</pDif>");
                        xmlListaProduto.Append("<vICMSDif>" + pessoa.Venda.ProdutoTributos.vICMSDif.ToString().Replace(".", "").Replace(",", ".") + "</vICMSDif>");
                        xmlListaProduto.Append("</ICMS51>");
                    }
                    else
                    {
                        //tag icms 51
                        xmlListaProduto.Append("<ICMS51>");
                        xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                        xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                        xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.ModBC.Trim() + "</modBC>");
                        xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.ToString().Replace(".", "").Replace(",", ".") + "</vBC>");
                        xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.pICMSST.ToString().Replace(".", "").Replace(",", ".") + "</pICMS>");
                        xmlListaProduto.Append("<vICMSOp>" + pessoa.Venda.ProdutoTributos.vICMSOp.ToString().Replace(".", "").Replace(",", ".") + "</vICMSOp>");
                        xmlListaProduto.Append("<pDif>" + pessoa.Venda.ProdutoTributos.pDif.ToString().Replace(".", "").Replace(",", ".") + "</pDif>");
                        xmlListaProduto.Append("<vICMSDif>" + pessoa.Venda.ProdutoTributos.vICMSDif.ToString().Replace(".", "").Replace(",", ".") + "</vICMSDif>");
                        xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.ToString().Replace(".", "").Replace(",", ".") + "</vICMS>");
                        xmlListaProduto.Append("</ICMS51>");
                    }
                }

                #endregion

                #region ICMS60

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "60")
                {
                    //tag icms 60
                    xmlListaProduto.Append("<ICMS60>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("</ICMS60>");
                }

                #endregion

                #region ICMS70

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "70")
                {
                    //tag icms 60
                    xmlListaProduto.Append("<ICMS70>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("<modBC>" + pessoa.Venda.ProdutoTributos.modBC + "</modBC>");
                    xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.ProdutoTributos.pRedBC.ToString().Replace(",", ".") + "</pRedBC>");
                    xmlListaProduto.Append("<vBC>" + pessoa.Venda.ProdutoTributos.vBC.Trim().ToString().Replace(",", ".") + "</vBC>");
                    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.ProdutoTributos.pICMS.ToString().Replace(",", ".") + "</pICMS>");
                    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.ProdutoTributos.vICMS.ToString().Replace(",", ".") + "</vICMS>");
                    xmlListaProduto.Append("<modBCST>" + pessoa.Venda.ProdutoTributos.modBCST.ToString().Replace(",", ".") + "</modBCST>");
                    xmlListaProduto.Append("<pMVAST>" + pessoa.Venda.ProdutoTributos.pMVAST.ToString().Replace(",", ".") + "</pMVAST>");
                    xmlListaProduto.Append("<pRedBCST>" + pessoa.Venda.ProdutoTributos.pRedBCST.ToString().Replace(",", ".") + "</pRedBCST>");
                    xmlListaProduto.Append("<vBCST>" + pessoa.Venda.ProdutoTributos.pRedBCST.ToString().Replace(",", ".") + "</vBCST>");
                    xmlListaProduto.Append("<pICMSST>" + pessoa.Venda.ProdutoTributos.pICMSST.ToString().Replace(",", ".") + "</pICMSST>");
                    xmlListaProduto.Append("<vICMSST>" + pessoa.Venda.ProdutoTributos.vICMSST.ToString().Replace(",", ".") + "</vICMSST>");
                    xmlListaProduto.Append("</ICMS70>");
                }

                #endregion

                #region ICMS90

                else if (pessoa.Venda.ProdutoTributos.IcmsCst.Trim() == "90")
                {
                    //tag icms 60
                    xmlListaProduto.Append("<ICMS90>");
                    xmlListaProduto.Append("<orig>" + pessoa.Venda.ProdutoTributos.Origem.Trim() + "</orig>");
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.IcmsCst.Trim() + "</CST>");
                    xmlListaProduto.Append("</ICMS90>");
                }

                //else if (pessoa.Venda.TributoProduto.IcmsCst.Trim() == "90")
                //{
                //    //Exemplo de XML para CST = 90 - Outras, com informação do CST e ICMS próprio
                //    xmlListaProduto.Append("<ICMS90>");
                //    xmlListaProduto.Append("<orig>" + pessoa.Venda.TributoProduto.Origem.Trim() + "</orig>");
                //    xmlListaProduto.Append("<CST>" + pessoa.Venda.TributoProduto.IcmsCst.Trim() + "</CST>");
                //    xmlListaProduto.Append("<modBC>" + pessoa.Venda.TributoProduto.modBC.ToString().Replace(",", ".") + "</modBC>");
                //    xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.TributoProduto.pRedBC.ToString().Replace(",", ".") + "</pRedBC>");
                //    xmlListaProduto.Append("<vBC>" + pessoa.Venda.TributoProduto.vBC.ToString().Replace(",", ".") + "</vBC>");
                //    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.TributoProduto.pICMS.ToString().Replace(",", ".") + "</pICMS>");
                //    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.TributoProduto.vICMS.ToString().Replace(",", ".") + "</vICMS>");
                //    xmlListaProduto.Append("</ICMS90>");
                //}

                //else if (pessoa.Venda.TributoProduto.IcmsCst.Trim() == "90")
                //{
                //    //Exemplo de XML para CST = 90 - Outras, com informação do CST e ICMS ST
                //    xmlListaProduto.Append("<ICMS90>");
                //    xmlListaProduto.Append("<orig>" + pessoa.Venda.TributoProduto.Origem.Trim() + "</orig>");
                //    xmlListaProduto.Append("<CST>" + pessoa.Venda.TributoProduto.IcmsCst.Trim() + "</CST>");
                //    xmlListaProduto.Append("<modBC>" + pessoa.Venda.TributoProduto.modBC.ToString().Replace(",", ".") + "</modBC>");
                //    xmlListaProduto.Append("<pMVAST>" + pessoa.Venda.TributoProduto.pMVAST.ToString().Replace(",", ".") + "</pMVAST>");
                //    xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.TributoProduto.pRedBC.ToString().Replace(",", ".") + "</pRedBC>");
                //    xmlListaProduto.Append("<vBC>" + pessoa.Venda.TributoProduto.vBC.ToString().Replace(",", ".") + "</vBC>");
                //    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.TributoProduto.pICMS.ToString().Replace(",", ".") + "</pICMS>");
                //    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.TributoProduto.vICMS.ToString().Replace(",", ".") + "</vICMS>");
                //    xmlListaProduto.Append("</ICMS90>");
                //}

                //else if (pessoa.Venda.TributoProduto.IcmsCst.Trim() == "90")
                //{
                //    //Exemplo de XML para CST = 90 - Outras, com informação do CST, ICMS próprio e ICMS ST
                //    xmlListaProduto.Append("<ICMS90>");
                //    xmlListaProduto.Append("<orig>" + pessoa.Venda.TributoProduto.Origem.Trim() + "</orig>");
                //    xmlListaProduto.Append("<CST>" + pessoa.Venda.TributoProduto.IcmsCst.Trim() + "</CST>");
                //    xmlListaProduto.Append("<modBC>" + pessoa.Venda.TributoProduto.modBC.ToString().Replace(",", ".") + "</modBC>");

                //    xmlListaProduto.Append("<pRedBC>" + pessoa.Venda.TributoProduto.pRedBC.ToString().Replace(",", ".") + "</pRedBC>");
                //    xmlListaProduto.Append("<vBC>" + pessoa.Venda.TributoProduto.vBC.ToString().Replace(",", ".") + "</vBC>");
                //    xmlListaProduto.Append("<pICMS>" + pessoa.Venda.TributoProduto.pICMS.ToString().Replace(",", ".") + "</pICMS>");
                //    xmlListaProduto.Append("<vICMS>" + pessoa.Venda.TributoProduto.vICMS.ToString().Replace(",", ".") + "</vICMS>");
                //    xmlListaProduto.Append("<modBCST>" + pessoa.Venda.TributoProduto.modBCST.ToString().Replace(",", ".") + "</modBCST>");
                //    xmlListaProduto.Append("<pMVAST>" + pessoa.Venda.TributoProduto.pMVAST.ToString().Replace(",", ".") + "</pMVAST>");
                //    xmlListaProduto.Append("<pRedBCST>" + pessoa.Venda.TributoProduto.pRedBCST.ToString().Replace(",", ".") + "</pRedBCST>");
                //    xmlListaProduto.Append("<vBCST>" + pessoa.Venda.TributoProduto.vBCST.ToString().Replace(",", ".") + "</vBCST>");
                //    xmlListaProduto.Append("<pICMSST>" + pessoa.Venda.TributoProduto.pICMSST.ToString().Replace(",", ".") + "</pICMSST>");
                //    xmlListaProduto.Append("<vICMSST>" + pessoa.Venda.TributoProduto.pICMSST.ToString().Replace(",", ".") + "</vICMSST>");
                //    xmlListaProduto.Append("</ICMS90>");
                //}

                #endregion

                xmlListaProduto.Append("</ICMS>");

                #endregion

                #region IMPOSTO PIS


                #region PIS 49

                if (pessoa.Venda.ProdutoTributos.cstPis.Trim() == "49")
                {
                    xmlListaProduto.Append("<PIS>");

                    xmlListaProduto.Append("<PISOutr>");

                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstPis.Trim() + "</CST>");
                    xmlListaProduto.Append("<qBCProd>0.0000</qBCProd>");
                    xmlListaProduto.Append("<vAliqProd>0.0000</vAliqProd>");
                    xmlListaProduto.Append("<vPIS>0.00</vPIS>");

                    xmlListaProduto.Append("</PISOutr>");

                    xmlListaProduto.Append("</PIS>");
                }

                #endregion

                #region PIS 99

                else if (pessoa.Venda.ProdutoTributos.cstPis.Trim() == "99")
                {
                    xmlListaProduto.Append("<PIS>");

                    xmlListaProduto.Append("<PISOutr>");

                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstPis.Trim() + "</CST>");
                    xmlListaProduto.Append("<qBCProd>0.0000</qBCProd>");
                    xmlListaProduto.Append("<vAliqProd>0.0000</vAliqProd>");
                    xmlListaProduto.Append("<vPIS>0.00</vPIS>");

                    xmlListaProduto.Append("</PISOutr>");

                    xmlListaProduto.Append("</PIS>");
                }

                #endregion

                #region PIS 90 OU 49

                else
                {
                    xmlListaProduto.Append("<PIS>");

                    //tag PISNT
                    xmlListaProduto.Append("<PISNT>");

                    //tag pisnt
                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstPis.Trim() + "</CST>");
                    xmlListaProduto.Append("</PISNT>");

                    xmlListaProduto.Append("</PIS>");
                }

                #endregion

                #endregion

                #region IMPOSTO COFINS

                //tag COFINS
                xmlListaProduto.Append("<COFINS>");

                #region COFINS ST

                if (pessoa.Venda.ProdutoTributos.cstCofins.Trim() == "49")
                {
                    xmlListaProduto.Append("<COFINSOutr>");

                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstCofins.Trim() + "</CST>");
                    xmlListaProduto.Append("<qBCProd>0.0000</qBCProd>");
                    xmlListaProduto.Append("<vAliqProd>0.0000</vAliqProd>");
                    xmlListaProduto.Append("<vCOFINS>0.00</vCOFINS>");

                    xmlListaProduto.Append("</COFINSOutr>");
                }

                else if (pessoa.Venda.ProdutoTributos.cstCofins.Trim() == "99")
                {
                    xmlListaProduto.Append("<COFINSOutr>");

                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstCofins.Trim() + "</CST>");
                    xmlListaProduto.Append("<qBCProd>0.0000</qBCProd>");
                    xmlListaProduto.Append("<vAliqProd>0.0000</vAliqProd>");
                    xmlListaProduto.Append("<vCOFINS>0.00</vCOFINS>");

                    xmlListaProduto.Append("</COFINSOutr>");
                }

                else
                {
                    xmlListaProduto.Append("<COFINSNT>");

                    xmlListaProduto.Append("<CST>" + pessoa.Venda.ProdutoTributos.cstCofins.Trim() + "</CST>");

                    xmlListaProduto.Append("</COFINSNT>");
                }

                #endregion

                xmlListaProduto.Append("</COFINS>");

                #endregion

                xmlListaProduto.Append("</imposto>");

                #endregion
            }

            #endregion

            xmlListaProduto.Append("</det>");

            return xmlListaProduto.ToString();
        }

        public string GerarXmlCancelamentoNFCe(string versao, string chave, string cUF, string sequencia, int tpAmb, string CnpjEmit, string protocoloCancel, string path)
        {
            try
            {
                XmlDocument xmlEnvio = new XmlDocument();
                StringBuilder xml = new StringBuilder();


                string dataCancel = (DateTime.Now.ToString("s") + DateTime.Now.ToString("zzz"));

                xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

                xml.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + versao + "\">");

                xml.Append("<infEvento Id=\"" + "ID" + 110111 + chave + sequencia.Trim().PadLeft(2, '0') + "\">");

                xml.Append("<cOrgao>" + cUF + "</cOrgao>");
                xml.Append("<tpAmb>" + tpAmb + "</tpAmb>");
                xml.Append("<CNPJ>" + CnpjEmit + "</CNPJ>");
                xml.Append("<chNFe>" + chave + "</chNFe>");
                xml.Append("<dhEvento>" + dataCancel + "</dhEvento>");
                xml.Append("<tpEvento>" + 110111 + "</tpEvento>");
                xml.Append("<nSeqEvento>" + sequencia + "</nSeqEvento>");
                xml.Append("<verEvento>" + versao + "</verEvento>");

                #region detEvento

                //tag versao
                xml.AppendFormat("<detEvento versao=\"" + versao + "\">");

                xml.Append("<descEvento>" + "Cancelamento" + "</descEvento>");
                xml.Append("<nProt>" + protocoloCancel + "</nProt>");
                xml.Append("<xJust>Venda Cancela pelo cliente</xJust>");

                xml.Append("</detEvento>");

                xml.Append("</infEvento>");

                xml.Append("</evento>");

                xmlEnvio.LoadXml(xml.ToString());
                xmlEnvio.Save(path + "SERVICOS\\CANCELAR\\CANCELAMENTO.xml");

                return xml.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlPagamentos(Pessoa pessoa)
        {
            try
            {
                StringBuilder xmlPagamentos = new StringBuilder();

                if (pessoa.Venda.PagamentoVendaC.indPag == "02")
                {
                    if (pessoa.Venda.PagamentoVendaC.indPag.Trim() == "0")
                    {
                        xmlPagamentos.Append("<detPag>");
                        xmlPagamentos.Append("<tPag>" + pessoa.Venda.PagamentoVendaC.indPag.Trim() + "</tPag>");
                        xmlPagamentos.Append("<vPag>" + pessoa.Venda.PagamentoVendaC.vPag.ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</vPag>");
                        xmlPagamentos.Append("</detPag>");
                    }
                    else if (pessoa.Venda.PagamentoVendaC.indPag.Trim() == "1")
                    {
                        xmlPagamentos.Append("<detPag>");
                        xmlPagamentos.Append("<indPag>" + pessoa.Venda.PagamentoVendaC.tpIntegra.Trim() + "</indPag>");
                        xmlPagamentos.Append("<tPag>" + pessoa.Venda.PagamentoVendaC.indPag.Trim() + "</tPag>");
                        xmlPagamentos.Append("<vPag>" + pessoa.Venda.PagamentoVendaC.vPag.ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</vPag>");
                        xmlPagamentos.Append("<card>");
                        xmlPagamentos.Append("<tpIntegra>" + pessoa.Venda.PagamentoVendaC.tpIntegra.Trim() + "</tpIntegra>");
                        xmlPagamentos.Append("<CNPJ>" + pessoa.Venda.PagamentoVendaC.CNPJ.Trim() + "</CNPJ>");
                        xmlPagamentos.Append("<tBand>" + pessoa.Venda.PagamentoVendaC.tBand.Trim() + "</tBand>");
                        xmlPagamentos.Append("<cAut>" + pessoa.Venda.PagamentoVendaC.cAut.Trim() + "</cAut>");
                        xmlPagamentos.Append("</card>");
                        xmlPagamentos.Append("</detPag>");
                    }
                }
                else if (pessoa.Venda.PagamentoVendaC.indPag.Trim() == "01")
                {
                    xmlPagamentos.Append("<detPag>");
                    xmlPagamentos.Append("<tPag>" + pessoa.Venda.PagamentoVendaC.indPag.Trim() + "</tPag>");
                    xmlPagamentos.Append("<vPag>" + pessoa.Venda.PagamentoVendaC.vPag.ToString("N2").Trim().Replace(".", "").Replace(",", ".") + "</vPag>");

                    xmlPagamentos.Append("</detPag>");

                    if (Convert.ToDecimal(pessoa.Venda.PagamentoVendaC.troco) > 0)
                    {
                        xmlPagamentos.Append("<vTroco>" + pessoa.Venda.PagamentoVendaC.troco.ToString("N2").Trim().Replace(".", "").Replace(",", ".").Trim() + "</vTroco>");
                    }
                }
                else
                {
                    xmlPagamentos.Append("<detPag>");
                    xmlPagamentos.Append("<tPag>" + pessoa.Venda.PagamentoVendaC.indPag.Trim() + "</tPag>");
                    xmlPagamentos.Append("<vPag>0.00</vPag>");
                    xmlPagamentos.Append("</detPag>");
                }

                return xmlPagamentos.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXmlInformacaoComplementar(string informacao)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<infAdic>");

                sb.Append("<infCpl>" + informacao + "</infCpl>");

                sb.Append("</infAdic>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public XmlDocument EnveloparXMLEnvioDocAssinado(string xmlLoteAssinado, string pathVendaCFe)
        {
            try
            {
                XmlDocument soapEnvelop = new XmlDocument();

                soapEnvelop.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">" +
                    " <soap:Body>" +
                    " <nfeDadosMsg xmlns=\"http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4\">" + xmlLoteAssinado.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "") +
                    " </nfeDadosMsg>" +
                    " </soap:Body>" +
                    "</soap:Envelope>");

                soapEnvelop.Save(pathVendaCFe + "\\XMLs\\SERVICOS\\EMITIR\\EMITIR_ENVELOPE.xml");

                return soapEnvelop;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public XmlDocument GerarXmlProcNFe(string versao, int idTipoAmbiente, string verAplic, string chNFe, string dhRecbto, string nProt, string digVal, string cStat, string xMotivo)
        {
            try
            {
                XmlDocument xml = new XmlDocument();

                StringBuilder xmlProc = new StringBuilder();

                xmlProc.Append("<protNFe versao=\"" + versao + "\">")
               .Append("<infProt>")
               .Append("<tpAmb>" + idTipoAmbiente + "</tpAmb>")
               .Append("<verAplic>" + verAplic + "</verAplic>")
               .Append("<chNFe>" + chNFe + "</chNFe>")
               .Append("<dhRecbto>" + dhRecbto + "</dhRecbto>")
               .Append("<nProt>" + nProt + "</nProt>")
               .Append("<digVal>" + digVal + "</digVal>")
               .Append("<cStat>" + cStat + "</cStat>")
               .Append("<xMotivo>" + xMotivo + "</xMotivo>")
               .Append("</infProt>")
               .Append("</protNFe>");

                xml.LoadXml(xmlProc.ToString());

                return xml;
            }
            catch (Exception ex)
            {
                return null;

                throw new Exception(ex.Message);
            }
        }

        public string GerarXMLProcNFCe(string nsURI, string versao, string strNFe, string strProtNfe)
        {
            try
            {
                XmlDocument xml = new XmlDocument();

                StringBuilder sb = new StringBuilder();

                sb.Append("<NFeProc xmlns=\"" + nsURI + "\" versao=\"" + versao.Trim() + "\">");
                sb.Append(strNFe + strProtNfe.Replace("xmlns=\"http://www.portalfiscal.inf.br/nfe\"", ""));
                sb.Append("</NFeProc> ");

                xml.LoadXml(sb.ToString());

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarXMLProcNFCe(string versao, string strArqNFe, string strProtNfe)
        {
            try
            {
                string tipo = "nf";

                string nsURI = "http://www.portalfiscal.inf.br/nfe";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strArqNFe);

                XmlNodeList NFeList = doc.GetElementsByTagName(tipo.ToUpper() + "e");
                XmlNode NFeNode = NFeList[0];

                string strNFe = NFeNode.OuterXml;

                return "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                     "<" + tipo + "eProc xmlns=\"" + nsURI + "\" versao=\"" + versao.Trim() + "\">" +
                     strNFe + strProtNfe.Replace("xmlns=\"http://www.portalfiscal.inf.br/nfe\"", "") +
                     "</" + tipo + "eProc>";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
