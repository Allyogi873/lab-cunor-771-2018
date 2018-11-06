using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waPruebaLogin.Helpers
{
    public class Convertidor
    {
        #region FIELDS

        //- 1 unidad = 1 unidad

        private Dictionary<int, string> unidad;

        //- 1 decena = 10 unidades

        private Dictionary<int, string> decena;

        //- 1 centena = 100 unidades

        private Dictionary<int, string> centenas;

        //- 1 unidad de mil = 1 000 unidades

        //- 1 decena de mil = 10 000 unidades

        //- 1 centena de mil = 100 000 unidades

        //- 1 unidad de millón = 1 000 000 unidades

        //- 1 decena de millón= 10 000 000 unidades

        //- 1 centena de millón = 100 000 000 unidades

        #endregion

        #region CONSTRUCTOR

        public Convertidor()

        {

            unidad = new Dictionary<int, string>();

            decena = new Dictionary<int, string>();

            centenas = new Dictionary<int, string>();

            //1-9

            unidad.Add(1, "uno ");

            unidad.Add(2, "dos ");

            unidad.Add(3, "tres ");

            unidad.Add(4, "cuatro ");

            unidad.Add(5, "cinco ");

            unidad.Add(6, "seis ");

            unidad.Add(7, "siete ");

            unidad.Add(8, "ocho ");

            unidad.Add(9, "nueve ");

            //10-99

            decena.Add(10, "diez ");

            decena.Add(11, "once ");

            decena.Add(12, "doce ");

            decena.Add(13, "trece ");

            decena.Add(14, "catorce ");

            decena.Add(15, "quince ");

            decena.Add(16, "dieciseis ");

            decena.Add(17, "diecisiete ");

            decena.Add(18, "dieciocho ");

            decena.Add(19, "diecinueve ");

            decena.Add(20, "veinte ");

            decena.Add(30, "treinta ");

            decena.Add(40, "cuarenta ");

            decena.Add(50, "cincuenta ");

            decena.Add(60, "sesenta ");

            decena.Add(70, "setenta ");

            decena.Add(80, "ochenta ");

            decena.Add(90, "noventa ");

            //100-1000

            centenas.Add(100, "cien ");

            centenas.Add(200, "doscientos ");

            centenas.Add(300, "trescientos ");

            centenas.Add(400, "cuatrocientos ");

            centenas.Add(500, "quinientos ");

            centenas.Add(600, "seiscientos ");

            centenas.Add(700, "setecientos ");

            centenas.Add(800, "ochocientos ");

            centenas.Add(900, "novecientos ");

        }

        #endregion

        #region METHODOS

        public string Convertir(string monto, bool isUpper)

        {

            string rs = string.Empty;

            decimal mnd = decimal.Parse(monto);

            string mon = string.Format("{0:c2}", mnd).Replace("$", "").Replace(".00", "");

            if (mon.IndexOf(",") == -1)

            {

                if (monto.Length == 3)

                {

                    rs = GetCentena(monto);

                }

                else if (monto.Length == 2)

                {

                    rs = GetDecena(monto);

                }

                else

                {

                    rs = GetUnidad(monto);

                }

            }

            else

            {

                List<String> args = mon.Split(',').ToList();

                rs = GetMontoRecursivo(args);

            }

            //

            if (isUpper)

            {

                rs = rs.ToUpper();

            }

            return rs;

        }

        //

        private string GetUnidad(string monto)

        {

            int key = int.Parse(monto);

            string value = string.Empty;

            unidad.TryGetValue(key, out value);

            return value;

        }

        //

        private string GetDecena(string monto)

        {

            int d = int.Parse(monto[0].ToString());

            int u = int.Parse(monto[1].ToString());

            int key = 0;

            string value = string.Empty;

            if (u == 0)

            {

                key = d * 10;

                decena.TryGetValue(key, out value);

                return value;

            }

            else

            {

                string un = string.Empty;

                if (u > 0)

                {

                    un = GetUnidad(monto[1].ToString());

                }

                key = d * 10;

                decena.TryGetValue(key, out value);

                return value + un;

            }

        }

        //

        private string GetCentena(string monto)

        {

            if (monto.Length == 1)

            {

                return GetUnidad(monto);

            }

            int c = int.Parse(monto[0].ToString());

            int d = int.Parse(monto.Substring(1, 2));

            int key = 0;

            string value = string.Empty;

            if (d == 0)

            {

                key = c * 100;

                centenas.TryGetValue(key, out value);

                return value;

            }

            else

            {

                key = c * 100;

                centenas.TryGetValue(key, out value);

                string cen = value;

                string dec;

                if (d > 9)

                {

                    dec = GetDecena(monto.Substring(1, 2));

                    cen += "y " +dec;

                }

                else

                {

                    dec = GetDecena(monto.Substring(1, 2));

                    cen += "y " +dec;

                }

                return cen;

            }

        }

        //

        private string GetMontoRecursivo(List<string> monto)

        {

            int count = monto.Count();

            int idx = 1;

            string rs = String.Empty;

            switch (count)

            {

                //millones

                case 3:

                    {

                        foreach (String cdu in monto)

                        {

                            if (idx == 1)

                            {

                                rs = GetCentena(cdu) + "millones ";

                            }

                            else if (idx == 2)

                            {

                                rs += "y " +GetCentena(cdu) + "mil ";

                            }

                            else

                            {

                                rs += "y " +GetCentena(cdu);

                            }

                            idx++;

                        }

                        break;

                    }

                //milles

                case 2:

                    {

                        if (int.Parse(monto[0]) > 0)

                        {

                            if (int.Parse(monto[0]) == 1)

                            {

                                rs = "Un Mil ";

                            }

                            else

                            {

                                rs = GetUnidad(monto[0]) + "Mil";

                            }

                            if (int.Parse(monto[1]) > 0)

                            {

                                rs += " y " +GetCentena(monto[1]);

                            }

                        }

                        break;

                    }

                //cintos

                case 1:

                    {

                        rs = GetCentena(monto[0]);

                        break;

                    }

            }

            return rs + "";

        }

        #endregion
    }
}