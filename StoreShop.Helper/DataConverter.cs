global using System.Text;

namespace StoreShop.Helper
{
    public static class DataConverter
    {
        public static string ConvertToBase64(string srcString)
        {
            var messageBytes = Encoding.UTF8.GetBytes(srcString);
            return Convert.ToBase64String(messageBytes);
        }
    }
}