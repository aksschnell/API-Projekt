using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Projekt.Models;

namespace API_Projekt.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Search(string title, string author, string genre);
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int id);

    }
}
