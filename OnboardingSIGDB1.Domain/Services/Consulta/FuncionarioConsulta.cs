using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Consulta
{
    public class FuncionarioConsulta : IFuncionarioConsulta
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioConsulta(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public List<FuncionarioDto> ConsultaFiltro(FuncionarioFiltroDto filtro)
        {
            var resultado = _funcionarioRepository
                            .ConsultaComFiltro()
                            .OndeNomeContem(filtro.Nome)
                            .ComCpf(filtro.Cpf)
                            .DataContratacaoMaiorQue(filtro.DataContratacaoInicio)
                            .DataContratacaoMenorQue(filtro.DataContratacaoFim)
                            .Select(s =>
                            new FuncionarioDto
                            {
                                Id = s.Id,
                                Nome = s.Nome,
                                Cpf = s.Cpf,
                                DataContratacao = s.DataContratacao
                            })
                            .ToList();

            return resultado;
        }
    }
}
