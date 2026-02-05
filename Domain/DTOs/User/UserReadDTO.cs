using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class UserReadDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

}
