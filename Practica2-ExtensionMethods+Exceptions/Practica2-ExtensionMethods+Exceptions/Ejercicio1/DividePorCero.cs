using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_Exceptions.Ejercicio1
{
    public static class DividePorCero
    {
        public static void DividirPorCero()
        {
            try
            {
                Console.WriteLine("Ejercicio 1: Divide por cero");
                Console.WriteLine("Ingrese el dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                int divisor = 0;
                int resultado = dividendo / divisor;
                Console.WriteLine($"El resultado de la division es: {resultado}");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("No se puede dividir por cero");
                Console.WriteLine($"Mensaje de la excepcion: {e.Message}");
            }
            catch(FormatException e)
            {
                Console.WriteLine("El valor ingresado no es un numero");
                Console.WriteLine($"Mensaje de la excepcion: {e.Message}");
            }
            catch(Exception e)
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
