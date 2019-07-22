using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public virtual List<OrdenDeCompraDTO> OrdenDeCompraDTO { get; set; }
    }
}
