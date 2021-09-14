using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Endereco
    {
        public int idPessoa { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string complemento { get; set; }
        public string observacao { get; set; }
        public bool status { get; set; }
        public string ibge { get; set; }
        public string codPAis { get; set; }
        public string pais { get; set; }
        public int IdCidade { get; set; }
    }
}
