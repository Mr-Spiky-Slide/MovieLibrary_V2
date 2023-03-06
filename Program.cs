using NLog;

 // See https://aka.ms/new-console-template for more information
 string path = Directory.GetCurrentDirectory() + "//nlog.config";

 // create instance of Logger
 var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
 logger.Info("Program started");

Movie movie = new Movie
 {
   movieId = 1,
   title = "Jeff's Killer Movie (2019)",
   genres = new List<string> { "Action", "Romance", "Comedy" }
 };
 logger.Info("Program ended");

Console.WriteLine(movie.Display());
