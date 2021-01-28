using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Helpers;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class VinculacaoDeFuncionarioAEmpresa : IVinculacaoDeFuncionarioAEmpresa
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEmpresaRepository _empresaRepository;

        private readonly NotificationContext _notificationContext;

        public VinculacaoDeFuncionarioAEmpresa(NotificationContext notificationContext, IFuncionarioRepository funcionarioRepository, IEmpresaRepository empresaRepository)
        {
            _notificationContext = notificationContext;
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        public void VincularEmpresa(FuncionarioDto dto)
        {
            var funcionario = _funcionarioRepository.ObterPorId(dto.Id);

            var empresa = _empresaRepository.ObterPorId(dto.IdEmpresa);

            if (empresa == null)
            {
                _notificationContext.AddNotification("500", FuncionarioResource.EmpresaNaoCadastrada);
                return;
            }

            if (funcionario.IdEmpresa != null)
            {
                _notificationContext.AddNotification("500", FuncionarioResource.NPossivelAlterarVinculoJaPossuiEmpresa);
                return;
            }

            funcionario.AlterarIdEmpresa(dto.IdEmpresa);

            _funcionarioRepository.Atualizar(funcionario);
        }

    }
}
