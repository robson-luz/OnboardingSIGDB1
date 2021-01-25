using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Helpers;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class ExclusaoDeEmpresa
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly NotificationContext _notificationContext;

        public ExclusaoDeEmpresa(NotificationContext notificationContext, IEmpresaRepository empresaRepository)
        {
            _notificationContext = notificationContext;
            _empresaRepository = empresaRepository;
        }

        public void Excluir(int id)
        {
            var empresa = _empresaRepository.ObterPorId(id);

            if(empresa != null)
                _empresaRepository.Remover(empresa);
        }
    }
}
