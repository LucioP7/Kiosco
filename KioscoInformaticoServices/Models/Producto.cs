using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KioscoInformaticoServices.Models;

public partial class Producto
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [DataType(DataType.Currency)]
    public decimal Precio { get; set; }
    public bool Eliminado { get; set; } = false;
    public bool Oferta { get; set; } = false;
}
