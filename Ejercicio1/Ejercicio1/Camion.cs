using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    [Serializable]
    public class Camion
    {
        Stack<Auto> transporte = new Stack<Auto>();
        DateTime fecha;
        int cantidad;
        double valorAsegurado;

        public int NroRegistro { get; set; }

        public Camion(DateTime fecha, int cantidad)
        {
            this.fecha = fecha;
            this.cantidad = cantidad;
        }

        public void CargarVehiculo(Auto unAuto)
        {
            if (transporte.Count < cantidad)
            {
                transporte.Push(unAuto);
            }
        }

        public Auto RetirarVehiculo()
        {
            if (transporte.Count > 0)
            {
                return transporte.Pop();
            }

            return null;
        }

        public string[] VerCarga()
        {
            string[] carga = new string[cantidad];
            int aux = 0;

            foreach (Auto unAuto in transporte)
            {
                carga[aux++] = unAuto.ToString();
            }

            return carga;
        }

        public override string ToString()
        {
            return "NroRegistro " + NroRegistro + "Fecha " + fecha.Day + "." + fecha.Month + "." + fecha.Year;
        }

        public double ValorAsegurado()
        {
            return valorAsegurado;
        }

        public int CantidadVehiculos()
        {
            return transporte.Count;
        }
    }
}
