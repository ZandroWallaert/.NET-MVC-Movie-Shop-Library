using System;
using System.Linq;
using System.Collections.Generic;
using howest_movie_lib.Library.Models;

namespace howest_movie_lib.Library.Services
{
    public class RecordService
    {
        db_moviesContext context = new db_moviesContext();
        private ShopService shopService = new ShopService();
        List<Record> recordsList = new List<Record>();

        public List<Record> GetRecords()
        {
            IEnumerable<howest_movie_lib.Library.Models.ShopOrderDetail> ShopOrderDetail = context.ShopOrderDetail;
            IEnumerable<howest_movie_lib.Library.Models.ShopCustomer> ShopCustomer = context.ShopCustomer;
            IEnumerable<howest_movie_lib.Library.Models.ShopOrder> ShopOrder = context.ShopOrder;

                Record record = new Record();

                record.OrderId = ShopOrder.First().Id;              //needs to get fixed --> InvalidOperationException: There is already an open DataReader associated with this Command which must be closed first.
                record.OrderDate = ShopOrder.First().OrderDate;
                var movieTitles = from det in ShopOrderDetail
                                  where record.OrderId == det.OrderId
                                  select det.MovieId;
                record.MovieTitles = shopService.GetTitles(movieTitles);
                record.TotalPrice = shopService.GetTotalPrice(movieTitles);
                var name = from cust in ShopCustomer
                           where record.OrderId == cust.Id
                           select cust.Name;
                record.CustomerName = name.First();
                var address = from cust in ShopCustomer
                              where record.OrderId == cust.Id
                              select cust.Street;
                var city = from cust in ShopCustomer
                           where record.OrderId == cust.Id
                           select cust.City;
                record.Address = address.First() + ", " + city.First();

                recordsList.Add(record);

            return recordsList;
        }
    }
}