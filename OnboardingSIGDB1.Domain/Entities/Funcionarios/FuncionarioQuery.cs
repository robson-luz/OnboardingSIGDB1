using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Funcionarios
{
    public static class FuncionarioQuery
    {
        public static IQueryable<Funcionario> ComCpf(this IQueryable<Funcionario> funcionarios, string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return funcionarios;

            return funcionarios.Where(e => e.Cpf == cpf);
        }

        public static IQueryable<Funcionario> OndeNomeContem(this IQueryable<Funcionario> funcionarios, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return funcionarios;

            return funcionarios.Where(e => e.Nome.Contains(nome));
        }

        public static IQueryable<Funcionario> DataContratacaoMaiorQue(this IQueryable<Funcionario> funcionarios, DateTime? dataInicio)
        {
            if (dataInicio == null)
                return funcionarios;

            return funcionarios.Where(e => e.DataContratacao >= dataInicio );
        }
        public static IQueryable<Funcionario> DataContratacaoMenorQue(this IQueryable<Funcionario> funcionarios, DateTime? dataFim)
        {
            if (dataFim == null)
                return funcionarios;

            return funcionarios.Where(e => e.DataContratacao <= dataFim);
        }
    }
}
