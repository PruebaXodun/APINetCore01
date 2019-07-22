using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasenya { get; set; }
        public int Rut { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }

        public virtual List<OrdenDeCompraDTO> OrdenDeCompraDTO { get; set; }
    }
}
