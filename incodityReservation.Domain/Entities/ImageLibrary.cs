using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Domain.Entities
{
    public class ImageLibrary:BaseEntity
    {
        public virtual int VillaId { get; set; }
        public byte[] Image { get; set; }
        //navigation properties
        public virtual Villa Villa { get; set; }
    }
}
