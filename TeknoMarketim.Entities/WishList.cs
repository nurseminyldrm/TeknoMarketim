

namespace TeknoMarketim.Entities;

public class WishList
{
    public int Id {  get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public Cart Cart { get; set; }
    public int CartId { get; set; }
}
