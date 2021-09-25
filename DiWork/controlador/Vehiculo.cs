using System.Collections.Generic;

namespace controlador
{
    public abstract class Vehiculo
    {
        public int ID { get; set; }
        public Modelo modelo { get; set; }
        public string patente { get; set; }
        public bool estado { get; set; }
        public List<Desperfecto> desperfecto
        {
            get
            {
                return desperfecto;
            }
            set
            {
                desperfecto.AddRange(value);
            }
        }

        public Vehiculo()
        {
            estado = true;
            desperfecto = new List<Desperfecto>();
        }
    }
}
