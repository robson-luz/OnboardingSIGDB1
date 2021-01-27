using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Common.Tests.Base
{
    public abstract class BuilderBase
    {
        protected void AtribuirId(int id, object entidade)
        {
            if (!TemId(id)) return;

            Atribuir(id, "Id", entidade);
        }

        private bool TemId(long id)
        {
            return id > 0;
        }

        private void Atribuir(object valor, string propriedade, object entidade)
        {
            var propertyInfo = entidade.GetType().GetProperty(propriedade);
            propertyInfo.SetValue(entidade, Convert.ChangeType(valor, propertyInfo.PropertyType), null);
        }
    }
}
