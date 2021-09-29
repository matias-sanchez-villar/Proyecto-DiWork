using System.Collections.Generic;

namespace controlador
{
    public abstract class Vehiculo
    {
        public Modelo modelo { get; set; }
        public string patente { get; set; }
        public bool estado { get; set; }
        public List<Desperfecto> desperfecto { get; set; }

        public Vehiculo()
        {
            estado = true;
            desperfecto = new List<Desperfecto>();
            modelo = new Modelo();
        }
    }
}
