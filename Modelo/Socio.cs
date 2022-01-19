using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSocios.Modelo
{
    public class Socio
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNaci { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Saldo { get; set; }
    }
}
