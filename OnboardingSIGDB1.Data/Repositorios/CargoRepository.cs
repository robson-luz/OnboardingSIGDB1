using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class CargoRepository : Repository<Cargo>
    {
        public CargoRepository(DataContext context) : base(context)
        {
        }

        public override List<Cargo> Consultar()
        {
            var query = Context.Set<Cargo>()
                .Include(i => i.FuncionariosCargos)
                .ToList();

            return query;
        }
    }
}
