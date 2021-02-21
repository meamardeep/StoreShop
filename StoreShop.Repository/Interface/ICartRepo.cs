using System;
using System.Collections.Generic;
using System.Text;
using StoreShop.DataAccess;

namespace StoreShop.Repository
{
    public interface ICartRepo
    {
        IEnumerable<CartItem> GetCartItems(int userId);
    }
}
