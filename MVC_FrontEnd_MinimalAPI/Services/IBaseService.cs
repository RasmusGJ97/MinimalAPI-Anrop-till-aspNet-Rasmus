using FrontEnd_MinimalAPI.Models;
using MVC_FrontEnd_MinimalAPI.Models;

namespace FrontEnd_MinimalAPI.Services
{
    public interface IBaseService:IDisposable
    {
        ResponseDTO responseDTO { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
