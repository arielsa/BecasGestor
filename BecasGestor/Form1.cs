using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BecasGestor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            universidad = new Universidad();
            // alumnos creados desde el inicio para agilizar las primeras pruebas
            universidad.AgregarAlumno(new Ingresante("B00074791-T4","Hilario","Perez","11.111.111"));
            universidad.AgregarAlumno(new Alumno("B00074792-T5","Teodosia","Gomez","21.111.112"));
            universidad.AgregarAlumno(new Alumno("B00074793-T6","Jasinta","Pichimahuida","31.111.113"));
            Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());
        }
        Regex rgx;
        Universidad universidad;
        public string GeneradorDeLegajo() // generador de numero de legajo automatico
        {
            //ejemplo de legajo : Legajo: B00074791-T4
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);
            int randomNum = random.Next(1, 10);
            string legajo = "B000" + randomNumber.ToString() + "-T" + randomNum.ToString();
            if ((universidad.MaximoDeLegajos())) { throw new Exception("espacio para legajos superado"); }    
                
            if (universidad.VerificarNumLegajo(legajo)) //verificar que el legajo no exista
            {
                GeneradorDeLegajo();// recursividad para regenar legajo en caso de que exista.
            }
                return legajo;            
        }

        private void Mostrar (DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }

        private void CrearAlumnoConCategoria(Alumno a, string numLegajo)
        {
            rgx = new Regex(@"\d{2}.\d{3}.\d{3}");
            String dni = Interaction.InputBox("ingrese DNI: ");
            if ((!rgx.IsMatch(dni)) || dni.Length > 10) throw new Exception("Error de formato");// formato del dni
            a.DNI = dni;
            if (universidad.ValidarDNIAlumno(a))//si el dni pertenece a un alumno existente se borra el legajo creado y se va a excepcion
            {
                universidad.EliminarLegajo(numLegajo);
                throw new Exception("DNI existente, Legajo nuevo borrado");
            }
            a.Apellido = Interaction.InputBox("ingrese apellido");
            a.Nombre = Interaction.InputBox("ingrese nombre");

            universidad.AgregarAlumno(a);// agregamos el alumno y lo mostramos en la grilla
            Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());
        }

        private void btnAddAlumno_Click(object sender, EventArgs e)
        {
            //ejemplo de legajo : B00074791-T4
            
            try
            {
                string numLegajo = GeneradorDeLegajo();
                rgx = new Regex(@"[A-Z]\d{8}-[A-Z]\d");
                string nuevoLegajo = Interaction.InputBox("legajo creado por sistema: " +numLegajo,"nuevo legajo",numLegajo);
                //Interaction.MsgBox(nuevoLegajo);
                if (!(rgx.IsMatch(nuevoLegajo)) && nuevoLegajo.Length > 12) throw new Exception("Error de formato");// verificamos el formato del legajo
                if (universidad.VerificarNumLegajo(numLegajo)) throw new Exception("legajo existente");//verificamos inexistencia del legajo
                universidad.AñadirLegajo(numLegajo);// añadimos legajo

                // creamos el alumno a partir del Legajo
                rgx = new Regex("[1-3]");
                String categoria =Interaction.InputBox("seleccione: Ingresante (1) Grado(2) posgrado(3)");
                if (!(rgx.IsMatch(categoria) && categoria.Length == 1 )) throw new Exception("categoria incorrecta");               

                switch (categoria)
                {
                    case "1": 
                        Ingresante a = new Ingresante(numLegajo);
                        a.categoria = "Ingresante";
                        CrearAlumnoConCategoria(a, numLegajo);
                        break;
                    case "2":
                        Grado b = new Grado(numLegajo);
                        b.categoria = "Ingresante";
                        CrearAlumnoConCategoria(b, numLegajo);
                        break;
                    case "3":
                        Ingresante c = new Ingresante(numLegajo);
                        c.categoria = "Ingresante";
                        CrearAlumnoConCategoria(c, numLegajo);
                        break;

                    default:
                         
                        break;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
