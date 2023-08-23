using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_Exceptions.Ejercicio3
{
    public static class Logic
    {
        public static void LanzarExcepcion()
        {
            try
            {
                Console.WriteLine("Ejercicio 3: Lanzar excepcion");
                throw new Exception("Excepcion lanzada");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Mensaje de la excepcion: {e.Message}");
                Console.WriteLine($"Tipo de la excepcion: {e.GetType()}");
            }
            finally
            {
                Console.WriteLine("Ejercicio finalizado.");
            }   
        }
    }
}
