using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BorsaBekya.Models.ValAttr;

namespace BorsaBekya.Models.ViewModel
{
    public class RegistrationVm
    {
        public AspUser User { get; set; }

        public IEnumerable<AspCountry> Categories{ get; set; }
        [Required(ErrorMessage = "اختر الدوله")]
        public int CatId { get; set; }

        public IEnumerable<AspCity> Cities { get; set; }
        [Required]
        public int CityId { get; set; }

        public IEnumerable<AspRegions> Regiones { get; set; }
        [Required]
        public int RegionId { get; set; }

        public IEnumerable<AspRole> Roles { get; set; }


        public IEnumerable<string> FileName { get; set; }

        [Required(ErrorMessage = "اختر صوره")]
        public HttpPostedFileBase File { get; set; }

        
        public string Error { get; set; }
    }
}