using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BorsaBekya.Models;

namespace BorsaBekya.Controllers.api
{
    public class RegistrationApiController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult GetCities(int catId)
        {
            var cities = _context.Cities.Where(c => c.CountryId == catId).Select(c => new {c.Name,c.Id}).ToList();
            
            return Ok(cities);
        }

        [HttpGet]
        public IHttpActionResult Regions(int cityId)
        {
            var regions = _context.Regionses.Where(c => c.CityId == cityId).Select(c => new { c.Name, c.Id }).ToList();

            return Ok(regions);
        }

        [HttpGet]
        public IHttpActionResult AllCountry()
        {
            var countries = _context.Countries.Select(c => new { c.Name, c.Id }).ToList();
            return Ok(countries);
        }
    }
}
