using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class ActorService
    {
        db_moviesContext context = new db_moviesContext();

        public IQueryable<MovieRole> GetMovieRoles(long movieId)
        {
            return context.MovieRole.Where(role => role.MovieId == movieId && role.Role.Equals("actor"));
        }
    }
}