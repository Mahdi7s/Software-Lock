using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabaSoftwareLock.Web.Utils
{
    public static class TimestampConverter
    {
        public static DateTime ToDateTime(double unixTimestamp)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimestamp).ToLocalTime();
        }

        public static DateTime JTimestampToDateTime(double javaTimestamp)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(Math.Round(javaTimestamp/1000)).ToLocalTime();
        }
    }
}