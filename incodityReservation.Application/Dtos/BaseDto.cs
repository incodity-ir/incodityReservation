using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Application.Dtos
{
    public abstract class BaseDto:IBaseDto<int>,IDateDto<string>
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string CreatedAt { get; set; }
        [Display(Name = "تاریخ بروز رسانی")]
        public string? UpdatedAt { get; set; }
        [Display(Name = "تاریخ حذف")]
        public string? DeletedAt { get; set; }
        [Display(Name = "آیا حذف شده")]
        public bool IsDeleted { get; set; } = false;
    }
}
