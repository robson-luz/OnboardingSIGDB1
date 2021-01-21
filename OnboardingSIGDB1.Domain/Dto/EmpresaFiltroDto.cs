using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class EmpresaFiltroDto
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataFundacaoInicio { get; set; }
        public DateTime? DataFundacaoFim { get; set; }
    }
}
