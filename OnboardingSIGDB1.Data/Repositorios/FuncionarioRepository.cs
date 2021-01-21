using OnboardingSIGDB1.Domain.Entities.Funcionarios;
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
    public class FuncionarioRepository : Repository<Funcionario>
    {
        public FuncionarioRepository(DataContext context) : base(context)
        {
        }

        public Funcionario ObterPorCpf(string cpf)
        {
            var entidade = Context.Set<Funcionario>().Where(f => f.Cpf == cpf);

            return entidade.Any() ? entidade.First() : null;
        }

        public override List<Funcionario> Consultar()
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.FuncionariosCargos)
                .ToList();

            return query;
        }

        public IQueryable<Funcionario> ConsultarComFiltro(FuncionarioFiltroDto dto)
        {
            var query = Context.Set<Funcionario>()
                .Include(i => i.Empresa)
                .Include(i => i.FuncionariosCargos)
                .OndeNomeContem(dto.Nome)
                .ComCpf(dto.Cpf)
                .DataContratacaoMaiorQue(dto.DataContratacaoInicio)
                .DataContratacaoMenorQue(dto.DataContratacaoFim);

            return query;
        }
    }
}
