using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.API.Models;

namespace TDD.API.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }

    public class UserService : IUserService
    {
        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
