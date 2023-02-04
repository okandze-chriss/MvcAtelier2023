using MvcGLAtelelier2023.Models;
using PagedList;
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
        int pageSize = 2;

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ListerClient(int? page)
        {
            page = page.HasValue ? page: 1;
            var liste = getListClient();
            int pageNumber = (page ?? 1);

            return View(liste.ToPagedList(pageNumber, pageSize));  
        }


        private List<ClientViewModel> getListClient()
        {
            List<ClientViewModel> lister = new List<ClientViewModel>();
            var liste = db.clients.Join(db.personnes, x => x.IdPers, y => y.IdPers, (x,y) =>
            new {x.IdPers, x.Sexe, y.AdressePers, y.EmailPers, y.PrenomPers, y.NomPers, y.TelPers}).ToList();


            foreach(var item in liste)
            {
                ClientViewModel c = new ClientViewModel();
                c.TelPers = item.TelPers;
                c.Sexe = item.Sexe;
                c.PrenomPers = item.PrenomPers;
                c.NomPers = item.NomPers;
                c.IdPers= item.IdPers;
                c.EmailPers= item.EmailPers;
                c.AdressePers = item.AdressePers;
                lister.Add(c);
            }

            return lister;
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

                return RedirectToRoute("ListerClient");
            }

            return View(client);
        }

    }
}