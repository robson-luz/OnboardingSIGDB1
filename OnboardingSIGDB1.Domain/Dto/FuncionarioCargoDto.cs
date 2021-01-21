using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioCargoDto
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public int IdCargo { get; set; }
        public DateTime DataVinculo { get; set; }
    }
}
