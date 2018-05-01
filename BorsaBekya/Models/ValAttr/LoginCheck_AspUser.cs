using BorsaBekya.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace BorsaBekya.Models.ValAttr
{
    public class LoginCheck_AspUser : ValidationAttribute
    {
        private readonly ApplicationDbContext _context;
        public LoginCheck_AspUser()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var userLogin = (LoginVm)validationContext.ObjectInstance;
            userLogin.Password = Crypto.encrypt(userLogin.Password);
            var result = _context.Users.Any(
                        user => user.Email.Equals(userLogin.Email, StringComparison.OrdinalIgnoreCase) &&
                        user.Password == userLogin.Password);
            if (result == false)
            {
                return new ValidationResult("البريد الألكترونى او كلمه المرور غير صحيحه");
            }
            return ValidationResult.Success;
        }
    }
}