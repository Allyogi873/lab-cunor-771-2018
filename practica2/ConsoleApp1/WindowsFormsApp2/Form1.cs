using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<Persona> lstPersona = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Persona nuevaPersona = new Persona();
            nuevaPersona.cui = txtCUI.Text;
            nuevaPersona.nit = txtNIT.Text;
            nuevaPersona.nombre_completo = txtNombre.Text;
            nuevaPersona.nacionalidad = txtNacionalidad.Text;
            nuevaPersona.profesion = txtProfesion.Text;
            nuevaPersona.sexo = txtSexo.Text;
            nuevaPersona.fec_nacimiento = txtFecNacimiento.Value;

            lstPersona.Add(nuevaPersona);
            limpiarForm();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lstPersona;
            

        }

        public void limpiarForm() {
            txtCUI.Text = "";
            txtNIT.Text = "";
            txtNombre.Text = "";
            txtNacionalidad.Text = "";
            txtProfesion.Text = "";
            txtSexo.Text = "";
            txtFecNacimiento.Value = DateTime.Now;
        }
    }
}
