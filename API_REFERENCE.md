# SharpLog API 参考

## 📚 概览

本文档提供 SharpLog 核心类和方法的 API 参考。

---

## 日志系统 (Logger)

### 类
```csharp
namespace SharpLog.Infrastructure
{
    public static class Logger
}
```

### 方法

#### Info(string message, string? module = null)
记录信息级别的日志。

```csharp
Logger.Info("用户登录成功", "AuthModule");
```

**参数：**
- `message` (string) - 日志消息
- `module` (string, 可选) - 模块名称，用于日志分类

**返回值：** 无

---

#### Error(string message, Exception? ex = null, string? module = null)
记录错误级别的日志，包含异常信息。

```csharp
try { /* ... */ }
catch (Exception ex)
{
    Logger.Error("操作失败", ex, "DataModule");
}
```

**参数：**
- `message` (string) - 错误消息
- `ex` (Exception, 可选) - 异常对象
- `module` (string, 可选) - 模块名称

**返回值：** 无

**说明：** 如果提供异常对象，日志将包含异常堆栈跟踪。

---

#### Warn(string message, string? module = null)
记录警告级别的日志。

```csharp
Logger.Warn("数据可能不符合规范", "ValidatorModule");
```

**参数：**
- `message` (string) - 警告消息
- `module` (string, 可选) - 模块名称

**返回值：** 无

---

#### Debug(string message, string? module = null)
记录调试级别的日志（仅在 DEBUG 模式下输出）。

```csharp
#if DEBUG
Logger.Debug($"用户输入值：{userInput}", "FormModule");
#endif
```

**参数：**
- `message` (string) - 调试消息
- `module` (string, 可选) - 模块名称

**返回值：** 无

---

#### CleanOldLogs(int daysToKeep = 7)
清理超过指定天数的旧日志文件。

```csharp
// 在应用启动时清理 7 天前的日志
Logger.CleanOldLogs(7);

// 清理 30 天前的日志
Logger.CleanOldLogs(30);
```

**参数：**
- `daysToKeep` (int) - 保留天数，默认为 7

**返回值：** 无

**说明：** 日志文件存储在 `<AppDirectory>/Logs/` 目录下。

---

## 数据库操作 (DBHelper)

### 类
```csharp
namespace SharpLog
{
    public static class DBHelper
}
```

### 方法

#### AddDBData_Async<T>(T data)
向数据库中异步添加一条数据。

```csharp
var newLog = new LogTable
{
    CallSign = "JA8ABZ",
    Frequency = "14.074MHz",
    // ... 其他字段
};

await DBHelper.AddDBData_Async(newLog);
```

**类型参数：**
- `T` - 数据对象类型（必须是 DbSet 中注册的实体类）

**参数：**
- `data` (T) - 要添加的数据对象

**返回值：** `Task`

**异常：**
- `SqliteException` - SQLite 数据库错误（会显示用户友好提示）
- `DbUpdateException` - 数据库更新失败（会显示用户友好提示）
- `NullReferenceException` - 数据对象为空（会显示用户友好提示）

**说明：** 所有异常都会自动记录日志。

---

#### GetDBData<T>(Func<T, bool> predicate)
按条件查询数据库中的数据。

```csharp
// 查询今天的所有日志
var todayLogs = DBHelper.GetDBData<LogTable>(log => log.Date == DateTime.Today);

// 查询特定呼号的日志
var logsByCallSign = DBHelper.GetDBData<LogTable>(log => log.CallSign == "JA8ABZ");

// 查询多个条件
var results = DBHelper.GetDBData<LogTable>(
    log => log.Date >= startDate && log.Date <= endDate && log.Mode == "FT8"
);
```

**类型参数：**
- `T` - 数据对象类型

**参数：**
- `predicate` (Func<T, bool>) - LINQ 查询条件

**返回值：** `List<T>` - 查询结果列表（如果出错返回空列表）

**异常：** 
- `SqliteException` - 数据库查询错误
- `InvalidOperationException` - EF Core 逻辑错误
- `NullReferenceException` - 空值引用错误

---

#### UpperDBData<T>(T data)
异步更新数据库中的数据。

```csharp
var existingLog = new LogTable
{
    Id = 123,
    CallSign = "JA8ABZ",
    // ... 其他字段，必须包含主键
};

bool success = await DBHelper.UpperDBData(existingLog);
```

**类型参数：**
- `T` - 数据对象类型

**参数：**
- `data` (T) - 包含主键的要更新的数据对象

**返回值：** `Task<bool>` - 更新是否成功

**说明：** 
- 数据对象必须包含主键，EF Core 通过主键匹配记录
- 成功时显示"数据更新成功！"提示
- 失败时显示具体错误信息

---

#### DeleteDBData<T>(Func<T, bool> predicate)
按条件异步删除数据库中的数据（包含二次确认）。

```csharp
// 删除特定 ID 的日志
bool deleted = await DBHelper.DeleteDBData<LogTable>(log => log.Id == targetId);

// 删除特定日期的日志
bool deleted = await DBHelper.DeleteDBData<LogTable>(
    log => log.Date == DateTime.Today
);
```

**类型参数：**
- `T` - 数据对象类型

**参数：**
- `predicate` (Func<T, bool>) - 删除条件

**返回值：** `Task<bool>` - 删除是否成功

**说明：**
- 删除全表时会进行二次确认
- 部分数据删除也会请求用户确认
- 用户取消删除时返回 `false`

---

## JSON 工具 (JSONTools)

### 类
```csharp
namespace SharpLog
{
    public static class JSONTools
}
```

### 方法

#### JSONSave<T>(string filePath, T data)
将对象保存到 JSON 文件。

```csharp
var userSettings = new UserData
{
    StationCallSign = "JA8ABC",
    OperatorName = "张三"
};

JSONTools.JSONSave("userData.json", userSettings);
```

**类型参数：**
- `T` - 要保存的对象类型

**参数：**
- `filePath` (string) - JSON 文件路径
- `data` (T) - 要保存的数据对象

**返回值：** 无

**异常：**
- `ArgumentException` - 文件路径为空或仅空白
- `DirectoryNotFoundException` - 目录不存在且无法创建
- `UnauthorizedAccessException` - 文件访问权限不足
- `JsonException` - 序列化失败
- `FileOperationException` - 其他文件操作异常

**说明：**
- 自动创建目录（如果不存在）
- 使用原子性写入（先写临时文件，再覆盖）
- 生成格式化的 JSON（便于阅读）

---

#### JSONLoad<T>(string filePath)
从 JSON 文件加载对象。

```csharp
try
{
    var userSettings = JSONTools.JSONLoad<UserData>("userData.json");
    Console.WriteLine($"台站呼号：{userSettings.StationCallSign}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("用户数据文件不存在");
}
catch (FileOperationException ex)
{
    Console.WriteLine("加载用户数据失败");
}
```

**类型参数：**
- `T` - 要加载的对象类型（必须是可序列化的）

**参数：**
- `filePath` (string) - JSON 文件路径

**返回值：** `T` - 反序列化的对象

**异常：**
- `FileNotFoundException` - 文件不存在
- `ArgumentException` - 文件路径为空或仅空白
- `UnauthorizedAccessException` - 文件访问权限不足
- `JsonException` - JSON 格式错误或无法反序列化
- `FileOperationException` - 其他文件操作异常

---

## 数据验证 (LogDataValidatorTools)

### 类
```csharp
namespace SharpLog
{
    public static class LogDataValidatorTools
}
```

### 方法

#### IsValidity(...)
综合验证所有 QSO 日志字段。

```csharp
bool isValid = LogDataValidatorTools.IsValidity(
    callSign: "JA8ABZ",
    frequency: "14.074MHz",
    modeSelectBox: modePanel,
    RSTPanel: myRstPanel,
    RRSTPanel: theirRstPanel
);

if (isValid)
{
    // 保存日志
}
else
{
    // 用户已被显示错误提示
}
```

**参数：**
- `callSign` (string) - 对方呼号
- `frequency` (string) - 通联频率
- `modeSelectBox` (FlowLayoutPanel) - 模式选择面板
- `RSTPanel` (FlowLayoutPanel) - 己方信号报告面板
- `RRSTPanel` (FlowLayoutPanel) - 对方信号报告面板

**返回值：** `bool` - 所有字段是否有效

**说明：** 
- 验证失败时自动显示错误提示对话框
- 错误提示包含所有验证失败的字段

---

## 全局参数 (GlobalStaticParameters)

### 类
```csharp
namespace SharpLog
{
    public static class GlobalStaticParameters
}
```

### 常量和属性

#### RelativePath
应用程序的运行目录。

```csharp
string logDir = Path.Combine(RelativePath, "Logs");
string dbPath = Path.Combine(RelativePath, "DB", "LogDatabase.db");
```

**类型：** `string` (只读)

---

#### 颜色常量
UI 元素的颜色定义。

```csharp
// 窗体颜色
Color formBgColor = logMainFormBackColor;      // 主窗体背景色
Color formFontColor = logMainFormFontColor;    // 主窗体字体色

// 按钮颜色
Color btnNormalBg = buttonNormalBackColor;     // 正常状态
Color btnHoverBg = buttonHoverBackColor;       // 悬浮状态
Color btnClickBg = buttonClickBackColor;       // 点击状态

// 输入框颜色
Color textboxBg = normalTextBoxBackColor;      // 正常背景
Color textboxFocus = focusTextBoxBorderColor;  // 焦点边框色
```

---

#### ModeColorMap
通联模式与颜色的映射字典。

```csharp
// 获取某个模式的颜色
Color ftColor = GlobalStaticParameters.ModeColorMap["FT8"];
Color fmColor = GlobalStaticParameters.ModeColorMap["FM"];

// 遍历所有模式颜色
foreach (var mode in GlobalStaticParameters.ModeColorMap)
{
    Console.WriteLine($"{mode.Key}: {mode.Value}");
}
```

**类型：** `Dictionary<string, Color>` (只读)

**支持的模式：** FM, AM, CW, SSB, FT8, FT4, SSTV, DMR, C4FM, D-STAR, NXDN, Packet, MSK144

---

#### ValidAmateurBands
合法业余无线电频段定义。

```csharp
// 检查频率是否在 20 米波段
if (GlobalStaticParameters.ValidAmateurBands.TryGetValue("20m", out var band))
{
    if (frequency >= band.MinFrequency && frequency <= band.MaxFrequency)
    {
        Console.WriteLine("频率有效");
    }
}

// 遍历所有波段
foreach (var band in GlobalStaticParameters.ValidAmateurBands)
{
    Console.WriteLine($"{band.Key}: {band.Value.MinFrequency} - {band.Value.MaxFrequency} MHz");
}
```

**类型：** `IReadOnlyDictionary<string, FrequencyRange>`

**支持的波段：** 160m, 80m, 40m, 20m, 15m, 10m, 2m, 6m, 70cm 等

---

#### 常用频率数组

```csharp
// FT8 常用频点
string[] ft8Freqs = GlobalStaticParameters.Ft8CommonFrequencies;

// FT4 常用频点
string[] ft4Freqs = GlobalStaticParameters.Ft4CommonFrequencies;

// SSTV 常用频点
string[] sstvFreqs = GlobalStaticParameters.sstvCommonFrequencies;
```

**类型：** `string[]` (只读)

---

## 自定义异常

### 类层次

```csharp
namespace SharpLog.Infrastructure.Exceptions
{
    public abstract class SharpLogException : Exception { }
    public class DatabaseException : SharpLogException { }
    public class DataValidationException : SharpLogException { }
    public class BusinessException : SharpLogException { }
    public class FileOperationException : SharpLogException { }
}
```

### 使用示例

```csharp
// 抛出异常
throw new DatabaseException("无法连接到数据库");
throw new DataValidationException($"频率不合法：{frequency}");
throw new FileOperationException("无法保存文件", innerException);

// 捕获异常
try
{
    // 业务代码
}
catch (DatabaseException ex)
{
    Logger.Error("数据库错误", ex, "MyModule");
}
catch (DataValidationException ex)
{
    MessageBox.Show($"数据验证失败：{ex.Message}");
}
catch (SharpLogException ex)
{
    Logger.Error("SharpLog 异常", ex, "MyModule");
}
```

---

## 常见用法示例

### 添加新日志条目

```csharp
// 创建数据对象
var newLog = new LogTable
{
    CallSign = callSignTextBox.Text,
    Frequency = frequencyTextBox.Text,
    Date = datePicker.Value.Date,
    Time = timePicker.Value.TimeOfDay,
    Mode = selectedMode,
    // ... 其他字段
};

// 验证
if (LogDataValidatorTools.IsValidity(
    newLog.CallSign,
    newLog.Frequency,
    modePanel,
    myRstPanel,
    theirRstPanel))
{
    // 保存到数据库
    try
    {
        await DBHelper.AddDBData_Async(newLog);
        Logger.Info($"添加新日志：{newLog.CallSign}", "LogForm");
        MessageBox.Show("日志添加成功！");
    }
    catch (Exception ex)
    {
        Logger.Error("添加日志失败", ex, "LogForm");
    }
}
```

### 查询和显示日志

```csharp
try
{
    // 查询今天的日志
    var todayLogs = DBHelper.GetDBData<LogTable>(
        log => log.Date == DateTime.Today
    );
    
    // 绑定到 DataGridView
    dataGridView.DataSource = todayLogs;
    
    Logger.Info($"成功查询 {todayLogs.Count} 条日志", "QueryModule");
}
catch (Exception ex)
{
    Logger.Error("查询日志失败", ex, "QueryModule");
    MessageBox.Show("查询失败，请查看日志");
}
```

### 保存用户设置

```csharp
var userSettings = new UserData
{
    StationCallSign = stationCallSignTextBox.Text,
    OperatorName = operatorNameTextBox.Text,
    // ... 其他字段
};

try
{
    string settingsPath = Path.Combine(RelativePath, "UserSettings.json");
    JSONTools.JSONSave(settingsPath, userSettings);
    Logger.Info("用户设置已保存", "SettingsForm");
}
catch (FileOperationException ex)
{
    Logger.Error("保存用户设置失败", ex, "SettingsForm");
    MessageBox.Show("保存设置失败：" + ex.Message);
}
```

---

**最后更新**：2025年1月29日
