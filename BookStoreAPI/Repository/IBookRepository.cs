using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
    }
}
