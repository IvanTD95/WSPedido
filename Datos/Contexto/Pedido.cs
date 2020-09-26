using System;
using System.Collections.Generic;

namespace WSPedido.Datos.Contexto
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public string Sku { get; set; }
        public string NombreUsuario { get; set; }
        public int? Cantidad { get; set; }
    }
}
