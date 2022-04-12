using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domains.Interfaces;
using CleanArch.Domains.Models;

namespace CleanArch.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public CheckUser CheckUser(string userName, string email)
        {
            bool userNameIsValid = _repository.IsExistUserName(userName);
            bool emailIsValid = _repository.IsExistUserEmail(email.Trim().ToLower());
           
            if (userNameIsValid&&emailIsValid)
            {
                return ViewModels.CheckUser.UsrNameAndEmailNotValid;
            }
            else if (emailIsValid)
            {
                return ViewModels.CheckUser.EmailNotValid;
            }
            else if (userNameIsValid)
            {
                return ViewModels.CheckUser.UserNameNotValid;
            }

            return ViewModels.CheckUser.Ok;
        }

        public int RegisterUser(Users users)
        {
            _repository.AddUser(users);
            _repository.Save();
            return users.UserId;
        }

        public bool IsUserExist(string email, string password)
        {
            return _repository.IsUserExist(email.Trim().ToLower(), PasswordHelper.EncodePasswordMd5(password));
        }
    }
}