using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;

namespace IMPRESSORA
{
    public class ImpressoraC : ParametroC
    {
        public string impCabecalho { get; set; }
        public string detalhes { get; set; }
        public string dadosVenda { get; set; }
        public string tipoPagamento { get; set; }
        public string troco { get; set; }
        public string impCorpo { get; set; }
        public string rodaPe { get; set; }
        public string dadosFinais { get; set; }
        public string vendaAberto { get; set; }
        public string corpo { get; set; }
        public string dadosSat { get; set; }
    }
}
