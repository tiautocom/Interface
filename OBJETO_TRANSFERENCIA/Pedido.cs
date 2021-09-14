using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class Pedido
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public int IdUsuario { get; set; }
        public int Numero { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public bool Status { get; set; }
        public decimal Qtde { get; set; }

        public string EsfODLonge { get; set; }
        public string EsfOELonge { get; set; }
        public string EsfODPerto { get; set; }
        public string EsfOEPerto { get; set; }

        public string CiliODLonge { get; set; }
        public string CiliOELonge { get; set; }
        public string CiliODPerto { get; set; }
        public string CiliOEPerto { get; set; }

        public string EixoODLonge { get; set; }
        public string EixoOElonge { get; set; }
        public string EixoODPerto { get; set; }
        public string EixoOEPerto { get; set; }

        public string DpODLonge { get; set; }
        public string DpOELonge { get; set; }
        public string DpODPerto { get; set; }
        public string DpOEPerto { get; set; }

        public string AltODLonge { get; set; }
        public string AltOELonge { get; set; }
        public string AltODPerto { get; set; }
        public string AltOEPerto { get; set; }

        public string Otico { get; set; }

        public string NumReceita { get; set; }

        public string StatusDesc { get; set; }
        public string Url { get; set; }

        public Medico Medico { get; set; }
    }
}
