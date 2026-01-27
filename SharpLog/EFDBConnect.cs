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
            string dbPath = Path.Combine(RelativePath, "LogDatabase.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    /// <summary>
    /// 数据库操作类
    /// </summary>
    public static class DBHelper
    {
        /// <summary>
        /// 向数据库中添加一条数据（异步）
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static async Task AddDBData_Async<T>(T data) where T : class
        {
            using EFDBConnect dbContext = new EFDBConnect();
            dbContext.Set<T>().Add(data);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 按条件查找数据
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <returns>查询返回值</returns>
        public static List<T> GetDBData<T>(Func<T, bool> predicate) where T : class
        {
            using DbContext dbContext = new EFDBConnect();
            return dbContext.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// 按条件更改数据（异步）
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="data">数据值</param>
        /// <returns></returns>
        public static async Task UpperDBData<T>(T data) where T : class
        {
            using EFDBConnect dbContext = new EFDBConnect();
            dbContext.Set<T>().Update(data);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 按条件删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task DeleteDBData<T>(Func<T, bool> predicate) where T : class
        {
            using EFDBConnect dbContext = new EFDBConnect();
            List<T> dataList = dbContext.Set<T>().Where(predicate).ToList();
            dbContext.Set<T>().RemoveRange(dataList);
            await dbContext.SaveChangesAsync();
        }
    }

}
