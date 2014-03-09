using System.Collections.Generic;

namespace Medidata.RwsCdsFormatter
{
    public static class Compare
    {
        public static bool DictionaryEquals<K, V>(this IDictionary<K, V> d1, IDictionary<K, V> d2) {
            if (d1.Count != d2.Count)
                return false;

            foreach (KeyValuePair<K, V> pair in d1) {
                if (!d2.ContainsKey(pair.Key))
                    return false;

                if (!Equals(d2[pair.Key], pair.Value))
                    return false;
            }
            return true;
        }
    }
}
