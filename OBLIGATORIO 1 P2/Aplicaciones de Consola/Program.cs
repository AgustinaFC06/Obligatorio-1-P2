using Biblioteca_de_Clase;

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
                    Console.WriteLine("1- Listar todas las personas con sus activos");
                    Console.WriteLine("2- Listar incidentes de una persona");
                    Console.WriteLine("3- Alta de persona");
                    Console.WriteLine("4- Listar activos sin backup");
                    Console.WriteLine("0- Salir");

                    opcionSeleccionada = int.Parse(Console.ReadLine());

                    if (opcionSeleccionada == 1)
                    {
                        // Lista TODAS las personas con sus activos sin pedir nada
                        s.ListarPersonasConActivos();
                        Console.ReadKey();
                    }
                    else if (opcionSeleccionada == 2)
                    {
                        Console.WriteLine("Ingrese la cedula de la persona: ");
                        int cedula = int.Parse(Console.ReadLine());
                        List<Incidente> listaIncidentes = new List<Incidente>();
                        listaIncidentes = s.MostrarIncidentesPersona(cedula);
                         if(listaIncidentes.Count == 0)
                        {
                            Console.WriteLine("Esta persona no tiene Activos");
                        }
                         if (listaIncidentes[0] == null)
                        {
                            Console.WriteLine("Esta persona no tiene Activos");
                        }
                         if(listaIncidentes.Count >0)
                        //count
                        //recorrer y mostrar con el tostring

                        Console.ReadKey();
                    }
                    // Pide cedula y muestra los incidentes de esa persona

                    else if (opcionSeleccionada == 3)
                    {
                        // Pide todos los datos y da de alta la persona con lista de Cuenta vacía
                        Console.WriteLine("Ingrese la cedula: ");
                        int cedula = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el email: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Ingrese el telefono: ");
                        string telefono = Console.ReadLine();

                        Persona nueva = new Persona(cedula, nombre, email, telefono);
                        s.AltaPersona(nueva);

                        Console.WriteLine($"Persona '{nombre}' agregada correctamente.");
                        Console.ReadKey();
                    }
                    else if (opcionSeleccionada == 4)
                    {
                        // Lista todos los activos que no tienen backup
                        List<Activo> sinBackup = s.ActivosSinBackup();

                        if (sinBackup.Count == 0)
                        {
                            Console.WriteLine("Todos los activos tienen backup.");
                        }
                        else
                        {
                            foreach (Activo activo in sinBackup)
                            {
                                Console.WriteLine($"{activo.CrearAlfanumerico()} - {activo.Nombre} - Tipo: {activo.TipoActivo} - Criticidad: {activo.Criticidad}");
                            }
                        }
                        Console.ReadKey();
                    }
                    else if (opcionSeleccionada == 0)
                    {
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opcion valida");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ha ocurrido un error: " + e.Message);
                }
            }

        }
    }
}






