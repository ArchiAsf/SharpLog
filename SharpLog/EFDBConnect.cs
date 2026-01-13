using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{

    /// <summary>
    /// EF Core数据库连接上下文类
    /// </summary>
    public class EFDBConnect : DbContext
    {
        // 配置LogTable的DbSet
        public DbSet<LogTable> LogTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite数据库路径配置
            string dbPath = Path.Combine(RelativePath, "RadioLog.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
