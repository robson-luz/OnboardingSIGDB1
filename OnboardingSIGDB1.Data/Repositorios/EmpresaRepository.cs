using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(DataContext context) : base(context)
        {

        }

        public Empresa obterPorCnpj(string cnpj)
        {
            var entidade = Context.Set<Empresa>().Where(e => e.Cnpj == cnpj).SingleOrDefault();

            return entidade;
        }
    }
}
