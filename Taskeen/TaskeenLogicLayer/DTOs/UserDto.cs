using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;

namespace TaskeenLogicLayer.DTOs
{
    public class UserDto
    {
        public string Role { get; set; } = "";
        public int UserId { get; set; }
        public string Username { get; set; } = "";

        public string FullName { get; set; }

        public UserDto(User user)
        {            
            UserId = user.UserId;
            Username = user.Username;
            Role = user.Role;
            FullName = $"{user.FirstName} {user.SecondName} {user.LastName}".Trim();
        }
    }
}
