using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentsApi;
using StudentsApi.ModelsUse;
using System.Windows.Forms;


namespace Assignemt3.Controllers
{
    public class LoginController : Controller
    {
      


        [HttpGet]
        public ActionResult Login()
        {
          
            var model = new LoginUser();
           
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
      
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.UserName, user.Password))
                {
                    Session["Pass"] = user.Password;
                    Session["User"] = user.UserName;
                    Session["Type"] = user.TypeId;
                    MessageBox.Show("User logat: "+ Session["User"]+" Tip: "+ Session["Type"]);
                  
                    if (user.TypeId == 2)
                    {
                        return RedirectToAction("LoginSecretary", "LoginSecretaries");
                    }   
                    else if (user.TypeId == 1)  
                    {
                        return RedirectToAction("LoginDoctor", "LoginDoctors");
                    }
                    else if (user.TypeId == 3)
                    {
                  
                        return RedirectToAction("LoginAdmin", "LoginAdmins");

                    }
                    return RedirectToAction("Create", "Patient");
                }
                else
                {
                    ModelState.AddModelError("", "Datele introduse pentru logare sunt incorecte!");
                    MessageBox.Show("Datele introduse pentru logare sunt incorecte!");
                }
            }
            return View("Login", user);
        }




    }
}
