using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Metodos
    {
        int op;
        string msjFallo;
        /// <summary>
        /// Constructor de Clase.
        /// </summary>
        public Metodos() {
            this.op = 1;
            this.msjFallo = "";
        }

        /// <summary>
        /// Constructor de clase sobre cargado.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="msj"></param>
        public Metodos(int op, string msj) {
            this.op = op;
            this.msjFallo = msj;
        }

        static void Main(string[] args)
        {
            string msj = "";
            Console.WriteLine("El resultado es: " + suma(2, 3, ref msj));

            Console.WriteLine(msj);

            double pot = potencia(2,5);

            Console.WriteLine(pot);

            Console.Read();
        }

        #region "Geovani"

        /// <summary>
        /// Método que permite sumar dos números enteros (num1 y num2).
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static int suma(int num1, int num2, ref string msj) {
            msj = "Hola programador";
            return num1 + num2;
        }

        /// <summary>
        /// Potencia a la 2 de un número cualquiera
        /// </summary>
        /// <param name="num1"></param>
        /// <returns></returns>
        static double potencia(int num1) {
            return Math.Pow(num1, 2);
        }

        /// <summary>
        /// Potencia N de un número X
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double potencia(int num1, int num2) {
            return Math.Pow(num1, num2);
        }
        #endregion
    }
}
