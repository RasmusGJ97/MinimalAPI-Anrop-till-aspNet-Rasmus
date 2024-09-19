using FrontEnd_MinimalAPI;
using FrontEnd_MinimalAPI.Services;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace MVC_FrontEnd_MinimalAPI.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public Task<T> AddBookAsync<T>(BookDTO bookDTO)
        {
            return this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.POST,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
            });
        }

        public Task<T> DeleteBookAsync<T>(int id)
        {
            return this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/books",
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
            });
        }

        public Task<T> UpdateBookAsync<T>(BookDTO bookDTO)
        {
            return this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.PUT,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
            });
        }
    }
}
