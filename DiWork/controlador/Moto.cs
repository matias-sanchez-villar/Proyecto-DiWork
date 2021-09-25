using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlador
{
    public class Moto : Vehiculo
    {
        public int cilindrada
        {
            get
            {
                return cilindrada;
            }
            set
            {
                if (value > 0)
                    cilindrada = value;
            }
        }
    }
}
