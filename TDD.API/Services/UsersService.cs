using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.API.Models;

namespace TDD.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }

    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
