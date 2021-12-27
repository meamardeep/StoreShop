using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Repository;

namespace StoreShop.Presentation.Support
{
    public class ServiceExtensions
    {
    }
    public static class DependancyInjector
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<ICustomerManagement, CustomerManagement>();
            //services.AddScoped<ICustomerManagement>(s => new CustomerManagement(ControllerBase.GetUserSession()));
            services.AddScoped<ICustomerRepo, CustomerRepo>();

            services.AddScoped<IStoreManagement, StoreManagement>();
            services.AddScoped<IStoreRepo, StoreRepo>();

            services.AddScoped<IProductManagement, ProductManagement>();
            services.AddScoped<IProductRepo, ProductRepo>();

            services.AddScoped<ICartManagement, CartManagement>();
            services.AddScoped<ICartRepo, CartRepo>();
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Store, StoreModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<CustomerProductType, CustomerProductTypeModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Brand, BrandModel>().ReverseMap();
            CreateMap<ExceptionLog, ExceptionLogModel>().ReverseMap();
        }
    }
}
