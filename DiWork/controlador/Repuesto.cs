namespace controlador
{
    public class Repuesto
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public float precio
        {
            get
            {
                return precio;
            }
            set
            {
                if (value >= 0)
                    precio = value;
            }
        }

        public bool estado { get; set; }

        public Repuesto()
        {
            estado = true;
        }
    }
}
