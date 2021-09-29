namespace controlador
{
    public class Automovil : Vehiculo
    {
        public Tipo tipo { get; set; }
        public int cantidadPuertas { get; set; }

    }

    public enum Tipo { compacto = 1, sedan, monovolumen, utilitario, lujo }
}
