using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.IOC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(dto => dto.Id, o => o.MapFrom(s => s.Id))
                .ForMember(dto => dto.Nome, o => o.MapFrom(s => s.Nome))
                .ForMember(dto => dto.Cnpj, o => o.MapFrom(s => s.Cnpj))
                .ForMember(dto => dto.DataFundacao, o => o.MapFrom(s => s.DataFundacao));

            CreateMap<Cargo, CargoDto>()
                .ForMember(dto => dto.Id, o => o.MapFrom(s => s.Id))
                .ForMember(dto => dto.Descricao, o => o.MapFrom(s => s.Descricao));

            CreateMap<Funcionario, FuncionarioDto>()
                .ForMember(dto => dto.Id, o => o.MapFrom(s => s.Id))
                .ForMember(dto => dto.Cpf, o => o.MapFrom(s => s.Cpf))
                .ForMember(dto => dto.DataContratacao, o => o.MapFrom(s => s.DataContratacao))
                .ForMember(dto => dto.IdEmpresa, o => o.MapFrom(s => s.IdEmpresa))
                .ForMember(dto => dto.NomeEmpresa, o => o.MapFrom(s => s.Empresa.Nome));
        }
    }
}
