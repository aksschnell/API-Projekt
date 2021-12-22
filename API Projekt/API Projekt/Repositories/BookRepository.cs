using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Projekt.Models;
using Microsoft.EntityFrameworkCore;

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
            var bookToDelete = await _context.Books.FindAsync(id);

            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> Search(string title, string author, string genre)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(e => e.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(e => e.Author.Contains(author));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(e => e.Genre.Contains(genre));
            }



            return await query.ToListAsync();
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
