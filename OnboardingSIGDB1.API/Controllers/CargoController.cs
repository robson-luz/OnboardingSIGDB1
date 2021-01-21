using Microsoft.AspNetCore.Mvc;
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
    public class CargoController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ICargoRepository _cargoRepository;
        private readonly ArmazenadorDeCargo _armazenador;

        public CargoController(ICargoRepository cargoRepository, ArmazenadorDeCargo armazenador, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _armazenador = armazenador;
            _mapper = mapper;
        }

        [HttpGet("Cargos")]
        public ActionResult<List<CargoDto>> Get()
        {
            var cargos = _cargoRepository
                .Consultar();

            List<CargoDto> cargosDto = new List<CargoDto>();

            foreach (var cargo in cargos)
            {
                cargosDto.Add(_mapper.Map<CargoDto>(cargo));
            }

            return cargosDto;
        }


        [HttpGet("Cargos/{id}")]
        public ActionResult<CargoDto> Get(int id)
        {
            var cargo = _cargoRepository.ObterPorId(id);

            var dto = _mapper.Map<CargoDto>(cargo);

            return dto;
        }

        [HttpPost("Cargos/Salvar")]
        public ActionResult Salvar(CargoDto dto)
        {
            _armazenador.Armazenar(dto);

            return Ok();
        }

        [HttpDelete("Cargos/Remover/{id}")]
        public ActionResult Remover(int id)
        {
            _armazenador.Remover(id);

            return Ok();
        }
    }
}
