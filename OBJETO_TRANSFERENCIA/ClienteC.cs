using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class ClienteC
    {
        public int idCliente { get; set; }
        public string nome { get; set; }
        public int NumVenda { get; set; }
        public int NumCaixa { get; set; }

        public string dataCadastro { get; set; }
        public string apelidoFantasia { get; set; }
        public string cpfCnpj { get; set; }
        public string rgIe { get; set; }
        public DateTime datas { get; set; }
        public bool status { get; set; }
        public DateTime DtAniversario { get; set; }

        public decimal limite { get; set; }
        public decimal gasto { get; set; }
        public string bloq { get; set; }

        public string email { get; set; }
        public String observacao { get; set; }

        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
