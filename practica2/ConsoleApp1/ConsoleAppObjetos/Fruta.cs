using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppObjetos
{
    class Fruta
    {
        public string color { get; set; }
        public string textura { get; set; }
        public string sabor { get; set; }
        public string ancho { get; set; }
        public string forma { get; set; }
        public string peso { get; set; }
        protected string nombre { get; set; }

        public void imprimir()
        {
            Console.WriteLine("Nombre: " + this.nombre);
            Console.WriteLine("Forma: " + this.forma);
            Console.WriteLine("Sabor: " + this.sabor);
            Console.WriteLine("Color: " + this.color);
        }
    }
}
