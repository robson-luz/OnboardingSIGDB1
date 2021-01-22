using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioCargoMap : IEntityTypeConfiguration<FuncionarioCargo>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCargo> builder)
        {           
            builder.HasKey(fc => fc.Id);

            builder.Property(fc => fc.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(fc => fc.IdFuncionario).IsRequired();
            builder.Property(fc => fc.IdCargo).IsRequired();
            builder.Property(fc => fc.DataVinculo).IsRequired();

            builder.HasOne(fc => fc.Funcionario).WithMany(f => f.CargosVinculados).HasForeignKey(fc => fc.IdFuncionario);
            builder.HasOne(fc => fc.Cargo).WithMany(f => f.FuncionariosCargos).HasForeignKey(fc => fc.IdCargo);
        }
    }
}
