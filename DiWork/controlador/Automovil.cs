namespace controlador
{
    public class Automovil : Vehiculo
    {
        public Tipo tipo { get; set; }
        public int cantidadPuertas
        {
            get { return cantidadPuertas; }
            set
            {
                if (value > 0 && value <= 5)
                    cantidadPuertas = value;
            }
        }

    }

    public enum Tipo { compacto = 1, sedan, monovolumen, utilitario, lujo }
    ///Para asignar tipo.
}
