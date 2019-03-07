using Microsoft.AspNet.Identity;

namespace ProductsStore.BLL.Infrastructure
{
    public class UserPasswordValidator : PasswordValidator
    {
        public UserPasswordValidator()
        {
            RequiredLength = 6;
            RequireNonLetterOrDigit = true;
            RequireDigit = true;
            RequireLowercase = true;
            RequireUppercase = true;
        }
    }
}
