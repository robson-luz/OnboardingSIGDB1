using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        private readonly DataContext _context;

        public EmpresaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Empresa ObterPorCnpj(string cnpj)
        {
            var entidade = _context.Set<Empresa>().Where(e => e.Cnpj == cnpj);

            return entidade.Any() ? entidade.First() : null;
        }

        public override List<Empresa> Consultar()
        {
            var query = _context.Set<Empresa>()
                .Include(i => i.Funcionarios)
                .ToList();

            return query;
        }

        public IQueryable<Empresa> ConsultaComFiltro()
        {
            var query = _context.Set<Empresa>()
                .Include(i => i.Funcionarios);

            return query;
        }
    }
}
