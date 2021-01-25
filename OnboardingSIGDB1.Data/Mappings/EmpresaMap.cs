using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {           
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(e => e.DataFundacao);

            builder.Ignore(e => e.Invalid);
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);

            builder.HasMany(e => e.Funcionarios).WithOne(f => f.Empresa).HasForeignKey(f => f.IdEmpresa).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
