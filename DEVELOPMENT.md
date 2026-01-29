# SharpLog 开发指南

## 📖 目录

1. [项目结构](#项目结构)
2. [开发环境](#开发环境)
3. [编码规范](#编码规范)
4. [模块说明](#模块说明)
5. [添加功能](#添加功能)
6. [测试指南](#测试指南)

---

## 项目结构

### 核心架构

SharpLog 采用**分层架构**，分为以下层次：

```
表现层 (Presentation Layer)
    ├── LogMainForm.cs       # 主窗体
    ├── UserDataForm.cs      # 用户数据窗体
    └── FormStyles.cs        # 样式管理

业务逻辑层 (Business Logic Layer)
    ├── LogDataValidatorTools.cs    # 数据验证
    └── SaveDatahelper.cs           # 数据保存辅助

数据访问层 (Data Access Layer)
    ├── EFDBConnect.cs           # 数据库连接和操作
    └── JSONTools.cs             # JSON 序列化

基础设施层 (Infrastructure Layer)
    ├── Logger.cs                # 日志系统
    ├── Exceptions/              # 异常定义
    └── GlobalStaticParameters.cs # 全局配置
```

### 文件说明

| 文件 | 用途 | 说明 |
|------|------|------|
| `LogMainForm.cs` | 主窗体 | QSO 日志输入和管理的主要界面 |
| `LogTable.cs` | 数据模型 | 日志条目的数据结构定义 |
| `UserData.cs` | 用户数据 | 台站个人信息（呼号、操作员等） |
| `EFDBConnect.cs` | 数据库操作 | Entity Framework 上下文和 CRUD 操作 |
| `LogDataValidatorTools.cs` | 数据验证 | QSO 数据合法性检验 |
| `JSONTools.cs` | JSON 工具 | 用户数据的序列化/反序列化 |
| `FormStyles.cs` | 样式管理 | UI 控件的统一样式设置 |
| `GlobalStaticParameters.cs` | 全局配置 | 颜色、频率、模式等常量 |
| `Logger.cs` | 日志系统 | 应用级别的日志记录（v1.1.0+） |
| `SharpLogException.cs` | 异常定义 | 自定义异常类（v1.1.0+） |

---

## 开发环境

### 环境要求

- **IDE**：Visual Studio 2022 或 Visual Studio Code + C# 扩展
- **.NET SDK**：10.0 或更高版本
- **Git**：版本控制

### 环境配置

1. **克隆仓库**
```bash
git clone https://github.com/ArchiAsf/SharpLog.git
cd SharpLog
```

2. **恢复依赖**
```bash
dotnet restore
```

3. **构建项目**
```bash
dotnet build
```

4. **运行项目**
```bash
dotnet run --project SharpLog/SharpLog.csproj
```

### VS Code 开发环境设置

#### 推荐扩展
- C# (ms-dotnettools.csharp)
- .NET Runtime Installer (ms-dotnettools.vscode-dotnet-runtime)
- Ionide for F# (ionide.ionide-fsharp) - 可选，但有助于代码分析

#### Launch.json 配置
```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "SharpLog Debug",
            "type": "coreclr",
            "request": "launch",
            "program": "${workspaceFolder}/SharpLog/bin/Debug/net10.0-windows/SharpLog.dll",
            "args": [],
            "stopAtEntry": false,
            "console": "integratedTerminal",
            "cwd": "${workspaceFolder}/SharpLog"
        }
    ]
}
```

---

## 编码规范

### 命名约定

| 类型 | 约定 | 示例 |
|------|------|------|
| 类 | PascalCase | `LogMainForm`, `DatabaseException` |
| 方法 | PascalCase | `AddDBData_Async`, `IsValidAmateurFrequency` |
| 属性 | PascalCase | `UserId`, `CreateTime` |
| 私有字段 | _camelCase | `_logger`, `_dbContext` |
| 公共常量 | UPPER_CASE | `MAX_CALLSIGN_LENGTH`, `DEFAULT_TIMEOUT` |
| 局部变量 | camelCase | `isValid`, `userCount` |

---

## 模块说明

### 日志系统 (Infrastructure/Logger.cs)

#### 功能

- 统一的日志记录接口
- 按日期自动分割日志文件
- 支持多种日志级别
- 自动清理旧日志

#### 使用示例

```csharp
// 记录信息
Logger.Info("用户创建了新日志", "LogMainForm");

// 记录错误
try { ... }
catch (Exception ex)
{
    Logger.Error("保存数据失败", ex, "SaveDataHelper");
}

// 记录警告
Logger.Warn("数据格式可能不符合规范", "Validator");

// 调试信息（仅在 DEBUG 模式下输出）
Logger.Debug($"用户输入：{input}", "FormHandler");
```

### 异常系统 (Infrastructure/Exceptions/)

#### 异常体系

```
SharpLogException (基类)
├── DatabaseException      - 数据库操作错误
├── DataValidationException - 数据验证错误
├── BusinessException      - 业务逻辑错误
└── FileOperationException - 文件操作错误
```

#### 使用示例

```csharp
// ✅ 抛出特定异常
if (!IsValidFrequency(frequency))
{
    throw new DataValidationException($"频率不合法：{frequency}");
}

// ✅ 捕获特定异常
try
{
    // 数据库操作
}
catch (DatabaseException ex)
{
    Logger.Error("数据库操作失败", ex, "DBModule");
    MessageBox.Show("数据库错误，请检查日志");
}
```

### 数据库操作 (EFDBConnect.cs)

#### API 说明

```csharp
// 添加数据（异步）
await DBHelper.AddDBData_Async<LogTable>(logData);

// 查询数据
var logs = DBHelper.GetDBData<LogTable>(l => l.Date == DateTime.Today);

// 更新数据（异步）
await DBHelper.UpperDBData<LogTable>(updatedLog);

// 删除数据（异步，带确认）
await DBHelper.DeleteDBData<LogTable>(l => l.Id == targetId);
```

#### 注意事项

- 异步方法需要使用 `await` 关键字
- 所有数据库操作都有日志记录
- 异常会自动捕获并显示用户友好的提示

---

## 添加功能

### 场景 1：添加新的 QSO 日志字段

#### 步骤

1. **定义数据模型**
```csharp
// LogTable.cs
public class LogTable
{
    // ... 现有字段 ...
    public string NewField { get; set; }  // 新字段
}
```

2. **添加 UI 控件**
```csharp
// LogMainForm.Designer.cs
private TextBox newFieldTextBox;
this.newFieldTextBox = new TextBox();
this.newFieldTextBox.Location = new Point(x, y);
this.Controls.Add(this.newFieldTextBox);
```

3. **应用样式**
```csharp
// LogMainForm.cs
formStyles.SetAllControlsStyle(this);  // 自动应用样式
```

4. **添加验证**
```csharp
// LogDataValidatorTools.cs
public static bool ValidateNewField(string value, out string errorText)
{
    // 验证逻辑
    errorText = "";
    if (string.IsNullOrWhiteSpace(value))
    {
        errorText = "新字段不能为空";
        return false;
    }
    return true;
}
```

5. **集成到保存流程**
```csharp
// LogMainForm.cs
var newLog = new LogTable
{
    // ... 现有字段 ...
    NewField = newFieldTextBox.Text
};
await DBHelper.AddDBData_Async(newLog);
```

### 场景 2：添加新的验证规则

```csharp
// LogDataValidatorTools.cs
private static bool ValidateNewField(string input, out string errorText)
{
    errorText = string.Empty;
    
    // 检查空值
    if (string.IsNullOrWhiteSpace(input))
    {
        errorText = "新字段不能为空";
        return false;
    }
    
    // 检查长度
    if (input.Length > 50)
    {
        errorText = "新字段长度不能超过 50 个字符";
        return false;
    }
    
    // 检查特殊字符
    if (input.Any(c => char.IsControl(c)))
    {
        errorText = "新字段包含无效字符";
        return false;
    }
    
    return true;
}

// 在主验证方法中调用
public static bool IsValidity(...)
{
    bool isNewFieldValid = ValidateNewField(newFieldValue, out string newFieldError);
    // ...
}
```

### 场景 3：添加新的 UI 窗体

```csharp
// 创建 NewFeatureForm.cs
public partial class NewFeatureForm : Form
{
    private FormStyles formStyles = new FormStyles();
    
    public NewFeatureForm()
    {
        InitializeComponent();
        InitializeUI();
    }
    
    private void InitializeUI()
    {
        // 应用深色主题
        this.BackColor = logMainFormBackColor;
        
        // 应用样式
        formStyles.SetAllControlsStyle(this);
        formStyles.EnableDoubleBufferForChildren(this);
        
        // 其他初始化...
    }
}
```

---

## 测试指南

### 单元测试结构

```csharp
// Tests/LogDataValidatorToolsTests.cs
[TestClass]
public class LogDataValidatorToolsTests
{
    [TestMethod]
    public void TestValidCallSign_WithValidInput_ReturnsTrue()
    {
        // Arrange
        string callSign = "JA8ABZ";
        
        // Act
        bool result = LogDataValidatorTools.HasValidCallSign(callSign);
        
        // Assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestValidCallSign_WithNullInput_ThrowsException()
    {
        // Act
        LogDataValidatorTools.HasValidCallSign(null);
    }
}
```

## 常见问题

### Q: 如何调试异步代码？

A: 在异步方法中设置断点时，Visual Studio 会自动处理。使用 `await` 表达式上的断点。

### Q: 如何添加新的全局配置？

A: 在 `GlobalStaticParameters.cs` 中添加新的公共静态字段或属性，并添加适当的注释。

---