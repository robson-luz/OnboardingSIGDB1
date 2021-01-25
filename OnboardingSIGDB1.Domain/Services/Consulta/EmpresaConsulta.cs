using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Consulta
{
    public class EmpresaConsulta : IEmpresaConsulta
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaConsulta(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<EmpresaDto> ConsultaFiltro(EmpresaFiltroDto filtro)
        {
            var resultado = _empresaRepository
                        .ConsultaComFiltro()
                        .OndeNomeContem(filtro.Nome)
                        .ComCnpj(filtro.Cnpj)
                        .DataFundacaoMaiorQue(filtro.DataFundacaoInicio)
                        .DataFundacaoMenorQue(filtro.DataFundacaoFim)
                        .Select(s =>
                        new EmpresaDto
                        {
                            Id = s.Id,
                            Nome = s.Nome,
                            Cnpj = s.Cnpj,
                            DataFundacao = s.DataFundacao
                        })
                        .ToList();

            return resultado;
        }
    }
}
