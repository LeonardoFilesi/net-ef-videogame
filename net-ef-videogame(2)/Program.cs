using net_ef_videogame_2_;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel nostro sistema di gestione del catalogo videogiochi");
            while (true)
            {
                Console.WriteLine("Seleziona l'opzione desiderata:");
                Console.WriteLine(@"
- 1: inserire un nuovo videogioco
- 2: ricercare un videogioco per id
- 3: ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
- 4: cancellare un videogioco
- 5: inserire una nuova software house
- 6: chiudere il programma
");

                int selectedOption = int.Parse(Console.ReadLine());

                switch (selectedOption)
                {
                    // CREATE VIDEOGAME
                    case 1:
                        {
                            Console.WriteLine("Create a Videogame!");
                            Console.WriteLine("Enter the title: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter an overview of the game: ");
                            string overview = Console.ReadLine();
                            Console.WriteLine("Enter release date: ");
                            DateTime releasedate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter software house id: ");
                            long softwareHouseId = long.Parse(Console.ReadLine());

                            Videogame videogame = new Videogame(0, name, overview, releasedate, softwareHouseId);
                            bool inserted = VideogameManager.CreateVideogame(videogame);

                            if (inserted)
                            {
                                Console.WriteLine("Game created and added to the list!");
                            }
                            else
                            {
                                Console.WriteLine("Game not created!");
                            }

                        }
                        break;

                    // SEARCH VIDEOGAME BY ID
                    case 2:
                        {
                            Console.WriteLine("Search game by id!");
                            Console.WriteLine("Insert Videogame id:");
                            long id = Convert.ToInt64(Console.ReadLine());

                            List<Videogame> videogames = VideogameManager.GetVideogamesById(id);

                            foreach (Videogame videogame in videogames)
                            {
                                Console.WriteLine($"- {videogame}");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("No videogame found with your id, cheack the inserted id!!!");
                        break;

                    // SEARCH BY STRING
                    case 3:
                        {
                            Console.WriteLine("Insert a string");
                            string gamestring = Console.ReadLine();

                            List<Videogame> videogames = VideogameManager.GetVideogamesByString($"%{gamestring}%");

                            if (videogames != null && videogames.Count > 0)
                            {
                                Console.WriteLine("Research results:");

                                foreach (Videogame videogame in videogames)
                                {
                                    Console.WriteLine(videogame.Name);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No game found.");
                            }

                            return;
                        }

                    // DELETE VIDEOGAME
                    case 4:
                        Console.Write("Insert the Game Id you want to delete: ");
                        long deletegameid = long.Parse(Console.ReadLine());

                        bool deleted = VideogameManager.DeleteVideogame(deletegameid);

                        if (deleted)
                        {
                            Console.WriteLine("Your game was deleted!");
                        }
                        else
                        {
                            Console.WriteLine("Your game is immortal!");
                        }

                        break;

                    // CREATE SOFTWAREHOUSE
                    case 5:
                        {
                                        Console.WriteLine("Create a SoftwareHouse!");
                                        Console.WriteLine("Enter the name: ");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Enter the country in which is located: ");
                                        string country = Console.ReadLine();
                                        Console.WriteLine("Enter software house id: ");
                                        long softwareHouseId = long.Parse(Console.ReadLine());

                                        SoftwareHouse softwareHouse = new SoftwareHouse(softwareHouseId, name, country);
                                        bool inserted = VideogameManager.CreateSoftwareHouse(softwareHouse);

                                        if (inserted)
                                        {
                                            Console.WriteLine("Game created and added to the list!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Game not created!");
                                        }                  
                                    break;
                            }
                }
            }
        }
    }
}