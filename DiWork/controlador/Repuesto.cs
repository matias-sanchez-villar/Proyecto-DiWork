namespace controlador
{
    public class Repuesto
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }

        public bool estado { get; set; }

        public Repuesto()
        {
            estado = true;
        }
    }
}
