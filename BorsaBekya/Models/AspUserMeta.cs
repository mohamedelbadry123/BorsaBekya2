using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BorsaBekya.Models
{
    [Table("tblUser_meta")]
    public class AspUserMeta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public AspUser Users { get; set; }
        public int UserId { get; set; }

        [Required]
        public string ColName { get; set; }

        [Required]
        public string Value { get; set; }
    }
}