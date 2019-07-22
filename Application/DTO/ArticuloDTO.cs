using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Codigo { get; set; }

        public virtual List<DetalleDeCompraDTO> DetalleDeCompraDTO { get; set; }
    }
}
