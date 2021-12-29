namespace StoreShop.BusinessLogic
{
    public interface IProductManagement
    {
        List<DropDownItem> GetMasProductTypes();

        #region Product Type interface management
        List<CustomerProductTypeModel> GetProductTypes(int customerId);
        CustomerProductTypeModel GetProductType(int productTypeId);
        void CreateProductType(CustomerProductTypeModel model);
        void UpdateProductType(CustomerProductTypeModel model);
        void DeleteProductType(int productTypeId);
        #endregion

        #region clothing
        List<ProductModel> GetProducts(int productType, int sessionCustomerId, long sessionUserId);

        #endregion
    }
}
