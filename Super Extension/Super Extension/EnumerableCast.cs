using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperExtension
{
    public static class EnumerableCast
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> CastToIEnumerable<TSource>(this IEnumerable source)
        {
            return from object item in source
                   select (TSource)item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TSource> CastToList<TSource>(this IEnumerable source)
        {
            return CastToIEnumerable<TSource>(source).ToList();
        }
    }
}
