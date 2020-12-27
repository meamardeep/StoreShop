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
    public class StoreManagement : IStoreManagement
    {
        private readonly IStoreRepo _storeRepo;
        private readonly ICustomerManagement _customerManagement;
        private readonly IMapper _mapper;
        private UserSessionModel userSession;
        public StoreManagement(IStoreRepo storeRepo, ICustomerManagement customerManagement, IMapper mapper)
        {
            _storeRepo = storeRepo;
            _customerManagement = customerManagement;
            _mapper = mapper;
        }

        public StoreManagement(UserSessionModel userSessionModel)
        {
            userSession = userSessionModel;
        }
        #region CRUD
        public StoreModel GetStore(int storeId)
        {
            Store store = _storeRepo.GetStore(storeId);
            return _mapper.Map<StoreModel>(store);
        }

        public List<StoreModel> GetStores(int customerId)
        {
            IEnumerable<Store> stores = _storeRepo.GetStores(customerId);
            List<StoreModel> storeModels = _mapper.Map<List<StoreModel>>(stores.ToList());
            return storeModels;
        }

        public void CreateStore(StoreModel storeModel, UserSessionModel userSessionModel)
        {
            storeModel.AddressId = _customerManagement.CreateAddress(storeModel.Address);
            Store store = _mapper.Map<Store>(storeModel);
            store.IsActive = true;
            store.CustomerId = userSessionModel.SessionCustomerId;
            // If null value is not assigned then Addrees entity will have value and entity framework 
            //will create a new  address record again(but address record is already created in above code)
            store.Address = null;  

            _storeRepo.CreateStore(store);
        }

        public void DeleteStore(int storeId)
        {
            Store store = _storeRepo.GetStore(storeId);
            _storeRepo.DeleteStore(store);
        }

        public void UpdateStore(StoreModel model)
        {
            _customerManagement.UpdateAddress(model.Address);

            Store store = _storeRepo.GetStore(model.StoreId);
            store.StoreName = model.StoreName;           
            _storeRepo.UpdateStore(store);
        }


        #endregion
    }
}
