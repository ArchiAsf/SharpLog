using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharpLog.Infrastructure;
using SharpLog.Infrastructure.Exceptions;
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
            if (!Directory.Exists(Path.Combine(RelativePath, "DB")))
            {
                //如果DB目录不存在，创建它
                Directory.CreateDirectory(Path.Combine(RelativePath, "DB"));
            }
            string dbPath = Path.Combine(RelativePath, "DB", "LogDatabase.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    /// <summary>
    /// 数据库操作类（包含日志记录和改进的异常处理）
    /// </summary>
    public static class DBHelper
    {
        /// <summary>
        /// 初始化数据库并连接，如果数据库文件或表不存在则创建
        /// </summary>
        /// <returns></returns>
        public static bool Initialize()
        {
            try
            {
                using (var CT = new EFDBConnect())
                {
                    CT.Database.EnsureCreated();
                    bool ISConnected = CT.Database.CanConnect();
                    return ISConnected;
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"数据库初始化失败：{ex.Message}", ex, "DBHelper");
                return false;
            }
        }

        /// <summary>
        /// 向数据库中添加一条数据（异步，包含日志记录）
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static async Task AddDBData_Async<T>(T data) where T : class
        {
            try
            {
                using EFDBConnect dbContext = new EFDBConnect();
                dbContext.Set<T>().Add(data);
                await dbContext.SaveChangesAsync();
                Logger.Info($"成功添加{typeof(T).Name}类型的数据", "DBHelper");
            }
            // 精准捕获SQLite唯一约束冲突
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                Logger.Warn($"数据重复：尝试添加已存在的{typeof(T).Name}数据", "DBHelper");
                MessageBox.Show("添加失败：数据已存在，请勿重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // 捕获其他SQLite底层错误
            catch (SqliteException ex)
            {
                Logger.Error($"SQLite数据库错误：{ex.Message}", ex, "DBHelper");
                MessageBox.Show($"SQLite数据库错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 捕获EF Core数据更新异常
            catch (DbUpdateException ex)
            {
                string msg = ex.InnerException?.Message ?? ex.Message;
                Logger.Error($"数据更新失败：{msg}", ex, "DBHelper");
                MessageBox.Show($"数据更新失败：{msg}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 捕获通用数据操作异常
            catch (NullReferenceException ex)
            {
                Logger.Error($"操作错误：数据对象为空", ex, "DBHelper");
                MessageBox.Show($"操作错误：数据对象为空，请检查输入！\r\n错误提示：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // 兜底捕获所有未指定的异常
            catch (Exception ex)
            {
                Logger.Error($"添加数据失败：{ex.Message}", ex, "DBHelper");
                MessageBox.Show($"添加数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 按条件查找数据（增加完整异常检测，适配EF Core+SQLite+WinForm）
        /// </summary>
        /// <typeparam name="T">数据对象类型（EF实体类）</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <returns>查询成功返回数据列表，异常返回空列表</returns>
        public static List<T> GetDBData<T>(Func<T, bool> predicate) where T : class
        {
            try
            {
                // 校验上下文实例创建是否正常
                using DbContext dbContext = new EFDBConnect();
                if (dbContext == null)
                {
                    MessageBox.Show("数据库上下文初始化失败，无法执行查询！", "错误提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<T>();
                }

                // 校验实体集是否存在
                var dbSet = dbContext.Set<T>();
                if (dbSet == null)
                {
                    MessageBox.Show($"实体类型{typeof(T).Name}未在数据库上下文中注册！", "错误提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<T>();
                }

                // 原有查询逻辑，无异常则正常返回数据
                return dbSet.Where(predicate).ToList();
            }
            // 精准捕获SQLite底层核心异常（查询时最常遇到：表/字段不存在、数据库连接失败、权限不足等）
            catch (SqliteException ex)
            {
                // 按错误码给更友好的提示，贴合实际开发场景
                string errorMsg = ex.SqliteErrorCode switch
                {
                    1 => "查询失败：数据库中不存在当前实体对应的表/字段！",
                    5 => "查询失败：数据库文件权限不足/无法打开！",
                    _ => $"SQLite数据库查询错误：{ex.Message}"
                };
                MessageBox.Show(errorMsg, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 调试时打印详细异常信息（可选，方便定位问题）
                Console.WriteLine($"SQLite异常详情：{ex.ToString()}");
                return new List<T>();
            }
            // 捕获EF Core专属逻辑错误（上下文已释放、实体状态异常、导航属性未加载等）
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"查询逻辑错误：{ex.Message}", "执行错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"EF逻辑异常详情：{ex.ToString()}");
                return new List<T>();
            }
            // 捕获空值引用异常（比如查询条件中访问了空对象属性）
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"查询失败：空值引用，请检查查询条件！{ex.Message}", "参数错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<T>();
            }
            // 兜底捕获所有未预判的异常，避免程序崩溃
            catch (Exception ex)
            {
                MessageBox.Show($"查询数据失败：{ex.Message}", "未知错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"未知异常详情：{ex.ToString()}");
                return new List<T>();
            }
        }

        /// <summary>
        /// 按条件更改数据（异步，增加完整异常处理）
        /// </summary>
        /// <typeparam name="T">数据对象类型（EF实体类）</typeparam>
        /// <param name="data">要更新的数据对象（必须包含主键，EF通过主键匹配数据）</param>
        /// <returns>更新成功返回true，失败返回false</returns>
        public static async Task<bool> UpperDBData<T>(T data) where T : class
        {
            // 前置参数校验：避免传入空对象导致后续无意义的数据库操作
            if (data == null)
            {
                MessageBox.Show("更新失败：传入的更新数据不能为空！", "参数错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using EFDBConnect dbContext = new EFDBConnect();
                // 标记数据为更新状态，EF通过主键自动匹配数据库中的记录
                dbContext.Set<T>().Update(data);
                // 异步保存更改，执行SQL更新语句
                await dbContext.SaveChangesAsync();

                // 无异常则更新成功，给友好提示（可选，可根据业务注释）
                MessageBox.Show("数据更新成功！", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            // 精准捕获SQLite底层核心异常（更新时最高频，按错误码做个性化提示）
            catch (SqliteException ex)
            {
                string errorMsg = ex.SqliteErrorCode switch
                {
                    19 => "更新失败：违反唯一约束，数据值与现有记录重复！",// 你之前遇到的高频错误
                    1 => "更新失败：数据库中不存在当前实体对应的表/字段！",
                    5 => "更新失败：数据库文件被占用/权限不足，无法写入！",
                    2067 => "更新失败：主键值重复，无法更新！",
                    _ => $"SQLite数据库错误：{ex.Message}"// 其他SQLite错误
                };
                MessageBox.Show(errorMsg, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 调试时打印详细异常信息（含堆栈，方便定位问题，生产环境可注释）
                Console.WriteLine($"SQLite更新异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获EF Core专属更新异常（实体状态错误、外键约束、无主键等）
            catch (DbUpdateException ex)
            {
                // EF的外层异常信息不直观，真实错误在InnerException中
                string realMsg = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"数据更新失败：{realMsg}", "EF更新错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"EF更新异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获EF逻辑错误（上下文已释放、实体未注册、无主键等）
            catch (InvalidOperationException ex)
            {
                string tip = ex.Message.Contains("primary key")
                    ? "更新失败：实体无主键/传入数据缺少主键，EF无法匹配更新记录！"
                    : $"更新逻辑错误：{ex.Message}";
                MessageBox.Show(tip, "执行错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"EF逻辑异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获空值引用异常（罕见，防止更新过程中访问空对象属性）
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"更新失败：空值引用，请检查数据对象属性！{ex.Message}",
                    "数据错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // 兜底捕获所有未预判的异常，避免程序崩溃
            catch (Exception ex)
            {
                MessageBox.Show($"数据更新失败：{ex.Message}", "未知错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"未知更新异常详情：{ex.ToString()}");
                return false;
            }
        }

        /// <summary>
        /// 按条件删除数据（异步，增加完整异常处理+防误删校验）
        /// </summary>
        /// <typeparam name="T">数据对象类型（EF实体类）</typeparam>
        /// <param name="predicate">删除条件（t=>true会删除全表，方法内会做二次确认）</param>
        /// <returns>删除成功返回true，失败/取消返回false</returns>
        public static async Task<bool> DeleteDBData<T>(Func<T, bool> predicate) where T : class
        {
            // 前置校验1：防止传入空条件（理论上不会，做兜底）
            if (predicate == null)
            {
                MessageBox.Show("删除失败：未传入删除条件，无法执行删除操作！", "参数错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using EFDBConnect dbContext = new EFDBConnect();
                var dbSet = dbContext.Set<T>();
                // 查询符合条件的待删除数据
                List<T> dataList = dbSet.Where(predicate).ToList();

                // 前置校验2：无符合条件数据，直接提示并返回
                if (dataList == null || dataList.Count == 0)
                {
                    MessageBox.Show("未查询到符合删除条件的数据，无需执行删除！", "操作提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // 前置校验3：删除全表二次确认（防误删核心，t=>true时触发）
                var allDataCount = dbSet.Count();
                if (dataList.Count == allDataCount)
                {
                    DialogResult result = MessageBox.Show(
                        $"即将删除【{typeof(T).Name}】表中所有{dataList.Count}条数据，此操作不可恢复，是否继续？",
                        "危险操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("已取消删除操作！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                // 常规删除：单条/多条非全表数据，可选简易确认（可根据业务注释）
                else
                {
                    DialogResult result = MessageBox.Show(
                        $"确认删除【{typeof(T).Name}】表中{dataList.Count}条符合条件的数据吗？",
                        "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("已取消删除操作！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                // 执行批量删除
                dbSet.RemoveRange(dataList);
                await dbContext.SaveChangesAsync();

                // 删除成功提示
                MessageBox.Show($"成功删除{dataList.Count}条数据！", "操作成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            // 精准捕获SQLite底层核心异常（按错误码做个性化友好提示）
            catch (SqliteException ex)
            {
                string errorMsg = ex.SqliteErrorCode switch
                {
                    1 => $"删除失败：数据库中不存在{typeof(T).Name}对应的表/字段！",
                    5 => "删除失败：数据库文件被占用/权限不足，无法执行删除！",
                    1299 => "删除失败：违反外键约束，该数据被其他表关联，无法直接删除！",
                    _ => $"SQLite数据库错误：{ex.Message}"
                };
                MessageBox.Show(errorMsg, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 调试时打印详细异常堆栈（生产环境可注释）
                Console.WriteLine($"SQLite删除异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获EF Core专属删除异常（外键冲突、实体状态错误等，提取内部真实错误）
            catch (DbUpdateException ex)
            {
                string realMsg = ex.InnerException?.Message ?? ex.Message;
                // 针对性提示外键约束冲突（删除高频坑）
                if (realMsg.Contains("foreign key") || realMsg.Contains("constraint"))
                {
                    realMsg = "删除失败：该数据与其他表存在关联关系，请先删除关联数据再尝试！";
                }
                MessageBox.Show($"数据删除失败：{realMsg}", "EF更新错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"EF删除异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获EF逻辑错误（上下文异常、实体未注册等）
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"删除逻辑错误：{ex.Message}", "执行错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"EF逻辑异常详情：{ex.ToString()}");
                return false;
            }
            // 捕获空值引用等通用业务异常
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"删除失败：空值引用，请检查删除条件！{ex.Message}",
                    "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // 兜底捕获所有未预判异常，避免程序崩溃
            catch (Exception ex)
            {
                MessageBox.Show($"数据删除失败：{ex.Message}", "未知错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"未知删除异常详情：{ex.ToString()}");
                return false;
            }
        }
    }

}
