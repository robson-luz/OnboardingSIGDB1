using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataContratacao { get; set; }

        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        public int IdCargo { get; set; }

        public FuncionarioDto()
        {
            if (!String.IsNullOrEmpty(Cpf))
                Cpf = Cpf.Replace(".", string.Empty).Replace("-", string.Empty);
        }
    }
}
