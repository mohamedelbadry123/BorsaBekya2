using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BorsaBekya.Models
{
    [Table("tblCity")]
    public class AspCity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public AspCountry Country { get; set; }
        public int CountryId { get; set; }
    }
}