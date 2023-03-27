// See https://aka.ms/new-console-template for more information
using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string movieFilePath = Directory.GetCurrentDirectory() + "//movies.csv";

logger.Info("Program started");

MovieFile movieFile = new MovieFile(movieFilePath);

string choice = "";
do
{
    // display choices to user
    Console.WriteLine("1) Add Movie");
    Console.WriteLine("2) Display All Movies");
    Console.WriteLine("3) Search Movies");
    Console.WriteLine("Enter to quit");
    // input selection
    choice = Console.ReadLine();
    logger.Info("User choice: {Choice}", choice);

    if (choice == "1")
    {
        // Add movie
        Movie movie = new Movie();
        // ask user to input movie title
        Console.WriteLine("Enter movie title");
        // input title
        movie.title = Console.ReadLine();
        // verify title is unique
        if (movieFile.isUniqueTitle(movie.title))
        {
            // input genres
            string input;
            do
            {
                // ask user to enter genre
                Console.WriteLine("Enter genre (or done to quit)");
                // input genre
                input = Console.ReadLine();
                // if user enters "done"
                // or does not enter a genre do not add it to list
                if (input != "done" && input.Length > 0)
                {
                    movie.genres.Add(input);
                }
            } while (input != "done");
            // specify if no genres are entered
            if (movie.genres.Count == 0)
            {
                movie.genres.Add("(no genres listed)");
            }
            // add movie
            movieFile.AddMovie(movie);
        }
    }
    else if (choice == "2")
    {
        // Display All Movies
        foreach (Movie m in movieFile.Movies)
        {
            Console.WriteLine(m.Display());
        }
    }
    else if (choice == "3")
    {
        Console.WriteLine("Search by title: ");
        string keyword = Console.ReadLine();
        Console.WriteLine($"There are {movieFile.Movies.Where(m => m.title.Contains(keyword)).Count()} movies matching {keyword}");

        var Movies1921 = movieFile.Movies.Where(m => m.title.Contains("(1921)"));
        foreach (Movie m in Movies1921)
        {
            Console.WriteLine($"  {m.title}");
        }

    }
} while (choice == "1" || choice == "2" || choice == "3");

logger.Info("Program ended");