using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities.Funcionarios
{
    public class FuncionarioCargo : Entidade<FuncionarioCargo>
    {
        public int IdFuncionario { get; set; }
        public int IdCargo { get; set; }
        public DateTime DataVinculo { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public override bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
