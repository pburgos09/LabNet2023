using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_Exceptions.Ejercicio2
{
    public static class DivisionComun
    {
        public static void Dividir()
        {
            try
            {
                Console.WriteLine("Ejercicio 2: Division comun");
                Console.WriteLine("Ingrese el dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                int resultado = dividendo / divisor;
                Console.WriteLine($"El resultado de la division es: {resultado}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Que bruto, pongale cero!!");
                Console.WriteLine($"Mensaje de la excepcion: {e.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("¡Seguro ingresó una letra o no ingresó nada!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Mensaje de la excepcion: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Ejercicio finalizado.");
            }
        }
    }
}
