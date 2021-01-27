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
    [Route("[controller]/[action]")]
    public class FuncionarioController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioConsulta _consulta;
        private readonly IArmazenadorDeFuncionario _armazenador;

        private readonly IVinculacaoDeFuncionarioAEmpresa _vinculacaoDeFuncionarioAEmpresa;
        private readonly IVinculacaoDeFuncionarioACargo _vinculacaoDeFuncionarioACargo;
        private readonly IExclusaoDeFuncionario _exclusao;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IFuncionarioConsulta consulta, IArmazenadorDeFuncionario armazenador, IExclusaoDeFuncionario exclusao,
            IVinculacaoDeFuncionarioAEmpresa vinculacaoDeFuncionarioAEmpresa, IVinculacaoDeFuncionarioACargo vinculacaoDeFuncionarioACargo, IMapper mapper)
        {
            _consulta = consulta;
            _exclusao = exclusao;
            _funcionarioRepository = funcionarioRepository;
            _armazenador = armazenador;
            _vinculacaoDeFuncionarioACargo = vinculacaoDeFuncionarioACargo;
            _vinculacaoDeFuncionarioAEmpresa = vinculacaoDeFuncionarioAEmpresa;
            _mapper = mapper;
        }


        [HttpGet("ConsultaFiltro")]
        public List<FuncionarioDto> ConsultarFiltro(FuncionarioFiltroDto dto)
        {
            var funcionarios = _consulta
                .ConsultaFiltro(dto);

            //List<FuncionarioDto> funcionariosDto = new List<FuncionarioDto>();

            //foreach (var funcionario in funcionarios)
            //{
            //    funcionariosDto.Add(_mapper.Map<FuncionarioDto>(funcionario));
            //}

            return funcionarios;
        }

        //[HttpGet("Funcionarios")]
        //public ActionResult<List<FuncionarioDto>> Get()
        //{
        //    var funcionarios = _funcionarioRepository
        //        .Consultar();

        //    List<FuncionarioDto> funcionariosDto = new List<FuncionarioDto>();

        //    foreach (var funcionario in funcionarios)
        //    {
        //        funcionariosDto.Add(_mapper.Map<FuncionarioDto>(funcionario));
        //    }

        //    return funcionariosDto;
        //}


        [HttpGet]
        public ActionResult<FuncionarioDto> Get(int id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            var dto = _mapper.Map<FuncionarioDto>(funcionario);

            return dto;
        }

        [HttpPost]
        public ActionResult Salvar(FuncionarioDto dto)
        {
            _armazenador.Armazenar(dto);

            return Ok();
        }

        [HttpDelete]
        public ActionResult Remover(int id)
        {
            _exclusao.Excluir(id);

            return Ok();
        }

        [HttpPost]
        public ActionResult VincularEmpresa(FuncionarioDto dto)
        {
            _vinculacaoDeFuncionarioAEmpresa.VincularEmpresa(dto);

            return Ok();
        }

        [HttpPost]
        public ActionResult VincularCargo(FuncionarioDto dto)
        {
            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);

            return Ok();
        }
    }
}
