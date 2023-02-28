using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class Personal
    {
        private string nombre;
        private string dni;
        protected int horas;
        protected double importe;

        protected string Nombre
        {
            get => nombre; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Nombre vacio");
                }
                if (value.Any(char.IsNumber))
                {
                    throw new Exception("El nombre contiene numeros");
                }
                nombre = value;
            }
        }

        protected string Dni
        {
            get => dni; set
            {
                if (value.Length != 9 || value.Substring(0, 8).Any(char.IsLetter) || char.IsNumber(value[8]))
                {
                    throw new Exception("DNI in correcto");
                }
                dni = value;
            }
        }

        public Personal(string nombre, string dni, int horas, double importe)
        {
            if (horas < 20 || horas > 40)
            {
                throw new Exception("Cantidad de horas no permitidas");
            }
            if (importe < 5)
            {
                throw new Exception("Salario por debajo del minimo");
            }
            Nombre = nombre;
            Dni = dni;
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
        public new double salarioMensual()
        {
            return base.salarioMensual() + extras * 6;
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
