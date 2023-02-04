using MvcGLAtelelier2023.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGLAtelelier2023.Controllers
{
    public class GerantController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();
        int pageSize = 2;

        // GET: Gerant/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ListerGerant(int? page)
        {
            page = page.HasValue ? page : 1;
            var liste = getListGerant();

            int pageNumber = (page ?? 1);
            return View(liste.ToPagedList(pageNumber, pageSize));
        }


        private List<GerantVeiwModel> getListGerant()
        {
            List<GerantVeiwModel> lister = new List<GerantVeiwModel>();
            var liste = db.gerants.Join(db.personnes, x => x.IdPers, y => y.IdPers, (x, y) =>
            new { x.IdPers, y.AdressePers, y.EmailPers, y.PrenomPers, y.NomPers, y.TelPers }).ToList();


            foreach (var item in liste)
            {
                GerantVeiwModel g = new GerantVeiwModel();
                g.TelPers = item.TelPers;
                g.PrenomPers = item.PrenomPers;
                g.NomPers = item.NomPers;
                g.IdPers = item.IdPers;
                g.EmailPers = item.EmailPers;
                g.AdressePers = item.AdressePers;
                lister.Add(g);
            }

            return lister;
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

                return RedirectToRoute("ListerGerant");
            }

            return View(gerant);
        }
    }
}