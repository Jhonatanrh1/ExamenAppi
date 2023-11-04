using AutoMapper;
using examen.DTOs;
using examen.Models;
using System.Globalization;
namespace examen.Uitilidades
{
    public class AutoMaper:Profile
    {
        public AutoMaper()
        {
            //departamento
            CreateMap<Departamento,DepartamentoDTO>().ReverseMap();
            //fin
            //Provincia
            CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
            //fin
            //Distrito
            CreateMap<Distrito, DistritoDTO>().ReverseMap();
            //fin
            

            //trabjador
            CreateMap<Trabajador, TrabajadorDTO>().ForMember(destino =>destino.NombreDepartamento,opt=>opt.MapFrom(origen=>origen.IdDepartamentoNavigation.NombreDepartamento))
                .ForMember(destino => destino.NombreProvincia, opt => opt.MapFrom(origen => origen.IdProvinciaNavigation.NombreProvincia))
                .ForMember(destino => destino.NombreDistrito, opt => opt.MapFrom(origen => origen.IdDistritoNavigation.NombreDistrito));
            
            CreateMap<TrabajadorDTO, Trabajador>().ForMember(destino => destino.IdDepartamentoNavigation, opt => opt.Ignore())
                .ForMember(destino => destino.IdProvinciaNavigation, opt => opt.Ignore())
                .ForMember(destino => destino.IdDistritoNavigation, opt => opt.Ignore());
            //fin
        }
    }
}
