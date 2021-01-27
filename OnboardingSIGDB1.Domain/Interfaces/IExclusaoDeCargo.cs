using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IExclusaoDeCargo 
    {
        void Excluir(int id);
    }
}
