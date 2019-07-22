using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class OrdenDeCompraDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public DateTime? FechaEntregaEstimada { get; set; }
        public bool DespachoEnDomicilio { get; set; }
        public int Total { get; set; }

        public virtual ClienteDTO ClienteDTO { get; set; }
        public virtual EmpleadoDTO EmpleadoDTO { get; set; }
        public virtual EstadoDTO EstadoDTO { get; set; }
        public virtual List<DetalleDeCompraDTO> DetalleDeCompraDTO { get; set; }
    }
}
