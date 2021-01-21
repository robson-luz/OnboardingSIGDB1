using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace OnboardingSIGDB1.Domain.Entities.Cargos
{
    public class Cargo : Entidade<Cargo>
    {
        public string Descricao { get; private set; }

        public virtual ICollection<FuncionarioCargo> FuncionariosCargos { get; private set; }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validar()
        {
            RuleFor(c => c.Descricao)
                .NotNull().NotEmpty()
                .WithMessage("Campo 'Descriçao' é obrigatório.");

            RuleFor(c => c.Descricao)
                .MaximumLength(150)
                .WithMessage("Campo 'Descrição' deve ter menos que 250 caracteres.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
