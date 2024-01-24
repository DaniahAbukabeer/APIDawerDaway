using APIDawerDaway.Models;

namespace APIDawerDaway.ViewModels
{
    public class MergedProductsVM
    {
        public int ProductId { get; set; }
        public string TName { get; set; }
        public string Categorie { get; set; }
        public double? PublicPrice { get; set; }

        // Add other properties as needed

        public static MergedProductsVM FromProduct(Product product)
        {
            return new MergedProductsVM
            {
                ProductId = product.Id,
                TName = product.TName,
                Categorie = product.Categorie,
                PublicPrice = product.PharmaysProducts?.FirstOrDefault()?.PublicPrice ?? 0.0
            };
        }
    }
}
