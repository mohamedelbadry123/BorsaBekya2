using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BorsaBekya.Models;

namespace BorsaBekya.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/HomeAdmin
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
        public ActionResult Index()
        {
            if (CheckCookies())
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["User"] != null)
            {
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}