using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain;

namespace incodityReservation.Application.Mapping
{
    public class CityMapping :Profile
    {
        public CityMapping()
        {
            CreateMap<City, CityForShowDto>()
                .ForMember(p => p.Id, p => p.MapFrom(p => p.Id))
                .ForMember(p => p.Name, p => p.MapFrom(p => p.Name))
                .ForMember(p => p.ImageUrl, p => p.MapFrom(p => p.ImageUrl))
                .ForMember(p => p.ProvinceName, p => p.MapFrom(p => p.Province.Name)).ReverseMap();
        }
    }
}
