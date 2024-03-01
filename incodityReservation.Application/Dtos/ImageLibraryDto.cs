using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace incodityReservation.Application.Dtos
{
    public class ImageLibraryDto:BaseDto
    {
        public int VillaId { get; set; }
        public IFormFile Image { get; set; }
        
    }
}
