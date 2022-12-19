using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabaSoftwareLock.Web.Models
{
    public class PriceDetail
    {
        public int PriceDetailId
        {
            get;
            set;
        }

        public int From { get; set; }
        public int To { get; set; }
        public decimal Price { get; set; }
    }
}