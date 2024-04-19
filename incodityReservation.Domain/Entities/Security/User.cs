﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace incodityReservation.Domain.Entities.Security
{
    public class User:IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; }
    }
}