namespace FirstCoreMVCWebApplication.Models.Fluent_Validation.ProductModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
