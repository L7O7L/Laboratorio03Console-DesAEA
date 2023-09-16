using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Trabajador
    {
        public int id_trabajador {  get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public decimal sueldo { get; set; }
        public string fecha_nacimiento { get; set; }

        public Trabajador () { }

        public Trabajador(int id_trabajador, string nombres, string apellidos, decimal sueldo, string fecha_nacimiento)
        {
            this.id_trabajador = id_trabajador;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.sueldo = sueldo;
            this.fecha_nacimiento = fecha_nacimiento;
        }
    }
}
