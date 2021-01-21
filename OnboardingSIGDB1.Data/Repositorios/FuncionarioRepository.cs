using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class FuncionarioRepository : Repository<Funcionario>
    {
        public FuncionarioRepository(DataContext context) : base(context)
        {
        }

        public override List<Funcionario> Consultar()
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.FuncionariosCargos)
                .ToList();

            return query;
        }
    }
}
