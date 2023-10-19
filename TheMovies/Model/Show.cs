using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TheMovies.Model
{
    public class Show
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Movie Movie { get; set; }

        public int RunTimeTotal { get; set; }

        private int _adsCleaning = 30;

        public Cinema Cinema { get; set; }
        public int GeneratedShowID { get; set; }

        public Show(Movie movie, DateTime startTime, Cinema cinema)
        {  
            Movie = movie;
            StartTime = startTime;         
            RunTimeTotal = movie.Duration + _adsCleaning;
            EndTime = startTime.AddMinutes(RunTimeTotal);
            Cinema = cinema;
        }
        public Show(Movie movie, DateTime startTime, Cinema cinema, int showID)
        {
            Movie = movie;
            StartTime = startTime;
            RunTimeTotal = movie.Duration + _adsCleaning;
            EndTime = startTime.AddMinutes(RunTimeTotal);
            Cinema = cinema;
            GeneratedShowID = showID;
        }

    }
}

