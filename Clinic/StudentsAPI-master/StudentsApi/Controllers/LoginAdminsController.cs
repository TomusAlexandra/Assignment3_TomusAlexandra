using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsApi;
using StudentsApi.ModelsUse;

namespace StudentsApi.Controllers
{
    public class LoginAdminsController : Controller
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: LoginAdmins
        public ActionResult Index()
        {
            return View(db.LoginAdmins.ToList());
        }

        // GET: LoginAdmins/Create
        public ActionResult LoginAdmin()
        {
            return View();
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
