﻿using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // use automapper here
            //var records = await _context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).ToListAsync();

            //return records;

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel?> GetBookByIdAsync(int bookId)
        {
            // use automapper here
            //var record = await _context.Books
            //    .Where(x => x.Id == bookId)
            //    .Select(x => new BookModel()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Description = x.Description
            //    })
            //    .FirstOrDefaultAsync();
            //return record;


            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);

        }


        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            // can we use mapper here 
            // wouldn't it affect the id of bookModel?

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        // add atleast bool to send the proper response
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;
            //    await _context.SaveChangesAsync();
            //}
            // only 1 time database connection is required now

            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        // put -> update all properties of entity
        // patch -> update only one property of entity

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            // if delete key is primary -> delete the entity in one go
            // else hit the db twice

            // case 1: bookId is primary key
            /// TODO
            // case if Key does not exist???......
            var book = new Books() { Id = bookId };

            // case 2: bookId is not primary key
            //var book = _context.Books.Where(x => x.Title == "")
            //                         .FirstOrDefault();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
