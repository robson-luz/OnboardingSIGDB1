using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        //public bool Valid { get; private set; }
        //public bool Invalid => !Valid;
        //public ValidationResult ValidationResult { get; private set; }

        //public abstract bool Validate();

    }
}
