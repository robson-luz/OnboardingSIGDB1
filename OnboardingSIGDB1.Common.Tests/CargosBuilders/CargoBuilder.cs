using OnboardingSIGDB1.Common.Tests._Base;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Common.Tests.CargosBuilders
{
    public class CargoBuilder : BuilderBase
    {
        protected int Id;
        protected string Descricao;
        protected List<FuncionarioCargo> FuncionariosCargos;

        public static CargoBuilder Novo()
        {
            var faker = FakerBuilder.Novo().Build();
            var builder = new CargoBuilder
            {
                Descricao = faker.Lorem.Sentence()
            };

            return builder;
        }

        public CargoBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public CargoBuilder ComDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public CargoBuilder ComFuncionariosCargos(List<FuncionarioCargo> funcionariosCargos)
        {
            FuncionariosCargos = funcionariosCargos;
            return this;
        }

        public Cargo Build()
        {
            var cargo = new Cargo(Descricao);

            if (FuncionariosCargos != null)
                FuncionariosCargos.ForEach(fc => cargo.AdicionarFuncionarioCargo(fc));

            AtribuirId(Id, cargo);

            return cargo;
        }
    }
}
