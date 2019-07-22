using Application.DTO;
using AutoMapper;
using Domain.Entities.MiTienda;

namespace Application.Profiles
{
    public class ArticuloProfile : Profile
    {
        public ArticuloProfile()
        {
            CreateMap<Articulo, ArticuloDTO>();
            //.ForMember(x=>x.DetalleDeCompraDTO,o=>o.Ignore());
            //.ForMember(x=>x.Identificador,o=>o.MapFrom(s=>s.Id));
            CreateMap<ArticuloDTO, Articulo>();
        }


        //public override string ProfileName => "ArticuloProfile";

        //protected void Configure()
        //{

        //    //var map = CreateMap<Articulo, ArticuloDTO>();
        //    //map.ForMember(x => x.DetalleDeCompraDTO, o => o.Ignore());
        //    //map.ReverseMap();
        //    ////MapADemandaExterna.ForMember(model => model.ID, model => model.MapFrom(e => e.ID));
        //    ////MapADemandaExterna.ForMember(model => model.ID_SUCURSAL, model => model.MapFrom(e => e.ID_SUCURSAL));
        //}
    }
}