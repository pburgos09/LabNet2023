using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros, int interno) : base(pasajeros, interno)
        {
            if (pasajeros <= 100)
            {
                return;
            }
            throw new ArgumentException("La cantidad máxima de pasajeros es de 100");
        }

        public override string Avanzar()
        {
            return $"Omnibus N°{Interno} está avanzando con {Pasajeros} pasajeros.";
        }

        public override string Detenerse()
        {
            return $"Omnibus N°{Interno} ahora está detenido.";
        }

    }
}
