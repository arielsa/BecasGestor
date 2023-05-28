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
           decimal diferencia =  RetornaDiferencia();
            decimal descuento =  diferencia * Abonado.Beneficio;
            return descuento;
        }
    }
}
