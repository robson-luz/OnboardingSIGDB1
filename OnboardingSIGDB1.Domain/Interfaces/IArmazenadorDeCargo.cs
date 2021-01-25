using OnboardingSIGDB1.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IArmazenadorDeCargo
    {
        void Armazenar(CargoDto dto);
    }
}
