using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsApi;
using StudentsApi.Providers;
using System.Windows.Forms;


namespace StudentsApi.Controllers
{
    public class ConsultationController : Controller
    {
        private DatabaseDB db = new DatabaseDB();
        private DoctorProvider doctorProvider = new DoctorProvider();
        // GET: Consultation
        public ActionResult Index()
        {
            var consultations = db.Consultations.Include(c => c.Doctor).Include(c => c.Patient);
            return View(consultations.ToList());
        }

        // GET: Consultation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
          
            ViewBag.DoctorId = new SelectList(doctorProvider.GetDisponibilityDoctors(), "Id", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name");
            MessageBox.Show("User logat: " + Session["User"]);

            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,DoctorId,Consult,Date")] Consultation consultation)
        {

            var doctor = doctorProvider.GetDoctorById(consultation.DoctorId);
            if (ModelState.IsValid)
            {
                db.Consultations.Add(consultation);
                db.SaveChanges();

                MessageBox.Show("Domnule doctor " + doctor.Name + "  " + " A ajuns un nou pacient!");
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId=  new SelectList(db.Doctors, "Id", "Name", consultation.Consult);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", consultation.PatientId);
            return View(consultation);
        }

        // GET: Consultation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", consultation.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", consultation.PatientId);
            return View(consultation);
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,DoctorId,Consult,Date")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", consultation.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", consultation.PatientId);
            return View(consultation);
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            db.Consultations.Remove(consultation);
            db.SaveChanges();
            return RedirectToAction("Index");
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
