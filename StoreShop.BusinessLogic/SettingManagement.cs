using AutoMapper;
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
        
        public SettingManagement(ISettingRepo settingRepo, ICustomerManagement customerManagement,IMapper mapper)
        {
            _settingRepo = settingRepo;
            _customerManagement = customerManagement;
            _mapper = mapper;
        }

        #region CRUD
        public StoreModel GetStore(int storeId)
        {
            Store store = _settingRepo.GetStore(storeId);
            return _mapper.Map<StoreModel>(store);
        }

        public List<StoreModel> GetStores(int customerId)
        {
            IEnumerable<Store> stores = _settingRepo.GetStores(customerId);
            List<StoreModel> storeModels = _mapper.Map<List<StoreModel>>(stores.ToList());
            return storeModels;
        }

        public void CreateStore(StoreModel storeModel)
        {
            storeModel.AddressId = _customerManagement.CreateAddress(storeModel.Address);
            Store store = _mapper.Map<Store>(storeModel);
            store.IsActive = true;
            //store.CustomerId = SessionManager.

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
