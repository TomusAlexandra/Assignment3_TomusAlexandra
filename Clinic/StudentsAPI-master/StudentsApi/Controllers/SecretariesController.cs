using StudentsApi.ModelsUse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsApi.Controllers
{
    public class SecretariesController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
          
            var model = new LoginUser();

            return View("Login");
        }

    }
}