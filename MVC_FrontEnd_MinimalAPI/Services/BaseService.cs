using FrontEnd_MinimalAPI.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MVC_FrontEnd_MinimalAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd_MinimalAPI.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO responseDTO { get; set; }
        public IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            responseDTO = new ResponseDTO();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MinimalApiUrl");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiRespo = null;

                switch (apiRequest.apiType)
                {
                    case StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }

                apiRespo = await client.SendAsync(message);

                var apiContent = await apiRespo.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    Message = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false,
                };

                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiResponseDto;
            }
        }
    }
    
}
