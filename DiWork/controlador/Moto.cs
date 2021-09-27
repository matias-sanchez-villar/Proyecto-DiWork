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
