using System;
using System.Collections.Generic;

namespace howest_movie_lib.Library.Models
{
    public partial class Record
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<string> MovieTitles { get; set; }
        public decimal MoviePrice { get; set; }
        public string TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
