using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class usuario
{
    public int ID { get; set; }

    public string? Nombre { get; set; }

    public string? Rol { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<pedido> pedidos { get; set; } = new List<pedido>();
}
