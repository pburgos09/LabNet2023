using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

            for (int i = 1; i <= 5; i++)
            {
                int pasajerosTaxi = LeerPasajeros("Taxi", i, 4);
                transportes.Add(new Taxi(pasajerosTaxi,i));
            }

            for (int i = 1; i <= 5; i++)
            {
                int pasajerosOmnibus = LeerPasajeros("Omnibus", i, 100);
                transportes.Add(new Omnibus(pasajerosOmnibus, i));
            }

            Console.WriteLine("Lista de transportes con su cantidad de pasajeros:");

            foreach (var transporte in transportes)
            {
                Console.WriteLine($"{transporte.GetType().Name} N°{transporte.Interno} : {transporte.Pasajeros} pasajeros");
            }
                Console.ReadKey();
        }

        private static int LeerPasajeros(string tipoTransporte, int interno, int maxPasajeros)
        {
          while(true)
            {
                Console.WriteLine($"Ingrese la cantidad de pasajeros para el {tipoTransporte} N°{interno}: ");
                if(int.TryParse(Console.ReadLine(), out int pasajeros) && pasajeros >= 0 && pasajeros <= maxPasajeros)
                {
                    return pasajeros;
                }
                else
                {
                    Console.WriteLine($"Valor no válido. Ingrese un numero entre 0 y {maxPasajeros}");
                }
            }
        }
    }
}
