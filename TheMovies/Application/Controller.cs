﻿using System;
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
        public void AddMovie(string title, int duration, string genre, string director, DateTime premiereDate)
        {
            movieRepo.AddMovie(title, duration, genre, director, premiereDate);
        }

        // Adds a Movie, a Cinema and finally a show til the repositories
        public void AddShow(string title, int duration, string genre, string director,
            string cinemaName, int cinemaHall,
            DateTime premiereDate, DateTime startTime, DateTime endTime, int runTimeTotal)
        {
            // Add the movie to movies
            movieRepo.AddMovie(title, duration, genre, director, premiereDate);

            // Add the cinema to cinemas
            cinemaRepo.AddCinema(cinemaName, cinemaHall);

            // Add show to shows (parameter Movie and Cinema passed via GetAddedxxx()-methods)
            showRepo.AddShow(movieRepo.GetAddedMovie(), startTime, endTime, runTimeTotal, cinemaRepo.GetAddedCinema());

        }

    }
}
