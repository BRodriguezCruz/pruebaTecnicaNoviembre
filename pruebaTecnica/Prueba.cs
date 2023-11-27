using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pruebaTecnicaPunto1
{
    public class Prueba
    {

        public int Id { get; } = 1;
        public string Nombre { get; set; }
        public string Locacion { get; set; }
        public List<object> Datos { get; set; }


        public string Data()
        {   

            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    Console.WriteLine("Escribe tu Nombre: ");
                    Nombre = Console.ReadLine();
                }
                if (j == 1)
                {
                    Console.WriteLine("Escribe tu Locacion: ");
                    Locacion = Console.ReadLine();
                }
            }

            string datos = "El ID de tu zona es " + Id + ", tu nombre es " + Nombre + ", y vives en: " + Locacion;

            return datos;
        }

        public string Data(string nombre, string locacion, int num)
        {
            string[] datos = {nombre, locacion};

            int aux = 0;

            string id = "Soy el numero " + Id;
            string datos1 = "";
            string datos2 = "";
            string datos3 = "";


            while (aux != datos.Length)
            {
                Nombre = datos[0];
                Locacion = datos[1];

                if (aux == 0)
                {
                    datos1 = "Hola mi nombre es " + Nombre;
                }
                if (aux == 1)
                {
                    datos2 = "Vivo muy lejos, estoy en " + Locacion;

                    if (num != Id)
                    {
                        datos3 = "Esa persona no vive en tu misma zona :(";
                    }
                    else
                    {
                        datos3 = "Esa persona vive en tu misma zona";
                    }
                }
                aux++;
            }


            string datosMetodo2 = datos1 + ", " + datos2 + " y " + datos3;

            return datosMetodo2;
        }
    }
}
