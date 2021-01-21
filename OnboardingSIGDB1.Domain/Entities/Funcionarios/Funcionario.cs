using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace OnboardingSIGDB1.Domain.Entities.Funcionarios
{
    public class Funcionario : Entidade<Funcionario>
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataContratacao { get; private set; }

        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; private set; }

        public virtual ICollection<FuncionarioCargo> FuncionariosCargos { get; set; }

        public Funcionario(string nome, string cpf, DateTime? dataContratacao, int idEmpresa)
        {
            Nome = nome;
            Cpf = cpf;
            DataContratacao = dataContratacao;
            IdEmpresa = idEmpresa;
        }

        public override bool Validar()
        {
            RuleFor(f => f.Nome)
                .NotNull().NotEmpty()
                .WithMessage("Campo'Nome' é obrigatório.");

            RuleFor(f => f.Nome)
                .MaximumLength(150)
                .WithMessage("Campo 'Nome' deve ter menos que 150 caracteres.");

            RuleFor(f => f.Cpf)
                .NotNull().NotEmpty()
                .WithMessage("Campo 'Cpf' é obrigatório.");

            RuleFor(f => f.Cpf)
                .MaximumLength(11)
                .WithMessage("Campo 'Cpf' está fora do tamanho padrão.");

            RuleFor(e => e.DataContratacao)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Campo 'Data Contratação' inválido.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarCpf(string cpf)
        {
            Cpf = cpf;
        }

        public void AlterarDataContratacao(DateTime dataContratacao)
        {
            DataContratacao = dataContratacao;
        }

        public void AlterarIdEmpresa(int idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }

    }
}
