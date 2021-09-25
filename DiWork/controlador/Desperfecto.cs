using System.Collections.Generic;

namespace controlador
{
    public class Desperfecto
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public string manoDeObra { get; set; }
        public int tiempo { get; set; }
        public List<Repuesto> repuesto
        {
            get
            {
                return repuesto;
            }
            set
            {
                repuesto.AddRange(value); /// Tenmos que validar
            }
        }

        public bool estado { get; set; }

        public Desperfecto()
        {
            estado = true;
            repuesto = new List<Repuesto>();
        }

    }
}
