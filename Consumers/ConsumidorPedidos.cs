using Contracts;
using DesafioBtg.Models;
using MassTransit;

namespace DesafioBtg.Consumers
{
    public class ConsumidorPedidos : IConsumer<PedidoCriado>
    {
        
        public async Task Consume(ConsumeContext<PedidoCriado> context)
        {
            Console.WriteLine($"Processando pedido: {context.Message.PedidoId}");

            //Delay de 2 segundos para simular o processamento
            await Task.Delay(2000);

            //pesquisa pelo Id na lista de pedidos para "processa-lo" == atualizar seu status
            var pedido = ListaDePedidos.pedidos.FirstOrDefault(p => p.Id == context.Message.PedidoId);

            if (pedido != null)
            {
                pedido.Status = "processado";
            }
            
            Console.WriteLine($"Pedido processado: {context.Message.PedidoId}");
        }
    }
}
