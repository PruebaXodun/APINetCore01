using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities.MiTienda;
using Infrastructure.Crosscutting.Adapter;

namespace Application.AppServices
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository articuloRepository;

        private readonly IMapper mapper;

        public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper)
        {
            this.articuloRepository = articuloRepository;
            this.mapper = mapper;
        }

        public ArticuloDTO Crear(ArticuloDTO dto)
        {

            var model = mapper.Map<Articulo>(dto);
            articuloRepository.Add(model);

            articuloRepository.UnitOfWork.Commit();

            dto = mapper.Map<ArticuloDTO>(model);
            return dto;
        }

        public ArticuloDTO ObtenerPorID(object id)
        {
            var result = articuloRepository.Get(id);
            var dto = mapper.Map<ArticuloDTO>(result);
            
            //var adapter = TypeAdapterFactory.CreateAdapter();

            //var dto = adapter.Adapt<Articulo, ArticuloDTO>(result);

            return dto;
        }
    }
}
