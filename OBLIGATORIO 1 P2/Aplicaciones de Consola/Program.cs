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

                    switch (opcionSeleccionada)
                    {
                        case 1:
                            // 4a) Lista TODAS las personas con sus activos
                            s.ListarPersonasConActivos();
                            Console.ReadKey();
                            break;

                        case 2:
                            // 4b) Pide cedula y muestra incidentes de esa persona
                            Console.WriteLine("Ingrese la cedula de la persona: ");
                            int cedula2 = int.Parse(Console.ReadLine());

                            List<Incidente> listaIncidentes = s.ListarIncidentesPersona(cedula2);

                            if (listaIncidentes == null)
                            {
                                Console.WriteLine("No se encontro ninguna persona con esa cedula.");
                            }
                            else if (listaIncidentes.Count == 0)
                            {
                                Console.WriteLine("Esta persona no tiene incidentes registrados.");
                            }
                            else
                            {
                                foreach (Incidente inc in listaIncidentes)
                                {
                                    // POLIMORFISMO: inc es Incidente pero ejecuta
                                    // el ToString() de Phishing o Ransomware segun corresponda
                                    Console.WriteLine(inc.ToString());
                                }
                            }
                            Console.ReadKey();
                            break;

                        case 3:
                            // 4c) Alta de persona con lista de Cuenta vacia
                            Console.WriteLine("Ingrese la cedula: ");
                            int cedula3 = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el nombre: ");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el email: ");
                            string email = Console.ReadLine();

                            Console.WriteLine("Ingrese el telefono: ");
                            string telefono = Console.ReadLine();

                            Persona nueva = new Persona(cedula3, nombre, email, telefono);
                            s.AltaPersona(nueva);

                            Console.WriteLine($"Persona '{nombre}' agregada correctamente.");
                            Console.ReadKey();
                            break;

                        case 4:
                            // 4d) Lista activos sin backup
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
                            break;

                        case 0:
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Ingrese una opcion valida");
                            break;
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
