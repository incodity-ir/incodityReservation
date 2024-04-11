using incodityReservation.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace incodityReservation.Application.Dtos
{
    public class VillaDto:BaseDto
    {
        [Display(Name = "شناسه شهر")]
        public int CityId { get; set; }
        [Display(Name = "نام ویلا")]
        public string Name { get; set; }
        [Display(Name = "توضیحات ویلا")]
        public string? Description { get; set; }
        [Display(Name = "اجاره بها")]
        public double Price { get; set; }
        [Display(Name = "تصویر ویلا")]
        public byte[]? ImageBytes { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ExpireDate { get; set; }
        //navigation properties
        public CityDto City { get; set; }
        public ICollection<ImageLibraryDto>? ImageLibraries { get; set; }
    }

    /// <summary>
    /// افزودن ویلای جدید
    /// </summary>
    public class AddVillaDto
    {
        [Display(Name = "شناسه شهر")]
        public int CityId { get; set; }
        [Display(Name = "نام ویلا")]
        public string Name { get; set; }
        [Display(Name = "توضیحات ویلا")]
        public string? Description { get; set; }
        [Display(Name = "اجاره بها")]
        public double Price { get; set; }
        [Display(Name = "تصویر ویلا")]
        public IFormFile? ImageBytes { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ExpireDate { get; set; }
    }

    public class EditVillaDto
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "شناسه شهر")]
        public int CityId { get; set; }
        [Display(Name = "نام ویلا")]
        public string Name { get; set; }
        [Display(Name = "توضیحات ویلا")]
        public string? Description { get; set; }
        [Display(Name = "اجاره بها")]
        public double Price { get; set; }
        [Display(Name = "تصویر ویلا")]
        public IFormFile? ImageBytes { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ExpireDate { get; set; }
    }

    public class VillaPageDto
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "نام شهر")]
        public int CityName { get; set; }
        [Display(Name = "نام ویلا")]
        public string Name { get; set; }
        [Display(Name = "اجاره بها")]
        public double Price { get; set; }
        [Display(Name = "تصویر ویلا")]
        public IFormFile? ImageBytes { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ExpireDate { get; set; }
    }

    public class VillaTableDto
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "نام شهر")]
        public string CityName { get; set; }
        [Display(Name = "نام ویلا")]
        public string Name { get; set; }
        [Display(Name = "اجاره بها")]
        public double Price { get; set; }
        [Display(Name = "تصویر ویلا")]
        public byte[]? ImageBytes { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ExpireDate { get; set; }
    }
}
