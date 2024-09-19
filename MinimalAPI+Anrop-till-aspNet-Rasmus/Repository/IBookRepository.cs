using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;
using static Azure.Core.HttpHeader;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetAllAsync();
        Task<Books> GetAsync(int id);
        Task<Books> GetAsync(string bookTitle);
        Task CreateAsync(Books book);
        Task UpdateAsync(Books book);
        Task RemoveASync(Books book);
        Task SaveASync();
    }
}
