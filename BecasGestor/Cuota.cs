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


    }
}
