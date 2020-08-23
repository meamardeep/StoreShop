using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.Data
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelName { get; set; }
        public string ProductQRCode { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }

        public int ProductTypeId { get; set; }
        public ProductTypeModel ProductTypeModel { get; set; }

        public int BrandId { get; set; }
        public BrandModel BrandModel { get; set; }
    }


    public class BrandModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }
        public StoreModel StoreModel { get; set; }
    }

    public class ProductTypeModel
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
