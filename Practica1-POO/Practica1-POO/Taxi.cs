using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros, int interno) : base(pasajeros, interno)
        {
            if (pasajeros <= 4)
            {
                return;
            }
            throw new ArgumentException("La cantidad máxima de pasajeros es de 4");
        }

        public override string Avanzar()
        {
            return $"Taxi N°{Interno} está avanzando con {Pasajeros} pasajeros.";
        }

        public override string Detenerse()
        {
            return $"Taxi N°{Interno} ahora está detenido.";
        }
    }
}
