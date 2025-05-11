using DesafioBtg.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioBtg.Models;
using MassTransit;
using Contracts;

namespace DesafioBtg.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoInterface;
        private readonly IPublishEndpoint _publishEndpoint;
        public PedidoController (IPedidoInterface pedidoInterface, IPublishEndpoint publishEndpoint)
        {
            _pedidoInterface = pedidoInterface;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("CriarPedido")]
        public async Task<IActionResult> Criar(PedidoRequest request)
        {
            //Cria um novo pedido e o salva na variável novoPedido
            var novoPedido = _pedidoInterface.AdicionarPedido(request);

            //Adiciona o novo pedido na lista de pedidos que é armazenada em memória
            ListaDePedidos.pedidos.Add(novoPedido);

            var evento = new PedidoCriado(novoPedido.Id, novoPedido.Status);

            //Publica na fila o evento criado com o novo pedido 
            await _publishEndpoint.Publish(evento);

            return Ok(novoPedido);
        }

        [HttpGet("ObterStatusPedido/{id}")]
        public IActionResult Status(Guid id)
        {
            var status = _pedidoInterface.ObterStatus(id);

            if (status != null)
            {
                return Ok(new { PedidoId = id, Status = status });
            }

            return Ok(status = "Id de pedido não encontrado");
        }

    }
}
