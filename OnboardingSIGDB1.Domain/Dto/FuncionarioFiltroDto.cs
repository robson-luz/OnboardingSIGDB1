using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioFiltroDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataContratacaoInicio { get; set; }
        public DateTime? DataContratacaoFim { get; set; }
    }
}
