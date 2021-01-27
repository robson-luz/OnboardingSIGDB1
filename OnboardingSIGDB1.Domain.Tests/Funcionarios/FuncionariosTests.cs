using Bogus;
using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Common.Tests.CargosBuilder;
using OnboardingSIGDB1.Common.Tests.EmpresasBuilder;
using OnboardingSIGDB1.Common.Tests.FuncionariosBuilder;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnboardingSIGDB1.Domain.Tests.Funcionarios
{
    public class FuncionariosTests
    {
        private readonly Faker _faker;
        private readonly int _id;
        private readonly string _nome;
        private readonly string _cpf;
        private readonly DateTime _dataContratacao;

        private readonly List<FuncionarioCargo> _funcionariosCargos;

        public FuncionariosTests()
        {
            _faker = FakerBuilder.Novo().Build();
            _id = _faker.Random.Int(1, 500000);
            _nome = _faker.Company.CompanyName();
            _cpf = "49186180061";
            _dataContratacao = _faker.Date.Recent();
        }

        [Fact]
        public void DeveCriarFuncionario()
        {
            var funcionario = FuncionarioBuilder
                .Novo()
                .ComNome(_nome)
                .ComCpf(_cpf)
                .ComDataContratacao(_dataContratacao)                
                .Build();

            Assert.Equal(_nome, funcionario.Nome);
            Assert.Equal(_cpf, funcionario.Cpf);
            Assert.Equal(_dataContratacao, funcionario.DataContratacao);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveValidarNomeObrigatorio(string nomeInvalido)
        {
            var funcionario = FuncionarioBuilder
                .Novo()
                .ComNome(nomeInvalido)
                .Build();

            var resultado = funcionario.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveValidarNomeCaracteres()
        {
            var funcionario = FuncionarioBuilder
                .Novo()
                .ComNome(_faker.Lorem.Random.String2(151))
                .Build();

            var resultado = funcionario.Validar();

            Assert.False(resultado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveValidarCpfObrigatorio(string cpfInvalido)
        {
            var funcionario = FuncionarioBuilder
                .Novo()
                .ComCpf(cpfInvalido)
                .Build();

            var resultado = funcionario.Validar();

            Assert.False(resultado);
        }
        
        [Fact]
        public void DeveValidarCnpjCaracteres()
        {
            var cpf = _faker.Lorem.Sentence(12);

            var funcionario = FuncionarioBuilder
                .Novo()
                .ComCpf(cpf)
                .Build();

            var resultado = funcionario.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveValidarDataFundacaoMaiorQueValorMinimo()
        {
            var dataContratacao = DateTime.MinValue;

            var funcionario = FuncionarioBuilder
                .Novo()
                .ComDataContratacao(dataContratacao)
                .Build();

            var resultado = funcionario.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var nome = _faker.Company.CompanyName();

            var funcionario = FuncionarioBuilder
                .Novo()
                .Build();

            funcionario.AlterarNome(nome);

            Assert.Equal(nome, funcionario.Nome);
        }

        [Fact]
        public void DeveAlterarCpf()
        {
            var cpf = _faker.Random.String();

            var funcionario = FuncionarioBuilder
                .Novo()
                .Build();

            funcionario.AlterarCpf(cpf);

            Assert.Equal(cpf, funcionario.Cpf);
        }

        [Fact]
        public void DeveAlterarDataContratacao()
        {
            var dataContratacao = _faker.Date.Recent();

            var funcionario = FuncionarioBuilder
                .Novo()
                .Build();

            funcionario.AlterarDataContratacao(dataContratacao);

            Assert.Equal(dataContratacao, funcionario.DataContratacao);
        }

        [Fact]
        public void DeveAlterarIdEmpresa()
        {
            int idEmpresa = 5;

            var funcionario = FuncionarioBuilder
                .Novo()
                .Build();

            funcionario.AlterarIdEmpresa(idEmpresa);

            Assert.Equal(idEmpresa, funcionario.IdEmpresa);
        }

        [Fact]
        public void DeveAlterarEmpresa()
        {
            var empresa = EmpresaBuilder
                .Novo()
                .Build();

            var funcionario = FuncionarioBuilder
                .Novo()
                .Build();

            funcionario.AlterarEmpresa(empresa);

            Assert.Equal(empresa, funcionario.Empresa);
        }

        [Fact]
        public void DeveAdicionarCargo()
        {
            var funcionario = FuncionarioBuilder.Novo().Build();

            var funcionarioCargo = new FuncionarioCargo()
            {
                IdCargo = 1,
                IdFuncionario = funcionario.Id,
                DataVinculo = DateTime.Now
            };

            funcionario.AdicionarCargo(funcionarioCargo);

            Assert.Contains(funcionarioCargo, funcionario.CargosVinculados);
        }
    }
}
