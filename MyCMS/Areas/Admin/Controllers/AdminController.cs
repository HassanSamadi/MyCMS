using DataLayer;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        ILoginRepository loginRepository;
        MyCMSContext db = new MyCMSContext();
        public AdminController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View(loginRepository.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAdminViewModel admin)
        {
            if (admin.Password != admin.RePassword)
            {
                ModelState.AddModelError("RePassword", "کلمه عبور و تکرار آن یکسان نیستند");
                return View(admin);
            }
            AdminLogin adminLogin = new AdminLogin()
            {
                UserName = admin.UserName,
                Email = admin.Email,
                Password = admin.Password
            };
            loginRepository.InsertAdmin(adminLogin);
            loginRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin admin = loginRepository.GetAdminById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return PartialView(admin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
                loginRepository.UpdateAdmin(admin);
                loginRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin admin = loginRepository.GetAdminById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return PartialView(admin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loginRepository.DeleteAdmin(id);
            loginRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                loginRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}