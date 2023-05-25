using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecasGestor
{
    internal class Universidad
    {
        List<Alumno> la;
        List<string> ll;
        List<Beca> lb;
        public Universidad() 
        {
            la=new List<Alumno>();
            lb=new List<Beca>();
            ll = new List<string>();
        }
        public void AgregarAlumno(Alumno pAlumno)
        {
            la.Add(new Alumno (pAlumno));
        }
        public object RetornarListaAlumnos()
        {
            return (from a in la select new { 

                                            legajo = a.Legajo,
                                            nombre = a.Nombre,
                                            apellido = a.Apellido,
                                            DNI = a.DNI,
                                            cat= a.Categoria,
                                            
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

        public bool MaximoDeLegajos() 
        {
            int espaciDisponible = (99999 - 10000);
            return ll.Count == espaciDisponible;
        }
        public bool ValidarDNIAlumno(Alumno pAlumno)
        {
            return la.Exists(a => a.DNI == pAlumno.DNI );
        }
    }
}
