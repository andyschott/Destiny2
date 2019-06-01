using Newtonsoft.Json;

namespace Destiny2.Responses
{
    public class SingleComponentResponse<T>
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
}