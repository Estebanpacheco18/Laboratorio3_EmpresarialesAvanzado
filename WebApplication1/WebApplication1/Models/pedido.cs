using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class pedido
{
    public int ID { get; set; }

    public int? UsuarioID { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual usuario? Usuario { get; set; }

    public virtual ICollection<detallepedido> detallepedidos { get; set; } = new List<detallepedido>();
}
