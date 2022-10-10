using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuRecipe.Domain.Entity;

namespace NeuRecipe.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").HasKey(e => e.Email);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Recipe)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.CreatedBy);
        }
    }
}
