using System;
using System.Collections.Generic;

namespace csharp.Utility
{
    public static class DictionaryEx
    {
        public static TValue GetValueOrNew<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, Func<TValue> newFunc)
        {
            TValue value;
            if (source.TryGetValue(key, out value))
                return value;
            value = newFunc();
            source.Add(key,value);
            return value;
        }
    }
}
