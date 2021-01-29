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

namespace OnboardingSIGDB1.Domain.Tests.Funcionarios
{
    public class VinculacaoDeFuncionarioACargoTests
    {
        private readonly Faker _faker;

        private readonly Mock<IFuncionarioRepository> _funcionarioRepositoryMock;
        private readonly Mock<ICargoRepository> _cargoRepositoryMock;
        private readonly Mock<NotificationContext> _notificationContextMock;

        private readonly VinculacaoDeFuncionarioACargo _vinculacaoDeFuncionarioACargo;

        public VinculacaoDeFuncionarioACargoTests()
        {
            _faker = FakerBuilder.Novo().Build();

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _notificationContextMock = new Mock<NotificationContext>();

            _vinculacaoDeFuncionarioACargo = new VinculacaoDeFuncionarioACargo(
                _notificationContextMock.Object,
                _funcionarioRepositoryMock.Object,
                _cargoRepositoryMock.Object);
        }

        [Fact]
        public void DeveVincularCargo()
        {
            //Given
            var dto = new FuncionarioDto
            {
                Id = _faker.Random.Int(100),
                IdCargo = _faker.Random.Int(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).ComIdEmpresa(_faker.Random.Int(100)).Build();
            var cargoMock = CargoBuilder.Novo().ComId(dto.IdCargo).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            _cargoRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.IdCargo))
                .Returns(cargoMock);

            //When
            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Once);
        }

        [Fact]
        public void NaoDeveVincularCargoQuandoCargoNaoCadastrado()
        {
            //Given
            var dto = new FuncionarioDto()
            {
                Id = _faker.Random.Int(100),
                IdCargo = _faker.Random.Int(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).ComIdEmpresa(_faker.Random.Int(100)).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            //When
            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Never);
        }

        [Fact]
        public void NaoDeveVincularCargoQuandoNaoTemEmpresa()
        {
            //Given
            var dto = new FuncionarioDto
            {
                Id = _faker.Random.Number(100),
                IdCargo = _faker.Random.Number(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).Build();
            var cargoMock = CargoBuilder.Novo().ComId(dto.IdCargo).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            _cargoRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.IdCargo))
                .Returns(cargoMock);

            //When
            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Never);
        }

        [Fact]
        public void NaoDeveVincularCargoQuandoJaPossuiMesmoCargo()
        {
            //Given
            var dto = new FuncionarioDto
            {
                Id = _faker.Random.Number(100),
                IdCargo = _faker.Random.Number(100),
                IdEmpresa = _faker.Random.Number(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).Build();
            var cargoMock = CargoBuilder.Novo().ComId(dto.IdCargo).Build();

            funcionarioMock.CargosVinculados.Add(new FuncionarioCargo()
            {
                IdCargo = cargoMock.Id,
                IdFuncionario = funcionarioMock.Id
            });

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            _cargoRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.IdCargo))
                .Returns(cargoMock);

            //When
            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Never);
        }

        [Fact]
        public void DeveNotificarErrosDeServicoQuandoExistir()
        {
            var dto = new FuncionarioDto();

            _vinculacaoDeFuncionarioACargo.VincularCargo(dto);
            
            Assert.True(_notificationContextMock.Object.HasNotifications);
        }
    }
}
