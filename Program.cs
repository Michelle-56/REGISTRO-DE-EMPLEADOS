using System;
using System.Collections.Generic;

namespace registro_de_empleados
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal SalarioBase { get; set; }
        public decimal HorasExtra { get; set; }

        public Empleado(int id, string nombre, decimal salarioBase, decimal horasExtra)
        {
            Id = id;
            Nombre = nombre;
            SalarioBase = salarioBase;
            HorasExtra = horasExtra;
        }

        public decimal PagoTotal()
        {
            return SalarioBase + (HorasExtra * 50.00m);
        }
    }

    class Program
    {
        public static void Main()
        {
            List<Empleado> empleados = new List<Empleado>();

            int siguienteId = 1;
            int opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado(empleados, ref siguienteId);
                        break;

                    case 2:
                        ListarEmpleados(empleados);
                        break;

                    case 3:
                        BuscarEmpleado(empleados);
                        break;

                    case 4:
                        CalcularFactorial();
                        break;

                    case 5:
                        Console.WriteLine("\nPrograma finalizado.");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        private static int LeerOpcionMenu()
        {
            

            Console.WriteLine("==================================");
            Console.WriteLine("       REGISTRO DE EMPLEADOS");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Listar empleados");
            Console.WriteLine("3. Buscar empleado");
            Console.WriteLine("4. Calcular factorial");
            Console.WriteLine("5. Salir");
            Console.WriteLine("==================================");
            Console.Write("Seleccione una opción: ");

            int opcion;

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                return opcion;
            }

            return 0;
        }

        private static void AgregarEmpleado(
            List<Empleado> empleados,
            ref int siguienteId)
        {
           

            Console.WriteLine("==================================");
            Console.WriteLine("        AGREGAR EMPLEADO");
            Console.WriteLine("==================================");

            string nombre;

            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            decimal salarioBase;

            do
            {
                Console.Write("Salario base: ");

                if (!decimal.TryParse(Console.ReadLine(), out salarioBase) ||
                    salarioBase <= 0)
                {
                    Console.WriteLine("Ingrese un salario válido mayor que 0.");
                }

            } while (salarioBase <= 0);

            decimal horasExtra;

            do
            {
                Console.Write("Horas extra: ");

                if (!decimal.TryParse(Console.ReadLine(), out horasExtra) ||
                    horasExtra < 0)
                {
                    Console.WriteLine("Ingrese una cantidad válida de horas.");
                }

            } while (horasExtra < 0);

            Empleado empleado = new Empleado(
                siguienteId,
                nombre,
                salarioBase,
                horasExtra
            );

            empleados.Add(empleado);

            Console.WriteLine("\nEmpleado agregado correctamente.");
            Console.WriteLine("ID asignado: " + siguienteId);

            siguienteId++;
        }

        private static void ListarEmpleados(List<Empleado> empleados)
        {
            

            Console.WriteLine("==================================");
            Console.WriteLine("         LISTA DE EMPLEADOS");
            Console.WriteLine("==================================");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            decimal totalNomina = 0;

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine("\nID: " + empleado.Id);
                Console.WriteLine("Nombre: " + empleado.Nombre);
                Console.WriteLine("Salario base: Q" +
                                  empleado.SalarioBase.ToString("F2"));
                Console.WriteLine("Horas extra: " +
                                  empleado.HorasExtra);
                Console.WriteLine("Pago total: Q" +
                                  empleado.PagoTotal().ToString("F2"));

                totalNomina += empleado.PagoTotal();
            }

            Console.WriteLine("\n==================================");
            Console.WriteLine("TOTAL GENERAL DE NÓMINA: Q" +
                              totalNomina.ToString("F2"));
        }

        private static void BuscarEmpleado(List<Empleado> empleados)
        {
           

            Console.WriteLine("==================================");
            Console.WriteLine("         BUSCAR EMPLEADO");
            Console.WriteLine("==================================");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.Write("Ingrese el nombre a buscar: ");
            string texto = Console.ReadLine();

            bool encontrado = false;

            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre.IndexOf(
                    texto,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine("\nEmpleado encontrado:");
                    Console.WriteLine("ID: " + empleado.Id);
                    Console.WriteLine("Nombre: " + empleado.Nombre);
                    Console.WriteLine("Salario base: Q" +
                                      empleado.SalarioBase.ToString("F2"));
                    Console.WriteLine("Horas extra: " +
                                      empleado.HorasExtra);
                    Console.WriteLine("Pago total: Q" +
                                      empleado.PagoTotal().ToString("F2"));

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\nNo se encontró ningún empleado.");
            }
        }

        private static void CalcularFactorial()
        {
            

            Console.WriteLine("==================================");
            Console.WriteLine("        CALCULAR FACTORIAL");
            Console.WriteLine("==================================");

            Console.Write("Ingrese un entero no negativo: ");

            int numero;

            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("\nDato inválido.");
                return;
            }

            if (numero < 0)
            {
                Console.WriteLine("\nDato inválido.");
                return;
            }

            long resultado = Factorial(numero);

            Console.WriteLine("\n" + numero + "! = " + resultado);
        }

        private static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}