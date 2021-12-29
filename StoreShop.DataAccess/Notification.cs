
namespace StoreShop.DataAccess
{
    internal class Notification
    {
    }
    public class SMS
    {
        [Key]
        public long Id { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool IsSent { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
