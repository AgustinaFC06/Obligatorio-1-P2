using Biblioteca_de_Clase;
using System;
using System.Collections.Generic;
namespace Aplicaciones_de_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //agregado para usar caracteres de diseño

            Sistema s = Sistema.GetInstancia();
            #region Opciones en Consola
            int opcionSeleccionada = -1;

            while (opcionSeleccionada != 0)
            {
                try
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("╔════════════════════════════════════════════╗");
                    Console.WriteLine("║      SISTEMA DE GESTION DE INCIDENTES      ║");
                    Console.WriteLine("╠════════════════════════════════════════════╣");

                    Console.ResetColor();

                    Console.WriteLine("║  [1] Listar personas y activos             ║");
                    Console.WriteLine("║  [2] Ver incidentes de una persona         ║");
                    Console.WriteLine("║  [3] Alta de persona                       ║");
                    Console.WriteLine("║  [4] Activos sin backup                    ║");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("║  [0] Salir                                 ║");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("╚════════════════════════════════════════════╝");

                    Console.ResetColor();

                    Console.Write("\nSeleccione una opcion: ");

                    opcionSeleccionada = int.Parse(Console.ReadLine());

                    switch (opcionSeleccionada)
                    {
                        case 1:
                            Console.Clear();
                            Opcion1_ListarPersonasConActivos(s);
                            break;

                        case 2:
                            Console.Clear();
                            Opcion2_ListarIncidentesPersona(s);
                            break;

                        case 3:
                            Console.Clear();
                            Opcion3_AltaPersona(s);
                            break;

                        case 4:
                            Console.Clear();
                            Opcion4_ListarActivosSinBackup(s);
                            break;

                        case 0:
                            Console.Clear();
                            Console.WriteLine("\n¡Nos vemos la proxima profe!");
                            break;

                        default:
                            Console.WriteLine("\nOpcion invalida");
                            Console.WriteLine("\nPresiona cualquier tecla para continuar");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nError: {e.Message}");
                    Console.WriteLine("\nPresiona cualquier tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
            #endregion

            #region Metodos del UI

        static void Opcion1_ListarPersonasConActivos(Sistema s)
        {
            // Console.Clear();
            Console.WriteLine("╔═════════════════════════════════════════════╗");
            Console.WriteLine("║      LISTADO DE PERSONAS Y SUS ACTIVOS      ║");
            Console.WriteLine("╚═════════════════════════════════════════════╝");
            List<Persona> personas = s.ObtenerPersonasConActivos();

            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas");
            }
            else
            {
                foreach (Persona persona in personas)
                {
                    Console.WriteLine(persona.ToString());

                    bool tieneActivos = false;

                    foreach (Cuenta cuenta in persona.Cuenta)
                    {
                        foreach (Activo activo in cuenta.Activo)
                        {
                            Console.WriteLine($"-{activo.CrearAlfanumerico()}-{activo.Nombre}");
                            tieneActivos = true;
                        }
                    }

                    if (!tieneActivos)
                    {
                        Console.WriteLine("(Sin activos asignados)");
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        static void Opcion2_ListarIncidentesPersona(Sistema s)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║       LISTAR INCIDENTES DE PERSONAS     ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ResetColor();
            Console.Write("Ingrese la cedula de la persona: ");
            int cedula = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║         INCIDENTES         ║");
            Console.WriteLine("╚════════════════════════════╝");

            Console.ResetColor(); List<Incidente> incidentes = s.ListarIncidentesPersona(cedula);
            if (incidentes.Count == 0)
            {
                Console.WriteLine("  Sin incidentes registrados o no se encontro persona con esta cedula");
            }
            else
            {
                foreach (Incidente inc in incidentes)
                {
                    Console.WriteLine(inc.ToString());  // Polimorfismo
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        static void Opcion3_AltaPersona(Sistema s)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("║      ALTA DE PERSONA       ║");
                Console.WriteLine("╚════════════════════════════╝");

                Console.ResetColor();

                Console.Write("Ingrese la cedula: ");
                int cedula = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese el email: ");
                string email = Console.ReadLine();

                Console.Write("Ingrese el teléfono: ");
                string telefono = Console.ReadLine();

                Persona nueva = new Persona(cedula, nombre, email, telefono);
                s.AltaPersona(nueva);

                Console.WriteLine($"\n✓ Persona '{nombre}' agregada correctamente.");
            }
            catch (FormatException)
            {

                Console.WriteLine("\nError: Debe ingresar nuevamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nError: {e.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Opcion4_ListarActivosSinBackup(Sistema s)
        {

            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║       ACTIVOS SIN BACKUP      ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            List<Activo> sinBackup = s.ActivosSinBackup();

            if (sinBackup.Count == 0)
            {
                Console.WriteLine("Todos los activos tienen backup");
            }
            else
            {
                Console.WriteLine($"Se encontraron {sinBackup.Count} activos sin backup:\n");
                foreach (Activo activo in sinBackup)
                {
                    Console.WriteLine($"  - {activo.ToString()}");

                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
        #endregion