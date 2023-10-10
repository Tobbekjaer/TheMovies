using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Application
{
    public class Controller
    {
        MovieRepo movieRepo = new MovieRepo();
        ShowRepo showRepo = new ShowRepo();
        CinemaRepo cinemaRepo = new CinemaRepo();
        public Controller() 
        {

        }

        // Calls AddMovie in MovieRepo
        public void AddMovie(string title, int duration, string genre)
        {
            movieRepo.AddMovie(title, duration, genre);
        }



    }
}
