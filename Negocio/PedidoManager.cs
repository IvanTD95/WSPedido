using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSPedido.Datos;
using WSPedido.Datos.Contexto;

namespace WSPedido.Negocio
{
    public class PedidoManager
    {
        private PedidoDatos pedidoDatos;
        public PedidoManager()
        {
            this.pedidoDatos = new PedidoDatos();
        }

        public List<Pedido> GetPedido()
        {
            var lstProductos = new List<Pedido>();

            lstProductos = pedidoDatos.SelectPedidos();

            return lstProductos;
        }

        public List<Pedido> SelectPedidoId(int idPedido)
        {
            var lstPedidos = new List<Pedido>();

            lstPedidos = pedidoDatos.SelectPedidoId(idPedido);

            return lstPedidos;
        }



        public bool InsertPedido(List<Pedido> lstPedido)
        {
            return  pedidoDatos.InsertPedido(lstPedido);                                 

        }

        public bool UpdatePedido(List<Pedido> lstPedido)
        {
            return pedidoDatos.UpdatePedido(lstPedido);

        }


        public bool DeletePedido(int idPedido)
        {
            return pedidoDatos.DeletePedido(idPedido);

        }



    }
}
