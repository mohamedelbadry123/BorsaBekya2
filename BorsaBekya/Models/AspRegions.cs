using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BorsaBekya.Models
{
    [Table("tblRegion")]
    public class AspRegions
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("CityId")]
        public AspCity City { get; set; }
        public int CityId { get; set; }
    }
}