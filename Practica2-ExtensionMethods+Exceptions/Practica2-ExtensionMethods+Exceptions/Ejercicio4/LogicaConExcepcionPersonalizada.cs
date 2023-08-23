using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_Exceptions.Ejercicio4
{
    public class LogicaConExcepcionPersonalizada
    {
        public static void LanzarExcepcionPersonalizada()
        {
            try
            {
                Console.WriteLine("Ejercicio 4: Lanzar excepcion personalizada");
                Console.Write("Ingrese un mensaje personalizado para la excepción: ");
                string mensaje = Console.ReadLine();
                throw new ExcepcionPersonalizada(mensaje);
            }
            catch (ExcepcionPersonalizada e)
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
