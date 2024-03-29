﻿namespace StoreShop.Data
{
    public class UserModel
    {
        public IFormFile ProfilePhoto { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public DateTime? DOB { get; set; }
        public long CellNo { get; set; }
        public int? OTP { get; set; }
        public bool? LoginAttemptCounter { get; set; }
        public int RoleId { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }       
        public int CountryCode { get; set; }                
        public List<int> CountryCodes { get; set; }

        public long? ProfilePhotoId { get; set; }   
        public UserPhotoModel UserPhotoModel { get; set; }  
        public int GenderId { get; set; }
        public List<DropDownItem> Genders
        {
            get 
            {
                return new List<DropDownItem>() { 
                new DropDownItem(){ Text="--Select Gender--",Value = 0},
                new DropDownItem(){ Text = "Male", Value = 1},
                new DropDownItem(){ Text = "Female", Value = 2},
                new DropDownItem (){ Text = "Others", Value = 3}
                };
            }         
        }
        
    }
    public class UserPhotoModel
    {        
        public long ProfilePhotoId { get; set; }
        //public byte[] Photo { get; set; }
        //public string PhotoName { get; set; }
        public long UserId { get; set; }
        public string Guid { get; set; }
        public string FileName { get; set; }

    }
    public class UserStoreMapping
    {
        public long UserStoreMappingId { get; set; }
        public long UserId { get; set; }
        public int StoreId { get; set; }

        public UserModel User { get; set; }
        public StoreModel Store { get; set; }
    }

    public class UserSessionModel
    {
       public int SessionCustomerId { get; set; }
        public long SessionUserId { get; set; }
        //public int SessionStoreId { get; set; }
    }

}
