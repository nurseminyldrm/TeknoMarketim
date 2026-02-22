namespace TeknoMarketim.MvcUI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public List<WishListModel> WishLists { get; set; }
        public decimal TotalPrice()
        {
            return CartItems.Sum(ci => ci.DiscountedPrice * ci.Quantity);
        }
    }


    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  
        public decimal DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }

    public class WishListModel
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
