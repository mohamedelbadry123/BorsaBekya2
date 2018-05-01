
using System.Linq;
using System.Web.Http;
using BorsaBekya.Models;
using BorsaBekya.Models.Dto;

namespace BorsaBekya.Controllers.api
{
    public class CategoryApiController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            var countryInDb = from c in _context.Countries
                select new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name
                };
            return Ok(countryInDb);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var countryInDb = _context.Countries.Single(c => c.Id == id);
            _context.Countries.Remove(countryInDb);
            _context.SaveChanges();
        }
    }
}
