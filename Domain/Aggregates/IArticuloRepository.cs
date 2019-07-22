using Domain.Entities.MiTienda;
using Domain.Seedwork;

namespace Domain.Aggregates
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
        //otras weas modificar algo complejo u otra wea

        Articulo ObtenerArticuloPorSujetoContable(int id);
    }
}