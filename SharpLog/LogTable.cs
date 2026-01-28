using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SharpLog
{/// <summary>
 /// 通联日志表实体类（对应SQLite中的LogTable表）
 /// 用于记录无线电通联的详细信息
 /// </summary>
    [Table("LogTable")] // 显式指定映射的数据库表名，避免EF自动复数化
    [Index(nameof(StartTime), IsUnique = true)]
    public class LogTable
    {
        /// <summary>
        /// 通联开始时间（主键）
        /// 格式建议：YYYY-MM-DD HH:MM:SS（SQLite存储为TEXT类型）
        /// </summary>
        [Key] // 标记为主键
        [Column("StartTime")] // 映射到数据库的StartTime字段
        [Required(ErrorMessage = "通联开始时间不能为空")] // 对应NOT NULL约束
        public string StartTime { get; set; } = string.Empty;

        /// <summary>
        /// 通联结束时间
        /// 格式建议：YYYY-MM-DD HH:MM:SS（SQLite存储为TEXT类型）
        /// </summary>
        [Column("EndTime")]
        [Required(ErrorMessage = "通联结束时间不能为空")]
        public string EndTime { get; set; } = string.Empty;

        /// <summary>
        /// 对方呼号（电台标识）
        /// </summary>

        [Column("CallSign")]
        [Required(ErrorMessage = "对方呼号不能为空")]
        public string CallSign { get; set; } = string.Empty;

        /// <summary>
        /// 通联频率（单位：Hz，SQLite存储为INTEGER类型）
        /// 示例：7050000 表示7.050MHz
        /// </summary>
        [Column("Frequency")]
        [Required(ErrorMessage = "通联频率不能为空")]
        public string Frequency { get; set; } = string.Empty;

        /// <summary>
        /// 通联模式（如CW、SSB、FT8等）
        /// </summary>
        [Column("Mode")]
        [Required(ErrorMessage = "通联模式不能为空")]
        public string Mode { get; set; } = string.Empty;

        /// <summary>
        /// 我方发送的信号报告（RST码，如599）
        /// </summary>
        [Column("RST")]
        [Required(ErrorMessage = "我方信号报告不能为空")]
        public string RST { get; set; } = string.Empty;

        /// <summary>
        /// 对方发送的信号报告（RST码，如599）
        /// </summary>
        [Column("RRST")]
        [Required(ErrorMessage = "对方信号报告不能为空")]
        public string RRST { get; set; } = string.Empty;

        /// <summary>
        /// 对方地理位置（QTH，可选字段）
        /// </summary>
        [Column("QTH")]
        public string? QTH { get; set; }

        /// <summary>
        /// 我方使用的电台型号（可选字段）
        /// </summary>
        [Column("RIG")]
        public string? RIG { get; set; }

        /// <summary>
        /// 发射功率（可选字段，如100W、5W）
        /// </summary>
        [Column("Pow")]
        public string? Pow { get; set; }

        /// <summary>
        /// 使用的天线类型（可选字段）
        /// </summary>
        [Column("ANT")]
        public string? ANT { get; set; }

        /// <summary>
        /// 天线高度（可选字段，如10m）
        /// </summary>
        [Column("Height")]
        public string? Height { get; set; }

        /// <summary>
        /// 操作员（可选字段）
        /// </summary>
        [Column("OP")]
        public string? OP { get; set; }

        /// <summary>
        /// 备注信息（可选字段）
        /// </summary>
        [Column("RMKS")]
        public string? RMKS { get; set; }

        /// <summary>
        /// 是否已确认QSL卡片（0=否，1=是，SQLite INTEGER映射为bool）
        /// </summary>
        [Column("IsQSL")]
        public bool IsQSL { get; set; }

        /// <summary>
        /// 是否为低功率通联（QRP，0=否，1=是）
        /// </summary>
        [Column("IsQRP")]
        public bool IsQRP { get; set; }

        /// <summary>
        /// 是否为卫星通联（0=否，1=是）
        /// </summary>
        [Column("IsSatellite")]
        public bool IsSatellite { get; set; }

        /// <summary>
        /// 是否为中继台通联（0=否，1=是）
        /// </summary>
        [Column("IsRelayStation")]
        public bool IsRelayStation { get; set; }

        /// <summary>
        /// 是否为月面反射通联（EME，0=否，1=是）
        /// </summary>
        [Column("IsEME")]
        public bool IsEME { get; set; }

        /// <summary>
        /// 是否为流星余迹通联（0=否，1=是）
        /// </summary>
        [Column("IsMeteoricTrail")]
        public bool IsMeteoricTrail { get; set; }

        /// <summary>
        /// 是否为确认通联（0=否，1=是）
        /// </summary>
        [Column("IsConfirmation")]
        public bool IsConfirmation { get; set; }
    }
}
