using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVCApplication.Models
{
    public class Book
    {
        public Int64 Id { get; set; }
        public String Title { get; set; }
        public String ISBN { get; set; }
        public Decimal Price { get; set; }
    }
}