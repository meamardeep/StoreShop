using System;
using System.Collections.Generic;
using System.Text;
using StoreShop.Data;

namespace StoreShop.BusinessLogic
{
    public interface ICartManagement
    {
        List<CartItemModel> GetCartItems(long userId);
    }
}
