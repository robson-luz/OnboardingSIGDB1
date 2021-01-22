using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {           
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(f => f.Nome).HasMaxLength(150).IsRequired();
            builder.Property(f => f.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(f => f.DataContratacao);

            builder.HasOne(f => f.Empresa).WithMany(e => e.Funcionarios).HasForeignKey(f => f.IdEmpresa);
            builder.HasMany(f => f.CargosVinculados).WithOne(fc => fc.Funcionario).HasForeignKey(fc => fc.IdFuncionario).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
