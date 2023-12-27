

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductCatalog.DataAccess.Data.Models.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(p => p.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(f => f.ParentCategoryId);
        }
    }
}
