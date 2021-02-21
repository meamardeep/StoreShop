using AutoMapper;
using StoreShop.Data;
using StoreShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using StoreShop.Repository;

namespace StoreShop.BusinessLogic
{
    public class CartManagement : ICartManagement
    {
        private readonly CartRepo _cartRepo;
        private readonly IMapper _mapper;
        public CartManagement(CartRepo cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public List<CartItemModel> GetCartItems(long userId)
        {          
            IEnumerable<CartItem> cartItems    = _cartRepo.GetCartItems(5);
            List<CartItemModel> models = _mapper.Map<List< CartItemModel>>(cartItems);
            return models;
        }
    }
}
