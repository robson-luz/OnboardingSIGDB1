using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class ArmazenadorDeCargo
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly NotificationContext _notificationContext;

        public ArmazenadorDeCargo(NotificationContext notificationContext, ICargoRepository cargoRepository)
        {
            _notificationContext = notificationContext;
            _cargoRepository = cargoRepository;
        }

        public void Armazenar(CargoDto dto)
        {
            if (dto.Id == 0)
            {
                var Cargo = new Cargo(dto.Descricao);

                if(!Cargo.Validar())
                {
                    _notificationContext.AddNotifications(Cargo.ValidationResult);

                    return;
                }

                _cargoRepository.Adicionar(Cargo);
            }
            else
            {            
                var Cargo = _cargoRepository.ObterPorId(dto.Id);

                if (!Cargo.Validar())
                {
                    _notificationContext.AddNotifications(Cargo.ValidationResult);
                }

                Cargo.AlterarDescricao(dto.Descricao);

                _cargoRepository.Atualizar(Cargo);
            }
        }

        public void Remover(int id)
        {
            var Cargo = _cargoRepository.ObterPorId(id);

            if(Cargo != null)
                _cargoRepository.Remover(Cargo);
        }
    }
}
