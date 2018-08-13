using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppObjetos
{
    class Manzana : Fruta
    {
        public Manzana() {
            this.nombre = "Manzana";
            this.peso = "44";
            this.sabor = "Dulce";
            this.color = "Rojo";
            this.forma = "Redonda";

        }

        public new void imprimir()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Nombre: " + this.nombre);
            Console.WriteLine("Forma: " + this.forma);
            Console.WriteLine("Sabor: " + this.sabor);
            Console.WriteLine("Color: " + this.color);
            Console.WriteLine("-------------------------------");
        }
    }
}
