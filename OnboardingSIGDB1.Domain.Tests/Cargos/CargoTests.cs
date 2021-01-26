using Bogus;
using OnboardingSIGDB1.Common.Tests._Base;
using OnboardingSIGDB1.Common.Tests.CargosBuilders;
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
        private readonly List<FuncionarioCargo> _funcionariosCargos;


        public CargoTests()
        {
            _faker = FakerBuilder.Novo().Build();
            _id = _faker.Random.Int(1, 5000000);
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
    }
}
