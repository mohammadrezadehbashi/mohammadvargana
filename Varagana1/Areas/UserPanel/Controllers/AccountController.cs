using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ViewModel;
using System.Web.Security;

namespace Varagana1.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        Varagana_DBEntities db = new Varagana_DBEntities();
        // GET: UserPanel/Account
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Single(u=>u.UserName==User.Identity.Name);
                string oldPasswordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                if (user.Password == oldPasswordHash)
                {
                   string HashNewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    user.Password = HashNewPassword;
                    db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("oldPassword", "گذرواژه فعلی درست نمی باشد");
                }
            }
            return View();
        }
    }
}