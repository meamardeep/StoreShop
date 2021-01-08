using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreShop.DataAccess
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelName { get; set; }
        public string ProductQRCode{ get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public CustomerProductType ProductType { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }


    }

    [Table("MasBrands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }  
    }


    
    public class BrandStoreMapping
    {
        [Key]
        public int BrandStoreMappingId { get; set; }
        
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }


    [Table("CustomerProductTypes")]
    public class CustomerProductType
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Column("CustomerProductTypeId")]
        public int CustomerProductTypeId { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("MasProductType")]
        public int MasProductTypeId { get; set; }
        public bool IsActive { get; set; }

        public MasProductType MasProductType { get; set; }
    }

    [Table("MasProductTypes")]
    public class MasProductType
    {
        [Key]
        public int MasProductTypeId { get; set; }
        public string MasProductTypeName { get; set; }

        [ForeignKey("MasProductCategory")]
        public int ProductCategoryId { get; set; }

        public MasProductCategory MasProductCategory { get; set; }

    }

    [Table("MasProductCategories")]
    public class MasProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        
    }


       
}
