using System;
using System.Collections.Generic;
using System.Text;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;

namespace OnboardingSIGDB1.Domain.Entities.Empresas
{
    public class Empresa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime? DataFundacao { get; private set; }

        public ICollection<Funcionario> Funcionarios { get; private set; }

        public Empresa(string nome, string cnpj, DateTime? dataFundacao)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = DataFundacao;            
        }
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            if(funcionario != null)
                Funcionarios.Add(funcionario);
        }
    }
}
