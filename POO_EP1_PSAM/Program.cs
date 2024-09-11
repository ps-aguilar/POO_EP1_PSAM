namespace POO_EP1_PSAM
{
    internal class Program
    {
        static void Menu()
        {
            try
            {
                Menu menu = new Menu();
            }

            catch
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido");
                Console.WriteLine("\nPresione cualquier tecla para regresar al Menu");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}