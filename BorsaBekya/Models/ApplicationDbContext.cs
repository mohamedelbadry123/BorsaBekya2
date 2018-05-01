using System.Data.Entity;


namespace BorsaBekya.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<AspRole> Roles { get; set; }

        public virtual DbSet<AspCountry> Countries { get; set; }

        public virtual DbSet<AspCity> Cities { get; set; }

        public virtual DbSet<AspRegions> Regionses { get; set; }

        public virtual DbSet<AspUser> Users { get; set; }

        public virtual DbSet<AspUserMeta> UsersMeta { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}