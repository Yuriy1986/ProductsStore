using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Infrastructure;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ProductsStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        //Login.
        void CreateAdmin();

        IEnumerable<string> GetAllLogins();
        
        string Login(DTOLoginViewModel dtoLoginViewModel);

        string ChangePassword(DTOChangePasswordViewModel dtoChangePasswordViewModel);

        string Register(DTORegisterViewModel dtoRegisterViewModel);

        string ResetPassword(DTOChangePasswordAdminViewModel dtoChangePasswordAdminViewModel);

        DTOEditViewModel GetInformation(string login);

        string EditUser(DTOEditViewModel dtoEditViewModel);

        string DeleteUser(string login);


    }
}
