namespace StoreShop.BusinessLogic
{
    public interface ICustomerManagement
    {
        #region Address interface management
        List<DropDownItem> GetStates(int countryId);
        List<DropDownItem> GetCities(int stateId);
        List<DropDownItem> GetCountries();
        
        long CreateAddress(AddressModel addressModel);
        void UpdateAddress(AddressModel model);
        #endregion

        #region Brand interface management
        List<BrandModel> GetBrands(int customerId);
        BrandModel GetBrand(int brandId);
        void CreateBrand(BrandModel model);
        void UpdateBrand(BrandModel model);
        void DeleteBrand(int brandId);
        #endregion

    }
}
