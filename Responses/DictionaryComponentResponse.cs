using System.Collections.Generic;

namespace Destiny2.Responses
{
    public class DictionaryComponentResponse<TKey, TValue>
    {
        public IDictionary<TKey, TValue> Data { get; set; }
    }
}