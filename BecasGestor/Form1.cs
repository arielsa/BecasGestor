using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
            dataGridAlumno.MultiSelect = false;
            dataGridAlumno.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            dataGridBecas.MultiSelect = false;
            dataGridBecas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridBecasDeAlumno.MultiSelect = false;
            dataGridBecasDeAlumno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
              

            universidad = new Universidad();
            // alumnos creados desde el inicio para agilizar las primeras pruebas
            universidad.AgregarAlumno(new Ingresante("B00074791-T4","Hilario","Perez","11.111.111"));
            universidad.AñadirLegajo("B00074791-T4");
            universidad.AgregarAlumno(new Alumno("B00074792-T5","Teodosia","Gomez","21.111.112"));
            universidad.AñadirLegajo("B00074792-T5");
            universidad.AgregarAlumno(new Alumno("B00074793-T6","Jasinta","Pichimahuida","31.111.113"));
            universidad.AñadirLegajo("B00074793-T6");
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

        public string GeneradorDeCodigo()
        {
            Random random = new Random();
            int randomNumber = random.Next(10,99);
            char caracterRandom = (char)random.Next('A','Z'+ 1);
            char caracterRandom2 = (char)random.Next('A', 'Z' + 1);
            string codigo = caracterRandom.ToString()+caracterRandom2.ToString()+randomNumber.ToString();
            if (universidad.ValidaCodigoBeca(codigo))
            {
                GeneradorDeCodigo();
            }
            return codigo;
        }
        public string GeneradorID()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            char caracterRandom = (char)random.Next('A', 'D' + 1);
            
            string codigo = "FACT-"+ caracterRandom.ToString()+"-"+ randomNumber.ToString();
            if (universidad.FiltrarIDFact(codigo))
            {
                GeneradorID();
            }
            return codigo;            
        }
        private void Mostrar (DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }
        private void CrearAlumnoConCategoria(Alumno a, string numLegajo)
        {
            //generamos un DNI por defecto para agilizar el proceso de pruebas:
            //este DNI no lo pasamos por el proceso de validacion ya que solo
            //nos sera funcional para agilizar las pruebas. En un hipotetico caso
            //de pasar el programa a produccion se debera sacar.
            Random random = new Random();
            int rN3 = random.Next(100, 999);
            int rN2 = random.Next(100, 999);
            int rN1 = random.Next(10, 99);
            string DNInoValidado = rN1.ToString()+"."+ rN2.ToString()+"."+rN3.ToString();

            rgx = new Regex(@"\d{2}.\d{3}.\d{3}");
            String dni = Interaction.InputBox("ingrese DNI: ","DNI", DNInoValidado);
            if ((!rgx.IsMatch(dni)) || dni.Length > 10) throw new Exception("Error de formato");// formato del dni
            a.DNI = dni;
            if (universidad.ValidarDNIAlumno(a))//si el dni pertenece a un alumno existente se borra el legajo creado y se va a excepcion
            {
                universidad.EliminarLegajo(numLegajo);
                throw new Exception("DNI existente, Legajo nuevo borrado");
            }
            a.Apellido = Interaction.InputBox("ingrese apellido");
            a.Nombre = Interaction.InputBox("ingrese nombre");

            universidad.AgregarAlumno(a);// agregamos el alumno y lo mostramos en la grilla.

            Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());
            // Hasta aca, creamos un numero de legajo valido y lo listamos.
            // Creamos al alumno partir de una subclase.
            // Le asignamos aquel numero de legajo valido.
            // Terminamos de cargar los datos personales del alumno. 
            // Ante un error de carga se elimina el numero de legajo creado
            // y se aborta la insercion del alumno en la lista de la universidad. 
            // Y desde un metodo de la Universidad clonamos ese alumno
            // junto con todos los valores que acabamos de asignar y verificar.
            // Finalmente actualizamos la grilla correspondiente.
        }
        private void InstanciarNuevoAlumnoDesdeSubclase(Alumno pAlumno, string pLegajo)
        {
            try
            {
                //definir desde que subclase se desea instanciar:
                rgx = new Regex("[1-3]");
                string CatSeleccionada = Interaction.InputBox("selecione categoria: Ingresante(1), Grado(2), Posgrado(3): ");
                if (!(rgx.IsMatch(CatSeleccionada) && CatSeleccionada.Length == 1)) throw new Exception("categoria incorrecta");

                //guardo el alumno con el legajo original y los demas datos actualizados:
                string legajoOriginal = pAlumno.Legajo;

                //guardo el nuevo numero de legajo que pudo o no haber cambiado:
                string nuevoLegajo = pLegajo;

                //construyo un alumno actualizado con numero de legajo original:
                Alumno aConLegajoOriginal;
                switch (CatSeleccionada)
                {
                    case "1":
                        aConLegajoOriginal = new Ingresante(pAlumno);
                        break;
                    case "2":
                        aConLegajoOriginal = new Grado(pAlumno);
                        break;
                    case "3":
                        aConLegajoOriginal = new Posgrado(pAlumno);
                        break;
                    default:
                        aConLegajoOriginal = new Alumno(pAlumno);
                        break;
                }
                //llamo a la funcion de la universidad que borra el
                //alumno original(que pudo haber sido instanciado desde una subclase diferente)
                //y actualizo la informacion de las listas de la universidad 
                universidad.ModificarAlumnoOpcionCategoria(aConLegajoOriginal, pLegajo);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public DateTime RetronaDateTimeFecha (int dia, int mes, int año)
        {
             DateTime fechaEspecificada = new DateTime(año,mes,dia);
            return fechaEspecificada;
        }

        public string RetornaStringFecha(DateTime fechaEspecificada)
        {
            string d = fechaEspecificada.Day.ToString();
            string m = fechaEspecificada.Month.ToString();
            string a = fechaEspecificada.Year.ToString();
            string stringFecha= d+"/"+m+"/"+a;
            return stringFecha;
        }

        private void btnAddAlumno_Click(object sender, EventArgs e)
        {
            //ejemplo de legajo : B00074791-T4
            
            try
            {
                string numLegajo = GeneradorDeLegajo();
                rgx = new Regex(@"[A-Z]\d{8}-[A-Z]\d");
                numLegajo = Interaction.InputBox("legajo creado por sistema: " +numLegajo,"nuevo legajo",numLegajo);
                //Interaction.MsgBox(nuevoLegajo);
                if (!(rgx.IsMatch(numLegajo)) && numLegajo.Length > 12) throw new Exception("Error de formato");// verificamos el formato del legajo
                if (universidad.VerificarNumLegajo(numLegajo)) throw new Exception("legajo existente");//verificamos inexistencia del legajo
                universidad.AñadirLegajo(numLegajo);// añadimos legajo

                // creamos el alumno a partir del Legajo
                rgx = new Regex("[1-3]");
                String categoria =Interaction.InputBox("seleccione: Ingresante (1) Grado(2) Posgrado(3)","Categoria","1");
                if (!(rgx.IsMatch(categoria) && categoria.Length == 1 )) throw new Exception("categoria incorrecta");               
                //asignamos una categoria al alumno
                switch (categoria)
                {
                    case "1": 
                        Ingresante a = new Ingresante(numLegajo);
                        
                        CrearAlumnoConCategoria(a, numLegajo);
                        break;
                    case "2":
                        Grado b = new Grado(numLegajo);
                        
                        CrearAlumnoConCategoria(b, numLegajo);
                        break;
                    case "3":
                        Posgrado c = new Posgrado(numLegajo);
                        
                        CrearAlumnoConCategoria(c, numLegajo);
                        break;

                    default:
                         
                        break;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {   //creamos un nuevo valor valido para legajo y lo guardamos
                // le damos al usuario 3 opciones: cambio manual,cambio automatico, cambio por defecto
                string NuevoLegajoAutomatico = GeneradorDeLegajo();
                //seleccion de alumno desde la grilla
                if (dataGridAlumno.Rows.Count == 0) throw new Exception("no hay seleccion");
                DataGridViewRow f = dataGridAlumno.SelectedRows[0];
                //guardamos la subclase y el legajo original:
                string subclase = f.Cells[4].Value.ToString();
                string legajoOriginal = f.Cells[0].Value.ToString();

                //invocamos un metodo de universidad para que nos devuelva un clon del alumno de la grilla
                Alumno ActualAlumno=universidad.RetornaClonAlumno(legajoOriginal, subclase);

               // ActualAlumno = new Alumno(f.Cells[0].Value.ToString());////////////////////////////                
                //presnetamos la opcion de modificar legajo y guardamos el legajo actual en un auxiliar
                string legajoActual = ActualAlumno.Legajo;
                rgx = new Regex(@"[A-Z]\d{8}-[A-Z]\d");
                string nuevoLegajo = Interaction.InputBox("nuevo legajo automatico: " + NuevoLegajoAutomatico+"\n legajo actual: "+legajoActual, "cambio de legajo", legajoActual);
                if (!(rgx.IsMatch(nuevoLegajo)) && nuevoLegajo.Length > 12) throw new Exception("Error de formato");
                
                //construimos un nuevo alumno con el viejo legajo y valores que pueden cambiar:
                ActualAlumno.Nombre = Interaction.InputBox("cambien el nombre: ","cambio de nombre", f.Cells[1].Value.ToString());
                ActualAlumno.Apellido = Interaction.InputBox("cambien el apellido: ", "cambio de apellido", f.Cells[2].Value.ToString());
                rgx = new Regex(@"\d{2}.\d{3}.\d{3}");
                ActualAlumno.DNI = Interaction.InputBox("cambien el DNI: ", "cambio de DNI", f.Cells[3].Value.ToString());
                if ((!rgx.IsMatch(ActualAlumno.DNI)) || ActualAlumno.DNI.Length > 10) throw new Exception("Error de formato");
                string cambiarCat = (Interaction.MsgBox("desea cambiar la categoria del alumno?\n(categoria actual: "+f.Cells[4].Value.ToString()+")", MsgBoxStyle.OkCancel).ToString());
               
                if (cambiarCat == "Ok") 
                {                    
                    InstanciarNuevoAlumnoDesdeSubclase(ActualAlumno,nuevoLegajo);
                    //actualizamos la grila:
                    Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());
                }
                else
                {                
                    //invocamos el metyodo de universidad para modificar:                   
                    universidad.ModificarAlumno(ActualAlumno, nuevoLegajo);
                    //actualizamos la grila:
                    Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {   //creamos un alumno, solo nos interesa el legajo por que es
                //el ID que vamos a usar para buscar y borrar en ll y la         
                if (dataGridAlumno.Rows.Count == 0) throw new Exception("no hay seleccion");
                DataGridViewRow f = dataGridAlumno.SelectedRows[0];
                Alumno a = new Alumno(f.Cells[0].Value.ToString());
                universidad.BorrarAlumno(a);// invocamos el metodo de universidad para borrar
                Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());//actualizamos
                Mostrar(dataGridBecas, universidad.RetornarListaBecas());
                Mostrar(dataGridBecasDeAlumno,null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dataGridAlumno_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridAlumno.Rows.Count == 0) { dataGridBecasDeAlumno.DataSource = null; throw new Exception(); }
                if (dataGridAlumno.Rows.Count == 0) { dataGridViewCuotas.DataSource = null; throw new Exception(); }
                Alumno a = new Alumno(dataGridAlumno.SelectedRows[0].Cells[0].Value.ToString());
                Mostrar(dataGridBecasDeAlumno, universidad.RetornaListaBecasDeAlumno(a));
                Mostrar(dataGridViewCuotas, universidad.RetornaListaCuotasDeAlumno(a));
            }
            catch (Exception) { }//dejamos vacio el catch para eitar el errror en la falta de allumnos
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Beca FormularioDeBeca(Alumno pBeneficiario)
        {
            Beca nuevaBeca;
            //instanciamos una beca con un clon del beneficiario:
            nuevaBeca = new Beca(new Alumno(pBeneficiario));
            DateTime fechaActual =  DateTime.Now;
            string codigoSugerido= GeneradorDeCodigo();
            try
            {
                //creamos un codigo valido:
                rgx = new Regex(@"[A-Z][A-Z]{2}\d{2}");
                string codigo = Interaction.InputBox("ingrese codigo.(dos letras mayusculas + dos numeros)\n ej.AD37 \n codigo sugerido:" + codigoSugerido, "codigo de beca",codigoSugerido).ToUpper();
                if (rgx.IsMatch(codigo)) throw new Exception("err de formato");
                if (universidad.ValidaCodigoBeca(codigo)) throw new Exception("codigo existente");
                nuevaBeca.Codigo=codigo;
                //creamos una fecha valida:
                rgx = new Regex(@"\d{4}\d{2}\d{2}");
                int a = Int16.Parse(Interaction.InputBox("ingrese año de otorgamiento(valor de 4 digitos) \n ej.2020","Año",fechaActual.Year.ToString()));
                int m = Int16.Parse(Interaction.InputBox("ingrese mes de otorgamiento(valor de 2 digitos)\n ej.03", "Mes", fechaActual.Month.ToString()));
                int d = Int16.Parse(Interaction.InputBox("ingrese dia de otorgamiento(valor de 2 digitos)\n ej.03", "Dia", fechaActual.Day.ToString()));
                string fechaAux = a.ToString()+m.ToString()+d.ToString();
                if (!rgx.IsMatch(fechaAux) && fechaAux.Length == 8) throw new Exception("formato de fecha incorrecto");
                nuevaBeca.OtorgamientoDate = RetronaDateTimeFecha(d,m,a);
                //cargamos un importe valido al beneficio:               
                string importeIngresado = Interaction.InputBox("ingrese importe. utilice coma(,) o punto(.) para indicar los decimales", "importe","100.0");
                string cadenaNumerica = Regex.Replace(importeIngresado, @"[.]", ",");
                string cadenaNumerica2 = Regex.Replace(cadenaNumerica,@"[^0-9,]","");
                decimal importeAuxiliar = decimal.Parse(cadenaNumerica2);
                nuevaBeca.Importe = importeAuxiliar;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return nuevaBeca;            
        }
        private void btnCrearBeca_Click(object sender, EventArgs e)
        {
            try
            {
                //asignamos y creamos beca para alumno seleccionado:
                if (dataGridAlumno.Rows.Count == 0) throw new Exception("No hay alumno seleccionado");
                Alumno alumnoSeleccionado = new Alumno(dataGridAlumno.SelectedRows[0].Cells[0].Value.ToString());
                universidad.AsignaBecaAAlumno(
                                                alumnoSeleccionado,
                                                FormularioDeBeca(alumnoSeleccionado)
                                              );
                //actualizamos grillas de becas por universidad y becas por alumno:
                Mostrar(dataGridBecas, universidad.RetornarListaBecas());
                Mostrar(dataGridBecasDeAlumno, universidad.RetornaListaBecasDeAlumno(alumnoSeleccionado));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarBeca_Click(object sender, EventArgs e)
        {
            try
            {
                //seleccionamos el legajo del beneficiario y le removemos la beca
                if (dataGridAlumno.Rows.Count == 0) throw new Exception("no hay seleccion");
                Alumno alumnoSeleccionado = new Alumno(dataGridAlumno.SelectedRows[0].Cells[0].Value.ToString());
                string codigo = dataGridBecas.SelectedRows[0].Cells[0].Value.ToString();
                //verificamos que la beca seleccionada pertenesca al alumno seleccionado
                if (!(universidad.ValidarAlumnoBeneficiario(alumnoSeleccionado, codigo))) throw new Exception("seleccione alumno beneficiario de esta beca");
                //removemos la beca del listado de la universidad
                universidad.RemoverBeca(alumnoSeleccionado, codigo);
                //removemos la beca del listado del alumno
                Mostrar(dataGridAlumno, universidad.RetornarListaAlumnos());//actualizamos
                Mostrar(dataGridBecas, universidad.RetornarListaBecas());
                Mostrar(dataGridBecasDeAlumno, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }                     
        }

        private void dataGridBecas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCargarCuota_Click(object sender, EventArgs e)
        {
            try
            {
                //indicamos el alumno al que se le cargara la cuota. 
                //una vez cargada la primer cuota se pasara al sigueinte alumno de la lista de universidad
                string legajoPrimerCarga = universidad.RetornaLegajoPrimerAlumno();
                string proximoLegajo = universidad.RetornaLegajoSiguiente(legajoPrimerCarga);
                string legajoSugerido = legajoPrimerCarga;

                while (proximoLegajo!=null)
                {
                    rgx = new Regex(@"[A-Z]\d{8}-[A-Z]\d");
                    string legajoIngresado = Interaction.InputBox("ingrese alumno: \n alumno sugerido" + legajoSugerido, "alumno", legajoSugerido);
                    if (!(rgx.IsMatch(legajoIngresado)) && legajoIngresado.Length > 12) throw new Exception("Error de formato");
                    if (!(universidad.VerificarNumLegajo(legajoIngresado))) throw new Exception("numero de legajo no existente");

                    // con el numero de legajo traemos traemo un alumno para clonarlo en la cuota:
                    Alumno alumnoSeleccionado =  universidad.RetornaAlumnoPorLegajo(legajoIngresado);


                    //indicamos el ID de la cuota. el sistema sugiere y provee uno por defecto                
                    string IDsugerido = GeneradorID();
                    rgx = new Regex(@"FACT-[A-C]-\d{6}");
                    string cuotaID = (Interaction.InputBox("Ingrese ID con el formato correcto\nejemplo:FACT-A-000111 \nID sugerido:" + IDsugerido, "ID", IDsugerido)).ToUpper();
                    if (!(rgx.IsMatch(cuotaID))) throw new Exception("Error de formato");
                    //el ID se verificara en el listado de la universidad para todos los alumnos
                    if (universidad.FiltrarIDFact(cuotaID)) throw new Exception("ID existente");
                    //a asu vez cada alumno cuenta con su propia lista de cuotas pero la verificacion se genera en la universidad
                    //de una manera mas global.

                    //indicamos el mes-año que se desea cargar:
                    DateTime fechaActual = DateTime.Now;
                    rgx = new Regex(@"\d{1,2}.\d{4}");
                    string ma = (Interaction.InputBox("ingrese mes de otorgamiento(max 2 digitos) y  año (4 digitos) \n como separador se admiten (/-[espacio])\n ej.03 2020,03-2020", "Mes", fechaActual.Month.ToString() + " " + fechaActual.Year.ToString()));
                    ma = Regex.Replace(ma, @"[/ -]", ".");
                    if (!(rgx.IsMatch(ma))) throw new Exception("error de formato");
                    var x = ma.Split(new string[] { "." }, StringSplitOptions.None);
                    int mes = Int16.Parse(x[0]);
                    int año = Int16.Parse(x[1]);
                    int dia = 1;
                    DateTime mesAños = RetronaDateTimeFecha(dia, mes, año);


                    //indicamos fecha de pago:                
                    rgx = new Regex(@"\d{1,2}.\d{1,2}.\d{4}");
                    string dma = (Interaction.InputBox("ingrese fecha de pago 2 digitos max para el dia, el mes max 2 digitos y  año 4 digitos \n como separador se admiten (/-[espacio])\n ej.6 03 2020,08-3-2020", "Mes", fechaActual.Day.ToString() + " " + fechaActual.Month.ToString() + " " + fechaActual.Year.ToString()));
                    dma = Regex.Replace(dma, @"[/ -]", ".");
                    if (!(rgx.IsMatch(dma))) throw new Exception("error de formato");
                    x = dma.Split(new string[] { "." }, StringSplitOptions.None);
                    dia = Int16.Parse(x[0]);
                    mes = Int16.Parse(x[1]);
                    año = Int16.Parse(x[2]);
                    DateTime fechaDePago = RetronaDateTimeFecha(dia, mes, año);
                    //validar fecha:
                    string pMesAño = mesAños.Month.ToString() + "/" + mesAños.Year.ToString();
                    if (alumnoSeleccionado.CuotaExistente(pMesAño)) throw new Exception("Cuota del mes existente ");



                    // pedimos el importe al usuario:
                    rgx = new Regex(@"\d{1,6}(,\d{1,2})?");
                    string importeIngresado = Interaction.InputBox("ingrese importe de cuota \n se admiten punto(.) o coma (,) para indicar decimal ", "improte", "3000.00");
                    importeIngresado = Regex.Replace(importeIngresado, @"[.]", ",");
                    if (!(rgx.IsMatch(importeIngresado))) throw new Exception("error de formato");
                    decimal importeIngresadoDecimal = decimal.Parse(importeIngresado);

                    //verificamos que las becas no lleguen al 100% de la cuota:
                    decimal totalBecas = alumnoSeleccionado.RetornaTotalDeBecas();
                    decimal diferencia = importeIngresadoDecimal - totalBecas;
                    if (diferencia<=0) throw new Exception("Los montos de las becas superan o igualan el monto de la cuota.\n Gestione las becas de :"+alumnoSeleccionado.Nombre+" "+alumnoSeleccionado.Apellido+"\nLegajo: "+alumnoSeleccionado.Legajo );


                    //creamos cuota valida
                    

                    Cuota cuotaCreada = new Cuota(cuotaID, pMesAño, fechaDePago, importeIngresadoDecimal, new Alumno(alumnoSeleccionado));

                    //actualizamos grillas de becas por universidad y becas por alumno:


                    //invocamos el metodo asignarCuotaAAlumno este metodo 
                    universidad.AsignaCuotaAAlumno(alumnoSeleccionado, cuotaCreada);
                    //actualizamos la grilla:
                    Alumno a = new Alumno(dataGridAlumno.SelectedRows[0].Cells[0].Value.ToString());
                    Mostrar(dataGridViewCuotas, universidad.RetornaListaCuotasDeAlumno(a));
                    MessageBox.Show("Cuota cargada");
                    //reiniciamos la carga, si la lista acaba lo indicamos por un mensaje de excepcion.
                    proximoLegajo = universidad.RetornaLegajoSiguiente(legajoIngresado);
                    legajoSugerido = proximoLegajo;
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
