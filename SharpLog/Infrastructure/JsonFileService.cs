using System;
using System.IO;
using System.Text.Json;
using SharpLog.Infrastructure;
using SharpLog.Infrastructure.Exceptions;

namespace SharpLog.Infrastructure
{
    /// <summary>
    /// JSON文件操作服务类
    /// 负责JSON文件的读写、日志记录和异常处理
    /// 使用JSONTools进行序列化/反序列化的实际工作
    /// </summary>
    public static class JsonFileService
    {
        /// <summary>
        /// 将对象保存到JSON文件（带日志和异常处理）
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <param name="data">要保存的对象</param>
        public static void SaveToJsonFile<T>(string filePath, T data)
        {
            try
            {
                // 参数验证
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentException("文件路径不能为空或仅包含空白字符", nameof(filePath));
                }

                if (data == null)
                {
                    Logger.Warn($"尝试保存null对象到{filePath}", "JsonFileService");
                    return;
                }

                // 确保目录存在
                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Logger.Info($"创建目录：{directory}", "JsonFileService");
                }

                // 使用JSONTools进行序列化
                string jsonString = JSONTools.ObjectToJson(data);

                // 原子性写入（先写临时文件，然后覆盖）
                string tempPath = filePath + ".tmp";
                File.WriteAllText(tempPath, jsonString, System.Text.Encoding.UTF8);
                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.Move(tempPath, filePath);

                Logger.Info($"成功保存JSON文件：{filePath}，对象类型：{typeof(T).Name}", "JsonFileService");
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.Error($"目录不存在：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"无法创建目录，请检查路径：{filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error($"文件访问权限不足：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"没有权限保存文件：{filePath}", ex);
            }
            catch (JsonException ex)
            {
                Logger.Error($"JSON序列化失败：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"无法序列化对象到JSON：{ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Logger.Error($"保存JSON文件失败：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"保存JSON文件异常：{filePath}", ex);
            }
        }

        /// <summary>
        /// 从JSON文件加载对象（带日志和异常处理）
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns>反序列化的对象</returns>
        public static T LoadFromJsonFile<T>(string filePath) where T : class
        {
            try
            {
                // 参数验证
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentException("文件路径不能为空或仅包含空白字符", nameof(filePath));
                }

                // 检查文件是否存在
                if (!File.Exists(filePath))
                {
                    Logger.Warn($"JSON文件不存在：{filePath}", "JsonFileService");
                    throw new FileNotFoundException($"指定的JSON文件未找到：{filePath}", filePath);
                }

                // 读取文件内容
                string jsonString = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    Logger.Warn($"JSON文件为空：{filePath}", "JsonFileService");
                    throw new FileOperationException($"JSON文件内容为空：{filePath}");
                }

                // 使用JSONTools进行反序列化
                T? data = JSONTools.JsonToObject<T>(jsonString);

                if (data == null)
                {
                    Logger.Warn($"JSON反序列化结果为null：{filePath}", "JsonFileService");
                    throw new FileOperationException($"无法将JSON反序列化为{typeof(T).Name}类型");
                }

                Logger.Info($"成功加载JSON文件：{filePath}，对象类型：{typeof(T).Name}", "JsonFileService");
                return data;
            }
            catch (FileNotFoundException ex)
            {
                Logger.Error($"文件未找到：{ex.Message}", ex, "JsonFileService");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error($"文件访问权限不足：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"没有权限读取文件：{filePath}", ex);
            }
            catch (JsonException ex)
            {
                Logger.Error($"JSON反序列化失败：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"JSON格式错误或无法反序列化为{typeof(T).Name}：{ex.Message}", ex);
            }
            catch (Exception ex) when (!(ex is FileOperationException || ex is FileNotFoundException))
            {
                Logger.Error($"加载JSON文件失败：{ex.Message}", ex, "JsonFileService");
                throw new FileOperationException($"加载JSON文件异常：{filePath}", ex);
            }
        }
    }
}
