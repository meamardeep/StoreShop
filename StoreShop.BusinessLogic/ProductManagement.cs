namespace StoreShop.BusinessLogic
{
    public class ProductManagement : IProductManagement
    {
        private readonly  IProductRepo _productRepo ;
        private readonly IMapper _mapper;
        public ProductManagement(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public List<DropDownItem> GetMasProductTypes()
        {
            var items = from m in _productRepo.GetMasProductTypes()
                                       select new DropDownItem()
                                       {
                                           Value = m.MasProductTypeId,
                                           Text = m.MasProductTypeName
                                       };
            return items.ToList();
        }

        #region Product Type Management
        public List<CustomerProductTypeModel> GetProductTypes(int customerId)
        {
            List<CustomerProductType> productTypes = _productRepo.GetProductTypes(customerId);
            return _mapper.Map<List<CustomerProductTypeModel>>(productTypes);
        }

        public CustomerProductTypeModel GetProductType(int productTypeId)
        {
            CustomerProductType productType = _productRepo.GetProductType(productTypeId);
            return _mapper.Map<CustomerProductTypeModel>(productType);
        }
        public void CreateProductType(CustomerProductTypeModel model)
        {
            model.IsActive = true;
            CustomerProductType productType = _mapper.Map<CustomerProductType>(model);
            _productRepo.CreateProductType(productType);
        }

        public void UpdateProductType(CustomerProductTypeModel model)
        {
            //CustomerProductType productType = _customerRepo.GetProductType(model.ProductTypeId);
            //productType.ProductTypeName = model.ProductTypeName;
            //_customerRepo.UpdateProductType(productType);
        }

        public void DeleteProductType(int productTypeId)
        {
            CustomerProductType productType = _productRepo.GetProductType(productTypeId);
            _productRepo.DeleteProductType(productType);
        }
        #endregion

        #region Clothing
        public List<ProductModel> GetProducts(int productType, int sessionCustomerId, long sessionUserId)
        {
            //IEnumerable<Product> products = _productRepo.;
            
            return new List<ProductModel>();
        }
        #endregion
    }
}
