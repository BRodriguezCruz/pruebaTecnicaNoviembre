using pruebaTecnicaPunto1;
using System.ComponentModel.DataAnnotations;

namespace pruebaTecnica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prueba prueba = new Prueba();

            string datos = prueba.Data();

            Console.WriteLine(datos);
            Console.ReadKey();


            Console.WriteLine("A CONTINUACION EL SEGUNDO METODO, POR FAVOR DA UN ENTER :)");
            Console.ReadKey();
            Console.WriteLine("Escribe el nombre de alguien mas: ");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe donde vive: ");
            string locacion = Console.ReadLine();
            Console.WriteLine("Escribe el codigo de su zona: ");
            string id = Console.ReadLine();
            int numero = int.Parse(id);


            string datos2 = prueba.Data(name, locacion, numero);
            Console.WriteLine(datos2);
        }
    }
}