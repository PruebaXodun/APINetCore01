using Domain.Seedwork;
using System.Collections.Generic;

namespace Domain.Entities.MiTienda
{
    public partial class Articulo : Entity
    {
        public Articulo()
        {
            DetalleDeCompra = new HashSet<DetalleDeCompra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<DetalleDeCompra> DetalleDeCompra { get; set; }
    }
}