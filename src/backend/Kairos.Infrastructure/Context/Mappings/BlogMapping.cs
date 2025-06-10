namespace Kairos.Infrastructure.Context.Mappings
{
    public class BlogMapping : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.ToTable("Tbl_Blog");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Conteudo)
                .IsRequired();

            builder.Property(x => x.ImagemCapaUrl)
                .IsRequired();

            builder.Property(x => x.DataPublicacao)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.AutorID)
                .IsRequired();

            builder.HasOne(x => x.Autor)
                .WithMany()
                .HasForeignKey(x => x.AutorID)
                .HasConstraintName("FK_Usuario_Blog")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
