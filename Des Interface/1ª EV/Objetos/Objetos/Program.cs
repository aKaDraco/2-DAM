using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void mostrarPasta(IPastaGansa pg)
            {
                Console.WriteLine("Cual es el benficio de la empresa?");
                try
                {
                    double beneE = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Beneficios del directivo: " + pg.ganarPasta(beneE));
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("ERROR");
                }
            }

            Directivo d = new Directivo("Pedro", "Dominguez", 42, "55584769P", "Contabilidad", 10);
            Empleado e = new Empleado("Juan", "Santos", 34, "77789124U", 1500, 15, "774589102");
            EmpleadoEspecial ee = new EmpleadoEspecial("Doble V", "Vicente", 8, "48736791A");
            Boolean comp = true;
            while (comp == true)
            {
                try
                {
                    Console.WriteLine("Elige una de las siguientes opciones:");
                    Console.WriteLine();
                    Console.WriteLine("1.- Visualizar los datos del Directivo");
                    Console.WriteLine("2.- Visualizar datos Empleado");
                    Console.WriteLine("3.- Visualizar datos EmpleadoEspecial");
                    Console.WriteLine("4.- Salir");
                    Console.WriteLine();
                    int respuesta = Convert.ToInt32(Console.ReadLine());

                    switch (respuesta)
                    {
                        case 1:
                            d.MuestraDatos();
                            mostrarPasta(d);
                            d.hacienda();
                            break;
                        case 2:
                            e.MuestraDatos();
                            e.hacienda();
                            break;
                        case 3:
                            mostrarPasta(ee);
                            ee.hacienda();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ADIOS");
                            Console.ResetColor();
                            comp = false;
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion no valida");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("---ERROR---");
                }
            }

        }

    }
    abstract class Persona
    {
        private string nombre;
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        private string apellidos;
        public string Apellidos
        {
            set { apellidos = value; }
            get { return apellidos; }
        }
        private int edad;
        public int Edad
        {
            set { if (value > 0) edad = value; else edad = 0; }
            get { return edad; }
        }
        private string dni;
        public string Dni
        {
            set { dni = value.Substring(0, 8); }
            get
            {
                int calculo = Convert.ToInt32(dni) % 23;
                string[] letras = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                string letra = "T";
                //  for (int i = 0; i <= 22; i++)
                //{
                //}
                letra = letras[calculo];
                return dni + letra;
            }
        }

        public Persona(String nombre, String apellidos, int edad, String dni)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Dni = dni;
        }

        public Persona()
            : this("", "", 0, "")
        {
        }

        public virtual void MuestraDatos()
        {
            Console.WriteLine("{0} {1}\n{2}\n{3}\n", Nombre, Apellidos, Edad, Dni);
        }

        public virtual void PedirDatos()
        {
            Console.WriteLine("Introduce tu nombre");
            Nombre = Console.ReadLine();
            Console.WriteLine("Introduce tus apellidos");
            Apellidos = Console.ReadLine();
            Console.WriteLine("Introduce tu edad");
            Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce tu DNI");
            Dni = Console.ReadLine();
        }

        public abstract double hacienda();
    }

    class Empleado : Persona
    {
        private double salario;
        public double Salario
        {
            set
            {
                salario = value;
                if (value < 600)
                {
                    this.irpf = 0.07;
                }
                else if (value >= 600 && value < 3000)
                {
                    this.irpf = 0.15;
                }
                else
                {
                    this.irpf = 0.20;
                }
            }
            get
            {
                return salario;
            }
        }
        private double irpf;
        public double Irpf
        {
            get { return irpf; }
        }
        private string telefono;
        public string Telefono
        {
            set { telefono = value; }
            get
            {
                return "+34 " + telefono;
            }
        }

        public Empleado(String nombre, String apellidos, int edad, String dni, double salario, double irpf, String telefono)
            : base(nombre, apellidos, edad, dni)
        {
            this.Salario = salario;
            this.irpf = irpf;
            this.telefono = telefono;
        }

        public Empleado()
            : this("", "", 0, "", 0, 0, "")
        {
        }

        public override void MuestraDatos()
        {
            base.MuestraDatos();
            Console.WriteLine("{0}\n{1}\n{2}\n", Salario, Irpf, Telefono);
        }
        public void MuestraDatos(int n)
        {
            switch (n)
            {
                case 0:
                    Console.WriteLine("Nombre: " + Nombre);
                    break;
                case 1:
                    Console.WriteLine("Apellidos: " + Apellidos);
                    break;
                case 2:
                    Console.WriteLine("Edad: " + Edad);
                    break;
                case 3:
                    Console.WriteLine("DNI: " + Dni);
                    break;
                case 4:
                    Console.WriteLine("Salario: " + Salario);
                    break;
                case 5:
                    Console.WriteLine("Irpf: " + Irpf);
                    break;
                case 6:
                    Console.WriteLine("Teléfono: " + Telefono);
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }

        public override double hacienda()
        {
            return Irpf * Salario / 100;
        }
    }

    class Directivo : Persona, IPastaGansa
    {
        private double PastaGanada;
        private string departamento;
        public string Departamento
        {
            set { departamento = value; }
            get { return departamento; }
        }
        private double beneficios;
        public double Beneficios
        {
            get { return beneficios; }
        }
        private int personas;
        public int Personas
        {
            set
            {
                personas = value;
                if (personas <= 10)
                {
                    beneficios = 0.02;
                }
                else if (personas > 10 && personas < 50)
                {
                    beneficios = 0.035;
                }
                else
                {
                    beneficios = 0.04;
                }
            }
            get { return personas; }
        }

        public Directivo(String nombre, String apellidos, int edad, String dni, String departamento, int personas)
            : base(nombre, apellidos, edad, dni)
        {
            this.Departamento = departamento;
            this.Personas = personas;
        }
        public override void MuestraDatos()
        {
            base.MuestraDatos();
            Console.WriteLine("Departamento: " + Departamento);
            Console.WriteLine("Beneficios: " + Beneficios);
            Console.WriteLine("Personas a cargo: " + Personas);
        }

        public override void PedirDatos()
        {
            base.PedirDatos();
            Console.WriteLine("Introduzca el departamento al que pertenece");
            Departamento = Console.ReadLine();
            Console.WriteLine("Introduzca el número de personas que tienes a cargo");
            Personas = Convert.ToInt32(Console.ReadLine());
        }

        public static Directivo operator --(Directivo d)
        {
            if (d.beneficios > 1)
            {
                d.beneficios--;
            }
            else
            {
                d.beneficios = 0;
            }
            return d;
        }

        public override double hacienda()
        {
            return (PastaGanada * 30) / 100;
        }

        public double ganarPasta(double beneficiosE)
        {
            double ganancias = (beneficiosE * beneficios) / 100;
            if (beneficiosE < 0)
            {
                Directivo d = this;
                d--;
                ganancias = 0;
            }
            PastaGanada = ganancias;
            return ganancias;
        }
    }
    class EmpleadoEspecial : Empleado, IPastaGansa
    {

        public EmpleadoEspecial(String nombre, String apellidos, int edad, String dni)
            : base(nombre, apellidos, edad, dni)//
        {
        }
        public double ganarPasta(double beneficiosE)
        {
            return (beneficiosE * 0.5) / 100;
        }

        public override double hacienda()
        {
            return ((base.hacienda() * 0.5) / 100) + base.hacienda();
        }
    }
    public interface IPastaGansa
    {
        public double ganarPasta(double beneficios);
    }

}