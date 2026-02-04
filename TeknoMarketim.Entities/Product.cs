

namespace TeknoMarketim.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public short StockQuantity { get; set; }
    public decimal? Price { get; set; }
    public decimal? DiscountedPrice { get; set; }

    public bool ShowOnPageAsMonthlyHighLight { get; set; } //bu kısım vitrindeki ilanlar gibi düşünülebilir.
    public bool ShowOnPageAsDailyHighLight { get; set; }
    public bool ShowOnPageAsSpecialOffer { get; set; }
    public bool ShowOnPageAsPopular {  get; set; }

    public int BrandId { get; set; }
    public List<ProductFeature> ProductFeatures { get; set; }
    public bool IsApproved { get; set; } // Admin onayladı mı?

    public bool isActive { get; set; }
    public List<ProductCategory> ProductCategories { get; set; }
}
