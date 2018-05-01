using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BorsaBekya.Models.ViewModel;

namespace BorsaBekya.Models.ValAttr
{
    public class EmailCheck_AspUser : ValidationAttribute
    {
        private readonly ApplicationDbContext _context;
        public EmailCheck_AspUser()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var userLogin = (AspUser)validationContext.ObjectInstance;
            var result = _context.Users.Any(user => user.Email.Equals(userLogin.Email));
            if (result == true)
            {
                return new ValidationResult("البريد الألكترونى مستخدم من قبل شخص اخر");
            }
            return ValidationResult.Success;
        }
    }
}