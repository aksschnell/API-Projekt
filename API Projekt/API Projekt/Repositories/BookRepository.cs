using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Projekt.Models;

namespace API_Projekt.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync();

            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Book>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
