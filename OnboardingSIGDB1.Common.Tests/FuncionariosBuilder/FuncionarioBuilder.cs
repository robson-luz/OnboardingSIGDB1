using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Common.Tests.FuncionariosBuilder
{
    public class FuncionarioBuilder : BuilderBase
    {
        protected int Id;
        protected string Nome;
        protected string Cpf;
        protected DateTime? DataContratacao;
        public List<FuncionarioCargo> Cargos;

        public static FuncionarioBuilder Novo()
        {
            var faker = FakerBuilder.Novo().Build();
            var builder = new FuncionarioBuilder
            {
                Nome = faker.Company.CompanyName(),
                Cpf = "95301242000121",
                DataContratacao = faker.Date.Past(50, DateTime.Now)
            };

            return builder;
        }

        public FuncionarioBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public FuncionarioBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public FuncionarioBuilder ComCpf(string cpf)
        {            
            Cpf = cpf;
            return this;
        }

        public FuncionarioBuilder ComDataContratacao(DateTime dataContratacao)
        {
            DataContratacao = dataContratacao;
            return this;
        }

        public FuncionarioBuilder ComFuncionariosCargos(List<FuncionarioCargo> cargos)
        {
            Cargos = cargos;
            return this;
        }

        public Funcionario Build()
        {
            var funcionario = new Funcionario(Nome, Cpf, DataContratacao);

            AtribuirId(Id, funcionario);

            return funcionario;
        }
    }
}
