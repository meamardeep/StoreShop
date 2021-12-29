namespace StoreShop.BusinessLogic
{
    public class CartManagement : ICartManagement
    {
        private readonly ICartRepo _cartRepo;
        private readonly IMapper _mapper;
        public CartManagement(ICartRepo cartRepo, IMapper mapper)
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
