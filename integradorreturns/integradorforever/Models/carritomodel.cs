namespace integradorforever.Models
{
    public class carritomodel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public int Total { get; set; }
    }
}
