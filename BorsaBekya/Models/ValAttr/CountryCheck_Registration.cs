
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BorsaBekya.Models.ViewModel;

namespace BorsaBekya.Models.ValAttr
{
    public class CountryCheck_Registration : ValidationAttribute
    {
        private readonly ApplicationDbContext _context;
        public CountryCheck_Registration()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //var userRegister = (RegistrationVm)validationContext.ObjectInstance;
            //if (userRegister.RoleId == 1)
            //{
            //    if (userRegister.CatId == 0 || userRegister.CityId == 0 || userRegister.RegionId == 0)
            //    {
            //        return new ValidationResult("امل البيانات الفارغه");
            //    }
            //    return ValidationResult.Success;
            //}
            //if (userRegister.CatId == 0 || userRegister.CityId == 0 || userRegister.RegionId == 0)
            //{
            //    return new ValidationResult("امل البيانات الفارغه");
            //}
            return ValidationResult.Success;
            //if()
            ////userLogin.Password = Crypto.encrypt(userLogin.Password);
            //var result = _context.Users.Any(
            //    user => user.Email.Equals(userLogin.Email, StringComparison.OrdinalIgnoreCase) &&
            //            user.Password == userLogin.Password);
            //if (result == false)
            //{
            //    return new ValidationResult("البريد الألكترونى او كلمه المرور غير صحيحه");
            //}

        }
    }
}