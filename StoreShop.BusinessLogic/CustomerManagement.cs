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
        public CustomerManagement(ICustomerRepo customerRepo, IMapper mapper, UserSessionModel userSession)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _userSession = userSession;
        }

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


        public long CreateAddress(AddressModel addressModel)
        {
            Address address = _mapper.Map<Address>(addressModel);
            return  _customerRepo.CreateAddress(address);
             
        }
    }
    
}
