using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Destinatario
    {
        public int IdDestinatario { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string IeRg { get; set; }
        public string IM { get; set; }
        public int TipoPessoa { get; set; }
        public string Telefone { get; set; }
        public string indIEDest { get; set; }

        public Endereco Endereco { get; set; }
    }
}
