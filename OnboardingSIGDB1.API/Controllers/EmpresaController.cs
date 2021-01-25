using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnboardingSIGDB1.Domain.Entities.Empresas;

namespace OnboardingSIGDB1.API.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaConsulta _consulta;
        private readonly IArmazenadorDeEmpresa _armazenador;
        private readonly ExclusaoDeEmpresa _exclusao;

        public EmpresaController(IEmpresaRepository empresaRepository, IEmpresaConsulta consulta, IArmazenadorDeEmpresa armazenador, ExclusaoDeEmpresa exclusao, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _consulta = consulta;
            _armazenador = armazenador;
            _exclusao = exclusao;
            _mapper = mapper;
        }


        // GET api/empresas/consultar    
        /// <summary>    
        /// Método para consultar usando filtro    
        /// </summary>    
        /// <returns></returns>   
        [HttpGet("Empresas/Consultar")]
        public List<EmpresaDto> ConsultarFiltro(EmpresaFiltroDto dto)
        {
            var empresas = _consulta.ConsultaFiltro(dto);

            //List<EmpresaDto> empresasDto = new List<EmpresaDto>();

            //foreach (var empresa in empresas)
            //{
            //    empresasDto.Add(_mapper.Map<EmpresaDto>(empresa));
            //}

            return empresas;
        }

        //[HttpGet("Empresas")]
        //public ActionResult<List<EmpresaDto>> Get()
        //{
        //    var empresas = _empresaRepository
        //        .Consultar();

        //    List<EmpresaDto> empresasDto = new List<EmpresaDto>();

        //    foreach (var empresa in empresas)
        //    {
        //        empresasDto.Add(_mapper.Map<EmpresaDto>(empresa));
        //    }

        //    return empresasDto;
        //}


        [HttpGet("Empresas/{id}")]
        public ActionResult<EmpresaDto> Get(int id)
        {
            var empresa = _empresaRepository.ObterPorId(id);

            var dto = _mapper.Map<EmpresaDto>(empresa);

            return dto;
        }

        [HttpPost("Empresas/Salvar")]
        public ActionResult Salvar(EmpresaDto dto)
        {
            _armazenador.Armazenar(dto);

            return Ok();
        }

        [HttpDelete("Empresas/Remover/{id}")]
        public ActionResult Remover(int id)
        {
            _exclusao.Excluir(id);

            return Ok();
        }
    }
}
