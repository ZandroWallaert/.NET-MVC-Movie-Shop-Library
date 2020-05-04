using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class MovieService
    {
        db_moviesContext context = new db_moviesContext();

        public IEnumerable<Movies> AllMovies()
        {
            return context.Movies;
        }

        public Movies GetRandomMovie()
        {
            Random r = new Random();
            int rInt = r.Next(1, 250);
            return (from t in AllMovies() where t.Id.Equals(rInt) select t).First();
        }
    }
}
