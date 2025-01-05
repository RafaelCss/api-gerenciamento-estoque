using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EF.Configuracao;

internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        // Configuração da tabela
        builder.ToTable("Produtos");

        // Configuração da chave primária
        builder.HasKey(p => p.Id);

        // Configuração de propriedades
        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Preco)
            .HasPrecision(18 , 2); // Precisão decimal

        builder.Property(p => p.Descricao)
                .HasMaxLength(maxLength: 500);
    }
}
