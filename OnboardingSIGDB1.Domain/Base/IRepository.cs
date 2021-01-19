using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public interface IRepository<TEntidade>
    {
        List<TEntidade> Consultar();
        TEntidade ObterPorId(int id);
        void Adicionar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);

    }
}
