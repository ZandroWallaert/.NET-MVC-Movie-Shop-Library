using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class MainService
    {
        db_moviesContext context = new db_moviesContext();

        public List<string> GetSortKey()
        {
            List<string> keys = new List<string>();
            keys.Add("title");
            keys.Add("year");
            return keys;
        }

        public List<string> GetSortOrder()
        {
            List<string> order = new List<string>();
            order.Add("asc");
            order.Add("desc");
            return order;
        }
    }
}

