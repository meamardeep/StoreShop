﻿namespace StoreShop.BusinessLogic
{
    public class CustomerManagement : ICustomerManagement
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        private readonly UserSessionModel userSessionModel;

        public CustomerManagement(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public CustomerManagement(UserSessionModel userSessionModel) /*: this(ICustomerRepo, IMapper)*/
        {
            this.userSessionModel = userSessionModel;
        }

        #region Address
        public List<DropDownItem> GetCountries()
        {
            var countries = from c in _customerRepo.GetCountries().ToList()
                                           select new DropDownItem()
                                           {
                                               Text = c.CountryName,
                                               Value = c.CountryId
                                           };

            return countries.ToList();
        }

        public List<DropDownItem> GetStates(int countryId)
        {
            var states = from s in _customerRepo.GetStates(countryId).ToList()
                         select new DropDownItem
                         {
                             Text = s.StateName,
                             Value = s.StateId
                         };
            return states.ToList();
             
             }

        public List<DropDownItem> GetCities(int stateId)
        {
            var cities = from c in _customerRepo.GetCities(stateId).ToList()
                         select new DropDownItem
                         {
                             Text = c.CityName,
                             Value = c.CityId
                         };
            return cities.ToList();

        }

        public Address GetAddress(long addressId)
        {
            return _customerRepo.GetAddress(addressId);
        }
        public long CreateAddress(AddressModel addressModel)
        {
            Address address = _mapper.Map<Address>(addressModel);
            return  _customerRepo.CreateAddress(address);
             
        }

        public void UpdateAddress(AddressModel model)
        {
            Address address = _customerRepo.GetAddress(model.AddressId);
            address.AddressText = model.AddressText;
            address.CityId = model.CityId;
            address.StateId = model.StateId;
            address.CountryId = model.CountryId;
            _customerRepo.UpdateAddress(address);
        }
        #endregion

        #region Brand CRUD Management
        public List<BrandModel> GetBrands(int customerId)
        {
            List<Brand> brands = _customerRepo.GetBrands(customerId);
            return _mapper.Map<List<BrandModel>>(brands);
        }

        public BrandModel GetBrand(int brandId)
        {
            Brand brand = _customerRepo.GetBrand(brandId);
            return _mapper.Map<BrandModel>(brand);
        }

        public void CreateBrand(BrandModel model)
        {
            model.IsActive = true;
            Brand brand = _mapper.Map<Brand>(model);
            _customerRepo.CreateBrand(brand);
        }

        public void UpdateBrand(BrandModel model)
        {
            Brand brand = _customerRepo.GetBrand(model.BrandId);
            brand.BrandName = model.BrandName;
            _customerRepo.UpdateBrand(brand);
        }

        public void DeleteBrand(int brandId)
        {
            Brand brand = _customerRepo.GetBrand(brandId);
            _customerRepo.DeleteBrand(brand);
        }
        #endregion
    }

}
