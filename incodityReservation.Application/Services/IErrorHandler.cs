using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Services
{
    public interface IErrorHandler
    {
        string ErrorMessage { get; set; }
        int StatusCode { get; set; }
        void GetError(Exception ex);
    }

    public class ErrorHandler : IErrorHandler
    {
        public string ErrorMessage { get; set; } = "خطا";
        public int StatusCode { get; set; } = 500;
        public void GetError(Exception ex)
        {
            ErrorMessage = "خطا - لطفا با پشتیبانی سایت تماس بگیرید.";
            if (ex.GetType() == typeof(DivideByZeroException))
            {
                ErrorMessage = "خطای تقسیم بر صفر";
                StatusCode = 521;
            }

            if (ex.GetType() == typeof(CryptographicException))
            {
                ErrorMessage = "خطای رمز گشایی";
                StatusCode = 522;
            }

            if (ex.GetType() == typeof(SqlException))
            {
                ErrorMessage = "خطای پایگاه داده";
                SqlException sqlex = ex as SqlException;
                ErrorMessage = GetSqlServerError(sqlex);
            }

            if (ex.GetType() == typeof(DbUpdateException))
            {
                SqlException sqlex = ex.InnerException as SqlException;
                ErrorMessage = GetSqlServerError(sqlex);
            }
        }


        string GetSqlServerError(SqlException sqlex)
        {
            if (sqlex.Number == 515)
            {
                ErrorMessage = "اطلاعات فیلد های ستاره دار تکمیل نشده است";
                StatusCode = 530;
            }

            if (sqlex.Number == 2627)
            {
                ErrorMessage = "اطلاعات تکراری است";
                StatusCode = 531;
            }

            if (sqlex.Number == 547)
            {
                ErrorMessage = " به دلیل اینکه اطلاعات به قسمت های دیگر وابسته است، قابلیت تغییر نیست ";
                StatusCode = 532;
            }

            if (sqlex.Number == 0 || sqlex.Number == 2 || sqlex.Number == -2)
            {
                ErrorMessage = "عدم دسترسی به پایگاه داده ";
                StatusCode = 533;
            }

            return ErrorMessage;
        }
    }
}
