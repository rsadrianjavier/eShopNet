﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eShop.Web.Models
{
    public class AdminUserList
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Role { get; set; }
    }
}