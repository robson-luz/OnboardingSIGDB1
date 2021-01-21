using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSIGDB1.Data.Queries
{
    public static class EmpresaQuery
    {
        public static IQueryable<Empresa> ComCnpj(this IQueryable<Empresa> empresas, string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return empresas;

            return empresas.Where(e => e.Cnpj == cnpj);
        }

        public static IQueryable<Empresa> OndeNomeContem(this IQueryable<Empresa> empresas, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return empresas;

            return empresas.Where(e => e.Nome.Contains(nome));
        }

        public static IQueryable<Empresa> DataFundacaoMaiorQue(this IQueryable<Empresa> empresas, DateTime? dataInicio)
        {
            if (dataInicio == null)
                return empresas;

            return empresas.Where(e => e.DataFundacao >= dataInicio );
        }
        public static IQueryable<Empresa> DataFundacaoMenorQue(this IQueryable<Empresa> empresas, DateTime? dataFim)
        {
            if (dataFim == null)
                return empresas;

            return empresas.Where(e => e.DataFundacao <= dataFim);
        }
    }
}
