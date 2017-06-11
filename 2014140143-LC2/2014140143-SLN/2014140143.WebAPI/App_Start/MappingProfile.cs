

using _2014140143_ENT.Entities;
using _2014140143_ENT.EntitiesDTO;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineaTelefonica.WebAPI.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<AdministradorEquipo, AdministradorEquipoDTO>();
            CreateMap<AdministradorEquipoDTO, AdministradorEquipo>();

            CreateMap<AdministradorLinea, AdministradorLineaDTO>();
            CreateMap<AdministradorLineaDTO, AdministradorLinea>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();

            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<EquipoCelular, EquipoCelularDTO>();
            CreateMap<EquipoCelularDTO, EquipoCelular>();

            CreateMap<Evaluacion, EvaluacionDTO>();
            CreateMap<EvaluacionDTO, Evaluacion>();

            //CreateMap<LineaTelefonicas, LineaTelefonicaDTO>();
            //CreateMap<LineaTelefonicaDTO, LineaTelefonica>();

            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();

            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<Ubigeo, UbigeoDTO>();
            CreateMap<UbigeoDTO, Ubigeo>();

            CreateMap<CentroAtencion, CentroAtencionDTO>();
            CreateMap<CentroAtencionDTO, CentroAtencion>();


            /*    CreateMap<Genre, GenreDTO>();
                CreateMap<GenreDTO, Genre>();

                CreateMap<Movie, MovieDTO>();
                CreateMap<MovieDTO, Movie>();*/
        }
    }
}