using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Dtos;

namespace incodityReservation.Application.Models
{
    public class SearchVillaModel
    {
        
        public IEnumerable<VillaTableDto> Data { get; set; }

        // Searching
        public string? Name { get; set; }
        public string? City { get; set; }
        public double From { get; set; }
        public double To { get; set; }

        // Pagination
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        
    }
}
