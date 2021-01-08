using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Data
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelName { get; set; }
        public string ProductQRCode { get; set; }
        public double MRP { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }

        public int ProductTypeId { get; set; }
        public CustomerProductTypeModel ProductTypeModel { get; set; }

        public int BrandId { get; set; }
        public BrandModel BrandModel { get; set; }

        List<ProductImage> productImages { get; set; }
    }

    public class ProductImage
    {
        public long ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public int MyProperty { get; set; }

    }

    public class ProductCardModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelName { get; set; }
        public double MRP { get; set; }
        public int MyProperty { get; set; }
    }
    public class BrandModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }

        //public int StoreId { get; set; }
        //public StoreModel StoreModel { get; set; }
    }

    #region Product card model
    public class ClothingCardModel
    {
        public long ClothingId { get; set; }
        public string ClothName { get; set; }
        public int MyProperty { get; set; }

    }

    public class MobileCardModel
    {

    }
    public class LaptopCardModel
    {

    }
    public class TelevisionCardModel
    {

    }
    #endregion

    public class CustomerProductTypeModel
    {
        public int CustomerProductTypeId { get; set; }

        public int CustomerId { get; set; }

        public int MasProductTypeId { get; set; }
        public bool IsActive { get; set; }

        public MasProductTypeModel MasProductTypeModel { get; set; }

        public List<DropDownItem> ProductTypes { get; set; }
    }

    public class MasProductTypeModel
    {
        public int MasProductTypeId { get; set; }
        public string MasProductTypeName { get; set; }

        public int ProductCategoryId { get; set; }

        public MasProductCategoryModel MasProductCategoryModel { get; set; }

    }

    public class MasProductCategoryModel
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }


    

}
