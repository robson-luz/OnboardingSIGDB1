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
        private readonly ArmazenadorDeEmpresa _armazenador;

        public EmpresaController(IEmpresaRepository empresaRepository, ArmazenadorDeEmpresa armazenador, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _armazenador = armazenador;
            _mapper = mapper;
        }


        [HttpGet("Empresas/Consultar")]
        public List<EmpresaDto> Consultar()
        {
            var empresas = _empresaRepository
                .Consultar();

            List<EmpresaDto> empresasDto = new List<EmpresaDto>();

            foreach (var empresa in empresas)
            {
                empresasDto.Add(_mapper.Map<EmpresaDto>(empresa));
            }

            return empresasDto;
        }


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

        // DELETE api/values/5
        [HttpDelete("Empresas/Remover/{id}")]
        public ActionResult Remover(int id)
        {
            _armazenador.Remover(id);

            return Ok();
        }
    }
}
