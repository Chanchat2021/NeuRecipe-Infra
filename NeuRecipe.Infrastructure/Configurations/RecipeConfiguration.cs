using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuRecipe.Domain.Entity;
namespace NeuRecipe.Infrastructure.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipe").HasKey(e => e.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Ingredients).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Directions).IsRequired().HasMaxLength(2000);
            builder.Property(p => p.RecipeTips).IsRequired().HasMaxLength(200);
            builder.Property(p => p.NutritionFacts).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime2(0)");
            builder.Property(p => p.LastUpdatedDate).HasColumnType("datetime2(0)");
            builder.Property(p => p.CreatedBy).IsRequired();
        }

    }
}
