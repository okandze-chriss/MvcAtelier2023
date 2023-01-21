using MvcGLAtelelier2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGLAtelelier2023.Controllers
{
    public class GerantController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();

        // GET: Gerant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerant/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPers,NomPers,PrenomPers,AdressePers,EmailPers,TelPers, Matricule")] GerantVeiwModel gerant)
        {
            if (ModelState.IsValid)
            {
                Personne personne = new Personne();
                personne.NomPers = gerant.NomPers;
                personne.PrenomPers = gerant.PrenomPers;
                personne.AdressePers = gerant.AdressePers;
                personne.EmailPers = gerant.EmailPers;
                personne.TelPers = gerant.TelPers;
                db.personnes.Add(personne);
                db.SaveChanges();

                Gerant g = new Gerant();

                g.IdPers = personne.IdPers;
                g.Matricule = "6667AAZ";
                db.gerants.Add(g);
                db.SaveChanges();

                return RedirectToRoute("index");
            }

            return View(gerant);
        }
    }
}