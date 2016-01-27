using System;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Utility.Extensions
{
    public static class ListEx
    {
        public static void MoveItem<T>(this List<T> source, int oldIndex, int newIndex)
        {
            var item = source[oldIndex];
            source.RemoveAt(oldIndex);
            source.Insert(newIndex, item);
        }
    }
}

