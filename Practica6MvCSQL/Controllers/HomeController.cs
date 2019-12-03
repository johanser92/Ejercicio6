using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica6MvCSQL;
using Practica6MvCSQL.Models;

namespace Practica6MvCSQL.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroPeliculas rp = new RegistroPeliculas();

            return View(rp.RecupearTodos());
        }
        public ActionResult Grabar()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Grabar(FormCollection collection)
        {
            RegistroPeliculas rp = new RegistroPeliculas();
            Peliculas peli = new Peliculas
            {
                Codigo = int.Parse(collection["Codigo"]),
                Titulo = collection["Titulo"],
                Director = collection["Director"],
                AutorPrincipal = collection["AutorPrincipal"],
                NumAutores = int.Parse(collection["NumAutores"]),
                Duracion = float.Parse(collection["Duracion"].ToString()),
                Estreno = int.Parse(collection["Estreno"]),
            };
            rp.GrabarPelicula(peli);
            return RedirectToAction("Index");
        }
        public ActionResult Borrar(int cod)
        {
            RegistroPeliculas Peli = new RegistroPeliculas();
            Peli.Borrar(cod);
            return RedirectToAction("Index");

        }
        public ActionResult Modificar(int cod)
        {
            RegistroPeliculas Peli = new RegistroPeliculas();
            Peliculas rpt = Peli.Recuperar(cod);
            return View(rpt);
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection collection)
            
        {
            RegistroPeliculas peli = new RegistroPeliculas();
            Peliculas rpt = new Peliculas
            {

                Codigo = int.Parse(collection["Codigo"]),
                Titulo = collection["Titulo"],
                Director = collection["Director"],
                AutorPrincipal = collection["AutorPrincipal"],
                NumAutores = int.Parse(collection["NumAutores"]),
                Duracion = float.Parse(collection["Duracion"]),
                Estreno = int.Parse(collection["Estreno"]),
            };
            peli.Modificar(rpt);
            return RedirectToAction("Index");
            
        }
          
    }
}