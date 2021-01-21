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
    public class ArmazenadorDeFuncionario
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly NotificationContext _notificationContext;

        public ArmazenadorDeFuncionario(NotificationContext notificationContext, IFuncionarioRepository funcionarioRepository)
        {
            _notificationContext = notificationContext;
            _funcionarioRepository = funcionarioRepository;
        }

        public void Armazenar(FuncionarioDto dto)
        {
            if(!ValidadorCpfCnpj.CpfValido(dto.Cpf))
            {
                _notificationContext.AddNotification("500","Cpf inválido.");
                return;
            }                

            if (dto.Id == 0)
            {
                var funcionario = new Funcionario(dto.Nome, dto.Cpf, dto.DataContratacao.Value, dto.IdEmpresa);

                if(!funcionario.Validar())
                {
                    _notificationContext.AddNotifications(funcionario.ValidationResult);

                    return;
                }

                _funcionarioRepository.Adicionar(funcionario);
            }
            else
            {
                var funcionarioExistente = _funcionarioRepository.ObterPorCpf(dto.Cpf);

                if(funcionarioExistente != null && funcionarioExistente.Id != dto.Id)
                {
                    _notificationContext.AddNotification("500","Um funcionário com este Cpf já foi cadastrado.");

                    return;
                }                    

                var funcionario = _funcionarioRepository.ObterPorId(dto.Id);

                if (!funcionario.Validar())
                {
                    _notificationContext.AddNotifications(funcionario.ValidationResult);
                }

                funcionario.AlterarNome(dto.Nome);
                funcionario.AlterarCpf(dto.Cpf);
                funcionario.AlterarDataContratacao(dto.DataContratacao.Value);

                _funcionarioRepository.Atualizar(funcionario);
            }
        }

        public void Remover(int id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            if(funcionario != null)
                _funcionarioRepository.Remover(funcionario);
        }
    }
}
