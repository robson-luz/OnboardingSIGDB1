using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf {
            get { return Cpf; }

            set { Cpf = Cpf.Replace(".", String.Empty).Replace("-", String.Empty); }
        }
        public DateTime? DataContratacao { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
