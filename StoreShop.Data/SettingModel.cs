namespace StoreShop.Data
{
    public class SettingModel
    {
        public List<StoreModel> StoreModels { get; set; }//Only visible to customer admin(not visible to store admin)
        public List<BrandModel> BrandModels { get; set; }
        public List<CustomerProductTypeModel> ProductTypeModels { get; set; }
        public List<UserModel> UserModels { get; set; }
    }
}
