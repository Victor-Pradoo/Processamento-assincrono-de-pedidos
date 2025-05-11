using DesafioBtg.Models;

namespace DesafioBtg.Interfaces
{
    public interface IPedidoInterface
    {
        PedidoModel AdicionarPedido(PedidoRequest request);
        string? ObterStatus(Guid id);
    }
}
