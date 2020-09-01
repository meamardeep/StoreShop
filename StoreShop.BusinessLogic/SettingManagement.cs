using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreShop.BusinessLogic
{
    public class SettingManagement : ISettingManagement
    {
        private readonly ISettingRepo _settingRepo;
        private readonly ICustomerManagement _customerManagement;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        //private UserSessionModel userSessionModel;

        public SettingManagement(/*UserSessionModel userSessionModel,*/ ISettingRepo settingRepo, ICustomerManagement customerManagement,IMapper mapper,
            IWebHostEnvironment webHostEnvironment, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            //this.userSessionModel = userSessionModel;

            _settingRepo = settingRepo;
            _customerManagement = customerManagement;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }


        #region CRUD
        public StoreModel GetStore(int storeId)
        {
            Store store = _settingRepo.GetStore(storeId);
            return _mapper.Map<StoreModel>(store);
        }

        public List<StoreModel> GetStores(int customerId)
        {
            
            //var environment = Environment.MachineName;
            //var applicationName = _webHostEnvironment.ApplicationName;
            //var envirnmentName = _webHostEnvironment.EnvironmentName;
            //var applicationContentFilePath = _webHostEnvironment.WebRootPath;

            //var contentFileprovide = _webHostEnvironment.ContentRootFileProvider;
            //var webrootFileProvider = _webHostEnvironment.WebRootFileProvider;

            IEnumerable<Store> stores = _settingRepo.GetStores(customerId);
            List<StoreModel> storeModels = _mapper.Map<List<StoreModel>>(stores.ToList());
            return storeModels;
        }

        public void CreateStore(StoreModel storeModel)
        {
            storeModel.AddressId = _customerManagement.CreateAddress(storeModel.Address);
            Store store = _mapper.Map<Store>(storeModel);
            store.IsActive = true;
            //store.CustomerId = userSessionModel.SessionCustomerId;

            _settingRepo.CreateStore(store);
        }

        public void DeleteStore(int storeId)
        {
            Store store = _settingRepo.GetStore(storeId);
            _settingRepo.DeleteStore(store);
        }

        public void UpdateStore(StoreModel storeModel)
        {
            Store store = _mapper.Map<Store>(storeModel);
            _settingRepo.UpdateStore(store);
        }

        
        #endregion
    }
}
