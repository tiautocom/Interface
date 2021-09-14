using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Net.Security;

namespace REGRA_NEGOCIOS
{
    public class EnviarDocumentoSefazRegraNegocios
    {
        public bool retorno;

        public bool CertificateValidation(object sender, X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErros)
        {
            return true;
        }

        public bool EnviarXmlSefaz(string dadosCartao, string _url, string _action, XmlDocument soapEnvelopeXml, string pathEndereco)
        {
            try
            {
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly);

                var cert = store.Certificates.Find(X509FindType.FindBySubjectName, dadosCartao, true)[0];

                if (cert != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        bool ret = CreateHttpWebRequest(soapEnvelopeXml, _url, _action, dadosCartao, pathEndereco);

                        if (ret == true)
                        {
                            retorno = true;

                            break;
                        }
                    }

                    return retorno;
                }
                else
                {
                    return false;

                    throw new Exception("Erro no Cartão Digital do Cliente. Verifique Conexão e Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                return false;

                throw new Exception(ex.Message);
            }
        }

        public bool CreateHttpWebRequest(XmlDocument xml, string url, string actions, string dadosCartao, string pathEndereo)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CertificateValidation);

                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly);

                var cert = store.Certificates.Find(X509FindType.FindBySubjectName, dadosCartao, true)[0];

                HttpWebRequest webRequest = CreateWebRequest(url, actions);
                webRequest.ClientCertificates.Add(cert);
                webRequest.Proxy = null;
                webRequest.KeepAlive = true;
                webRequest.Timeout = 12000;

                ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                var bytes = Encoding.UTF8.GetBytes(xml.InnerXml);

                webRequest.ContentLength = bytes.Length;

                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var response = (HttpWebResponse)webRequest.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                xml.LoadXml(responseString.Trim());
                xml.Save(pathEndereo);

                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                xml = null;

                return false;
            }
            finally
            {
            }
        }

        private HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "application/soap+xml; charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            return webRequest;
        }
    }
}
