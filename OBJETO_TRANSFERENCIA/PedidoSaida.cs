using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class PedidoSaida
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int NumPedido { get; set; }
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
        public decimal Qtde { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public decimal Estoque { get; set; }
        public bool Status { get; set; }
        public string Obs { get; set; }
    }
}
