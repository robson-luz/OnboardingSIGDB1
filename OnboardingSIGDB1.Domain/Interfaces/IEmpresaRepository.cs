﻿using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Empresa obterPorCnpj(string cnpj);
    }
}
