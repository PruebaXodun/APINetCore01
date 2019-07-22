using System;
using System.Collections.Generic;

namespace Domain.Entities.MiTienda
{
    public partial class Empleado
    {
        public Empleado()
        {
            OrdenDeCompra = new HashSet<OrdenDeCompra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<OrdenDeCompra> OrdenDeCompra { get; set; }
    }
}
