using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Web.Models
{
    public class AdminCartList
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public string Client_Id { get; set; }

        public string Product { get; set; }

        public decimal Quantity { get; set; }

        public DateTime Date { get; set; }

        public decimal NetPrice { get; set; }
    }

}

