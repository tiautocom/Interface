using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class DepartamentoC : ProdutoC
    {
        public int Id { get; set; }
        public string idDepartamento { get; set; }
        public string descricaoDep { get; set; }
        public decimal Valor { get; set; }
        public string Anp { get; set; }
        public string cest { get; set; }
        public bool Aviso { get; set; }
    }
}
