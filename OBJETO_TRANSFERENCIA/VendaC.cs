using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class VendaC : ProdutoC
    {
        public int vendaId { get; set; }
        public int produtoId { get; set; }
        public decimal qtde { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        public int item { get; set; }
        public DateTime dtVenda { get; set; }
        public int idUsuario { get; set; }
        public bool baixado { get; set; }
        public int numVenda { get; set; }
        public bool fech { get; set; }
        public int numCaixa { get; set; }
        public string anp { get; set; }
        public string unid { get; set; }
        public bool tag { get; set; }

        public string indTot { get; set; }
        public string AliqSn { get; set; }
        public int Item { get; set; }
        public decimal vFrete { get; set; }
        public string InfComplementar { get; set; }

        public ProdutoC Produto { get; set; }
        public ProdutoTributos ProdutoTributos { get; set; }
        public VendaIcms VendaIcms { get; set; }
        public Transporte Transporte { get; set; }
        public PagamentoVendaC PagamentoVendaC { get; set; }
    }
}
