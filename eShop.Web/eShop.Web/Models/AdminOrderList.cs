using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Web.Models
{
    public class AdminOrderList
    {
        public int OrderId { get; set; }

        public string Status { get; set; }

        public string OrderDate { get; set; }

        public string ClientId { get; set; }
    }

}

