using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class PagamentoVendaC
    {
        public int idPagamentoVenda { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int tipoPagamento { get; set; }
        public decimal valor { get; set; }
        public string cnpj { get; set; }
        public int numVenda { get; set; }
        public bool baixado { get; set; }
        public DateTime data { get; set; }
        public decimal troco { get; set; }
        public bool fechado { get; set; }
        public int numCaixa { get; set; }
        public bool tag { get; set; }



        public string indPag { get; set; }
        public string tPag { get; set; }
        public double vPag { get; set; }


        //DADOS CARTAO CREDITO
        public string tpIntegra { get; set; }
        public string CNPJ { get; set; }
        public string tBand { get; set; }
        public string cAut { get; set; }
    }
}
