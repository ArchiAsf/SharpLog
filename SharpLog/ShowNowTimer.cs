using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    /// <summary>
    /// 显示时间类
    /// </summary>
    internal static class ShowNowTimer
    {
        /// <summary>
        /// 输出UTC时间字符串
        /// </summary>
        /// <returns></returns>
        public static string UtcTimeString_()
        {
            string utcNow = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm");
            string OutString = $"UTC时间：{utcNow}";
            return OutString;
        }

        /// <summary>
        /// 输出本地时间字符串
        /// </summary>
        /// <returns></returns>
        public static string LocalTimeString_()
        {
            string localNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string OutString = $"本地时间：{localNow}";
            return OutString;
        }
    }

}
