using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataContratacao { get; set; }
        public int IdEmpresa { get; set; }
    }
}
