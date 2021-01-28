using Bogus;
using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Common.Tests.EmpresasBuilder;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnboardingSIGDB1.Domain.Tests.Empresas
{
    public class EmpresaTests
    {
        private readonly Faker _faker;
        private readonly int _id;
        private readonly string _nome;
        private readonly string _cnpj;
        private readonly DateTime _dataFundacao;
        public EmpresaTests()
        {
            _faker = FakerBuilder.Novo().Build();
            _id = _faker.Random.Int(1, 500000);
            _nome = _faker.Company.CompanyName();
            _cnpj = "95301242000121";
            _dataFundacao = _faker.Date.Recent();
        }

        [Fact]
        public void DeveCriarEmpresa()
        {
            var empresa = EmpresaBuilder
                .Novo()
                .ComNome(_nome)
                .ComCnpj(_cnpj)
                .ComDataFundacao(_dataFundacao)                
                .Build();

            Assert.Equal(_nome, empresa.Nome);
            Assert.Equal(_cnpj, empresa.Cnpj);
            Assert.Equal(_dataFundacao, empresa.DataFundacao);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveValidarNomeObrigatorio(string nomeInvalido)
        {
            var empresa = EmpresaBuilder
                .Novo()
                .ComNome(nomeInvalido)
                .Build();

            var resultado = empresa.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveValidarNomeCaracteres()
        {
            var empresa = EmpresaBuilder
                .Novo()
                .ComNome(_faker.Lorem.Random.String2(151))
                .Build();

            var resultado = empresa.Validar();

            Assert.False(resultado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveValidarCnpjbrigatorio(string cnpjInvalido)
        {
            var empresa = EmpresaBuilder
                .Novo()
                .ComNome(cnpjInvalido)
                .Build();

            var resultado = empresa.Validar();

            Assert.False(resultado);
        }
        
        [Fact]
        public void DeveValidarCnpjCaracteres()
        {
            var cnpj = _faker.Lorem.Sentence(15);

            var empresa = EmpresaBuilder
                .Novo()
                .ComCnpj(cnpj)
                .Build();

            var resultado = empresa.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveValidarDataFundacaoMaiorQueValorMinimo()
        {
            var dataFundacao = DateTime.MinValue;

            var empresa = EmpresaBuilder
                .Novo()
                .ComDataFundacao(dataFundacao)
                .Build();

            var resultado = empresa.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var nome = _faker.Company.CompanyName();

            var empresa = EmpresaBuilder
                .Novo()
                .Build();

            empresa.AlterarNome(nome);

            Assert.Equal(nome, empresa.Nome);
        }

        [Fact]
        public void DeveAlterarCnpj()
        {
            var cnpj = _faker.Random.String();

            var empresa = EmpresaBuilder
                .Novo()
                .Build();

            empresa.AlterarCnpj(cnpj);

            Assert.Equal(cnpj, empresa.Cnpj);
        }

        [Fact]
        public void DeveAlterarDataFundacao()
        {
            var dataFundacao = _faker.Date.Recent();

            var empresa = EmpresaBuilder
                .Novo()
                .Build();

            empresa.AlterarDataFundacao(dataFundacao);

            Assert.Equal(dataFundacao, empresa.DataFundacao);
        }
    }
}
