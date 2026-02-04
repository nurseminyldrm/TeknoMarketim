using TeknoMarketim.Business.Abstract;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Business.Concrete
{
    public class WishListManager : IWishListService
    {
        private readonly IWishListRepository _wishListRepository;

        public WishListManager(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public void DeleteFromWishList(int cartId, int productId)
        {
            _wishListRepository.DeleteFromWishList(cartId, productId);
        }

        public WishList GetByUserId(string userId)
        {
            return _wishListRepository.GetByUserId(userId);
        }

        public WishList GetByUserWishListId(string userId)
        {
            return _wishListRepository.GetByUserWhishlistId(userId);
        }
    }
}
