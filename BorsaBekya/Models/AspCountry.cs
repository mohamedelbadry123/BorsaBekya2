using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BorsaBekya.Models
{
    [Table("tblCountry")]
    public class AspCountry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Name { get; set; }


    }
}