using MvcGLAtelelier2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGLAtelelier2023.Controllers
{

    public class InscriptionController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPers,NomPers,PrenomPers,AdressePers,EmailPers,TelPers, Sexe")] ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                Personne personne = new Personne();
                personne.NomPers = client.NomPers;
                personne.PrenomPers= client.PrenomPers;
                personne.AdressePers = client.AdressePers;
                personne.EmailPers= client.EmailPers;
                personne.TelPers= client.TelPers;
                db.personnes.Add(personne);
                db.SaveChanges();

                Client c = new Client();

                c.IdPers = personne.IdPers;
                c.Sexe = client.Sexe;
                db.clients.Add(c);
                db.SaveChanges();

                return RedirectToRoute("index");
            }

            return View(client);
        }

    }
}