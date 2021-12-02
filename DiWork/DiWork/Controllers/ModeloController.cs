using DiWork.Dato;
using DiWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiWork.Controllers
{
    public class ModeloController : Controller
    {
        ModeloDato dato = new ModeloDato();

        public ActionResult Index()
        {
            try
            {
                IEnumerable<Modelos> lista = dato.listar();
                return View(lista);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


    }
}