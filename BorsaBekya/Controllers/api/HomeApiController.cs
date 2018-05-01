
using System;
using System.Linq;
using System.Web.Http;
using BorsaBekya.Models;
using BorsaBekya.Models.ViewModel;
using Microsoft.Ajax.Utilities;

namespace BorsaBekya.Controllers.api
{
    public class HomeApiController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        [HttpPost]
        
        public IHttpActionResult Login(LoginVm model)
        {
            var result = _context.Users.Any(
                user => user.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) &&
                        user.Password == model.Password);
            if (result == false)
            {
                return BadRequest("Username or Password is Wrong");
            }
            return Ok();
        }
    }
}
