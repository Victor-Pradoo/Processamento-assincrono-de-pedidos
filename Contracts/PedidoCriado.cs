namespace Contracts
{
    //utilizado para caracterizar o evento e facilitar a localização do pedido na fila
    public record PedidoCriado(Guid PedidoId, string Status);
}