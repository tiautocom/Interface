using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBJETO_TRANSFERENCIA
{
    public class UsuarioC : TipoUsuarioC
    {
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string senha { get; set; }
        public string periodo { get; set; }
        public bool ativo { get; set; }
        public int numCaixa { get; set; }
        public bool statusUsuario { get; set; }
    }
}
