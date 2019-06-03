﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SweeTron.Models;

namespace SweeTron.Controllers
{
    public class HomeController : Controller
    {
        private SweeTronEntities3 db = new SweeTronEntities3();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID_Utilizador,Nome,Data_Nascimento,Admin,Username,Password,Email")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Utilizador
                            where u.Username == utilizador.Username && u.Password == utilizador.Password
                            select u);

                if (user.ToList<Utilizador>().Count() == 0) ModelState.AddModelError("", "Username e/ou Password Incorrectos!");
                else
                {
                    IQueryable<bool> admin = (from u in db.Utilizador
                                              where u.Username == utilizador.Username && u.Password == utilizador.Password
                                              select u.Admin);
                    bool admin2;
                    foreach (bool b in admin)
                    {
                        admin2 = b;
                        if (admin2 == true) return RedirectToAction("Index/", "Receita");
                        return RedirectToAction("Index/", "Utilizador");
                    }
                }
            }

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

}
}