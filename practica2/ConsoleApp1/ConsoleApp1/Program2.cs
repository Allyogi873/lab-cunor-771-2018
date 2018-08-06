using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program2
    {
        static void Main(string[] args) {
            var num1 = 1;

            switch (num1) {
                case 1:
                    Console.WriteLine("Opción 1");
                    break;
                case 2:
                    Console.WriteLine("Opción 2");
                    break;
            }

            int n = 1;

            for (n = 1; n <= 10; n++) {
                Console.WriteLine("Hola " + n);
            }

            for (n = 1; n <= 10; n++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Console.WriteLine("Resultado: " + n + " * " + y + " = " + (n*y));
                }
            }

            int n1 = 1;

            while (n1 < 100) {
                Console.WriteLine(n1);
                n1++;

            }
            n1 = 1;

            do
            {
                Console.WriteLine(n1);
                n1++;
            } while (n1 < 100);

            Console.Read();
        }
    }
}
