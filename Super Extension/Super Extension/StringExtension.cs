using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.IO;

namespace SuperExtension
{
    public static class StringExtension
    {
        /// <summary>
        /// 判断是否是Null，Empty，空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string str) =>
            str == null || str.Length == 0 || str.Trim().Length == 0;

        /// <summary>
        /// 转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Conver<T>(this string str)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (!str.IsNullOrEmptyOrWhiteSpace())
                try
                {
                    return (T)converter.ConvertFromString(str);
                }
                catch (Exception)
                {}
            return default;
        }

        /// <summary>
        /// 删除字符串中的空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeleteWhitespace(this string str)
        {
            if (str.IsNullOrEmptyOrWhiteSpace())
                return string.Empty;

            return string.Join(string.Empty, str.Where(item => !char.IsWhiteSpace(item)));
        }

        /// <summary>
        /// 比较两个字符串，不区分大小写
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string str1, string str2)
        {
            return str1?.ToLower() == str2?.ToLower();
        }

        /// <summary>
        /// 删除字符串前面和后面的空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimStartAndEnd(this string str)
        {
            if (str.IsNullOrEmptyOrWhiteSpace())
                return string.Empty;
            return str.TrimStart().TrimEnd();
        }

        /// <summary>
        /// 将文本内容存入文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Path"></param>
        /// <param name="encoding"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SaveToFile(this string str, string Path, Encoding encoding)
        {
            if(Path.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException(nameof(Path));

            string DirPath = System.IO.Path.GetDirectoryName(Path);
            if (!DirPath.IsNullOrEmptyOrWhiteSpace())
                Directory.CreateDirectory(DirPath);
            
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, encoding))
                {
                    sw.Write(str ?? string.Empty);
                }
            }
        }

        /// <summary>
        /// 将文本内容存入文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Path"></param>
        public static void SaveToFile(this string str, string Path)
        {
            str.SaveToFile(Path, Encoding.UTF8);
        }

        /// <summary>
        /// 文字编码变换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="InputEncoding"></param>
        /// <param name="OutPutEncoing"></param>
        /// <returns></returns>
        public static string EncodingChange(this string str, Encoding InputEncoding, Encoding OutPutEncoing)
        {
            return OutPutEncoing.GetString(InputEncoding.GetBytes(str));
        }
    }
}
