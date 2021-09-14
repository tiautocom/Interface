using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
   public class FORMA_PAGAMENTOS
    {
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public decimal Total { get; set; }
        public string Troco { get; set; }
        public int contador { get; set; }
        public int idCliente { get; set; }
    }
}
