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
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void SaveToFile(this IEnumerable<string> source, string path, Encoding encoding)
        {
            string DirPath = Path.GetDirectoryName(path);
            if (!DirPath.IsNullOrEmptyOrWhiteSpace())
                Directory.CreateDirectory(DirPath);

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, encoding))
                {
                    source.ForEach(x => sw.WriteLine(x));
                }
            }
        }

        /// <summary>
        /// 
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
