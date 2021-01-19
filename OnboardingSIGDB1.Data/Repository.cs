using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnboardingSIGDB1.Data
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade
    {
        protected readonly DataContext Context;

        public Repository(DataContext _context)
        {
            Context = _context;
        }

        public void Adicionar(TEntidade entidade)
        {
            Context.Set<TEntidade>().Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            Context.Set<TEntidade>().Update(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            Context.Set<TEntidade>().Remove(entidade);
        }

        public virtual TEntidade ObterPorId(int id)
        {
            var query = Context.Set<TEntidade>().Where(e => e.Id == id);

            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntidade> Consultar()
        {
            var entidades = Context.Set<TEntidade>().ToList();

            return entidades.Any() ? entidades : new List<TEntidade>();
        }
    }
}
