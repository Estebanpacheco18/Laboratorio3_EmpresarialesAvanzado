using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class producto
{
    public int ID { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<detallepedido> detallepedidos { get; set; } = new List<detallepedido>();
}
