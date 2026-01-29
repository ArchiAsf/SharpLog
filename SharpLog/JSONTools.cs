using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using SharpLog.Infrastructure;
using SharpLog.Infrastructure.Exceptions;

namespace SharpLog
{
    /// <summary>
    /// JSON序列化/反序列化工具类（包含日志和异常处理改进）
    /// </summary>
    public static class JSONTools
    {
        /// <summary>
        /// 将对象保存到JSON文件中（含异常处理和日志）
        /// </summary>
        /// <typeparam name="T">将要保存的对象的数据类型</typeparam>
        /// <param name="filePath">JSON文件路径</param>
        /// <param name="data">要保存的数据对象</param>
        public static void JSONSave<T>(string filePath, T data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentException("文件路径不能为空或仅包含空白字符", nameof(filePath));
                }

                if (data == null)
                {
                    Logger.Warn($"尝试保存null对象到{filePath}", "JSONTools");
                    return;
                }

                // 确保目录存在
                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Logger.Info($"创建目录：{directory}", "JSONTools");
                }

                // 创建缩进格式的JSON字符串
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(data, options);

                // 原子性写入（先写临时文件，然后覆盖）
                string tempPath = filePath + ".tmp";
                File.WriteAllText(tempPath, jsonString, Encoding.UTF8);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.Move(tempPath, filePath);

                Logger.Info($"成功保存JSON文件：{filePath}，对象类型：{typeof(T).Name}", "JSONTools");
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.Error($"目录不存在：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"无法创建目录，请检查路径：{filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error($"文件访问权限不足：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"没有权限保存文件：{filePath}", ex);
            }
            catch (JsonException ex)
            {
                Logger.Error($"JSON序列化失败：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"无法序列化对象到JSON：{ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Logger.Error($"保存JSON文件失败：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"保存JSON文件异常：{filePath}", ex);
            }
        }

        /// <summary>
        /// 从JSON文件中加载对象（含异常处理和日志）
        /// </summary>
        /// <typeparam name="T">将要加载的对象的数据类型</typeparam>
        /// <param name="filePath">JSON文件的路径</param>
        /// <returns>对应的数据对象</returns>
        /// <exception cref="FileNotFoundException">如果指定的JSON文件未找到则返回报错</exception>
        public static T JSONLoad<T>(string filePath) where T : class
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentException("文件路径不能为空或仅包含空白字符", nameof(filePath));
                }

                if (!File.Exists(filePath))
                {
                    Logger.Warn($"JSON文件不存在：{filePath}", "JSONTools");
                    throw new FileNotFoundException($"指定的JSON文件未找到：{filePath}", filePath);
                }

                // 读取JSON文件内容
                string jsonString = File.ReadAllText(filePath, Encoding.UTF8);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    Logger.Warn($"JSON文件为空：{filePath}", "JSONTools");
                    throw new FileOperationException($"JSON文件内容为空：{filePath}");
                }

                // 反序列化为对象
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                T? data = JsonSerializer.Deserialize<T>(jsonString, options);

                if (data == null)
                {
                    Logger.Warn($"JSON反序列化结果为null：{filePath}", "JSONTools");
                    throw new FileOperationException($"无法将JSON反序列化为{typeof(T).Name}类型");
                }

                Logger.Info($"成功加载JSON文件：{filePath}，对象类型：{typeof(T).Name}", "JSONTools");
                return data;
            }
            catch (FileNotFoundException ex)
            {
                Logger.Error($"文件未找到：{ex.Message}", ex, "JSONTools");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error($"文件访问权限不足：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"没有权限读取文件：{filePath}", ex);
            }
            catch (JsonException ex)
            {
                Logger.Error($"JSON反序列化失败：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"JSON格式错误或无法反序列化为{typeof(T).Name}：{ex.Message}", ex);
            }
            catch (Exception ex) when (!(ex is FileOperationException || ex is FileNotFoundException))
            {
                Logger.Error($"加载JSON文件失败：{ex.Message}", ex, "JSONTools");
                throw new FileOperationException($"加载JSON文件异常：{filePath}", ex);
            }
        }
    }
}