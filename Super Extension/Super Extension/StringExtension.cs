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
            FileExtension.CreateDir(Path);

            using (StreamWriter sw = FileExtension.CreateStreamWriter(Path, encoding))
            {
                sw.Write(str ?? string.Empty);
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

        /// <summary>
        /// 如果为空，返回默认字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultStr"></param>
        /// <returns></returns>
        public static string DefaultString(this string str, string defaultStr)
        {
            return str ?? defaultStr;
        }

        /// <summary>
        /// 如果为空，返回默认字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultStr"></param>
        /// <returns></returns>
        public static string DefaultString(this string str)
        {
            return str.DefaultString(string.Empty);
        }

        /// <summary>
        /// 如果满足条件，则返回默认字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="func"></param>
        /// <param name="defaultStr"></param>
        /// <returns></returns>
        public static string DefaultString(this string str, Func<string, bool> func, string defaultStr)
        {
            return func.Invoke(str) ? defaultStr : str;
        }

        /// <summary>
        /// 将字符串反转
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Reverse(this string str)
        {
            IEnumerable<char> reverseStr = str.Reverse<char>();
            return string.Join(string.Empty, reverseStr);
        }

        /// <summary>
        /// 寻找不同字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int DifferenceAt(this string str,  string s2)
        {
            if (str == null || s2 == null)
                return -1;

            int i;
            for (i = 0; (i < str.Length) && (i < s2.Length); ++i)
            {
                if (str[i] != s2[i])
                {
                    break;
                }
            }
            if ((i < s2.Length) || (i < str.Length))
            {
                return i;
            }
            return -1;
        }

        /// <summary>
        /// 寻找不同字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string Difference(this string str, string s2)
        {
            int at = DifferenceAt(str, s2);
            if (at == -1)
            {
                return string.Empty;
            }
            return s2.Substring(at);
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LowerFirstLetter(this string str)
        {
            if (str == null || str == string.Empty)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append(char.ToLower(str.First()));
            sb.Append(string.Join(string.Empty, str.Skip(1)));
            return sb.ToString();
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperFirstLetter(this string str)
        {
            if (str == null || str == string.Empty)
                return string.Empty;
            
            StringBuilder sb = new StringBuilder();
            sb.Append(char.ToUpper(str.First()));
            sb.Append(string.Join(string.Empty, str.Skip(1)));
            return sb.ToString();
        }
    }
}
