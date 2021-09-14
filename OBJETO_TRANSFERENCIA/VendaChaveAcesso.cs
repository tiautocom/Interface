using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class VendaChaveAcesso
    {
        public int Id { get; set; }
        public string CnpjEmitente { get; set; }
        public string CnpjDestinatario { get; set; }
        public string ChaveCFe { get; set; }
        public string Produto { get; set; }
        public DateTime Data { get; set; }
        public decimal Qtde { get; set; }
        public decimal Valor { get; set; }
        public int NumVenda { get; set; }
        public bool Fechado { get; set; }
        public string Condutor { get; set; }
        public string Placa { get; set; }

        public VendaC Venda { get; set; }
    }
}
