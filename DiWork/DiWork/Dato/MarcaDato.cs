using DiWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiWork.Dato
{
    public class MarcaDato
    {

        public IEnumerable<Marcas> listar()
        {
            using (DiWorkdbEntities contexto = new DiWorkdbEntities())
            {
                return contexto.Marcas.AsNoTracking().Where(x=> x.estado == true).ToList();
            }
        }
        
    }
}