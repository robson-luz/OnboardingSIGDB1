using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Cargos
{
    public class Cargo
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<FuncionarioCargo> FuncionariosCargos { get; private set; }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }
    }
}
