using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AppServices
{
    public interface IArticuloService
    {
        ArticuloDTO ObtenerPorID(object id);

        ArticuloDTO Crear(ArticuloDTO dto);
    }
}
