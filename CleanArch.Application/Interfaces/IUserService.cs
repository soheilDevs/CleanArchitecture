using CleanArch.Application.ViewModels;
using CleanArch.Domains.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        CheckUser CheckUser(string userName, string email);
        int RegisterUser(Users users);
    }
}