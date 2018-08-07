using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Persona
    {
        public Persona() {
            this.cui = "";
            this.nit = "";
            this.nombre_completo = "";
            this.fec_nacimiento = DateTime.Now;
            this.nacionalidad = "";
            this.sexo = "";
            this.profesion = "";
        }
        public string cui { get; set; }
        public string nit { get; set; }
        public string nombre_completo { get; set; }
        public DateTime fec_nacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string sexo { get; set; }
        public string profesion { get; set; }
    }
}
