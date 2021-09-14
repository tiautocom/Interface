using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace REGRA_NEGOCIOS
{
    public class SerealizarRegraNegocios
    {
        public XmlDocument SerializarNFe(object objectToSerialize, string strUrl = null)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                if (strUrl == null)
                {
                    strUrl = "http://www.portalfiscal.inf.br/nfe";
                }

                ns.Add("", strUrl);

                Stream mStream = new MemoryStream();

                XmlWriter writer = XmlWriter.Create(mStream);
                XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
                serializer.Serialize(writer, RuntimeHelpers.GetObjectValue(objectToSerialize), ns);

                writer.Flush();
                mStream.Flush();
                mStream.Position = 0L;
                doc.Load(mStream);
                return doc;
            }
            catch (Exception ex)
            {
                return doc;
                throw new Exception(ex.Message);
            }
        }
    }
}
