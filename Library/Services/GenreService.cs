using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class GenreService
    {
        db_moviesContext context = new db_moviesContext();

        public IEnumerable<GenreMovie> GetGenre(long movieId)
        {
            return context.GenreMovie.Where(movieGenre => movieGenre.MovieId == movieId);
        }
    }
}