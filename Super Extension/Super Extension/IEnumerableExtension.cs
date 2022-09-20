using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperExtension
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="If"></param>
        /// <param name="Then"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool If, Func<TSource, bool> Then)
        {
            return If ? source.Where(Then) : source;
        }

        /// <summary>
        /// 将数据写入文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void SaveToFile(this IEnumerable<string> source, string path, Encoding encoding)
        {
            FileExtension.CreateDir(path);

            using (StreamWriter sw = FileExtension.CreateStreamWriter(path, encoding))
            {
                source.ForEach(x => sw.WriteLine(x));
            }
        }

        /// <summary>
        /// 将数据写入指定文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        public static void SaveToFile(this IEnumerable<string> source, string path)
        {
            source.SaveToFile(path, Encoding.UTF8);
        }

        /// <summary>
        /// 循环遍历
        /// </summary>
        /// <param name="souce"></param>
        /// <param name="action"></param>
        public static void ForEach(this IEnumerable<string> souce, Action<string> action)
        {
            foreach (string item in souce)
                action(item);
        }
    }
}
