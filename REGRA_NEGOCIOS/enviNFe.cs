using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace REGRA_NEGOCIOS
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class enviNFe
    {
        /// <summary>
        ///     AP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute(AttributeName = "versao")]
        public string versao { get; set; }

        /// <summary>
        ///     AP03 - Identificador de controle do envio do lote.
        /// </summary>
        public string idLote { get; set; }

        /// <summary>
        ///     AP03a - Indicador de Sincronização
        /// </summary>
        public string indSinc { get; set; }

        /// <summary>
        ///     AP04 - Conjunto de NF-e transmitidas
    }
}
