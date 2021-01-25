using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Helpers;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class ExclusaoDeFuncionario 
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly NotificationContext _notificationContext;

        public ExclusaoDeFuncionario(NotificationContext notificationContext, IFuncionarioRepository funcionarioRepository)
        {
            _notificationContext = notificationContext;
            _funcionarioRepository = funcionarioRepository;
        }       

        public void Excluir(int id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            if(funcionario != null)
                _funcionarioRepository.Remover(funcionario);
        }
    }
}
