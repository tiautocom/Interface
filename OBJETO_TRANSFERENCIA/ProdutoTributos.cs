using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class ProdutoTributos
    {
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int NumVenda { get; set; }
        public string Ncm { get; set; }
        public string Cfop { get; set; }
        public string Cest { get; set; }
        public string Origem { get; set; }
        public string IcmsCst { get; set; }
        public string cstPis { get; set; }
        public string cstCofins { get; set; }
        public string ModBC { get; set; }
        public string RedBC { get; set; }
        public string Trib { get; set; }
        public decimal pPIS { get; set; }
        public string vICMS { get; set; }
        public string vBC { get; set; }
        public string vTotaTrib { get; set; }
        public string modBCST { get; set; }
        public string pMVAST { get; set; }
        public string pRedBCST { get; set; }
        public string vBCST { get; set; }
        public string pICMSST { get; set; }
        public string vICMSST { get; set; }
        public decimal vICMSOp { get; set; }
        public decimal pDif { get; set; }
        public decimal vICMSDif { get; set; }
        public decimal modBC { get; set; }
        public decimal pRedBC { get; set; }
        public string pICMS { get; set; }
        public string Ipi { get; set; }
        public string vOutro { get; set; }

        public string DescricaoProduto { get; set; }
    }
}
