using DataLayer;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCMS.Controllers
{
    public class AccountController : Controller
    {
        private ILoginRepository loginRepository;
        MyCMSContext db = new MyCMSContext();
        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {

                if (loginRepository.IsUserExists(login.UserName,login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Password", "نام کاربری یا رمز عبور اشتباه است");
                }
            }
            return View(login);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}