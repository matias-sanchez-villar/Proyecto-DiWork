using DiWork.Dato;
using DiWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiWork.Controllers
{
    public class MarcaController : Controller
    {
        MarcaDato dato = new MarcaDato();

        //Index Lista todas las marcas
        public ActionResult Index()
        {
            IEnumerable<Marcas> lista = dato.listar();
            return View(lista);
        }



    }
}