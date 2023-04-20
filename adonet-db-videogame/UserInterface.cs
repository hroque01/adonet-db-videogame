using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class UserInterface
    {
        public static void UserNewGame()
        {
            //stringa di connessione
            string stringConnection = "Data Source=localhost;Initial Catalog=test;Integrated Security=True";

            //Creo una nuova istanza della classe VideogameManager
            VideogameManager insertGame1 = new VideogameManager(stringConnection);

            string nome;
            string overview;
            DateTime release_date;
            long software_house_id;

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
            } while (!long.TryParse(input, out software_house_id));

            Videogame game1 = new Videogame(nome, overview, release_date, software_house_id);

            //Chiamo il metodo InserisciVideoGame
            insertGame1.InserisciVideogame(game1);

            Console.WriteLine("Gioco inserito! \n");


        }

        public static void UserGetById()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=test;Integrated Security=True";
            VideogameManager manager = new VideogameManager(connectionString);

            int id;
            string input;

            do
            {
                Console.Write("Inserisci l'ID del videogioco: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out id));

            Videogame videogame = manager.GetVideogameId(id);

            if (videogame != null)
            {
                Console.WriteLine($"Il tuo videogioco: {videogame.Name} \n");
            }
            else
            {
                Console.WriteLine($"Nessun videogioco trovato con l'ID {id}. \n");
            }
        }
    }
}
