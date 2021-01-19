using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Funcionarios
{
    public class Funcionario : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataContratacao { get; private set; }

        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; private set; }

        public virtual ICollection<FuncionarioCargo> FuncionariosCargos { get; set; }

        public Funcionario(string nome, string cpf, DateTime? dataContratacao, int idEmpresa)
        {
            Nome = nome;
            Cpf = cpf;
            DataContratacao = dataContratacao;
            IdEmpresa = idEmpresa;
        }
    }
}
