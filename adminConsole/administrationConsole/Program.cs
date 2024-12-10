using System.Security.Cryptography;

namespace administrationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AMONG US H INC. ADMINISTRATION CONSOLE";   
            Menu menu = new Menu();
            menu.menu();
        }
    }
}
