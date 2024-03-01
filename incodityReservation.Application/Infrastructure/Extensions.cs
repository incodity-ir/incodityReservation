using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace incodityReservation.Application.Infrastructure
{
    public static class Extensions
    {
        public static string ToPersian(this DateTime date)
        {
            var persianDate = new PersianCalendar();
            return $"{persianDate.GetYear(date)}/{persianDate.GetMonth(date)}/{persianDate.GetDayOfMonth(date)}";
        }

        public static DateTime PersianToMiladi(this string date)
        {
            //1376/01/01
            if (date.Length != 10) throw new ArgumentException(nameof(date));
            var persianDate = new PersianCalendar();
            int year = Convert.ToInt32(date.Substring(0, 4));
            var convertDate = persianDate.ToDateTime(year, Convert.ToInt32(date.Substring(5, 2)),
                Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, 0);
            return convertDate;
        }

        public async static Task<byte[]> ConvertImageToByte(this IFormFile file)
        {
            byte[] image = null;
            if (file != null && file.Length > 0)
            {
                using (var memoryStram = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStram);
                    image = memoryStram.ToArray();
                }
            }
            return image;
        }

    }
}
