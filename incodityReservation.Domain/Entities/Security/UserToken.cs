using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace incodityReservation.Domain.Entities.Security
{
    public class UserToken:IdentityUserToken<long>
    {
        public long Id { get; set; }
    }
}
