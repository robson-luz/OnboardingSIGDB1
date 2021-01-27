using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using FluentValidation;
using OnboardingSIGDB1.Domain.Resources;

namespace OnboardingSIGDB1.Domain.Entities.Empresas
{
    public class Empresa : Entidade<Empresa>
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime? DataFundacao { get; private set; }

        public virtual ICollection<Funcionario> Funcionarios { get; private set; } = new List<Funcionario>();

        private Empresa()
        {

        }

        public Empresa(string nome, string cnpj, DateTime? dataFundacao)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = dataFundacao;
        }

        public override bool Validar()
        {
            RuleFor(e => e.Nome)
                .NotNull().NotEmpty()
                .WithMessage(EmpresaResource.CampoNomeObrigatorio);

            RuleFor(e => e.Nome)
                .MaximumLength(150)
                .WithMessage(EmpresaResource.CampoNomeDeveTerMenosQue150);

            RuleFor(e => e.Cnpj)
                .NotNull().NotEmpty()
                .WithMessage(EmpresaResource.CampoCnpjObrigatorio);

            RuleFor(e => e.Cnpj)
                .MaximumLength(14)
                .WithMessage(EmpresaResource.CampoCnpjForaDoTamanhoPadrao);

            RuleFor(e => e.DataFundacao)
                .GreaterThan(DateTime.MinValue)
                .WithMessage(EmpresaResource.CampoDataFundacaoInvalido);

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarCnpj(string cnpj)
        {
            Cnpj = cnpj;
        }

        public void AlterarDataFundacao(DateTime dataFundacao)
        {
            DataFundacao = dataFundacao;
        }        
    }
}
