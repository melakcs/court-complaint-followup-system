using CourtCaseApi.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
//using CourtCaseApi.Models;

//using System.Web.Mvc;

namespace CourtCaseApi.Controllers
{
    public class LoginController : Controller
    {
        public CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.User userr)
        {
            //if (ModelState.IsValid)  
            //{  
            if (IsValid(userr.UserName, userr.Password))
            {
                FormsAuthentication.SetAuthCookie(userr.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userr);
        }

        private bool IsValid(string UserName, string Password)
        {
            bool IsValid = false;
            var user = db.Users.FirstOrDefault(p => p.UserName == UserName &&p.Password==Password);
            if ((user != null)&&(Password!= null))
            {
                if (user.Password == Password)
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }
    }
}