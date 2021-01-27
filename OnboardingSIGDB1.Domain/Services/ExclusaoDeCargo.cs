using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class ExclusaoDeCargo : IExclusaoDeCargo
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly NotificationContext _notificationContext;

        public ExclusaoDeCargo(NotificationContext notificationContext, ICargoRepository cargoRepository)
        {
            _notificationContext = notificationContext;
            _cargoRepository = cargoRepository;
        }

        public void Excluir(int id)
        {
            var Cargo = _cargoRepository.ObterPorId(id);

            if(Cargo != null)
                _cargoRepository.Remover(Cargo);
        }
    }
}
