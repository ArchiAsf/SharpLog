# JSON 工具使用指南

## 两个工具，两个职责

| 工具 | 职责 | 使用场景 |
|------|------|--------|
| **JSONTools** | 对象 ↔ JSON字符串转换 | 序列化、网络传输 |
| **JsonFileService** | 文件读写 | 配置保存、数据持久化 |

---

## 快速上手

### JSONTools（序列化）
\`\`\`csharp
// 对象 → JSON
var json = JSONTools.ObjectToJson(data);

// JSON → 对象
var obj = JSONTools.JsonToObject<MyClass>(json);
\`\`\`

### JsonFileService（文件操作）
\`\`\`csharp
using SharpLog.Infrastructure;

// 保存到文件（自动创建目录、原子写入、记录日志）
JsonFileService.SaveToJsonFile("config.json", data);

// 从文件加载（验证内容、完整错误处理）
var data = JsonFileService.LoadFromJsonFile<MyClass>("config.json");
\`\`\`

---

## 何时用哪个

### 用 JSONTools：
- ✅ 字符串和对象互转
- ✅ 网络传输前序列化
- ✅ 快速转换，不关心日志

### 用 JsonFileService：
- ✅ 保存配置文件
- ✅ 需要日志记录
- ✅ 需要自动错误处理
- ✅ 需要防止文件损坏（原子写入）

---

## 完整示例

```sharp
using SharpLog.Infrastructure;

public class ConfigManager
{
    public void SaveConfig(AppConfig config)
    {
        try
        {
            JsonFileService.SaveToJsonFile("app.config.json", config);
        }
        catch (FileOperationException ex)
        {
            Console.WriteLine($"保存失败：{ex.Message}");
        }
    }

    public AppConfig LoadConfig()
    {
        try
        {
            return JsonFileService.LoadFromJsonFile<AppConfig>("app.config.json");
        }
        catch (FileNotFoundException)
        {
            return new AppConfig();  // 默认配置
        }
    }
}
```

---

**日志位置**：`<应用目录>/Logs/SharpLog_YYYY-MM-DD.log`