using CleanArch.Domains.Models;

namespace CleanArch.Domains.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(Users users);
        bool IsExistUserName(string userName);
        bool IsExistUserEmail(string email);
        void Save();
    }
}