using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace FrontEnd_MinimalAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(int id);
        Task<BookDTO> DeleteBookAsync(int id);
        Task<bool> UpdateBookAsync(BookDTO bookDTO);
        Task<bool> CreateBookAsync(BookDTO bookDTO);
    }
}
