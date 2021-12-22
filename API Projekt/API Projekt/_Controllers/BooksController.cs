using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Projekt.Attributes;
using API_Projekt.Models;
using API_Projekt.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API_Projekt._Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    
   
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;


        //Search
        [HttpGet("(search)")]
        public async Task<ActionResult<IEnumerable<Book>>> Search(string title, string author, string genre)
        {

              var result = await  _bookRepository.Search(title, author, genre);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
          
        }


        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }            

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {

            if(id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
                return NotFound();


            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();

        }

    }
}
