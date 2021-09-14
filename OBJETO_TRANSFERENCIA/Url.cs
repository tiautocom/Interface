using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Url
    {
        public int Id { get; set; }
        public string Versao { get; set; }
        public int Codigo { get; set; }
        public string Servico { get; set; }
        public int IdAmbiente { get; set; }
        public string DesccAmbiente { get; set; }
        public int CodNumerico { get; set; }

        public string urlProc { get; set; }
    }
}
