using System.ComponentModel.DataAnnotations;

namespace KioscoInformaticoServices.Models;

public partial class Producto
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    [Required]
    public decimal Precio { get; set; }

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual ICollection<DetallesVenta> DetallesVentas { get; set; } = new List<DetallesVenta>();
}
