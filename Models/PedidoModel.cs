namespace DesafioBtg.Models
{
    internal static class ListaDePedidos
    {
        public static List<PedidoModel> pedidos = new();
    }
    public class PedidoModel
    {
        public Guid Id { get; set; }
        public int ClienteId { get; set; }
        public required List<string> Itens { get; set; }
        public string Status { get; set; }
    }
}
