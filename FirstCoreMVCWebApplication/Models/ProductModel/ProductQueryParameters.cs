namespace FirstCoreMVCWebApplication.Models.ProductModel
{
    public class ProductQueryParameters
    {
        public string SearchTerm { get; set; }
        public string Category { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PaseSize { get; set; } = 3;
    }
}
