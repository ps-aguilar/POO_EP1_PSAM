using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace POO_EP1_PSAM
{
    internal class Menu
    {
        private List<Opcion> opcionesPrincipales;
        private List<Opcion> opcionesClientes;
        private Tienda tienda;
        private Cliente clienteActual;

        public Menu()
        {
            tienda = new Tienda();
            clienteActual = null;

            opcionesPrincipales = new List<Opcion>
            {
                new Opcion("Registrarse", registrarse),
                new Opcion("Iniciar sesión", iniciarSesion),
                new Opcion("Ver catálogo", verCatalogo), 
                new Opcion("Salir", salir),
            };

            opcionesClientes = new List<Opcion>
            {
                new Opcion("Agregar productos al carrito", agregarCarrito),
                new Opcion("Ver carrito", verCarrito),
                new Opcion("Total de la compra", calcularTotal),
                new Opcion("Cerrar sesión", cerrarSesion)
            };

            mostrarMenuPrincipal();
            
        }

        public void mostrarMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("** Bienvenid@ a Tienda de Arte**");
                Console.WriteLine("Seleccione la opción deseada:");
                Console.WriteLine();
                foreach (Opcion opcion in opcionesPrincipales)
                {
                    Console.WriteLine(opcionesPrincipales.IndexOf(opcion) + " .  " + opcion.Message);
                }
                Console.WriteLine();
                seleccionarOpcion(opcionesPrincipales);
            }
        }

        public void mostrarMenuClientes() //Solo se llamará después de un inicio de sesión
        {
            while (true) 
            {
                Console.WriteLine("**Tienda de Arte**");
                Console.WriteLine("Seleccione la opción deseada:");
                Console.WriteLine();
                foreach (Opcion opcion in opcionesClientes)
                {
                    Console.WriteLine(opcionesClientes.IndexOf(opcion) + " .  " + opcion.Message);
                }
                Console.WriteLine();
                seleccionarOpcion(opcionesClientes);
            }
        }

        public void seleccionarOpcion(List<Opcion> opciones)
        {
            int numOpcion = int.Parse(Console.ReadLine());
            Console.Clear();
            opciones[numOpcion].Action.Invoke();
            Console.Clear();
        }

        public void Continuar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }

        public void registrarse()
        {
            Console.WriteLine("Registro de Cliente:\n");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Correo Electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            tienda.registrarCliente(nombre, correo, contrasena);
            Console.WriteLine("\nCliente registrado con éxito.");
            Continuar();
        }

        public void iniciarSesion()
        {
            Console.WriteLine("Iniciar Sesión:\n");
            Console.WriteLine("Ingresa tu correo electrónico:");
            string correo = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña:");
            string contrasena = Console.ReadLine();
            Console.WriteLine();

            int status = tienda.verificarContrasena(correo, contrasena);
            if (status == 1)
            {
                clienteActual = tienda.obtenerCliente(correo);
                Console.WriteLine("Inicio de sesión exitoso.");
                Console.Clear();
                mostrarMenuClientes();
            }
            else if (status == -1)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else if (status == 0)
            {
                Console.WriteLine("Correo no encontrado.");
            }
            else if (status == -2)
            {
                Console.WriteLine("Contraseña incorrecta.");
            }
            Continuar();
        }

        public void verCatalogo()
        {
            Console.WriteLine("Catálogo de Productos:\n");
            List<string> catalogo = tienda.verCatalogo();
            foreach (string item in catalogo)
            {
                Console.WriteLine(item);
            }
            Continuar();
        }

        public void agregarCarrito()
        {
            Console.WriteLine("Agregar al Carrito:\n");
            Console.WriteLine("Ingrese el ID del producto que desea agregar:");
            int idProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad:");
            int cantidad = int.Parse(Console.ReadLine());

            bool status = clienteActual.Carrito.agregarProductos(idProducto, cantidad);

            if (status)
            {
                Console.WriteLine("Producto agregado al carrito.");
            }
            else
            {
                Console.WriteLine("No se pudo agregar el producto. Verifique el ID del producto.");
            }
            Continuar();
        }

        public void verCarrito()
        {
            Console.WriteLine("Carrito:\n");
            List<string> catalogo = clienteActual.Carrito.verCarrito();
            foreach (string item in catalogo)
            {
                Console.WriteLine(item);
            }
            Continuar();
        }

        public void calcularTotal()
        {
            float total = clienteActual.Carrito.calcularTotal();
            Console.WriteLine($"El total de la compra es: ${total}");
            Continuar();
        }

        public void cerrarSesion()
        {
            Console.WriteLine("Cerrando sesión...");
            Thread.Sleep(1000);
            Console.Clear();
            mostrarMenuPrincipal();
        }

        public void salir()
        {
            Console.WriteLine("Cerrando el programa...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
