using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public abstract class Entidade<T> : AbstractValidator<T>
    {
        public int Id { get; set; }

        public bool Valid { get; protected set; }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool Validar();

    }
}
