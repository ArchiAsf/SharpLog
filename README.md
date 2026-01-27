# SharpLog - 业余无线电 QSO 日志系统

SharpLog 是一款为业余无线电爱好者设计的专业日志记录应用，用于记录和管理业余无线电通联（QSO）信息。

## 主要功能

- 📝 **QSO 日志记录** - 记录完整的无线电通联信息，包括时间、频率、呼号、信号报告等
- 📊 **日志可视化** - 直观展示已记录的通联历史
- 🗄️ **数据管理** - 基于 SQLite 的可靠数据持久化
- ⚙️ **台站设置** - 保存个人台站信息（呼号、操作员、QSL 地址等）
- ✅ **智能校验** - 自动验证输入数据的有效性
- 🎨 **现代 UI** - 深色主题设计，优化长时间使用体验

## 必填字段

根据 IARU 标准和工信部令第22号，以下字段为 QSO 日志的必填项：

- **呼号** (Call Sign) - 对方无线电台呼号
- **频率** (Frequency) - 通联频率
- **模式** (Mode) - 通联模式（如 CW、SSB、FT8 等）
- **我方信号报告** (RST) - 我方发出的信号报告（如 599）
- **对方信号报告** (RST) - 对方回复的信号报告
- **日期** (Date) - 通联日期
- **时间** (Time) - 通联时间(UTC)

可选字段：
- **对方地理位置** (QTH)
- **使用设备** (RIG)

## 系统要求

- **操作系统** - Windows 10 或更高版本
- **.NET** - .NET 10.0 或更高版本
- **数据库** - SQLite（内置，无需单独安装）

## 安装与使用

### 从源代码构建

```bash
# 克隆仓库
git clone https://github.com/ArchiAsf/SharpLog.git
cd SharpLog

# 构建项目
dotnet build

# 运行应用
dotnet run --project SharpLog/SharpLog.csproj
```

### 或使用发行版本

从 [Releases](https://github.com/ArchiAsf/SharpLog/releases) 页面下载最新版本的可执行文件。

## 项目结构

```
SharpLog/
├── LogMainForm.cs           # 主窗体（日志输入界面）
├── LogData.cs               # QSO 日志数据模型
├── UserData.cs              # 台站个人信息
├── EFDBConnect.cs           # Entity Framework 数据库连接
├── LogDataValidatorTools.cs # 数据校验工具类
├── GlobalStaticParameters.cs # 全局配置（主题、颜色）
├── FormStyles.cs            # 窗体样式设置
├── JSONTools.cs             # JSON 序列化工具
├── DoubleBufferedPanel.cs   # 优化渲染的面板控件
└── SharpLog.csproj          # 项目配置文件
```

## 开发指南

### 构建项目

```bash
dotnet build
```

### 调试运行

在 Visual Studio Code 或 Visual Studio 中打开项目，使用调试功能运行应用。

### 数据库初始化

应用首次运行时，会自动在程序目录下创建 `RadioLog.db` SQLite 数据库。如需重置数据库，只需删除该文件。

### 添加新字段

1. 在 `LogData.cs` 中添加属性
2. 在 `LogMainForm.Designer.cs` 中添加 UI 控件
3. 在 `FormStyles.cs` 中设置控件样式
4. 在 `LogDataValidatorTools.cs` 中添加验证规则
5. 重新运行应用，数据库会自动迁移

## 技术栈

- **框架** - Windows Forms (.NET 10.0)
- **数据库** - SQLite
- **ORM** - Entity Framework Core 10.0
- **语言** - C# 12.0

## 联系方式

如有问题或建议，请在 [GitHub Issues](https://github.com/ArchiAsf/SharpLog/issues) 中提出。

---

**注意** - SharpLog 为业余爱好项目，仅供业余无线电爱好者学习和使用。请遵守当地关于业余无线电的相关法律法规。
