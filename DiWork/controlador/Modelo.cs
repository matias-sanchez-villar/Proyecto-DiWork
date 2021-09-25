using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlador
{
    public class Modelo : Marca
    {
        public int IDModelo { get; set; }
        public string nombreModelo { get; set; }
        public bool estadoModelo { get; set; }
    }
}
