using Domain.Aggregates;
using Domain.Entities.MiTienda;
using Infrastructure.Data.Context.MiTienda;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly MiTiendaDbContext unitOfWork;

        public ArticuloRepository(MiTiendaDbContext unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Articulo ObtenerArticuloPorSujetoContable(int id)
        {
            throw new NotImplementedException();
        }
    }

    //public class ReglaFormatoRepository : Repository<REGLA_FORMATO>, IReglaFormatoRepository
    //{
    //    private readonly SocofinContext _unitOfWork;
    //    public ReglaFormatoRepository(SocofinContext unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //}
}
