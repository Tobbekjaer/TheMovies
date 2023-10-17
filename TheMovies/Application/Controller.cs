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
        BookingRepo bookingRepo = new BookingRepo();
        public Controller() 
        {

        }

        // Calls AddMovie in MovieRepo
        public void AddMovie(string title, int duration, string genre, string director, DateTime premiereDate)
        {
            movieRepo.AddMovie(title, duration, genre, director, premiereDate);
        }

        // Adds a Movie, a Cinema and finally a show til the repositories
        public void AddShow(string title, int duration, string genre, string director,
            DateTime premiereDate, string cinemaName, int cinemaHall,
            DateTime startTime)
        {
            // Add the movie to movies
            movieRepo.AddMovie(title, duration, genre, director, premiereDate);

            // Add the cinema to cinemas
            cinemaRepo.AddCinema(cinemaName, cinemaHall);

            // Add show to shows (parameter Movie and Cinema passed via GetAddedxxx()-methods)
            showRepo.AddShow(movieRepo.GetAddedMovie(), startTime, cinemaRepo.GetAddedCinema());

        }
        // Calls AddBooking in BookingRepo
        public void AddBooking(int ticketAmount, string email, string phone, string title, 
            string cinemaName, int cinemaHall, int numberOfSeats, DateTime startTime)
        {
            // Add the movie to movies
            movieRepo.AddMovieToBooking(title);
            // Add the cinema to cinemas
            cinemaRepo.AddCinemaToBooking(cinemaName, cinemaHall, numberOfSeats);
            // Add show to shows (parameter Movie and Cinema passed via GetAddedxxx()-methods)
            showRepo.AddShowToBooking(movieRepo.GetAddedMovie(), startTime, cinemaRepo.GetAddedCinema());
            // Add booking to bookings
            bookingRepo.AddBooking(ticketAmount, email, phone, showRepo.GetAddedShow());
        }

    }
}
