﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class VendaFechamentoItem
    {
        public int IdVendaFechamento { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Qtde { get; set; }
        public decimal Total { get; set; }
    }
}
