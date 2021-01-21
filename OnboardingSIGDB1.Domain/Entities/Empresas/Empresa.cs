using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using FluentValidation;

namespace OnboardingSIGDB1.Domain.Entities.Empresas
{
    public class Empresa : Entidade
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

        //public override bool Validate()
        //{
        //    RuleFor(e => e.Nome)
        //        .MaximumLength(150);

        //    RuleFor(e => e.Cnpj)
        //        .MaximumLength(14);

        //    RuleFor(e => e.DataFundacao)
        //        .GreaterThan(DateTime.MinValue);

        //    return true;
        //}

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

        public bool CnpjValido()
        {
            return false;
        }
    }
}
