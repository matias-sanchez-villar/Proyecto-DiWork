namespace controlador
{
    public class Modelo : Marca
    {
        public int IDModelo { get; set; }
        public string nombreModelo { get; set; }
        public bool estadoModelo { get; set; }

        public Modelo() : base()
        {
            estadoModelo = true;
        }
    }
}
