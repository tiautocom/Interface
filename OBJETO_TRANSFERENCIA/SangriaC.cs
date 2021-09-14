using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class SangriaC: UsuarioC
    {
        public int idSangria { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public int numCaixa { get; set; }
        public bool fechado { get; set; }
        public bool tipo { get; set; }
        public int Qtde { get; set; }
        public string Motivo { get; set; }
        public string Operador { get; set; }
    }
}
