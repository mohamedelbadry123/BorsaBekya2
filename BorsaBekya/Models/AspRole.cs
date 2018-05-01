
using System.ComponentModel.DataAnnotations.Schema;


namespace BorsaBekya.Models
{
    [Table("tblRole")]
    public class AspRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}