using Bogus;
using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Common.Tests.CargosBuilder;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnboardingSIGDB1.Domain.Tests.Cargos
{
    public class CargoTests
    {
        private readonly Faker _faker;
        private readonly int _id;
        private readonly string _descricao;

        public CargoTests()
        {
            _faker = FakerBuilder.Novo().Build();
            _id = _faker.Random.Int(1, 500000);
            _descricao = _faker.Lorem.Sentence(2);
        }

        [Fact]
        public void DeveCriarCargo()
        {
            var cargo = CargoBuilder
                .Novo()
                .ComDescricao(_descricao)
                .Build();

            Assert.Equal(_descricao, cargo.Descricao);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveValidarDescricaoObrigatoria(string descricaoInvalida)
        {
            var cargo = CargoBuilder
                .Novo()
                .ComDescricao(descricaoInvalida)
                .Build();

            var resultado = cargo.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveValidarDescricaoCaracteres()
        {
            var cargo = CargoBuilder
                .Novo()
                .ComDescricao(_faker.Lorem.Random.String2(251))
                .Build();

            var resultado = cargo.Validar();

            Assert.False(resultado);
        }

        [Fact]
        public void DeveAdicionarFuncionario()
        {
            var cargo = CargoBuilder.Novo().Build();

            var funcionarioCargo = new FuncionarioCargo()
            {
                IdCargo = cargo.Id,
                IdFuncionario = 1,
                DataVinculo = DateTime.Now
            };

            cargo.AdicionarFuncionario(funcionarioCargo);

            Assert.Contains(funcionarioCargo, cargo.FuncionariosCargos);
        }
    }
}
