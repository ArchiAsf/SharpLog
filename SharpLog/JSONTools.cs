using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace SharpLog
{
    public static class JSONTools
    {
        /// <summary>
        /// 将对象保存到JSON文件中
        /// </summary>
        /// <typeparam name="T">将要保存的对象的数据类型</typeparam>
        /// <param name="filePath">JSON文件路径</param>
        /// <param name="data">要保存的数据对象</param>
        public static void JSONSave<T>(string filePath, T data)
        {
            //创建缩进格式的JSON字符串
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            //将JSON字符串写入文件，如果文件不存在则创建新文件
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, jsonString, Encoding.UTF8);
            }
            else
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(jsonString);
                }
            }
        }

        /// <summary>
        /// 从JSON文件中加载对象
        /// </summary>
        /// <typeparam name="T">将要加载的对象的数据类型</typeparam>
        /// <param name="filePath">JSON文件的路径</param>
        /// <returns>对应的数据对象</returns>
        /// <exception cref="FileNotFoundException">如果指定的JSON文件未找到则返回报错</exception>
        public static T JSONLoad<T>(string filePath)
        {
            string jsonString = "";
            //读取JSON文件内容，如果文件不存在则抛出异常
            if (File.Exists(filePath))
            {
                jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            }
            else
            {
                throw new FileNotFoundException("指定的JSON文件未找到", filePath);
            }
            //将JSON字符串反序列化为对象
            T data = JsonSerializer.Deserialize<T>(jsonString);
            return data;
        }
    }
}
