using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            this._context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // use automapper here
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return records;
        }

        public async Task<BookModel?> GetBookByIdAsync(int bookId)
        {
            // use automapper here
            var record = await _context.Books
                .Where(x => x.Id == bookId)
                .Select(x => new BookModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();

            return record;
        }
    }
}
