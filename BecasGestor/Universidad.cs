using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecasGestor
{
    internal class Universidad
    {
        List<Alumno> la;
        List<string> ll;
        List<Beca> lb;
        List<Cuota> lc;
        public Universidad()
        {
            la = new List<Alumno>();//lista de alumnos
            lb = new List<Beca>();//lista de becas
            ll = new List<string>();//lista de legajos
            lc = new List<Cuota>();//lista de cuotas
        }
        public void AgregarAlumno(Alumno pAlumno)
        {
            la.Add(new Alumno(pAlumno));
        }
        public void BorrarAlumno(Alumno pAlumno)
        {
            try
            {
                Alumno a = la.Find(x => x.Legajo == pAlumno.Legajo);
                if (a == null) throw new Exception("alumno no encontrado");
                List<Beca> becasDeAlumno = a.lb.ToList();
                int cantidadBecas = a.lb.Count();
                if (cantidadBecas > 0)
                {
                    for (int i = 0; i < cantidadBecas; i++)
                    {
                        Beca Aborrar = lb.Find(x => x.Codigo == becasDeAlumno[i].Codigo);
                        lb.Remove(Aborrar);
                    }
                }

                lb.Count();
                la.Remove(a);
                ll.Remove(a.Legajo);
            }
            catch (Exception ex) { throw ex; }
        }
        public void ModificarAlumno(Alumno pAlumno, string pLegajo)
        {
            try
            {
                Alumno a = la.Find(x => x.Legajo == pAlumno.Legajo);
                if (a == null) throw new Exception("alumno no encontrado");
                a.Legajo = pLegajo;//si el legajo se cambio o se conservo se define aca
                a.Nombre = pAlumno.Nombre;
                a.Apellido = pAlumno.Apellido;
                a.DNI = pAlumno.DNI;
                //borramos en la lista ll el legajo de pAlumno.legajo y agregamos el pLegajo
                ll.Remove(pAlumno.Legajo);
                ll.Add(pLegajo);
            }
            catch (Exception ex) { throw ex; }
        }
        public void AgregarBeca(Beca pBeca)
        {
            lb.Add(new Beca(pBeca));
        }

        public object RetornarListaAlumnos()
        {
            return (from a in la select new {

                legajo = a.Legajo,
                nombre = a.Nombre,
                apellido = a.Apellido,
                DNI = a.DNI,
                cat = a.Categoria,
            }).ToArray();
        }
        public object RetornarListaBecas()
        {
            return (from b in lb select new {
                Codigo = b.Codigo,
                Fecha_de_otorgamiento = b.OtorgamientoDate,
                Importe = b.Importe,
            }).ToArray();
        }

        public bool VerificarNumLegajo(string pNumLegajo)
        {
            return ll.Exists(l => l == pNumLegajo);
        }
        public void AñadirLegajo(String pNLegajo)
        {
            ll.Add(pNLegajo);
        }
        public void EliminarLegajo(string pNLegajo)
        {
            ll.Remove(pNLegajo);
        }

        public bool MaximoDeLegajos() //hay un espacio finito para la creacion de legajos en este modelo. Pero la universidad controla una situacion de desborde. Para este ejercicio simplemente muestra un mensaje, pero imaginandolo en un escenario real podria implementarce algun protocolo automatico frente a esta eventualidad.
        {
            int espaciDisponible = (99999 - 10000);
            return ll.Count == espaciDisponible;
        }
        public bool ValidarDNIAlumno(Alumno pAlumno)
        {
            return la.Exists(a => a.DNI == pAlumno.DNI);
        }
        public void ModificarAlumnoOpcionCategoria(Alumno pAlumnoActual, string pNuevoLegajo)
        {
            try
            {
                //recibo un alumno existente q pudo haber sido instanciado desde una subclase distinta. 
                //elimino de las listtas la vieja version y copio la nueva con los datos actualizados
                Alumno a = la.Find(x => x.Legajo == pAlumnoActual.Legajo);
                if (a == null) throw new Exception("alumno no encontrado");
                //eliminamos los datos actuales del alumno
                ll.Remove(a.Legajo);
                la.Remove(a);
                //creamos un alumno nuevo con datos actualizados y el nuevo legajo en el caso de que se cambie
                Alumno b = new Alumno(pAlumnoActual);
                b.Legajo = pNuevoLegajo;
                //lo agregamos a las listas
                la.Add(pAlumnoActual);
                ll.Add(b.Legajo);
            }
            catch (Exception ex) { throw ex; }
        }
        public Alumno RetornaClonAlumno(string pLegajo, string pCategoria)
        {
            Alumno buscado = la.Find(a => a.Legajo == pLegajo);
            Alumno clon;
            switch (pCategoria)
            {
                case "Ingresante":
                    clon = new Ingresante(buscado);
                    break;
                case "Grado":
                    clon = new Grado(buscado);
                    break;
                case "Posgrado":
                    clon = new Posgrado(buscado);
                    break;
                default:
                    clon = new Alumno();
                    break;
            }
            return clon;
        }

        public void AsignaBecaAAlumno(Alumno pAlmuno, Beca pBeca)
        {
            try
            {
                //comprobamos la existencia del alumno
                Alumno A = la.Find(a => a.Legajo == pAlmuno.Legajo);
                Beca B = new Beca(pBeca);
                B.IndicarBeneficiario(new Alumno(A));
                if (A == null) throw new Exception(" alumno no encontrado");

                // el conteo de las becas de A esta dentro del metodo AgregarBeca.
                //si A ya tiene 2 becas la ejecucion se va por la excepcion dentro del metodo.
                A.AgregarBeca(new Beca(B));
                lb.Add(B);
                //B.IndicarBeneficiario(new Alumno(A));                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public bool ValidaCodigoBeca(string pCodigo)
        {
            return lb.Exists(b => b.Codigo == pCodigo);
        }
        public object RetornaListaBecasDeAlumno(Alumno pAlumno)
        {
            Alumno A = la.Find(x => x.Legajo == pAlumno.Legajo);
            return (from b in A.RetornaListaBecas() select new
            {
                Codigo = b.Codigo,
                fecha_de_otorgamiento = b.OtorgamientoDate,
                Importe = b.Importe,
            }).ToArray();
        }
        public void RemoverBeca(Alumno alumnoSeleccionado, string codigo)
        {
            Alumno a = la.Find(x => x.Legajo == alumnoSeleccionado.Legajo);
            Beca B = lb.Find(x => x.Codigo == codigo);
            lb.Remove(B);
            a.RemoverBeca(codigo);
            a.lb.Count();
        }
        public bool ValidarAlumnoBeneficiario(Alumno pAlumno, string pCodigo)
        {
            //verificamos que el alumno seleccionado y el beneficiario de la beca concidan
            Alumno A = la.Find(x => x.Legajo == pAlumno.Legajo);
            Beca B = lb.Find(x => x.Codigo == pCodigo);
            Alumno beneficiario = B.RetornaBeneficiario();
            if (beneficiario.Legajo != A.Legajo)
            {
                return false;
            }
            else
            {
                return true;
            }
                
        }

        public decimal RetornaNetoAPagarPorAlumno(Alumno pAlumno, Cuota pCuota ) 
        {

            try
            {            
                //capturamos el valor de la cuota listado en la universidad
                Cuota cuotaAsignada = lc.Find(x => x.Id == pCuota.Id);
                if (cuotaAsignada == null) throw new Exception("cuota no encontrada");
                decimal valorCuota = cuotaAsignada.Valor;
                //capturamos el monto de los las becas del alumno listado
                Alumno alumnoSeleccionado = la.Find(x => x.Legajo == pAlumno.Legajo);
                if (alumnoSeleccionado == null) throw new Exception("alumno no encontrado");
                decimal totalBecas = alumnoSeleccionado.RetornaTotalDeBecas();
                //si el monto de las becas es mayor o igual al de la cuota retornamos 0
                if(totalBecas >= valorCuota) { return 0; }
                else { return valorCuota - totalBecas; }                
            }
            catch (Exception ex) { throw ex; }
        }
        public decimal RetornaBeneficioAplicadoPorAlumno(Alumno pAlumno, Cuota pCuota)
        {
            try
            {
                //capturamos el valor de la cuota listado en la universidad
                Cuota cuotaAsignada = lc.Find(x => x.Id == pCuota.Id);
                if (cuotaAsignada == null) throw new Exception("cuota no encontrada");
                decimal valorCuota = cuotaAsignada.Valor;
                //capturamos el monto de los las becas del alumno listado
                Alumno alumnoSeleccionado = la.Find(x => x.Legajo == pAlumno.Legajo);
                if (alumnoSeleccionado == null) throw new Exception("alumno no encontrado");
                decimal totalBecas = alumnoSeleccionado.RetornaTotalDeBecas();
                //si el monto de las becas es mayor o igual al de la cuota retornamos 0
                if (totalBecas >= valorCuota) { return 0; }
                else
                {
                    decimal beneficio = alumnoSeleccionado.Beneficio;
                    decimal beneficioAplicado = (valorCuota - totalBecas) * beneficio;
                    return beneficioAplicado;
                }
            }
            catch (Exception ex) { throw ex; }

        }

        public bool FiltrarIDFact(string pId)
        {            
            return lc.Any(x=> x.Id == pId);
        }

        public string RetornaLegajoPrimerAlumno()
        {
            return la.First().Legajo;
        }

        public string RetornaLegajoSiguiente(string pLegajo)
        {

            try
            {            
                int index = la.FindIndex(x => x.Legajo == pLegajo);
                return la[index+1].Legajo;

            }
            catch (Exception ex) { throw ex; }

        }
        

    }
}
