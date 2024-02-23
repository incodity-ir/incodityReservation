using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Application.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }


    public class CityForShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ProvinceName { get; set; }
    }

    public class CreateCityDto
    {
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    }
}
