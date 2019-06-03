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
    public class ReceitaController : Controller
    {
        private SweeTronEntities3 db = new SweeTronEntities3();

        // GET: Receita
        public ActionResult Index()
        {
            return View(db.Receita.ToList());
        }

        // GET: Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            Dictionary<Ingrediente, double? > dicionario = new Dictionary<Ingrediente, double? >();
            //HashSet<Ingrediente> ingredientes = new HashSet<Ingrediente>();
            System.Diagnostics.Debug.WriteLine("HOLLA");

            foreach (Possui possui in receita.Possui)
            {
                int id_ing = possui.ID_Ingrediente;
                double? quantidade = possui.Quantidade;
                Ingrediente ing = db.Ingrediente.Find(id_ing);
                System.Diagnostics.Debug.WriteLine(ing.ToString());
                dicionario.Add(ing,quantidade);
            }
            ViewBag.Ingredientes = dicionario;

            List<int> id_passos = new List<int>();

            foreach(Passo passo in receita.Passo)
            {
                id_passos.Add(passo.ID_Passo);
            }

            ViewBag.ids_passos = id_passos.ToArray();

            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Receita,Rating,Dificuldade,Nome,Duracao,Preparacao,Video,Foto")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Receita.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Receita,Rating,Dificuldade,Nome,Duracao,Preparacao,Video,Foto")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receita.Find(id);
            db.Receita.Remove(receita);
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
