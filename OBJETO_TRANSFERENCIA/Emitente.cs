using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Emitente
    {
        public int IdEmitente { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string IeRg { get; set; }
        public string IM { get; set; }
        public string Email { get; set; }
        public string RegimeTributario { get; set; }
        public string Telefone { get; set; }
        public string Rntrc { get; set; }
        public string CRT { get; set; }
        public double cAliqSn { get; set; }

        public Endereco Endereco { get; set; }
    }
}
