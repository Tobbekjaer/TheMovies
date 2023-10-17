using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime PremiereDate { get; set; } = DateTime.Now;
        public int GeneratedMovieID { get; set; }

        public Movie(string title, int duration, string genre, string director, DateTime premiereDate) 
        {
            Title = title;
            Duration = duration;
            Genre = genre;
            Director = director;
            PremiereDate = premiereDate;
        }

        public Movie(string title, int duration, string genre, string director)
        {
            Title = title;
            Duration = duration;
            Genre = genre;
            Director = director;
            PremiereDate = PremiereDate;
        }

        public Movie(string title)
        {
            Title = title;        
        }

    }
}
