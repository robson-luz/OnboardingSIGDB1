using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;

namespace OnboardingSIGDB1.Domain.Entities.Empresas
{
    public class Empresa : Entidade
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime? DataFundacao { get; private set; }

        public virtual ICollection<Funcionario> Funcionarios { get; private set; }

        private Empresa()
        {

        }

        public Empresa(string nome, string cnpj, DateTime? dataFundacao)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = DataFundacao;

            Funcionarios = new List<Funcionario>();
        }
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            if(funcionario != null)
                Funcionarios.Add(funcionario);
        }
    }
}
