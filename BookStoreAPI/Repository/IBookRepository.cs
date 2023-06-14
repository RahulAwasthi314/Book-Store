using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();

        public Task<BookModel?> GetBookByIdAsync(int bookId);

        public Task<int> AddBookAsync(BookModel bookModel);
    }
}
