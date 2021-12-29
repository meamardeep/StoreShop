namespace StoreShop.BusinessLogic
{
    public interface ICartManagement
    {
        List<CartItemModel> GetCartItems(long userId);
    }
}
