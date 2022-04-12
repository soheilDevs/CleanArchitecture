using CleanArch.Domains.Models;

namespace CleanArch.Domains.Interfaces
{
    public interface IUserRepository
    {
        bool IsUserExist(string email, string password);



        void AddUser(Users users);
        bool IsExistUserName(string userName);
        bool IsExistUserEmail(string email);
        void Save();
    }
}