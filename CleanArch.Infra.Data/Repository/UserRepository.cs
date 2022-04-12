using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domains.Interfaces;
using CleanArch.Domains.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly UniversityDbContext _context;

        public UserRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public bool IsUserExist(string email, string password)
        {
            return _context.Users.Any(u => u.Email == email && u.Password == password);
        }

        public void AddUser(Users users)
        {
            _context.Users.Add(users);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistUserEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
