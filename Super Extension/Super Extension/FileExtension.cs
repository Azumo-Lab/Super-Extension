using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperExtension
{
    public static class FileExtension
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="Path">包含文件夹文件名的完整路径, 例如：Dir/Test.txt</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CreateDir(string Path)
        {
            if (Path.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException(nameof(Path));

            string DirName = System.IO.Path.GetDirectoryName(Path);
            if (!DirName.IsNullOrEmptyOrWhiteSpace())
            {
                Directory.CreateDirectory(DirName);
            }
        }

        /// <summary>
        /// 创建一个StreamWriter
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static StreamWriter CreateStreamWriter(string Path, Encoding encoding)
        {
            return CreateStreamWriter(Path, FileMode.OpenOrCreate, encoding);
        }

        /// <summary>
        /// 创建一个StreamWriter
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="fileMode"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static StreamWriter CreateStreamWriter(string Path, FileMode fileMode, Encoding encoding)
        {
            return new StreamWriter(new FileStream(Path, fileMode), encoding);
        }

        /// <summary>
        /// 如果文件存在，则删除文件
        /// </summary>
        /// <param name="Path"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Delete(string Path)
        {
            if (Path.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentNullException(nameof(Path));

            if (File.Exists(Path))
                File.Delete(Path);
        }
    }
}
