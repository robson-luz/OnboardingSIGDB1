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
using OnboardingSIGDB1.Domain.Resources;
using OnboardingSIGDB1.Common.Tests.EmpresasBuilder;

namespace OnboardingSIGDB1.Domain.Tests.Funcionarios
{
    public class VinculacaoDeFuncionarioAEmpresaTests
    {
        private readonly Faker _faker;

        private readonly Mock<IFuncionarioRepository> _funcionarioRepositoryMock;
        private readonly Mock<IEmpresaRepository> _empresaRepositoryMock;
        private readonly Mock<NotificationContext> _notificationContextMock;

        private readonly VinculacaoDeFuncionarioAEmpresa _vinculacaoDeFuncionarioAEmpresa;

        public VinculacaoDeFuncionarioAEmpresaTests()
        {
            _faker = FakerBuilder.Novo().Build();

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _notificationContextMock = new Mock<NotificationContext>();

            _vinculacaoDeFuncionarioAEmpresa = new VinculacaoDeFuncionarioAEmpresa(
                _notificationContextMock.Object,
                _funcionarioRepositoryMock.Object,
                _empresaRepositoryMock.Object);
        }

        [Fact]
        public void DeveVincularEmpresa()
        {
            //Given
            var dto = new FuncionarioDto
            {
                Id = _faker.Random.Int(100),
                IdEmpresa = _faker.Random.Int(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).Build();
            var empresaMock = EmpresaBuilder.Novo().ComId(dto.IdEmpresa).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            _empresaRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.IdEmpresa))
                .Returns(empresaMock);

            //When
            _vinculacaoDeFuncionarioAEmpresa.VincularEmpresa(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Once);
        }

        [Fact]
        public void NaoDeveVincularQuandoEmpresaNaoCadastrada()
        {
            //Given
            var dto = new FuncionarioDto()
            {
                Id = _faker.Random.Int(100),
                IdEmpresa = _faker.Random.Int(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            //When
            _vinculacaoDeFuncionarioAEmpresa.VincularEmpresa(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Never);
        }

        [Fact]
        public void NaoDeveVincularQuandoJaTemEmpresaVinculada()
        {
            //Given
            var dto = new FuncionarioDto
            {
                Id = _faker.Random.Number(100),
                IdEmpresa = _faker.Random.Number(100)
            };

            var funcionarioMock = FuncionarioBuilder.Novo().ComId(dto.Id).ComIdEmpresa(_faker.Random.Number(100)).Build();
            var empresaMock = EmpresaBuilder.Novo().ComId(dto.IdEmpresa).Build();

            _funcionarioRepositoryMock
                .Setup(fr => fr.ObterPorId(dto.Id))
                .Returns(funcionarioMock);

            _empresaRepositoryMock
                .Setup(cr => cr.ObterPorId(dto.IdCargo))
                .Returns(empresaMock);

            //When
            _vinculacaoDeFuncionarioAEmpresa.VincularEmpresa(dto);

            //Then
            _funcionarioRepositoryMock.Verify(fr => fr.Atualizar(funcionarioMock), Times.Never);
        }       
    }
}
