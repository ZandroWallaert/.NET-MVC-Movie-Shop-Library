using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class DetailService
    {
        db_moviesContext context = new db_moviesContext();

        public IEnumerable<Movies> GetMovies()
        {
            return context.Movies;
        }

        public int GetGenreId(long movieId)
        {
            return context.GenreMovie.Where(s => s.MovieId == movieId).Select(s => s.GenreId).First();
        }

        public String GetGenreName(int genreId)
        {
            return context.Genres.Where(s => s.Id == genreId).Select(s => s.Name).First();
        }

        public IEnumerable<Persons> GetActorName(String movieName)
        {
            return context.Persons.Where(s => s.Biography.Contains(movieName));
        }

    }
}
