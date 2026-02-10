using TeknoMarketim.Entities;

namespace TeknoMarketim.MvcUI.Models.ProductModel
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

    }
}
