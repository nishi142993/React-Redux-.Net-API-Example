using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactReduxAxiosAPI.Models
{
    public class Merchant
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string avatarUrl { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool hasPremium { get; set; }
        public List<Bid> bids { get; set; }


    }
    public class Bid
    {
        public int id { get; set; }
        public string carTitle { get; set; }
        public int amount { get; set; }
        public DateTime created { get; set; }
    }


}