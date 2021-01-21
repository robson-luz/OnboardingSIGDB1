using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;

namespace OnboardingSIGDB1.API.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ArmazenadorDeFuncionario _armazenador;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, ArmazenadorDeFuncionario armazenador, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _armazenador = armazenador;
            _mapper = mapper;
        }


        [HttpGet("Funcionarios/Consultar")]
        public List<FuncionarioDto> ConsultarFiltro(FuncionarioFiltroDto dto)
        {
            var funcionarios = _funcionarioRepository
                .ConsultarComFiltro(dto);

            List<FuncionarioDto> funcionariosDto = new List<FuncionarioDto>();

            foreach (var funcionario in funcionarios)
            {
                funcionariosDto.Add(_mapper.Map<FuncionarioDto>(funcionario));
            }

            return funcionariosDto;
        }

        [HttpGet("Funcionarios")]
        public ActionResult<List<FuncionarioDto>> Get()
        {
            var funcionarios = _funcionarioRepository
                .Consultar();

            List<FuncionarioDto> funcionariosDto = new List<FuncionarioDto>();

            foreach (var funcionario in funcionarios)
            {
                funcionariosDto.Add(_mapper.Map<FuncionarioDto>(funcionario));
            }

            return funcionariosDto;
        }


        [HttpGet("Funcionarios/{id}")]
        public ActionResult<FuncionarioDto> Get(int id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            var dto = _mapper.Map<FuncionarioDto>(funcionario);

            return dto;
        }

        [HttpPost("Funcionarios/Salvar")]
        public ActionResult Salvar(FuncionarioDto dto)
        {
            _armazenador.Armazenar(dto);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("Funcionarios/Remover/{id}")]
        public ActionResult Remover(int id)
        {
            _armazenador.Remover(id);

            return Ok();
        }
    }
}
