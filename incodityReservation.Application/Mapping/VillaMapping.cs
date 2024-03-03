using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Infrastructure;
using incodityReservation.Domain;

namespace incodityReservation.Application.Mapping
{
    public class VillaMapping:Profile
    {
        public VillaMapping()
        {
            CreateMap<Villa, VillaDto>()
                .ForMember(m => m.Id, m => m.MapFrom(m => m.Id))
                .ForMember(m => m.CreatedAt, m => m.MapFrom(m => m.CreatedAt.ToPersian()))
                .ForMember(m => m.UpdatedAt, m => m.MapFrom(m => m.UpdatedAt.Value.ToPersian()))
                .ForMember(m => m.DeletedAt, m => m.MapFrom(m => m.DeletedAt.Value.ToPersian()))
                .ForMember(m => m.IsDeleted, m => m.MapFrom(m => m.IsDeleted))
                .ForMember(m => m.CityId, m => m.MapFrom(m => m.CityId))
                .ForMember(m => m.Name, m => m.MapFrom(m => m.Name))
                .ForMember(m => m.Description, m => m.MapFrom(m => m.Description))
                .ForMember(m => m.Price, m => m.MapFrom(m => m.Price))
                .ForMember(m => m.ImageBytes, m => m.MapFrom(m => m.ImageBytes))
                .ForMember(m => m.Address, m => m.MapFrom(m => m.Address))
                .ForMember(m => m.StartDate, m => m.MapFrom(m => m.StartDate.ToPersian()))
                .ForMember(m => m.ExpireDate, m => m.MapFrom(m => m.ExpireDate.ToPersian()));


            CreateMap<AddVillaDto, Villa>()
                .ForMember(m => m.CityId, m => m.MapFrom(m => m.CityId))
                .ForMember(m => m.Name, m => m.MapFrom(m => m.Name))
                .ForMember(m => m.Description, m => m.MapFrom(m => m.Description))
                .ForMember(m => m.Price, m => m.MapFrom(m => m.Price))
                .ForMember(m => m.Address, m => m.MapFrom(m => m.Address))
                .ForMember(m => m.StartDate, m => m.MapFrom(m => m.StartDate.PersianToMiladi()))
                .ForMember(m => m.ExpireDate, m => m.MapFrom(m => m.ExpireDate.PersianToMiladi()));

            // CreateMap < TSource , TDestination >
            CreateMap<EditVillaDto, VillaDto>()

                //For Member ( destinationMember , map from ( source member ) )
                .ForMember(m => m.Id, m => m.MapFrom(m => m.Id))
                .ForMember(m => m.CityId, m => m.MapFrom(m => m.CityId))
                .ForMember(m => m.Name, m => m.MapFrom(m => m.Name))
                .ForMember(m => m.Description, m => m.MapFrom(m => m.Description))
                .ForMember(m => m.Price, m => m.MapFrom(m => m.Price))
                .ForMember(m => m.ImageBytes, m => m.MapFrom(m => m.ImageBytes.ConvertImageToByte()))
                .ForMember(m => m.Address, m => m.MapFrom(m => m.Address))
                .ForMember(m => m.StartDate, m => m.MapFrom(m => m.StartDate.PersianToMiladi()))
                .ForMember(m => m.ExpireDate, m => m.MapFrom(m => m.ExpireDate.PersianToMiladi()));


            CreateMap<Villa, VillaPageDto>()
                .ForMember(m => m.Id, m => m.MapFrom(m => m.Id))
                .ForMember(m => m.CityName, m => m.MapFrom(m => m.City.Name))
                .ForMember(m => m.Name, m => m.MapFrom(m => m.Name))
                .ForMember(m => m.Price, m => m.MapFrom(m => m.Price))
                .ForMember(m => m.ImageBytes, m => m.MapFrom(m => m.ImageBytes))
                .ForMember(m => m.StartDate, m => m.MapFrom(m => m.StartDate.ToPersian()))
                .ForMember(m => m.ExpireDate, m => m.MapFrom(m => m.ExpireDate.ToPersian()));
        }
    }
}
