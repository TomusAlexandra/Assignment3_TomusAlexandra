using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsApi;

namespace StudentsApi.Controllers
{
    public class SecretaryController : Controller
    {
        private DatabaseDB db = new DatabaseDB();

        // GET: Secretary
        public async Task<ActionResult> Index()
        {
            var secretaries = db.Secretaries.Include(s => s.User);
            return View(await secretaries.ToListAsync());
        }

        // GET: Secretary/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = await db.Secretaries.FindAsync(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            return View(secretary);
        }

        // GET: Secretary/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Secretary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,UserId")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                db.Secretaries.Add(secretary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", secretary.UserId);
            return View(secretary);
        }

        // GET: Secretary/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = await db.Secretaries.FindAsync(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", secretary.UserId);
            return View(secretary);
        }

        // POST: Secretary/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,UserId")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", secretary.UserId);
            return View(secretary);
        }

        // GET: Secretary/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = await db.Secretaries.FindAsync(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            return View(secretary);
        }

        // POST: Secretary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Secretary secretary = await db.Secretaries.FindAsync(id);
            db.Secretaries.Remove(secretary);
            await db.SaveChangesAsync();
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
