using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Helpers;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services
{
    public class VinculacaoDeFuncionarioACargo : IVinculacaoDeFuncionarioACargo
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;

        private readonly NotificationContext _notificationContext;

        public VinculacaoDeFuncionarioACargo(NotificationContext notificationContext, IFuncionarioRepository funcionarioRepository, ICargoRepository cargoRepository)
        {
            _notificationContext = notificationContext;
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
        }

        public void VincularCargo(FuncionarioDto dto)
        {
            var funcionario = _funcionarioRepository.ObterPorId(dto.Id);

            var cargo = _cargoRepository.ObterPorId(dto.IdCargo);
            
            if(cargo == null)
            {
                _notificationContext.AddNotification("500", "Cargo a ser vinculado não está cadastrado.");
                return;
            }
            if (funcionario.Empresa == null)
            {
                _notificationContext.AddNotification("500", "Não é possível vincular um cargo a um funcionário sem empresa.");
                return;
            }
            if (funcionario.CargosVinculados.Any(c => c.IdCargo == dto.IdCargo))
            {
                _notificationContext.AddNotification("500", "Funcionário já possui o cargo a ser vinculado.");
                return;
            }

            FuncionarioCargo cargoVinculado = new FuncionarioCargo()
            {
                IdFuncionario = funcionario.Id,
                IdCargo = cargo.Id,
                DataVinculo = DateTime.Now
            };

            funcionario.AdicionarCargo(cargoVinculado);

            _funcionarioRepository.Atualizar(funcionario);
        }

    }
}
