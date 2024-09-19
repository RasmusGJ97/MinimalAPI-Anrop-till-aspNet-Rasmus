using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;
using System.Text;
using System.Text.Json;

namespace FrontEnd_MinimalAPI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateBookAsync(ApiResponse apiResponse)
        {
            try
            {
                var itemJson = new StringContent(JsonSerializer.Serialize(apiResponse), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/books", itemJson);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    var addedBook = await JsonSerializer.DeserializeAsync<Books>(responseBody, new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true});

                    return addedBook;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public Task<BookDTO> DeleteBookAsync(int id)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            try
            {
                var apiResponse = await _httpClient.GetStreamAsync("api/books");

                var bookDTO = await JsonSerializer.DeserializeAsync<BookDTO>(apiResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return (IEnumerable<BookDTO>)bookDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public Task<BookDTO> GetBookById(int id)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public Task<bool> UpdateBookAsync(BookDTO bookDTO)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }
    }
}
