using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Funcionario ObterPorCpf(string cpf);

        List<Funcionario> ConsultarComFiltro(FuncionarioFiltroDto dto);
    }
}
