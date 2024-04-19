using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Application.Dtos
{
    public class UserDto
    {
    }

    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public required string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
    }

    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
