using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eShop.Web.Models
{
    public class AdminProductList
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Double Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}