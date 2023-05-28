using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecasGestor
{
    public class Cuota
    {
        public string Id { get; set; }
        public string MesAño  { get; set; }
        public DateTime FechaDePago { get; set; }
        public decimal Valor { get; set; }
        

        public Alumno Abonado { get; set; }

        public Cuota(Alumno pAlumno) 
        {
            Abonado = pAlumno;
        }
        public Cuota(string pId, string pMesAño, DateTime pFechaDePago,decimal pValor,Alumno pAbonado) : this(pAbonado) 
        {
            Id = pId;
            MesAño = pMesAño;
            FechaDePago= pFechaDePago;
            Valor = pValor;           
        }
        public Cuota(Cuota pCuota) : this(pCuota.Id, pCuota.MesAño, pCuota.FechaDePago, pCuota.Valor, pCuota.Abonado) 
        {
        }
        public void IndicarAbonado(Alumno pAlumno)
        {
            Abonado = pAlumno;
        }

        public decimal RetornaDiferencia()
        {
            decimal becas= Abonado.RetornaTotalDeBecas();
            return Valor - becas;
        }
        public decimal Descuento()
        {
            decimal beneficio = 1m;
           decimal diferencia =  RetornaDiferencia();
            if (Abonado.Categoria == "Ingresante") { beneficio = 0.1m; }
            if (Abonado.Categoria == "Grado") { beneficio = 0.05m; }
            if (Abonado.Categoria == "Posgrado") { beneficio = 0.01m; }

            decimal descuento =  diferencia * beneficio;
            return descuento;
        }
        public decimal RetornaNeto()
        {
            return RetornaDiferencia()-Descuento();
        }
    }
}
