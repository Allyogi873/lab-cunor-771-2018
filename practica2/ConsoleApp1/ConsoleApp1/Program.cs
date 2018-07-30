using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Clase principal del programa.
    /// </summary>
    class Program
    {

        /// <summary>
        /// Método principal de la aplicación
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int num1 = 2;
            int num2 = 4;
            int num3 = 3;

            Console.Write("El resultado es: " + (num1+num2) + "\n");

            if (num1 > num2)
            {
                if (num1 > num3)
                {
                    Console.WriteLine("El mayor es: " + num1);
                }
                else {
                    Console.WriteLine("El mayor es: " + num3);
                }
            }
            else {
                if (num2 > num3)
                {
                    Console.WriteLine("El mayor es: " + num2);

                }
                else
                {
                    Console.WriteLine("El mayor es: " + num3);
                }
            }

            // Esto es un comentario de una línea

            /*
             * Esto es un comentario de varias líneas
             * :P
             */

            if (num1 > num2 && num1 > num3)
            {
                Console.WriteLine("El mayor es: " + num1);
            }
            else if (num2 > num1 && num2 > num3)
            {
                Console.WriteLine("El mayor es: " + num2);
            }
            else {
                Console.WriteLine("El mayor es: " + num3);
            }


            Console.Read();
        }
    }
}
