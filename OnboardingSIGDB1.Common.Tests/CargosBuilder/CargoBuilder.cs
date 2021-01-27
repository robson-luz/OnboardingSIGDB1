using OnboardingSIGDB1.Common.Tests.Base;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Common.Tests.CargosBuilder
{
    public class CargoBuilder : BuilderBase
    {
        protected int Id;
        protected string Descricao;
        public List<FuncionarioCargo> FuncionariosCargos;

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
                FuncionariosCargos.ForEach(fc => cargo.AdicionarFuncionario(fc));

            AtribuirId(Id, cargo);

            return cargo;
        }
    }
}
