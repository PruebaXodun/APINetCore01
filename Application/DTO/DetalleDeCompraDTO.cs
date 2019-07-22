using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class DetalleDeCompraDTO
    {
        public int Id { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ArticuloId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }

        public virtual ArticuloDTO ArticuloDTO { get; set; }
        public virtual OrdenDeCompraDTO OrdenDeCompraDTO { get; set; }
    }
}
