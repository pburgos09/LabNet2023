using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionMethods_Exceptions.Ejercicio4
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string mensaje) : base("Mensaje personalizado: " + mensaje)
        {
        }

        public override string Message
        {
            get
            {
                return "¡Excepción personalizada! " + base.Message;
            }
        }
    }
}
