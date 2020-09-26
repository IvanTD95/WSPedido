using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSPedido.Datos.Contexto;

namespace WSPedido.Datos
{
    public class PedidoDatos
    {

        public TRUPERContex context;

        // GET; Obtiene todos los pedidos
        public List<Pedido> SelectPedidos()
        {
            var lstProducto = new List<Pedido>();

            using (var context = new TRUPERContex())
            {

                lstProducto = context.Pedido.ToList();

            }
            return lstProducto;
        }

        public List<Pedido> SelectPedidoId(int idPedido)
        {
            var lstPedido = new List<Pedido>();

            using (var context = new TRUPERContex())
            {

                lstPedido = context.Pedido.Where(x => x.IdPedido == idPedido).ToList();

            }
            return lstPedido;
        }


        public bool InsertPedido(List<Pedido> lstPedido )
        {
            var insertado = false;  
            


            using (var context = new TRUPERContex())
            {
              int ultimoIdPedido =   context.Pedido.OrderByDescending(x => x.IdPedido).First().IdPedido + 1;
                               
                lstPedido.ForEach(item => {
                    item.IdPedido = ultimoIdPedido;
                    context.Pedido.Add(item);
                });
                
                insertado = context.SaveChanges() > 0 ? true : false;

            }

            return insertado;

        }


        public bool UpdatePedido(List<Pedido> lstPedido)
        {
            var actualizado = false;
            var objPedido = new Pedido();
            
            try
            {
                using (var context = new TRUPERContex())
                {
                    lstPedido.ForEach(item =>
                    {

                        objPedido = context.Pedido.FirstOrDefault(x => x.IdPedido == item.IdPedido && x.Sku == item.Sku);
                       

                        if (objPedido != null)
                        {
                            objPedido.NombreUsuario = item.NombreUsuario;
                            objPedido.Cantidad = item.Cantidad;
                            context.Pedido.Update(objPedido);
                        }
                        else
                        {
                            context.Pedido.Add(item);

                        }                        

                    });

                    actualizado  = context.SaveChanges() > 0 ? true : false;
                }
            }
            catch
            {
                actualizado = false;

            }

            return actualizado;

        }




        public bool DeletePedido(int  idPedido)
        {

            bool eliminado = false;
            var objPedido = new Pedido();

            using (var context = new TRUPERContex())
            {
                var lstPedido = context.Pedido.Where(x => x.IdPedido == idPedido).ToList();

                context.Pedido.RemoveRange(lstPedido);

               eliminado  = context.SaveChanges() > 0 ? true : false;
            }

            return eliminado;
        }







    }
}
