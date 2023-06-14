
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();

        public Task<BookModel?> GetBookByIdAsync(int bookId);

        public Task<int> AddBookAsync(BookModel bookModel);

        public Task UpdateBookAsync(int bookId, BookModel bookModel);

        public Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

        public Task DeleteBookAsync(int bookId);

    }
}
