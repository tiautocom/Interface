using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class VENDAS
    {
        public int IdVenda { get; set; }
        public string itemVenda { get; set; }
        public string codoBarra { get; set; }
        public string descricao { get; set; }
        public string unid { get; set; }
        public string qtde { get; set; }
        public string precoProd { get; set; }
        public decimal totVenda { get; set; }
        public string subTotal { get; set; }
        public string estoque { get; set; }
        public int idProd { get; set; }

        public string cst { get; set; }
        public string ncm { get; set; }
        public string cfop { get; set; }
    }
}
