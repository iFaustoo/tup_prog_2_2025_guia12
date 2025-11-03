using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    [Serializable]
    public class Auto
    {
        int nroRegistro;
        string modelo;
        public double Precio { get; set; }

        public Auto(int registro, string modelo)
        {
            this.nroRegistro = registro;
            this.modelo = modelo;
        }

        public int NroRegistro
        {
            get { return nroRegistro; }
            set { nroRegistro = value; }
        }

        public override string ToString()
        {
            return $"{modelo};{nroRegistro}";
        }
    }
}
