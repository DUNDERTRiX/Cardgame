using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame.ExtensionMethods
{
    public static class MyExtensions
    {
        /// <summary>
        ///  Extensions for IList
        /// </summary>

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rnd = new Random();
            for (var i = 0; i < list.Count - 1; i++)
            {
                list.Swap(i, rnd.Next(i, list.Count));
            }
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var tempListItem = list[i];
            list[i] = list[j];
            list[j] = tempListItem;
        }
    }
}
