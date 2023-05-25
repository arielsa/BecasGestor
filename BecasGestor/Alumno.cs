using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecasGestor
{
    public class Alumno
    {
        public List<Beca> lb;

        public string Categoria;
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public string DNI { get; set; }

        public Alumno()
        {
            lb = new List<Beca>();
        }
        public Alumno (string pLegajo, string pNombre="", string pApellido = "", string pDNI = "" ) : this() 
        {
            Nombre = pNombre;
            Legajo = pLegajo;
            Apellido = pApellido;
            DNI = pDNI;            
        }
        public Alumno (Alumno pAlumno) : this( pAlumno.Legajo, pAlumno.Nombre, pAlumno.Apellido, pAlumno.DNI )
        {          
        }
        public void AgregarBeca(Beca pBeca)
        {
            lb.Add(pBeca);
        }

        public void RemoverBeca(Alumno pAlumno, string codBeca )
        {
            
        }
    }
    public class Ingresante : Alumno
    {
        public Ingresante(string pLegajo ) : base(pLegajo) { }
        public Ingresante(string pLegajo, string pNombre = "", string pApellido = "", string pDNI = "") : base(pLegajo,pNombre,pApellido,pDNI) { }

        public int Beneficio = 10;
        public string Categoria = "Ingresante";
    }
    public class Grado : Alumno
    {
        public Grado(string pLegajo) : base(pLegajo) { }
        public Grado(string pLegajo, string pNombre = "", string pApellido = "", string pDNI = "") : base(pLegajo, pNombre, pApellido, pDNI) { }
        public int Beneficio = 5;
        public string categoria = "Grado";
    }
    public class Posgrado : Alumno
    {
        public int Beneficio = 1;
        public string categoria = "Posgrado";
    }
}
