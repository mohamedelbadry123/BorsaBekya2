using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BorsaBekya.Models;
using BorsaBekya.Models.ValAttr;
using BorsaBekya.Models.ViewModel;

namespace BorsaBekya.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool CheckCookies()
        {
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                //string InputEnc = Request.Cookies["User"]["Enc"];
                //string ouputEnc = Crypto.Decrypt(InputEnc.ToString());
                //string[] Key = ouputEnc.Split(new string[] { "||" }, StringSplitOptions.None);
                //string KeyId = Key[0];
                //string KeyAuth = Key[1];
                //int Usercount = _context.Users.Where(c => c.UserId.ToString() == KeyId && c.AuthKey.ToString() == KeyAuth).Count();
                //if (Usercount == 1)
                //{

                //    var user = _context.Users.Single(c => c.Id.ToString() == Request.Cookies["User"]["UserID"]);
                //    ViewData["Id"] = user.Id;
                //    ViewData["Name"] = user.Name;
                //    ViewData["Role"] = user.RoleId.ToString();
                //    //ViewData["FullName"] = user.FirstName + " " + user.LastName;
                //    //ViewData["Email"] = user.Email;
                //    //ViewData["Role"] = user.AspRoleId.ToString();
                //    //ViewData["Level"] = user.AspStudentLvlId.ToString();
                //    //ViewData["Key"] = InputEnc;
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                string userId = Request.Cookies["User"]["UserID"];
                var user = _context.Users.Single(c => c.Id.ToString() == userId);
                ViewData["Id"] = user.Id;
                ViewData["Name"] = user.Name;
                ViewData["Role"] = user.RoleId.ToString();
                return true;
            }
            return false;
        }
        // GET: Admin/Country
        public ActionResult Index()
        {
            if (CheckCookies())
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult Add()
        {
            
            if (CheckCookies())
            {
                var viewModel = new CategoryVm();
                return View("CategoryForm", viewModel);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        public ActionResult Save(CategoryVm model)
        {
            if (model.Id == 0)
            {
                var newCountry = new AspCountry
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _context.Countries.Add(newCountry);
                _context.SaveChanges();
                return RedirectToAction("Index", "Country");
            }
            return RedirectToAction("Index", "Country");
        }
    }
}