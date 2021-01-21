using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class FuncionarioCargoRepository : Repository<FuncionarioCargo>
    {
        public FuncionarioCargoRepository(DataContext context) : base(context)
        {
        }

        public override List<FuncionarioCargo> Consultar()
        {
            var query = Context.Set<FuncionarioCargo>()
                .Include(i => i.Funcionario)
                .Include(i => i.Cargo)
                .ToList();

            return query;
        }
    }
}
