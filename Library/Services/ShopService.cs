using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class ShopService
    {
        db_moviesContext context = new db_moviesContext();

        public List<string> GetTitles(IEnumerable<long> titles) {
            var Movies = context.Movies;
            var movieTitles = titles;
            List<string> movieList = new List<string>();
            foreach(var item in movieTitles) {
                movieList.Add(Movies.Where(i => i.Id == item).Select(i => i.Title).First());
            }
            return movieList;
        }

        public string GetTotalPrice(IEnumerable<long> movieList) {
            var ShopMoviePrice = context.ShopMoviePrice;
            decimal priceCount = 0;
            foreach(var item in movieList) {
                priceCount += ShopMoviePrice.Where(i => i.MovieId == item).Select(i => i.UnitPrice).First();
            }
            return priceCount.ToString();
        }

        public ShopOrder AddOrder(long customerId, DateTime orderDate, string street, string city, string postalCode, string country)
        {
            ShopOrder order = new ShopOrder();
            order.CustomerId = customerId;
            order.OrderDate = orderDate;
            order.Street = street;
            order.City = city;
            order.PostalCode = postalCode;
            order.Country = country;

            context.ShopOrder.Add(order);
            context.SaveChanges();

            return order;
        }

        public ShopCustomer AddCustomer(string userId, string name, string street, string city, string postalCode, string country)
        {
            ShopCustomer order = new ShopCustomer();
            order.UserId = userId;
            order.Name = name;
            order.Street = street;
            order.City = city;
            order.PostalCode = postalCode;
            order.Country = country;

            context.ShopCustomer.Add(order);
            context.SaveChanges();

            return order;
        }

        public ShopOrderDetail AddOrderDetail(long movieId, decimal moviePrice)
        {
            ShopOrderDetail order = new ShopOrderDetail();
            order.MovieId = movieId;
            order.UnitPrice = moviePrice;

            context.ShopOrderDetail.Add(order);
            context.SaveChanges();

            return order;
        }

        public void Delete(ShopOrder shopOrder, ShopCustomer shopCustomer, ShopOrderDetail shopOrderDetail)
        {
            context.ShopOrder.Remove(shopOrder);
            context.ShopCustomer.Remove(shopCustomer);
            context.ShopOrderDetail.Remove(shopOrderDetail);
            context.SaveChanges();
        }
    }
}