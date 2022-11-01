using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using upd8.Business.Models;

namespace upd8.Data.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cpf)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.DataNascimento)
            .IsRequired()
            .HasColumnType("DATE");

        builder.Property(p => p.Sexo)
            .IsRequired()
            .HasColumnType("varchar(10)");

        builder.Property(p => p.Endereco)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Estado)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Cidade)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.ToTable("Clientes");

    }   
}
