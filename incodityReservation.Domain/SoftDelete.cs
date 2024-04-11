using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Domain
{
    public interface ISoftDelete
    {
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
