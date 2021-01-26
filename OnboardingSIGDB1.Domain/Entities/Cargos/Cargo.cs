using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using OnboardingSIGDB1.Domain.Resources;

namespace OnboardingSIGDB1.Domain.Entities.Cargos
{
    public class Cargo : Entidade<Cargo>
    {
        public string Descricao { get; private set; }

        public virtual List<FuncionarioCargo> FuncionariosCargos { get; private set; } = new List<FuncionarioCargo>();

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validar()
        {
            RuleFor(c => c.Descricao)
                .NotNull().NotEmpty()
                .WithMessage(CargoResources.CampoDescricaoEhObrigatorio);

            RuleFor(c => c.Descricao)
                .MaximumLength(150)
                .WithMessage(CargoResources.CampoDescricaoDeveTerMenosQue250Caracteres);

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void AdicionarFuncionarioCargo(FuncionarioCargo funcionarioCargo)
        {
            if (funcionarioCargo == null)
                return;
            FuncionariosCargos.Add(funcionarioCargo);
        }
    }
}
