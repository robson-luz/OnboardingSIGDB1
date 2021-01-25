using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities.Cargos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {           
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.Descricao).HasMaxLength(250).IsRequired();

            builder.Ignore(e => e.Invalid);
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);

            builder.HasMany(c => c.FuncionariosCargos).WithOne(fc => fc.Cargo).HasForeignKey(fc => fc.IdCargo);
        }
    }
}
