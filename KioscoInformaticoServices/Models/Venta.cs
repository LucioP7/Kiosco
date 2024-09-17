using KioscoInformaticoServices.Enums;

namespace KioscoInformaticoServices.Models;

public partial class Venta
{
    public int Id { get; set; }

    public FormaDePagoEnum FormaPago { get; set; }

    public int ClienteId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetallesVenta> DetallesVentas { get; set; } = new List<DetallesVenta>();
}
