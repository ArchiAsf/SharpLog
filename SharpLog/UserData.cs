using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    /// <summary>
    /// 台站个人信息类
    /// </summary>
    public class UserData
    {

        // 以下为台站个人信息字段
        //本地呼号
        public string UserCallSign { get; set; } = String.Empty;
        //操作员名称
        public string OPName { get; set; } = String.Empty;
        //QSL卡片邮寄地址
        public string QSLAddress { get; set; } = String.Empty;
        /*        //地理位置
                public string Location { get; set; } = String.Empty;
                //网格
                public string Grid { get; set; } = String.Empty;
                //常用设备
                public string Freq_RIG { get; set; } = String.Empty;
                //常用天线
                public string Freq_ANT { get; set; } = String.Empty;*/

    }
}
