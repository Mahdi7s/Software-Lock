using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabaSoftwareLock.Web.Models
{
    public class Setting
    {
        public Setting()
        {
            IsUsingSinglePrice = true;
        }

        public int SettingId { get; set; }

        public decimal PackageSerialPrice { get; set; }
        public bool IsUsingSinglePrice { get; set; }
        public List<PriceDetail> PriceDetails { get; set; }
    }
}