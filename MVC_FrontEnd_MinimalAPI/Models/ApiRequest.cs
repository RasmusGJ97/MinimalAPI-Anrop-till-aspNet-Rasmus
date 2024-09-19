using static FrontEnd_MinimalAPI.StaticDetails;

namespace MVC_FrontEnd_MinimalAPI.Models
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
