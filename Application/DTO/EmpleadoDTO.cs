using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual List<OrdenDeCompraDTO> OrdenDeCompra { get; set; }
    }
}
