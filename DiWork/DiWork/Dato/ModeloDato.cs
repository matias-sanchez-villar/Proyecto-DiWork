using DiWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiWork.Dato
{
    public class ModeloDato
    {

        public IEnumerable<Modelos> listar()
        {
            try
            {
                using (DiWorkdbEntities contexto = new DiWorkdbEntities())
                {
                    return contexto.Modelos.Include("Marcas").ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}