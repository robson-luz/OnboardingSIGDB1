﻿using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnboardingSIGDB1.Domain.Entities.Cargos;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("[controller]/[action]")]
    public class CargoController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ICargoRepository _cargoRepository;
        private readonly IArmazenadorDeCargo _armazenador;
        private readonly IExclusaoDeCargo _exclusao;

        public CargoController(ICargoRepository cargoRepository, IArmazenadorDeCargo armazenador, IExclusaoDeCargo exclusao, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _armazenador = armazenador;
            _exclusao = exclusao;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<List<CargoDto>> Get()
        //{
        //    var cargos = _cargoRepository
        //        .Consultar();

        //    List<CargoDto> cargosDto = new List<CargoDto>();

        //    foreach (var cargo in cargos)
        //    {
        //        cargosDto.Add(_mapper.Map<CargoDto>(cargo));
        //    }

        //    return cargosDto;
        //}

        [HttpGet]
        public ActionResult<CargoDto> Get(int id)
        {
            var cargo = _cargoRepository.ObterPorId(id);

            var dto = _mapper.Map<CargoDto>(cargo);

            return dto;
        }

        [HttpPost]
        public ActionResult Salvar(CargoDto dto)
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
    }
}
