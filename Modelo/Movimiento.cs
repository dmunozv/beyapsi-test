using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSocios.Modelo
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public string Cantidad { get; set; }
        public int id_socio { get; set; }
    }
}
