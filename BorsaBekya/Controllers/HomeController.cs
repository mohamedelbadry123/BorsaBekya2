using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BorsaBekya.Models;
using BorsaBekya.Models.ViewModel;

namespace BorsaBekya.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var path = Server.MapPath("~/Content/UserProfile/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            var viewModel = new RegistrationVm
            {
                Categories = _context.Countries.ToList(),
                Cities = _context.Cities.ToList(),
                Regiones = _context.Regionses.ToList(),
                Roles = _context.Roles.ToList(),
                FileName = files,
                User = new AspUser()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegistrationVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new RegistrationVm()
                    {
                        //CatId = model.CatId,
                        //CityId = model.CityId,
                        //RegionId = model.RegionId,
                        //RoleId = model.User.RoleId,
                        //Categories = model.Categories,
                        //Cities = model.Cities,
                        //Regiones = model.Regiones,
                        User = model.User,
                        Roles = _context.Roles.ToList()

                    };
                    return View(viewModel);
                }

                var addPath = Path.Combine(Server.MapPath("~/Content/UserProfile/"), model.File.FileName);
                var data = new byte[model.File.ContentLength];
                model.File.InputStream.Read(data, 0, model.File.ContentLength);
                using (var sw = new FileStream(addPath, FileMode.Create))
                {
                    sw.Write(data, 0, data.Length);
                }

                int insertedRoleId = 2;
                if (model.User.RoleId == 0)
                {
                    insertedRoleId = 2;
                }
                var newUser = new AspUser()
                {
                    Name = model.User.Name,
                    Email = model.User.Email,
                    Password = Crypto.encrypt(model.User.Password),
                    Image = model.File.FileName,
                    Phone = model.User.Phone,
                    RoleId = insertedRoleId
                };

                // --------------------- Insert Data in User Table --------------------------
                _context.Users.Add(newUser);
                _context.SaveChanges();

                // --------------------- Insert Data in User_meta Table ---------------------

                // [Insert User Country]
                AspUserMeta obj = new AspUserMeta();
                obj.UserId = newUser.Id;
                obj.ColName = "Country";
                obj.Value = model.CatId.ToString();
                _context.UsersMeta.Add(obj);
                _context.SaveChanges();

                // [Insert User City]
                obj.UserId = newUser.Id;
                obj.ColName = "City";
                obj.Value = model.CityId.ToString();
                _context.UsersMeta.Add(obj);
                _context.SaveChanges();

                // [Insert User Region]
                obj.UserId = newUser.Id;
                obj.ColName = "Region";
                obj.Value = model.CityId.ToString();
                _context.UsersMeta.Add(obj);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {

            var viewModel = new LoginVm();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginVm model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoginVm()
                {
                    Email = "",
                    Password = ""
                };
                return View(viewModel);
            }
            var userIndb = _context.Users.Single(c => c.Email == model.Email);
            var userId = userIndb.Id;
            //var AuthKey = userIndb.AuthKey;
            //var userId_AuthKey = userId + "||" + AuthKey;
            //var Enc = Crypto.encrypt(userId_AuthKey);
            //var isRegisterd = _context.Registrations.Count(c => c.UserId == userId);
            var name = userIndb.Name;
            HttpCookie cookie = new HttpCookie("User");
            cookie.Values.Add("UserID", userIndb.Id.ToString());
            cookie.Values.Add("Name", userIndb.Name);
            cookie.Values.Add("Role", userIndb.RoleId.ToString());
            //cookie.Values.Add("LastName", userIndb.LastName);
            //cookie.Values.Add("Email", userIndb.Email);
            //cookie.Values.Add("Role", userIndb.AspRoleId.ToString());
            //cookie.Values.Add("Level", userIndb.AspStudentLvlId.ToString());
            //cookie.Values.Add("Enc", Enc);
            //cookie.Values.Add("isRegisterBefore", isRegisterd.ToString());
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index","HomeAdmin", new { area = "Admin" });

        }
        
    }
}
