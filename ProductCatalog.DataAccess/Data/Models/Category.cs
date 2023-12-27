

namespace ProductCatalog.DataAccess.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public List<Product> Products { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
    }
}
