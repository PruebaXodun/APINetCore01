using System;
using System.Collections.Generic;

namespace Domain.Entities.MiTienda
{
    public partial class OrdenDeCompra
    {
        public OrdenDeCompra()
        {
            DetalleDeCompra = new HashSet<DetalleDeCompra>();
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public DateTime? FechaEntregaEstimada { get; set; }
        public bool DespachoEnDomicilio { get; set; }
        public int Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<DetalleDeCompra> DetalleDeCompra { get; set; }
    }
}
