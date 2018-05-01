
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using BorsaBekya.Models.ValAttr;


namespace BorsaBekya.Models.ViewModel
{
    public class LoginVm
    {
        [Required(ErrorMessage = "ادخل البريد الألكترونى")]
        [EmailAddress(ErrorMessage = "تأكد من صيغه البريد الألكترونى المدخل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ادخل كلمه المرور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [LoginCheck_AspUser]
        public string Error { get; set; }
        
    }
}