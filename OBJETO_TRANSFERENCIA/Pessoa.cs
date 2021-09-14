using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Id { get; set; }
        public string Telefone { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string CodPais { get; set; }
        public string CodMun { get; set; }
        public string OperadoraTelefone { get; set; }
        public string Data { get; set; }
        public bool Status { get; set; }

        public VendaC Venda { get; set; }
        public NFe NFe { get; set; }
        public Emitente Emitente { get; set; }
        public Destinatario Destinatario { get; set; }
    }
}
