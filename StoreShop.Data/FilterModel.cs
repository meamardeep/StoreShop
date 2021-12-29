namespace StoreShop.Data
{
    public class FilterModel
    {
    }

    public class SizeFilterModel
    {
        public int SizeFilterId { get; set; }
        public string SizeFilterName { get; set; }
    }

    public class PriceFilterModel
    {
        public int PriceFilterId { get; set; }
        public string PriceFilterValue { get; set; }
    }

    public class BrandFilterModel { }//consider same str of brandModel
    
}
