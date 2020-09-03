using AutoMapper;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreShop.BusinessLogic
{
    public class CustomerManagement : ICustomerManagement
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        private readonly UserSessionModel _userSession;

        public CustomerManagement(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
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

        #region Product Type Management

        public List<ProductTypeModel> GetProductTypes(int customerId)
        {
             List<ProductType> productTypes = _customerRepo.GetProductTypes(customerId);
            return _mapper.Map<List<ProductTypeModel>>(productTypes);
        }

        public ProductTypeModel GetProductType(int productTypeId)
        {
            ProductType productType = _customerRepo.GetProductType(productTypeId);
            return _mapper.Map<ProductTypeModel>(productType);
        }
        public void CreateProductType(ProductTypeModel model)
        {
            ProductType productType = _mapper.Map<ProductType>(model);
            _customerRepo.CreateProductType(productType);
        }

        public void UpdateProductType(ProductTypeModel model)
        {
            ProductType productType = _customerRepo.GetProductType(model.ProductTypeId);
            productType.ProductTypeName = model.ProductTypeName;
            _customerRepo.UpdateProductType(productType);
        }

        public void DeleteProductType(int productTypeId)
        {
            ProductType productType = _customerRepo.GetProductType(productTypeId);
            _customerRepo.DeleteProductType(productType);
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
