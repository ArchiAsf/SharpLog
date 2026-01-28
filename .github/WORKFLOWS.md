# GitHub Actions 工作流配置指南

## 概述

SharpLog 项目配置了自动化的 GitHub Actions 工作流，包括以下功能：

1. **代码质量检查 (Lint)** - 使用 StyleCop 分析代码风格
2. **自动构建** - 在 Windows 环境中编译项目
3. **自动生成安装包** - 创建 MSI 和便携式 ZIP 包

## 工作流配置

### 文件位置
- `.github/workflows/build.yml` - 主工作流配置

### 触发条件

工作流在以下情况自动运行：
- ✅ Push 到 `master` 或 `dev` 分支
- ✅ 提交 Pull Request 到 `master` 或 `dev` 分支
- ⚙️ 手动触发（可在 GitHub Actions 页面手动运行）

## 工作流详解

### 1. Lint & Build 任务（lint-and-build）

**步骤**：
1. 检出代码
2. 安装 .NET 10.0 SDK
3. 恢复 NuGet 依赖
4. 构建项目（Release 配置）
5. 运行 StyleCop 代码分析
6. 上传构建产物

**输出**：
- `SharpLog-Release` artifact - 包含所有已编译的 DLL、EXE 和配置文件

**代码分析规则**：
- 基于 StyleCop 分析器
- 检查代码风格、命名约定等
- 配置文件：`SharpLog/stylecop.json`

### 2. 创建安装包任务（create-installer）

**依赖**：等待 lint-and-build 任务成功完成

**步骤**：
1. 检出代码
2. 安装 .NET SDK
3. 安装 WiX Toolset（通过 Chocolatey）
4. 构建项目
5. 发布应用（Release 配置）
6. 创建便携式 ZIP 包
7. 上传 artifacts
8. 创建 GitHub Release（仅在标签发布时）

**输出**：
- `SharpLog-Installers` artifact，包含：
  - `SharpLog-x.x.x-portable.zip` - 便携式版本（无需安装，解压即用）

**优点**：
- ✅ 便携式设计 - 无需复杂的 MSI 安装程序
- ✅ 自包含（self-contained）- 包含所有必需的 .NET 运行时
- ✅ 简单易用 - 解压后直接运行

### 3. 自动发布（可选）

当在 master 分支上创建带标签的发布时（如 `v1.0.0`），工作流会自动将安装包上传到 GitHub Releases。

## 本地测试工作流

### 测试 Lint 配置

```bash
# 安装依赖
dotnet restore

# 运行代码分析
dotnet build --configuration Release /p:EnforceCodeStyleInBuild=true /p:EnableNETAnalyzers=true
```

### 本地发布便携版本

```bash
# 构建并发布应用
dotnet publish SharpLog/SharpLog.csproj -c Release -o "publish" --self-contained=true -p:PublishSingleFile=true

# 创建 ZIP 包
Compress-Archive -Path "publish" -DestinationPath "SharpLog-portable.zip" -Force
```

## 项目设置

### csproj 配置

已在 `SharpLog.csproj` 中添加：
- `<Version>` - 版本号（影响 ZIP 包名）
- `<EnableNETAnalyzers>true</EnableNETAnalyzers>` - 启用 .NET 分析器
- `<EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>` - 强制检查代码风格

### StyleCop 配置

`stylecop.json` 控制代码风格检查规则：
- 默认禁用文档注释要求（可按需修改）
- 启用命名规范检查

## 查看工作流运行结果

1. **访问 Actions 页面**：https://github.com/ArchiAsf/SharpLog/actions
2. **查看构建日志**：点击具体的工作流运行记录
3. **下载 Artifacts**：在工作流完成后，点击对应的 artifact 下载
4. **查看代码分析结果**：在"Run code analysis"步骤的日志中查看警告

## 常见问题

### Q: 工作流失败怎么办？
**A**: 
1. 查看"Run code analysis"步骤的日志，找出代码风格或编译问题
2. 本地修复问题
3. 提交代码，工作流会自动重新运行

### Q: 如何更新版本号？
**A**: 修改 `SharpLog.csproj` 中的 `<Version>` 标签，如：
```xml
<Version>1.1.0</Version>
```

### Q: 如何跳过某个步骤？
**A**: 在对应步骤中添加 `if: false` 条件（不推荐），或根据分支名称条件执行：
```yaml
if: github.ref == 'refs/heads/master'
```

### Q: WiX 生成失败怎么办？
**A**: 这是正常的，因为需要手动配置 Product.wxs。流程已设置为继续执行，会生成 ZIP 便携版本作为备选。

## 下一步优化

可考虑的改进：
- [ ] 集成代码覆盖率检查（Codecov）
- [ ] 自动发布到 GitHub Releases（已配置标签触发）
- [ ] 代码签名（使用证书签署 EXE）
- [ ] 国际化构建（多语言支持）
- [ ] 性能测试集成
- [ ] 单元测试集成
