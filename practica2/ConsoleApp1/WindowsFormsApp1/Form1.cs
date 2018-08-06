using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadToBin_Click(object sender, EventArgs e)
        {
            Funciones fnc = new Funciones();

            string cadena = txtEntrada.Text;
            string cadBina = "";
            for (int n = 0; n < cadena.Length; n++)
            {
                int cadInt = (int)cadena.ElementAt(n);
                cadBina = cadBina + fnc.DecToBin(cadInt) + " ";
            }

            txtSalida.Text = cadBina;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBinToCad_Click(object sender, EventArgs e)
        {
            string[] arrBin = txtEntrada.Text.Split(' ');
            string resu = "";
            Funciones fnc = new Funciones();
            for (int n = 0; n < arrBin.Length; n++) {
                resu = resu + ( (char)fnc.BinToDec(arrBin[n]));
            }

            txtSalida.Text = resu;
        }
    }
}
