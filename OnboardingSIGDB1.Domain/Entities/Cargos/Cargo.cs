using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Cargos
{
    public class Cargo : Entidade
    {
        public string Descricao { get; private set; }

        public virtual ICollection<FuncionarioCargo> FuncionariosCargos { get; private set; }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }
    }
}
