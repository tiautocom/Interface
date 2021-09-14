using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class ParametroC
    {
        public int idParametro { get; set; }
        public bool status { get; set; }
        public int codEtiqueta { get; set; }
        public string etiquetaBalanca { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string ie { get; set; }
        public string im { get; set; }
        public string cnpj { get; set; }
        public decimal aliquotaDia { get; set; }
        public bool placa { get; set; }
        public decimal limiteCompra { get; set; }
        public string msg { get; set; }
        public bool homologacaoTeste { get; set; }
        public string crt { get; set; }
        public bool cupomImagem { get; set; }
        public bool impressaoDigital { get; set; }
        public int qtdeCupom { get; set; }
        public bool vendaXml { get; set; }
        public bool pgtoVendaXml { get; set; }
        public int timeTelaDesc { get; set; }

        public int Numcaixa { get; set; }
    }
}
