using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecasGestor
{
    public class Beca
    {
        private Alumno Beneficiario { get; set; }
        public string Codigo { get; set; }  

        public DateTime OtorgamientoDate { get; set; }
        public decimal Importe {get; set; } 
        
        public Beca(Alumno pBeneficiario)
        {
            Beneficiario = new Alumno (pBeneficiario);
        }
        public Beca(Alumno pBeneficiario, string pCodigo, DateTime pOtorgamientoDate, decimal pImporte) : this(pBeneficiario)
        {
            Codigo = pCodigo;
            OtorgamientoDate = pOtorgamientoDate;
            Importe = pImporte;
        }
        public Beca(string pcodigo, DateTime pFecha, decimal pImporte)
        {
            Codigo = pcodigo;
            OtorgamientoDate=pFecha;
            Importe=pImporte;

        }
        public Beca (Beca pBeca)
        {
            Codigo = pBeca.Codigo;
            OtorgamientoDate = pBeca.OtorgamientoDate;
            Importe = pBeca.Importe;
            Beneficiario = pBeca.Beneficiario;            
        }
        public Beca(string codigo)
        {
            Codigo = codigo;
        }
        public Alumno RetornaBeneficiario()
        {
            return Beneficiario == null ? null : new Alumno(Beneficiario);
        }
        public void IndicarBeneficiario (Alumno pbeneficiario)
        {
            Beneficiario = new Alumno(pbeneficiario);
        }
    }
}
