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
    public class ArmazenadorDeEmpresa : IArmazenadorDeEmpresa
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly NotificationContext _notificationContext;

        public ArmazenadorDeEmpresa(NotificationContext notificationContext, IEmpresaRepository empresaRepository)
        {
            _notificationContext = notificationContext;
            _empresaRepository = empresaRepository;
        }

        public void Armazenar(EmpresaDto dto)
        {
            if (!ValidadorCpfCnpj.CnpjValido(dto.Cnpj))
            {
                _notificationContext.AddNotification("500", "Cnpj inválido.");
                return;
            }


            if (dto.Id == 0)
            {
                var empresa = new Empresa(dto.Nome, dto.Cnpj, dto.DataFundacao.Value);

                if(!empresa.Validar())
                {
                    _notificationContext.AddNotifications(empresa.ValidationResult);

                    return;
                }

                _empresaRepository.Adicionar(empresa);
            }
            else
            {
                var empresaExistente = _empresaRepository.ObterPorCnpj(dto.Cnpj);

                if(empresaExistente != null && empresaExistente.Id != dto.Id)
                {
                    _notificationContext.AddNotification("500","Uma empresa com esse Cnpj já foi cadastrada.");

                    return;
                }                    

                var empresa = _empresaRepository.ObterPorId(dto.Id);

                if (!empresa.Validar())
                {
                    _notificationContext.AddNotifications(empresa.ValidationResult);
                }

                empresa.AlterarNome(dto.Nome);
                empresa.AlterarCnpj(dto.Cnpj);
                empresa.AlterarDataFundacao(dto.DataFundacao.Value);

                _empresaRepository.Atualizar(empresa);
            }
        }
    }
}
