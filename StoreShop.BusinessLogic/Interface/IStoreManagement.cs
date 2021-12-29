namespace StoreShop.BusinessLogic
{
    public interface IStoreManagement
    {
        List<StoreModel> GetStores(int customerId);
        StoreModel GetStore(int storeId);
        void CreateStore(StoreModel storeModel, UserSessionModel userSessionModel);
        void UpdateStore(StoreModel storeModel);
        void DeleteStore(int storeId);
    }
}
