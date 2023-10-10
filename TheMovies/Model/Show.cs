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

        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set {_movie = value; }
        }


        public int RunTimeTotal { get; set; }

        private int _adsCleaning = 30;

        public Cinema Cinema { get; set; }

        public Show(Movie movie, DateTime startTime, DateTime endTime, int runTimeTotal, Cinema cinema)
        {  
            Movie = movie;
            StartTime = startTime;
            EndTime = endTime;
            RunTimeTotal = runTimeTotal; // RunTimeTotal = movie.Duration + _adsCleaning;
            Cinema = cinema;
        }

    }
}

