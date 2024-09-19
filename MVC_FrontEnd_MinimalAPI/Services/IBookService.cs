using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace MVC_FrontEnd_MinimalAPI.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> DeleteBookAsync<T>(int id);
        Task<T> AddBookAsync<T>(BookDTO bookDTO);
        Task<T> UpdateBookAsync<T>(BookDTO bookDTO);
    }
}
