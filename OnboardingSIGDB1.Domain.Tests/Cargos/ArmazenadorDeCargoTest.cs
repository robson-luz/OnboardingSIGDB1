using Bogus;
using Moq;
using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Common.Tests.FuncionariosBuilder;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using OnboardingSIGDB1.Common.Tests.CargosBuilder;
using OnboardingSIGDB1.Domain.Resources;
using OnboardingSIGDB1.Domain.Entities.Cargos;

namespace OnboardingSIGDB1.Domain.Tests.Funcionarios
{
    public class ArmazenadorDeCargoTest
    {
        private readonly Faker _faker;

        private readonly Mock<ICargoRepository> _cargoRepositoryMock;
        private readonly Mock<NotificationContext> _notificationContextMock;

        private readonly ArmazenadorDeCargo _armazenadorDeCargo;

        public ArmazenadorDeCargoTest()
        {
            _faker = FakerBuilder.Novo().Build();

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _notificationContextMock = new Mock<NotificationContext>();

            _armazenadorDeCargo = new ArmazenadorDeCargo(
                _notificationContextMock.Object,
                _cargoRepositoryMock.Object);
        }

        [Fact]
        public void DeveCadastrar()
        {
            //Given
            var dto = new CargoDto
            {
                Descricao = _faker.Random.AlphaNumeric(50)
            };

            //When
            _armazenadorDeCargo.Armazenar(dto);

            //Then
            _cargoRepositoryMock.Verify(cr => cr.Adicionar(It.Is<Cargo>(c => c.Descricao == dto.Descricao)), Times.Once);
        }

        [Fact]
        public void DeveAtualizar()
        {
            //Given
            var dto = new CargoDto
            {
                Id = _faker.Random.Int(100),
                Descricao = _faker.Random.AlphaNumeric(50)
            };

            var cargoMock = CargoBuilder.Novo().ComId(dto.Id).Build();

            _cargoRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.Id))
                .Returns(cargoMock);

            //When
            _armazenadorDeCargo.Armazenar(dto);

            //Then
            _cargoRepositoryMock.Verify(cr => cr.Atualizar(cargoMock), Times.Once);
        }  
    }
}
