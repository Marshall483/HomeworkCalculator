using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DiffAuth
{
    public class AuthOptions
    {
        public const string ISSUER = "borschTeam"; // издатель токена
        public const string AUDIENCE = "cocksuckers"; // потребитель токена
        const string KEY = "jopapopa228_1337";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
