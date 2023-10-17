﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Cinema
    {

        public string CinemaName { get; set; }
        public int CinemaHall { get; set; }
        public int NumberOfSeats { get; set; } = 100;
        public int GeneratedCinemaID { get; set; }
        public Cinema(string cinemaName, int cinemaHall)
        {
            CinemaName = cinemaName;
            CinemaHall = cinemaHall;
        }
        public Cinema(string cinemaName, int cinemaHall, int numberOfSeats)
        {
            CinemaName = cinemaName;
            CinemaHall = cinemaHall;
            NumberOfSeats = numberOfSeats;
        }

    }
}
