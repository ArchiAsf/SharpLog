using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    internal static class ShowNowTimer
    {

        public static string UtcTimeString_()
        {
            string utcNow = DateTime.UtcNow.ToString("yyyy年MM月dd日 HH:mm");
            string OutString = $"UTC时间：{utcNow}";
            return OutString;
        }

        public static string LocalTimeString_()
        {
            string localNow = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm");
            string OutString = $"本地时间：{localNow}";
            return OutString;
        }
    }

}
