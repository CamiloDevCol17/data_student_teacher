using System;
using System.Windows.Forms;

namespace Ingreso_usuarios
{
    public partial class Form1 : Form
    {
        private Persona persona;  // Variable para almacenar la instancia de Persona

        public Form1()
        {
            InitializeComponent();
            persona = new Persona();  // Inicializamos la instancia de Persona por defecto
            HabilitarControlesPorTipoPersona();
        }

        private void radProfesor_CheckedChanged(object sender, EventArgs e)
        {
            // Lógica específica para el RadioButton de Profesor
            if (radProfesor.Checked)
            {
                // Crear una nueva instancia de Trabajador cuando selecciona Profesor
                persona = new Trabajador();
            }
            HabilitarControlesPorTipoPersona();
        }

        private void radEstudiante_CheckedChanged(object sender, EventArgs e)
        {
            // Lógica específica para el RadioButton de Estudiante
            if (radEstudiante.Checked)
            {
                // Crear una nueva instancia de Estudiante cuando selecciona Estudiante
                persona = new Estudiante();
            }
            HabilitarControlesPorTipoPersona();
        }

        private void btnCapturarDatos_Click(object sender, EventArgs e)
        {
            // Lógica para capturar datos
            persona.Nombre = txtNombre.Text;

            if (persona is Trabajador trabajador)
            {
                trabajador.Sueldo = decimal.Parse(txtSueldo.Text);
            }
            else if (persona is Estudiante estudiante)
            {
                estudiante.Calificacion = int.Parse(txtCalificacion.Text);
            }

            // Limpiar los campos de texto
            LimpiarCamposTexto();
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar datos
            string mensaje = persona.Asistir();
            MessageBox.Show(mensaje);
        }

        private void LimpiarCamposTexto()
        {
            txtNombre.Text = "";
            txtSueldo.Text = "";
            txtCalificacion.Text = "";
        }

        private void HabilitarControlesPorTipoPersona()
        {
            // Lógica para habilitar o deshabilitar controles según el tipo de persona
            bool esProfesor = persona is Trabajador;
            bool esEstudiante = persona is Estudiante;

            // Controles comunes
            txtNombre.Enabled = true;

            // Controles específicos para Profesor
            txtSueldo.Enabled = esProfesor;

            // Controles específicos para Estudiante
            txtCalificacion.Enabled = esEstudiante;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            // Puedes dejar este método vacío o agregar cualquier lógica que desees ejecutar al hacer clic en el label.
        }

        // Clase base para Persona
        public class Persona
        {
            public string Nombre { get; set; }

            public virtual string Asistir()
            {
                return $"{Nombre} está asistiendo.";
            }
        }

        // Clase para representar a Trabajador (Profesor)
        public class Trabajador : Persona
        {
            public decimal Sueldo { get; set; }

            public override string Asistir()
            {
                return $"{Nombre} enseña. Sueldo: {Sueldo:C}";
            }
        }

        // Clase para representar a Estudiante
        public class Estudiante : Persona
        {
            public int Calificacion { get; set; }

            public override string Asistir()
            {
                return $"{Nombre} estudia. Calificación: {Calificacion}";
            }
        }
    }
}
