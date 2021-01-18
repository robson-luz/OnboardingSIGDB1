using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Funcionarios
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataContratacao { get; private set; }

        public Empresa Empresa { get; private set; }
        public ICollection<Cargo> Cargos { get; private set; }

        public Funcionario(string nome, string cpf, DateTime? dataContratacao, Empresa empresa)
        {
            Nome = nome;
            Cpf = cpf;
            DataContratacao = dataContratacao;
            Empresa = empresa;
        }
    }
}
