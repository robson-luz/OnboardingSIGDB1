using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Common.Tests.EmpresasBuilder
{
    public class EmpresaBuilder : BuilderBase
    {
        protected int Id;
        protected string Nome;
        protected string Cnpj;
        protected DateTime? DataFundacao;
        public List<Funcionario> Funcionarios;

        public static EmpresaBuilder Novo()
        {
            var faker = FakerBuilder.Novo().Build();
            var builder = new EmpresaBuilder
            {
                Nome = faker.Company.CompanyName(),
                Cnpj = "95301242000121",
                DataFundacao = faker.Date.Past(50, DateTime.Now)
            };

            return builder;
        }

        public EmpresaBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public EmpresaBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public EmpresaBuilder ComCnpj(string cnpj)
        {            
            Cnpj = cnpj;
            return this;
        }

        public EmpresaBuilder ComDataFundacao(DateTime? dataFundacao)
        {
            DataFundacao = dataFundacao;
            return this;
        }

        public EmpresaBuilder ComFuncionariosCargos(List<Funcionario> funcionarios)
        {
            Funcionarios = funcionarios;
            return this;
        }

        public Empresa Build()
        {
            var empresa = new Empresa(Nome, Cnpj, DataFundacao);

            AtribuirId(Id, empresa);

            return empresa;
        }
    }
}
