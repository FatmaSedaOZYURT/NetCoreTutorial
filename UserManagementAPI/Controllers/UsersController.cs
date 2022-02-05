using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Fake;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _users.FirstOrDefault(a=>a.Id==id);
        }
        [HttpPost]
        public User Post([FromBody]User addedUser)
        {
            _users.Add(addedUser);
            return addedUser;
        }

        [HttpPut]
        public User Put([FromBody] User updatedUser)
        {
            var editedUser = _users.FirstOrDefault(a => a.Id == updatedUser.Id);
            editedUser.FirstName = updatedUser.FirstName;
            editedUser.LastName = updatedUser.LastName;
            editedUser.Address = updatedUser.Address;
            return editedUser;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(a => a.Id == id);
            if (deletedUser != null)
            {
                _users.Remove(deletedUser);
            }
        }
    }
}
