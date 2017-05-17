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
    public class LoginSecretariesController : Controller
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: LoginSecretaries
        public ActionResult Index()
        {
            return View(db.LoginSecretaries.ToList());
        }

        // GET: LoginSecretaries/Create
        public ActionResult LoginSecretary()
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
