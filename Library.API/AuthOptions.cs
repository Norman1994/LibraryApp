using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Library.API
{
    public class AuthOptions
    {
        //Издатель токена
        public const string ISSUER = "LibraryServer";

        //Потребитель токена
        public const string AUDIENCE = "UserClient";

        //Ключ для шифрования
        private const string KEY = "KulikovKazinPosipkina";

        //Время жизни токена - 1 минута
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
