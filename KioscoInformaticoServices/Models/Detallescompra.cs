namespace KioscoInformaticoServices.Models;

public partial class DetallesCompra
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public int CompraId { get; set; }

    public virtual Producto Producto { get; set; } = null!;
    public virtual Compra Compra { get; set; } = null!;
}
