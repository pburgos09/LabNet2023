using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; set; }
        public int Interno { get; set; }

        public TransportePublico(int pasajeros, int interno)
        {
            this.Pasajeros = pasajeros;
            this.Interno = interno;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
