using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(DataContext context) : base(context)
        {
        }

        public Funcionario ObterPorCpf(string cpf)
        {
            var entidade = Context.Set<Funcionario>().Where(f => f.Cpf == cpf);

            return entidade.Any() ? entidade.First() : null;
        }

        public override Funcionario ObterPorId(int id)
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.CargosVinculados)
                .Where(e => e.Id == id);

            return query.Any() ? query.First() : null;
        }

        public override List<Funcionario> Consultar()
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.CargosVinculados)
                .ToList();

            return query;
        }

        public IQueryable<Funcionario> ConsultaComFiltro()
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.CargosVinculados);

            return query;
        }
    }
}
