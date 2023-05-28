using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecasGestor
{
    public class Alumno
    {
        public List<Beca> lb;
        public List<Cuota> lc;

        public string Categoria;
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public string DNI { get; set; }

        public  decimal Beneficio=0m;

        public Alumno()
        {
            lb = new List<Beca>();
            lc = new List<Cuota>();
        }
        public Alumno (string pLegajo, string pNombre="", string pApellido = "", string pDNI = "", string pCategoria = "sin asignar") : this() 
        {
            Nombre = pNombre;
            Legajo = pLegajo;
            Apellido = pApellido;
            DNI = pDNI;
            Categoria = pCategoria;
        }
        public Alumno (Alumno pAlumno) : this( pAlumno.Legajo, pAlumno.Nombre, pAlumno.Apellido, pAlumno.DNI, pAlumno.Categoria )
        {          
        }
        public void AgregarBeca(Beca pBeca)
        { 
            try
            {
                if (RetornaCantidadBecas() == 2) throw new Exception("maximo de becas alcanzado");
                lb.Add(pBeca);
            }
            catch (Exception ex ) { throw ex; }//La excepcion activara el try que lo anida e interrumpira el programa
        }

        public void RemoverBeca( string codBeca )
        {
            Beca B = lb.Find(x=>x.Codigo == codBeca);
            lb.Remove(B);            
        }

        public List<Beca> RetornaListaBecas()
        {
            List<Beca> becas = (from b in lb select new Beca(b.Codigo,b.OtorgamientoDate,b.Importe)).ToList();
            return becas;
                 
        }
        public List<Cuota> RetornaListaCuotas(Alumno A)
        {
            List<Cuota> cuotas = (from b in lc select new Cuota(b.Id, b.MesAño, b.FechaDePago,b.Valor,A)).ToList();
            return cuotas;
        }

        public int RetornaCantidadBecas()
        {
            return lb.Count;
        }

        public decimal RetornaTotalDeBecas ()
        {
            decimal total = 0;
            foreach (Beca b in lb) { total += b.Importe; }
            return total;
        }
        public void AgregarCuota(Cuota pCuota)
        {
            lc.Add(pCuota);
        }
        public bool CuotaExistente(string pMesAño)
        {
            return lc.Exists(x => x.MesAño == pMesAño);
        }


    }
    public class Ingresante : Alumno
    {
        public Ingresante(string pLegajo ) : base(pLegajo) { Categoria = "Ingresante"; }

        public Ingresante (Alumno pAlumno)
        {
            Categoria = "Ingresante";
            Nombre = pAlumno.Nombre;
            Apellido = pAlumno.Apellido;
            DNI = pAlumno.DNI;
            lb= pAlumno.lb;
            Legajo = pAlumno.Legajo;
        }
        public Ingresante(string pLegajo, string pNombre = "", string pApellido = "", string pDNI = "") : base(pLegajo,pNombre,pApellido,pDNI) 
        {
            Categoria = "Ingresante";        
        }

        public new decimal Beneficio = 0.1m;
        
    }
    public class Grado : Alumno
    {
        public Grado(string pLegajo) : base(pLegajo) { Categoria = "Grado"; }
        public Grado(Alumno pAlumno)
        {
            Categoria = "Grado";
            Nombre = pAlumno.Nombre;
            Apellido = pAlumno.Apellido;
            DNI = pAlumno.DNI;
            lb = pAlumno.lb;
            Legajo = pAlumno.Legajo;
        }
        public Grado(string pLegajo, string pNombre = "", string pApellido = "", string pDNI = "") : base(pLegajo, pNombre, pApellido, pDNI) 
        { Categoria = "Grado";}
        public  new decimal Beneficio = 0.05m;
        
    }
    public class Posgrado : Alumno
    {
        public Posgrado(string pLegajo) : base(pLegajo) { Categoria = "Posgrado"; }
        public Posgrado(Alumno pAlumno)
        {
            Categoria = "Posgrado";
            Nombre = pAlumno.Nombre;
            Apellido = pAlumno.Apellido;
            DNI = pAlumno.DNI;
            lb = pAlumno.lb;
            Legajo = pAlumno.Legajo;
        }
        public Posgrado(string pLegajo, string pNombre = "", string pApellido = "", string pDNI = "") : base(pLegajo, pNombre, pApellido, pDNI)
        { Categoria = "Posgrado"; }
        public new decimal Beneficio = 0.01m;
        
    }
}
