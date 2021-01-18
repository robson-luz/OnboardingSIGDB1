using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public interface IRepository<T> where T : class
    {
        List<T> Consultar();
        T ObterPorId(int id);
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);

    }
}
