using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    [Serializable]
    public class Sistema
    {
        public int NroOrden {  get; set; }
        List<Camion> listaCamiones = new List<Camion>();
        List<Auto> listaAutos = new List<Auto>();

        public void RecibirCamion(Camion unCamion)
        {
            listaCamiones.Add(unCamion);
        }

        public Auto DescargarCamion(int nroOrden)
        {
            Camion buscado = VerCamion(nroOrden);

            Auto retirado = null;

            if(buscado != null)
            {
                retirado = buscado.RetirarVehiculo();
                listaAutos.Add(retirado);
            }

            return retirado;
        }

        public Camion VerCamion(int numero)
        {
            for (int n = 0; n < listaCamiones.Count; n++)
            {
                if (listaCamiones[n].NroRegistro == numero)
                    return listaCamiones[n];
            }
            return null;
        }

        public int GenerarCamion(DateTime fecha, int cantidad)
        {
            Camion nuevoCamion = new Camion(fecha, cantidad);
            RecibirCamion(nuevoCamion);
            nuevoCamion.NroRegistro = NroOrden;

            return nuevoCamion.NroRegistro;
        }

        public void CargarCamion(int nroOrden, Auto unAuto)
        {
            Camion buscado = VerCamion(nroOrden);

            if (buscado != null)
            {
                listaCamiones[nroOrden].CargarVehiculo(unAuto);
                listaAutos.Remove(unAuto);

            }
        }

        public void CerrarCamion(int nro)
        {
            Camion camion = VerCamion(nro);
            if (camion != null)
            {
                //  if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // string path= saveFileDialog1.FileName;

                    string path = camion.ToString() + ".csv";

                    FileStream fs = null;
                    StreamWriter sw = null;
                    try
                    {

                        fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        sw = new StreamWriter(fs);

                        foreach (string linea in camion.VerCarga())
                        {
                            sw.WriteLine(linea);
                        }
                        ;
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        if (sw != null) sw.Close();
                        if (fs != null) fs.Close();
                    }
                }
            }
        }
    }
}
