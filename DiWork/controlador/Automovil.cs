using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlador
{
    public class Automovil : Vehiculo
    {
        private string tipo;
        public int cantidadPuertas
        {
            get { return cantidadPuertas; }
            set
            {
                if (value > 0 && value <= 5)
                    cantidadPuertas = value;
            }
        }

        public void setTipo(Tipo tipo)
        {
            this.tipo = tipo.ToString();
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public string getTipo()
        {
            return tipo;
        }


    }

    public enum Tipo { compacto = 1, sedan, monovolumen, utilitario, lujo }
}
