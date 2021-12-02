using DiWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiWork.Dato
{
    public class MotoDato
    {

        public IEnumerable<Motos> Listar()
        {
            try
            {
                using (DiWorkdbEntities contexto = new DiWorkdbEntities())
                {
                    return contexto.Motos.AsNoTracking().ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}