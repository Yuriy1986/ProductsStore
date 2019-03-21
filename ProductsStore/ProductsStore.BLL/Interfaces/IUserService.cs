using System;
using ProductsStore.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        // Oonly when creating a database !!! 
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
