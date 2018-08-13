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
        List<Persona> lstPersonaTemp;
        Persona personaActual;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstPersona.Add(new Persona("3384833", "94993", "Juan Perez", "Guatemalteco", "Masculino", "Deportista"));
            lstPersona.Add(new Persona("7474738", "94993", "Luis Alvarado", "Guatemalteco", "Masculino", "Deportista"));
            lstPersona.Add(new Persona("8483832", "94993", "Tomacita Figueroa", "Guatemalteca", "Femenino", "Deportista"));
            lstPersona.Add(new Persona("8483829", "94993", "Daniel Salvador", "Guatemalteco", "Masculino", "Deportista"));
            lstPersona.Add(new Persona("7382947", "94993", "Carla López", "Guatemalteca", "Femenino", "Deportista"));
            lstPersona.Add(new Persona("8384732", "94993", "José Luis El puma", "Mexicano", "Masculino", "Deportista"));
            limpiarForm();
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
            

        }

        public void limpiarForm() {
            txtCUI.Text = "";
            txtNIT.Text = "";
            txtNombre.Text = "";
            txtNacionalidad.Text = "";
            txtProfesion.Text = "";
            txtSexo.Text = "";
            txtFecNacimiento.Value = DateTime.Now;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lstPersona;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            personaActual = lstPersona.ElementAt<Persona>(index);
            txtCUI.Text = personaActual.cui;
            txtFecNacimiento.Value = personaActual.fec_nacimiento;
            txtNacionalidad.Text = personaActual.nacionalidad;
            txtNombre.Text = personaActual.nombre_completo;
            txtProfesion.Text = personaActual.profesion;
            txtSexo.Text = personaActual.sexo;
            txtNIT.Text = personaActual.nit;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            personaActual.cui = txtCUI.Text;
            personaActual.nit = txtNIT.Text;
            personaActual.nombre_completo = txtNombre.Text;
            personaActual.nacionalidad = txtNacionalidad.Text;
            personaActual.profesion = txtProfesion.Text;
            personaActual.sexo = txtSexo.Text;
            personaActual.fec_nacimiento = txtFecNacimiento.Value;
            limpiarForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            lstPersona.Remove(personaActual);
            limpiarForm();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string txtBusq = (txtBusqueda.Text).ToUpper();

            lstPersonaTemp = lstPersona.Where(x => x.nombre_completo.ToUpper().Contains(txtBusq)).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lstPersonaTemp;
        }
    }
}
