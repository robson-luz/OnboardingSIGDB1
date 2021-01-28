using Bogus;
using Moq;
using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Common.Tests.CargosBuilder;
using OnboardingSIGDB1.Common.Tests.EmpresasBuilder;
using OnboardingSIGDB1.Common.Tests.FuncionariosBuilder;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnboardingSIGDB1.Domain.Tests.Funcionarios
{
    public class VinculacaoDeFuncionarioACargoTests
    {
        private readonly Faker _faker;

        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IFuncionarioRepository> _funcionarioRepositoryMock;
        private readonly Mock<ICargoRepository> _cargoRepositoryMock;
        private readonly Mock<NotificationContext> _notificationContextMock;

        private readonly VinculacaoDeFuncionarioACargo _vinculacaoDeFuncionarioACargo;

        public VinculacaoDeFuncionarioACargoTests()
        {
            _faker = FakerBuilder.Novo().Build();

            _unitOfWork = new Mock<IUnitOfWork>();
            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _notificationContextMock = new Mock<NotificationContext>();

            _vinculacaoDeFuncionarioACargo = new VinculacaoDeFuncionarioACargo(
                _notificationContextMock.Object,
                _funcionarioRepositoryMock.Object,
                _cargoRepositoryMock.Object);
        }

        [Fact]
        public void DeveVincularEmpresa()
        {

        }
    }
}
