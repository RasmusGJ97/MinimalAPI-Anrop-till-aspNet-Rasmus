using Microsoft.EntityFrameworkCore;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Data;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Books book)
        {
            _db.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Books>> GetAllAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Books> GetAsync(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<Books> GetAsync(string bookTitle)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        }

        public async Task RemoveASync(Books book)
        {
            _db.Books.Remove(book);
        }

        public async Task SaveASync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Books book)
        {
            _db.Books.Update(book);
        }
    }
}
