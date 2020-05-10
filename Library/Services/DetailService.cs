using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class DetailService
    {
        db_moviesContext context = new db_moviesContext();
        private GenreService genreService = new GenreService();
        private ActorService actorService = new ActorService();
        List<Genres> genres = new List<Genres>();
        public IEnumerable<Movies> GetMovies()
        {
            return context.Movies;
        }

        public List<Persons> GetActors(long movieId)
        {
            IEnumerable<MovieRole> movieRoles = actorService.GetMovieRoles(movieId);

            List<Persons> actors = new List<Persons>();
            foreach (MovieRole role in movieRoles)
            {
                Persons actor = context.Persons.First(actor => actor.Id == role.PersonId);
                if (actor != null)
                {
                    actors.Add(actor);
                }
            }
            return actors;
        }

        public List<Genres> GetGenres(long movieId)
        {
            IEnumerable<GenreMovie> genreMovies = genreService.GetGenre(movieId);
            foreach (GenreMovie genreMovie in genreMovies)
            {
                Genres genre = context.Genres.First(movieGenre => movieGenre.Id == genreMovie.GenreId);
                if (genre != null)
                {
                    genres.Add(genre);
                }
            }
            return genres;
        }

    }
}
