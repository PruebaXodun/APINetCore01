using System;
using System.Collections.Generic;

namespace Domain.Entities.MiTienda
{
    public partial class DetalleDeCompra
    {
        public int Id { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ArticuloId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual OrdenDeCompra OrdenDeCompra { get; set; }
    }
}
