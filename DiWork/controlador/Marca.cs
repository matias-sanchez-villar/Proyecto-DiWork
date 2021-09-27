namespace controlador
{
    public class Marca
    {
        public int IDMarca { get; set; }
        public string nombreMarca { get; set; }
        public bool estadoMarca { get; set; }

        public Marca()
        {
            estadoMarca = true;
        }

    }
}
