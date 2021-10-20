using E_Commerce_WebApp.DBModels;
using E_Commerce_WebApp.FormDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce_WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var user = new UserLoginFormDataModel();
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(UserLoginFormDataModel user)
        {
            if (ModelState.IsValid)
            {
                string username = IsValid(user.Email, user.Password);
                if (username != String.Empty)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Dati non corretti");
                }
            }
            return View(user);
        }

        public ActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerRegister(CustomerRegisterFormDataModel customerUser)
        {
            if (ModelState.IsValid)
            {
                using (var dbCtx = new ECommerceContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    string encPassword = crypto.Compute(customerUser.Password);

                    User newCustomer = dbCtx.Users.Create();
                    newCustomer.UserName = customerUser.UserName;
                    newCustomer.Email = customerUser.Email;
                    newCustomer.Password = encPassword;
                    newCustomer.PasswordSalt = crypto.Salt;
                    newCustomer.UserID = Guid.NewGuid();
                    newCustomer.IsAdmin = false;

                    dbCtx.Users.Add(newCustomer);
                    dbCtx.SaveChanges();

                    return RedirectToAction("Index", "Account");
                }
            }
            return View(customerUser);
        }

        public ActionResult AdminRegister()
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public string IsValid(string email,string password)
        {
            string username = String.Empty;
            var crypto = new SimpleCrypto.PBKDF2();

            using (var dbCtx = new ECommerceContext()){
                var user = dbCtx.Users.FirstOrDefault(x => x.Email == email);
                if(user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                        username = user.UserName;
                }
            }
                return username;
        }
    }
}