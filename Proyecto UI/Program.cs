using Dominio;

namespace Proyecto_UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia;

            int opciones = -1;
            while (opciones != 0)
            {
                #region Menu principal
                try
                {
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("| Sistema de gestion de agendas. |");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("1 - Listado de actividades.");
                    Console.WriteLine("2 - Listado de proveedores.");
                    Console.WriteLine("3 - Buscar actividades segun costo y fechas.");
                    Console.WriteLine("4 - Establecer valor de promocion.");
                    Console.WriteLine("5 - Alta de huesped.");
                    Console.WriteLine("0 - Salir.");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    opciones = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Seleccione una opcion correcta.");
                }
                #endregion
                if (opciones == 1)
                {
                    #region Listado de actividades.
                    Console.Clear();
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("1 - Listado de actividades.");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    foreach (Actividad act in s.GetActividades())
                    {
                        Console.WriteLine(act);
                        Console.WriteLine("*-----------*");
                    }
                    #endregion
                }
                else if (opciones == 2)
                {
                    #region Listado de proveedores.
                    Console.Clear();
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("2 - Listado de proveedores.");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    foreach (Proveedor prov in s.GetProveedores())
                    {
                        Console.WriteLine(prov);
                    }
                    #endregion
                }
                else if (opciones == 3)
                {
                    #region Busqueda de actividades segun costo y fechas.
                    Console.Clear();
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("3 - Buscar actividades segun costo y fechas.");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    try
                    {
                        Console.WriteLine("Costo base: ");
                        int costoBase = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Desde (Fecha base): ");
                        DateTime fechaBase = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Hasta (Fecha maxima): ");
                        DateTime fechaMaxima = DateTime.Parse(Console.ReadLine());
                        foreach (Actividad unaActividad in s.GetActividadesSegunFechaYCosto(costoBase, fechaBase, fechaMaxima))
                        {
                            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*");
                            Console.WriteLine("Actividades encontradas: ");
                            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*");
                            Console.WriteLine(unaActividad);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    #endregion
                }
                else if (opciones == 4)
                {
                    #region Establecer el valor de promocion.
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                        Console.WriteLine("4 - Establecer valor de promocion.");
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                        Console.WriteLine("Ingrese ID del proveedor: ");
                        int idProv = Int32.Parse(Console.ReadLine());
                        Proveedor prov = s.GetProvForID(idProv);
                        Console.WriteLine("Ingrese el valor de promocion: ");
                        double valorPromocion = Int32.Parse(Console.ReadLine());
                        s.SetValorPromocion(prov, valorPromocion);
                        Console.WriteLine($"Se le asigno el descuento de {valorPromocion}% a las actividades de {prov.Nombre}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    #endregion
                }
                else if (opciones == 5)
                {
                    #region Alta de huesped.
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                        Console.WriteLine("5 - Alta de huesped.");
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");

                        Console.WriteLine("Email: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Password: ");
                        string pass = Console.ReadLine();

                        Console.WriteLine("Numero de documento: ");
                        int nroDocumento = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Apellido: ");
                        string apellido = Console.ReadLine();

                        Console.WriteLine("Habitacion: ");
                        string habitacion = Console.ReadLine();

                        Console.WriteLine("Fecha de nacimiento: ");
                        DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Nivel de fidelizacion (1-4): ");
                        int nivelF = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Tipo del documento (1 - CI, 2 - Pasaporte, 3 - Otro): ");
                        int tipoDocumento = Int32.Parse(Console.ReadLine());
                        TipoDoc tipoDoc = TipoDoc.Defecto;

                        if (tipoDocumento == 1)
                        {
                            tipoDoc = TipoDoc.CI;
                        }
                        else if (tipoDocumento == 2)
                        {
                            tipoDoc = TipoDoc.PASAPORTE;
                        }
                        else if (tipoDocumento == 3)
                        {
                            tipoDoc = TipoDoc.OTROS;
                        }

                        Huesped nuevoHuesped = new Huesped(tipoDoc, nroDocumento, nombre, apellido, habitacion, fechaNacimiento, nivelF, email, pass);
                        s.AltaHuesped(nuevoHuesped);
                        Console.WriteLine("Huesped agregado correctamente.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    #endregion
                }
                else if (opciones == 6)
                {
                    #region Alta de agenda.
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                        Console.WriteLine("6 - Alta de agenda.");
                        Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");

                        Console.WriteLine("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Apellido: ");
                        string apellido = Console.ReadLine();

                        Console.WriteLine("Nombre actividad: ");
                        string nombreActividad = Console.ReadLine();

                        Huesped huespedBuscado = s.GetHuespedPorNombre(nombre, apellido);
                        Actividad actBuscada = s.GetActividadPorNombre(nombreActividad);
                        Agenda unaAgenda = new Agenda(huespedBuscado, actBuscada);

                        s.AltaAgenda(unaAgenda);
                        Console.WriteLine("Agenda agregada correctamente.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    #endregion
                }
                else if (opciones == 7)
                {
                    #region Listado de agendas.
                    Console.Clear();
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    Console.WriteLine("7 - Listado de agendas.");
                    Console.WriteLine("|*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*|");
                    foreach (Agenda agenda in s.GetAgendas())
                    {
                        Console.WriteLine(agenda);
                        Console.WriteLine("*-----------*");
                    }
                    #endregion
                }
            }
            Console.ReadKey();
        }
    }
}