using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Funciones
    {

        /// <summary>
        /// Permite convertir un número decimal a binario.
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public string DecToBin(int dec) {
            int a = dec;
            int b;
            string resu = "";
            for (int n = 1; n <= 8; n++) {

                if (a > 0)
                {
                    a = dec / 2;
                    b = dec % 2;
                    dec = a;
                    resu = b + resu;
                }
                else {
                    resu = 0 + resu;
                }
            }

            return resu;
        }

        public int BinToDec(string bin) {
            int fin = bin.Length;
            int valFin = 0;
            if (fin > 0){
                
                for (int n = fin-1; n >= 0; n--) {
                    int x = (int.Parse("" + bin.ElementAt(n)));
                    double val =  Math.Pow(2, (7-n));
                    val = x * val;

                    valFin += int.Parse(""+val);
                }
            }

            return valFin;
        }
    }
}
