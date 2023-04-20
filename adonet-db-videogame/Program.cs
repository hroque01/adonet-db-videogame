using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //stringa di connessione
            string stringConnection = "Data Source=localhost;Initial Catalog=test;Integrated Security=True";

            //Creo una nuova istanza della classe VideogameManager
            VideogameManager insertGame1 = new VideogameManager(stringConnection);

            string nome;
            string overview;
            DateTime release_date;
            int software_house_id;

            // Inserimento di un gioco
            do
            {
                Console.Write("Inserisci il nome: ");
                nome = Console.ReadLine();

            } while (string.IsNullOrEmpty(nome));

            do
            {
                Console.Write("Inserisci la descrizione: ");
                overview = Console.ReadLine();

            } while (string.IsNullOrEmpty(overview));

            string input;
            do
            {
                Console.Write("Inserisci la data di uscita (formato yyyy-MM-dd): ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out release_date));

            do
            {
                Console.WriteLine("Le scelte possibili per la Software House sono: \n" +
                                "[1] Nintendo \n" +
                                "[2] Rockstar Games \n" +
                                "[3] Valve Corporation \n" +
                                "[4] Electronic Arts \n" +
                                "[5] Ubisoft \n" +
                                "[6] Konami \n");

                Console.Write("Inserisci l'ID della software house: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out software_house_id));

            Videogame game1 = new Videogame(nome, overview, release_date, software_house_id);

            //Chiamo il metodo InserisciVideoGame
            insertGame1.InserisciVideogame(game1);



        }
    }
}