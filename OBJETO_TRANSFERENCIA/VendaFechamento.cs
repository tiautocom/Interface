using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class VendaFechamento
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public int NumCaixa { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }

        public VendaFechamentoItem VendaFechamentoItem { get; set; }
    }
}
