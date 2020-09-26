using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSPedido.Datos.Contexto;
using WSPedido.Negocio;

namespace WSPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private PedidoManager pedidoNegocio;

        public PedidoController()
        {
            this.pedidoNegocio = new PedidoManager();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var lstProductos = this.pedidoNegocio.GetPedido();
            return lstProductos;

        }

        [HttpGet("{idPedido}")]
        public ActionResult<List<Pedido>> Get(int idPedido)
        {
            var lstPedido = this.pedidoNegocio.SelectPedidoId(idPedido);

            return lstPedido;

        }


        [HttpPost]
        public ActionResult<bool> Post([FromBody]List<Pedido> pedido)
        {

            return pedidoNegocio.InsertPedido(pedido);
        }


        [HttpPut]
        public ActionResult<bool> Put([FromBody]List<Pedido> pedido)
        {

            return pedidoNegocio.UpdatePedido(pedido);
        }

        [HttpDelete("{idPedido}")]
        public ActionResult<bool> Delete(int idPedido)
        {

             return pedidoNegocio.DeletePedido(idPedido);
        }





    }
}
