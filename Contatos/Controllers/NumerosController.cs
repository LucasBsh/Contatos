using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contatos.Models;

namespace Contatos.Controllers
{
    public class NumerosController : Controller
    {
        private NumerosDBContext db = new NumerosDBContext();

        // GET: Numeros
        public ActionResult Index()
        {
            return View(db.Numero.ToList());
        }

        // GET: Numeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numeros numeros = db.Numero.Find(id);
            if (numeros == null)
            {
                return HttpNotFound();
            }
            return View(numeros);
        }

        // GET: Numeros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Numeros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Register([Bind(Include = "ID,nome,numero,operadora")] Numeros numeros)
        {
            if (ModelState.IsValid)
            {
                db.Numero.Add(numeros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(numeros);
        }

        // GET: Numeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numeros numeros = db.Numero.Find(id);
            if (numeros == null)
            {
                return HttpNotFound();
            }
            return View(numeros);
        }

        // POST: Numeros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nome,numero,operadora")] Numeros numeros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numeros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(numeros);
        }

        // GET: Numeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numeros numeros = db.Numero.Find(id);
            if (numeros == null)
            {
                return HttpNotFound();
            }
            return View(numeros);
        }

        // POST: Numeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Numeros numeros = db.Numero.Find(id);
            db.Numero.Remove(numeros);
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
