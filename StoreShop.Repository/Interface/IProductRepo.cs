using System;
using System.Collections.Generic;
using System.Text;
using StoreShop.DataAccess;
namespace StoreShop.Repository
{
    public interface IProductRepo
    {
        public IEnumerable<MasProductType> GetMasProductTypes();

        #region Product Type
        List<CustomerProductType> GetProductTypes(int customerId);
        CustomerProductType GetProductType(int productTypeId);
        void CreateProductType(CustomerProductType productType);
        void UpdateProductType(CustomerProductType productType);
        void DeleteProductType(CustomerProductType productType);
        #endregion
    }
}
