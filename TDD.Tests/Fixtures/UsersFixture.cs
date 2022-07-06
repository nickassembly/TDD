using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.API.Models;

namespace TDD.Tests.Fixtures
{
   public static class UsersFixture 
   {
        public static List<User> GetTestUsers() =>
                new()
                {
                    new User
                    {
                        Name = "Test User 1",
                        Email = "test.user.1@kellercar.com",
                        Address = new Address
                        {
                            Street = "123 Market St.",
                            City = "Somewhere",
                            ZipCode = "213124",
                        }
                    },
                    new User
                    {
                        Name = "Test User 2",
                        Email = "test.user.2@kellercar.com",
                        Address = new Address
                        {
                            Street = "123 Main St.",
                            City = "Nowhere",
                            ZipCode = "70736",
                        }
                    },
                    new User
                    {
                        Name = "Test User 3",
                        Email = "test.user.3@kellercar.com",
                        Address = new Address
                        {
                            Street = "777 Hale St.",
                            City = "Anywhere",
                            ZipCode = "70032",
                        }
                    },
                };
   }
}
