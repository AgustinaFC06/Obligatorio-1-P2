using Biblioteca_de_Clase;
using System;
using System.Collections.Generic;
namespace Aplicaciones_de_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.GetInstancia();
            int opcionSeleccionada = -1;

            while (opcionSeleccionada != 0)
            {
                try
                {
                    //Console.Clear();// se repite titulo en opcion 1 si se pone en cada opcion no repite pero queda registro
                    Console.WriteLine("\n╔══════════════════════════════════════════╗");
                    Console.WriteLine("║   SISTEMA DE GESTIÓN DE INCIDENTES      ║");
                    Console.WriteLine("╚══════════════════════════════════════════╝\n");
                    Console.WriteLine("1. Listar todas las personas con sus activos");
                    Console.WriteLine("2. Listar incidentes de una persona");
                    Console.WriteLine("3. Alta de persona");
                    Console.WriteLine("4. Listar activos sin backup");
                    Console.WriteLine("0. Salir");
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

        #region Metodos del UI

        static void Opcion1_ListarPersonasConActivos(Sistema s)
        {
            // Console.Clear();
            Console.WriteLine("\n=== LISTADO DE PERSONAS Y SUS ACTIVOS ===\n");

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
            Console.WriteLine("\n=== LISTAR INCIDENTES DE UNA PERSONA ===\n");

            Console.Write("Ingrese la cedula de la persona: ");
            int cedula = int.Parse(Console.ReadLine());

            //Persona persona = s.BuscarPersonaPorCedula(cedula);
            //
            //if (persona == null)
            //{
            //    Console.WriteLine("\nNo se encontro ninguna persona con esa cedula");
            //}
            //else
            //{
            //    Console.WriteLine($"\nPersona: {persona}");
            //    Console.WriteLine("\n--- INCIDENTES ---\n");
            //
            //    List<Incidente> incidentes = persona.ObtenerMisIncidentes(s.Incidentes);
            Console.WriteLine("\n--- INCIDENTES ---\n");
            List<Incidente> incidentes = s.ListarIncidentesPersona(cedula);
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
                //Console.Clear();
                Console.WriteLine("\n=== ALTA DE PERSONA ===\n");

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
            //Console.Clear();
            Console.WriteLine("\n=== ACTIVOS SIN BACKUP ===\n");

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