using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true) 
            {
                int opzione;

                Console.WriteLine("Scegli una opzione: ");
                Console.WriteLine("1. Inserisci nuovo gioco");
                Console.WriteLine("2. Cerca un gioco tramite Id");
                Console.WriteLine("\n ------------------ \n");

                Console.Write("Inserisci opzione: ");
                if (!int.TryParse(Console.ReadLine(), out opzione))
                {
                    Console.WriteLine("Opzione non valida.");
                    continue;
                }

                switch (opzione)
                {
                    case 1:
                        UserInterface.UserNewGame();
                        break;
                    case 2:
                        UserInterface.UserGetById();
                        break;
                }
            }
            
        }
    }
}