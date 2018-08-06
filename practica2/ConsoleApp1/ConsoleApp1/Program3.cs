using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program3
    {
        static void Main(string[] args)
        {
            Funciones fnc = new Funciones();

            string val = fnc.DecToBin(128);

            int val2 = fnc.BinToDec("01010110");

            Console.WriteLine(val);
            Console.WriteLine(val2);

            string cadena = "Hola jóvenes como están?";
            string cadBina = "";
            for (int n = 0; n < cadena.Length; n++) {
                int cadInt = (int)cadena.ElementAt(n);
                cadBina = cadBina + " " + fnc.DecToBin(cadInt);
            }
            Console.WriteLine("\n\n" + cadBina);
            Console.Read();

        }
    }
}
