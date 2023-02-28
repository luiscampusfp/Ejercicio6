using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class Personal
    {
        protected string nombre;
        protected string dni;
        protected int horas;
        protected double importe;

        public Personal(string nombre, string dni, int horas, double importe)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.horas = horas;
            this.importe = importe;
        }

        public double salarioMensual()
        {
            return horas * importe * 4;
        }
    }

    public class PAS : Personal
    {
        protected int extras;
        public PAS(string nombre, string dni, int horas, double importe, int extras) : base(nombre, dni, horas, importe)
        {
            this.extras = extras;
        }
        public new double salarioMensual() {
            return base.salarioMensual() +extras*6;
        }
    }

    public class PDI : Personal
    {
        public PDI(string nombre, string dni, int horas, double importe) : base(nombre, dni, horas, importe)
        {
        }


    }

    public class Administrativo : PAS
    {
        public Administrativo(string nombre, string dni, int extras) : base(nombre, dni, 37, 7.5, extras)
        {
        }
    }

    public class Informatico : PAS
    {
        public Informatico(string nombre, string dni, int extras) : base(nombre, dni, 40, 6, extras)
        {
        }
    }

    public class Profesor : PDI
    {
        private int anyos;
        public Profesor(string nombre, string dni, int anyos) : base(nombre, dni, 37, 8)
        {
            this.anyos = anyos;
        }

        public new double salarioMensual()
        {
            return base.salarioMensual() + anyos / 6 * 100;
        }
    }

    public class Investigador : PDI
    {
        public Investigador(string nombre, string dni) : base(nombre, dni, 35, 7)
        {
        }
    }
}
