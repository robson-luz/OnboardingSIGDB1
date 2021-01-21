using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Data.Queries;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(DataContext context) : base(context)
        {
        }

        public Empresa ObterPorCnpj(string cnpj)
        {
            var entidade = Context.Set<Empresa>().Where(e => e.Cnpj == cnpj);

            return entidade.Any() ? entidade.First() : null;
        }

        public override List<Empresa> Consultar()
        {
            var query = Context.Set<Empresa>()
                .Include(i => i.Funcionarios)
                .ToList();

            return query;
        }

        public IQueryable<Empresa> ConsultarComFiltro(EmpresaFiltroDto dto)
        {
            var query = Context.Set<Empresa>()
                .Include(i => i.Funcionarios)
                .OndeNomeContem(dto.Nome)
                .ComCnpj(dto.Cnpj)
                .DataFundacaoMaiorQue(dto.DataFundacaoInicio)
                .DataFundacaoMenorQue(dto.DataFundacaoFim);            

            return query;
        }
    }
}
