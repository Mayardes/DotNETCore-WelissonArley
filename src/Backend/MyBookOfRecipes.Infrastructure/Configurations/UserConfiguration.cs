using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookOfRecipes.Domain.Entities;

namespace MyBookOfRecipes.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl.User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR").HasMaxLength(1000).IsRequired();

        }
    }
}
