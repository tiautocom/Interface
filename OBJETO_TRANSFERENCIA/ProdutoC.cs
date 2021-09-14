using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class ProdutoC
    {
        public int idProduto { get; set; }
        public string descricao { get; set; }
        public string codBarra { get; set; }
        public string gTin { get; set; }
        public decimal precoProduto { get; set; }
        public decimal precoPromocao { get; set; }
        public int numDepartamento { get; set; }
        public decimal preco { get; set; }
        public string unid { get; set; }
        public decimal desc { get; set; }
        public string trib { get; set; }
        public string reducao { get; set; }
        public decimal estoque { get; set; }
        public decimal estoqueMin { get; set; }
        public string ncm { get; set; }
        public string cfop { get; set; }
        public decimal tecla { get; set; }
        public string granel { get; set; }
        public bool descAuto { get; set; }
        public decimal qtdeDesc { get; set; }
        public decimal custo { get; set; }
        public string atualiza { get; set; }
        public decimal embal { get; set; }
        public decimal custoCaixa { get; set; }
        public decimal lixo { get; set; }
        public DateTime dtAjuste { get; set; }
        public decimal setor { get; set; }
        public string validade { get; set; }
        public string vencimento { get; set; }
        public string indeceB { get; set; }
        public decimal margem { get; set; }
        public decimal qtdeCom { get; set; }
        public decimal qtdeAutomatica { get; set; }
        public string dtCom { get; set; }
        public string valorPis { get; set; }
        public string cstPis { get; set; }
        public string valorCofins { get; set; }
        public string cstCofins { get; set; }
        public string origemProduto { get; set; }
        public string icms { get; set; }
        public string icmsCst { get; set; }
        public string cest { get; set; }
        public string aliquota { get; set; }
        public string naturezaOperacao { get; set; }
        public string cstIcms { get; set; }
        public string cstIpi { get; set; }
        public string modRedBC { get; set; }
        public string DepartamentoDesc { get; set; }
        public int ItemVenda { get; set; }

        public decimal percIpi { get; set; }
        public decimal percRedBc { get; set; }
        public decimal percCofins { get; set; }
        public decimal percPis { get; set; }
    }
}
