using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreShop.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly StoreShopDataContext _database;
        public CartRepo(StoreShopDataContext storeShopDataContext) 
        {
            _database = storeShopDataContext;

        }
        public IEnumerable<CartItem> GetCartItems(int userId)
        {
            var sql = from ci in _database.CartItems
                      .Include(m => m.Product)
                      .Include(m=> m.User)
                      where ci.UserId == userId
                      select ci;

            return sql;
        }
    }
}
