using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlador
{
    public abstract class Vehiculo
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string patente { get; set; }
        public bool estado { get; set; }
        public List<Desperfecto> desperfecto {
            get
            {
                return desperfecto;
            }
            set
            {
                desperfecto.AddRange(value);
            }
        }

        public Vehiculo ()
        {
            estado = true;
            desperfecto = new List<Desperfecto>();
        }
    }
}
