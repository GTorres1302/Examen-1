using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_UH
{
    internal class clsEmpleado
    {
        private string nombre;
        private string cedula;
        private string direccion;
        private string telefono;
        private float salario;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public float Salario { get => salario; set => salario = value; }

        public clsEmpleado(string _nombre, string _cedula, string _direccion, string _telefono, float _salario)
        {
            this.nombre = _nombre;
            this.cedula = _cedula;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.salario = _salario;
        }

    }
}
