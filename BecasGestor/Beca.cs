using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecasGestor
{
    public class Beca
    {
        public Alumno Beneficiario { get; set; }
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
    }
}
