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
    public class LoginDoctorsController : Controller
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: LoginDoctors
        public ActionResult Index()
        {
            return View(db.LoginDoctors.ToList());
        }


        // GET: LoginDoctors/Create
        public ActionResult LoginDoctor()
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
