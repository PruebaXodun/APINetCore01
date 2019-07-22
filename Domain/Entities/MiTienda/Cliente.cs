using System;
using System.Collections.Generic;

namespace Domain.Entities.MiTienda
{
    public partial class Cliente
    {
        public Cliente()
        {
            OrdenDeCompra = new HashSet<OrdenDeCompra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasenya { get; set; }
        public int Rut { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<OrdenDeCompra> OrdenDeCompra { get; set; }
    }
}
