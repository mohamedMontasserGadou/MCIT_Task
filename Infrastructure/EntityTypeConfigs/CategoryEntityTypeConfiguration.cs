using MCIT_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCIT_Task.Infrastructure.EntityTypeConfigs
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
