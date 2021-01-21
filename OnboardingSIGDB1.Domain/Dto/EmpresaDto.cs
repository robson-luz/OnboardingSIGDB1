using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj
        {
            get { return Cnpj; }

            set { Cnpj = Cnpj.Replace(".", String.Empty).Replace("/", String.Empty); }
        }
        public DateTime? DataFundacao { get; set; }
    }
}
