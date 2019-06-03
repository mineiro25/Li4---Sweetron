using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweeTron.Models;

namespace SweeTron.Controllers
{
    public class PassosController : Controller
    {
        private SweeTronEntities3 db = new SweeTronEntities3();

        // GET: Passos
        public ActionResult Index()
        {
            return View(db.Passo.ToList());
        }

        // GET: Passos/Details/5
        public ActionResult Details(int? id, string array)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passo passo = db.Passo.Find(id);
            System.Diagnostics.Debug.WriteLine(array);
            if (array == null)
            {

            }
            else
            {
                int[] s_ids = Array.ConvertAll(array.Split('-'), s => int.Parse(s)).Skip(1).ToArray();
                ViewBag.ids_passos = s_ids;

            }

            if (passo == null)
            {
                return HttpNotFound();
            }
            return View(passo);
        }

        // GET: Passos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Passo,Descricao,Video")] Passo passo)
        {
            if (ModelState.IsValid)
            {
                db.Passo.Add(passo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passo);
        }

        // GET: Passos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passo passo = db.Passo.Find(id);
            if (passo == null)
            {
                return HttpNotFound();
            }
            return View(passo);
        }

        // POST: Passos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Passo,Descricao,Video")] Passo passo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passo);
        }

        // GET: Passos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passo passo = db.Passo.Find(id);
            if (passo == null)
            {
                return HttpNotFound();
            }
            return View(passo);
        }

        // POST: Passos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passo passo = db.Passo.Find(id);
            db.Passo.Remove(passo);
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
