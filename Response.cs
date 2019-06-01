using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2
{
    public class Response<T>
    {
        [JsonProperty(PropertyName = "Response")]
        public T Data { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string> MessageData { get; set; }
        public string DetailedErrorTrace { get; set; }
    }
}