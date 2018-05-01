using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BorsaBekya.Models.ValAttr;

namespace BorsaBekya.Models
{
    [Table("tblUser")]
    public class AspUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "ادخل اسمك هنا")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ادخل الأميل الخاص بك")]
        [EmailAddress(ErrorMessage = "صيغه الأميل ليست صحيحه")]
        [EmailCheck_AspUser]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "ادخل رقم الهاتف الخاص بك")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "صيغه رقم الهاتف غير صحيحه")]
        public string Phone { get; set; }

        
        public string Image { get; set; }

        //[ForeignKey("CountryId")]
        //public AspCountry Country { get; set; }
        //public int CountryId { get; set; }

        //[ForeignKey("CityId")]
        //public AspCity City { get; set; }
        //public int CityId { get; set; }

        //[ForeignKey("RegionId")]
        //public AspRegions Regions { get; set; }
        //public int RegionId { get; set; }

        [ForeignKey("RoleId")]
        public AspRole Role { get; set; }
        public int RoleId { get; set; }


        [Required(ErrorMessage = "ادخل الرقم السرى")]
        [StringLength(255, ErrorMessage = "الرقم السرى ضعيف", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuthKey { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
    }
}