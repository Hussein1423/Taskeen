using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class LoginDTO
    {
        public string? UsernameOrEmail { get; set; }
        public string? HashPassword { get; set; }
    }

}
