using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class detallepedido
{
    public int ID { get; set; }

    public int? PedidoID { get; set; }

    public int? ProductoID { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual pedido? Pedido { get; set; }

    public virtual producto? Producto { get; set; }
}
