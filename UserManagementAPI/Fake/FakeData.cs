using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Models;

namespace UserManagementAPI.Fake
{
    public static class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers(int count)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                    .RuleFor(x=>x.Id, y=>y.IndexFaker+1)
                    .RuleFor(x=>x.FirstName, y=>y.Name.FirstName())
                    .RuleFor(x=>x.LastName, y=>y.Name.LastName())
                    .RuleFor(x=>x.Address, y=>y.Address.FullAddress())
                    .Generate(count);
            }
            return _users;
        }
    }
}
