using DesafioBtg.Interfaces;
using DesafioBtg.Models;

namespace DesafioBtg.Services
{
    public class PedidoService : IPedidoInterface
    {

        // Adiciona um pedido ao dicionário com status "pendente"
        public PedidoModel AdicionarPedido(PedidoRequest pedidoRequest)
        {
            var id = Guid.NewGuid();
            var novoPedido = new PedidoModel() 
            {
                Id = Guid.NewGuid(),
                ClienteId = pedidoRequest.ClienteId,
                Itens = pedidoRequest.Itens,
                Status = "pendente" 
            };

            return novoPedido;
        }

        public string? ObterStatus(Guid id)
        {
            //Pesquisa o id passado como parâmetro na lista de pedidos
            var pedidoSolicitado = ListaDePedidos.pedidos.FirstOrDefault(p =>  p.Id == id);

            if (pedidoSolicitado != null)
            {
                return pedidoSolicitado.Status;
            }

            return null;
        }
    }
}
