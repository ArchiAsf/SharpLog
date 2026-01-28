using Microsoft.Data.Sqlite;
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
        public DbSet<LogTable> LogTable { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite数据库路径配置
            string dbPath = Path.Combine(RelativePath, "DB", "LogDatabase.db");
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
        public static void AddDBData_Async<T>(T data) where T : class
        {
            try
            {
                using EFDBConnect dbContext = new EFDBConnect();
                dbContext.Set<T>().Add(data);
                dbContext.SaveChangesAsync();
            }
            // 1. 精准捕获SQLite唯一约束冲突（你之前的高频错误）
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                MessageBox.Show("添加失败：数据已存在，请勿重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // 2. 捕获其他SQLite底层错误（表不存在、连接失败、权限不足等）
            catch (SqliteException ex)
            {
                MessageBox.Show($"SQLite数据库错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 3. 捕获EF Core数据更新异常（封装的其他数据库错误）
            catch (DbUpdateException ex)
            {
                // 取内部真实异常信息（EF的Message往往不直观）
                string msg = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"数据更新失败：{msg}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*// 4. 捕获实体模型验证失败（字段非空、长度超限等）
            catch (ModelValidationException ex)
            {
                MessageBox.Show($"数据验证失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
            // 5. 捕获通用数据操作异常（空值、类型转换等）
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"操作错误：数据对象为空，请检查输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // 6. 兜底捕获所有未指定的异常
            catch (Exception ex)
            {
                MessageBox.Show($"添加数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
